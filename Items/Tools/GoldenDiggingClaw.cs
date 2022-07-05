using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace FabusMod.Items.Tools;

public class GoldenDiggingClaw : ModItem
{
	public override void SetStaticDefaults()
	{
		Tooltip.SetDefault("[c/FF3C2B:Mining speed too high may result in no funcionality]");
	}

	public override void SetDefaults()
	{
		Item.damage = 60;
		Item.DamageType = DamageClass.Melee;
		Item.width = 38;
		Item.height = 38;
		Item.useTime = 3;
		Item.useAnimation = 9;
		Item.pick = 210;
		Item.axe = 28;
		Item.tileBoost = 6;
		Item.useStyle = ItemUseStyleID.Swing;
		Item.knockBack = 6f;
		Item.value = Item.sellPrice(0, 18, 0, 0);
		Item.rare = ItemRarityID.Red;
		Item.UseSound = SoundID.Item1;
		Item.autoReuse = true;
	}

	public override void AddRecipes()
	{
		CreateRecipe()
			.AddIngredient(ItemID.ShroomiteDiggingClaw)
			.AddIngredient(ModContent.ItemType<Items.CraftingIngredients.GoddessGold>(), 18)
			.AddIngredient(ItemID.LunarBar, 22)
			.AddIngredient(ItemID.FragmentSolar, 8)
			.AddIngredient(ItemID.FragmentNebula, 8)
			.AddIngredient(ItemID.FragmentStardust, 8)
			.AddIngredient(ItemID.FragmentVortex, 8)
			.AddTile(TileID.LunarCraftingStation)
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
