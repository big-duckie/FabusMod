using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace FabusMod.Items.Tools;

public class GoddessPick : ModItem
{
	public override void SetStaticDefaults()
	{
		DisplayName.SetDefault("Goddess' Pick");
	}

	public override void SetDefaults()
	{
		Item.damage = 22;
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
			int num1 = Dust.NewDust(new Vector2(hitbox.X, hitbox.Y), hitbox.Width, hitbox.Height, ModContent.DustType<Dusts.MeatDust>());
			Main.dust[num1].scale = 1f;
			Main.dust[num1].velocity.Y = 0f;
			Main.dust[num1].velocity.X = 0.5f;
			Main.dust[num1].noGravity = true;
		}
	}

	public override void AddRecipes()
	{
		Recipe val = CreateRecipe();
		val.AddIngredient(ItemID.Picksaw, 1);
		val.AddIngredient(ModContent.ItemType<Items.CraftingIngredients.GoddessGold>(), 12);
		val.AddTile(TileID.AdamantiteForge);
		val.Register();
	}
}
