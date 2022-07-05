using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace FabusMod.Items.Tools;

public class GoldenHamaxe : ModItem
{
	public override void SetStaticDefaults()
	{
		DisplayName.SetDefault("Golden Hamaxe");
	}

	public override void SetDefaults()
	{
		Item.damage = 68;
		Item.DamageType = DamageClass.Melee;
		Item.width = 70;
		Item.height = 60;
		Item.useTime = 10;
		Item.useAnimation = 10;
		Item.axe = 23;
		Item.hammer = 95;
		Item.tileBoost = 2;
		Item.useStyle = ItemUseStyleID.Swing;
		Item.knockBack = 6f;
		Item.value = Item.sellPrice(0, 6, 0, 0);
		Item.rare = ItemRarityID.Yellow;
		Item.UseSound = SoundID.Item1;
		Item.autoReuse = true;
	}

	public override void AddRecipes()
	{
		CreateRecipe()
			.AddIngredient(ItemID.Picksaw, 1)
			.AddIngredient(ModContent.ItemType<Items.CraftingIngredients.GoddessGold>(), 12)
			.AddTile(TileID.AdamantiteForge)
			.Register();
	}

	public override void MeleeEffects(Player player, Rectangle hitbox)
	{
		if (Main.rand.NextBool(3))
		{
			int dust = Dust.NewDust(new Vector2(hitbox.X, hitbox.Y), hitbox.Width, hitbox.Height, ModContent.DustType<Dusts.MeatDust>());
			Main.dust[dust].scale = 1f;
			Main.dust[dust].velocity.Y = 0f;
			Main.dust[dust].velocity.X = 0.5f;
			Main.dust[dust].noGravity = true;
		}
	}
}
