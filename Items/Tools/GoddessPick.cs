using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace FabusMod.Items.Tools;

public class GoddessPick : ModItem
{
	public override void SetStaticDefaults()
	{
		// DisplayName.SetDefault("Goddess' Pick");
	}

	public override void SetDefaults()
	{
		Item.damage = 22;
		Item.DamageType = DamageClass.Melee;
		Item.width = 50;
		Item.height = 50;
		Item.useTime = 10;
		Item.useAnimation = 10;
		Item.pick = 210;
		Item.tileBoost = 3;
		Item.useStyle = ItemUseStyleID.Swing;
		Item.knockBack = 6f;
		Item.value = Item.sellPrice(0, 6, 0, 0);
		Item.rare = ItemRarityID.Yellow;
		Item.UseSound = SoundID.Item1;
		Item.autoReuse = true;
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

	public override void AddRecipes()
	{
		CreateRecipe()
			.AddIngredient(ItemID.Picksaw)
			.AddIngredient(ModContent.ItemType<Items.CraftingIngredients.GoddessGold>(), 12)
			.AddTile(TileID.AdamantiteForge)
			.Register();
	}
}
