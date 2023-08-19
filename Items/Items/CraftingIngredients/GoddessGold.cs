using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace FabusMod.Items.Items.CraftingIngredients;

public class GoddessGold : ModItem
{
	public override void SetStaticDefaults()
	{
		// Tooltip.SetDefault("[c/C9FF4C:Crafting Ingredient]\nGold to fit a goddess!");
	}

	public override void SetDefaults()
	{
		Item.width = 28;
		Item.height = 26;
		Item.maxStack = 99;
		Item.value = Item.sellPrice(0, 2, 75, 25);
		Item.rare = ItemRarityID.Yellow;
	}

	public override void AddRecipes()
	{
		CreateRecipe()
			.AddIngredient(ItemID.Ectoplasm)
			.AddIngredient(ItemID.GoldBar, 2)
			.AddIngredient(ModContent.ItemType<SoulofWisdom>())
			.AddTile(TileID.AdamantiteForge)
			.Register();

		CreateRecipe()
			.AddIngredient(ItemID.Ectoplasm)
			.AddIngredient(ItemID.PlatinumBar, 2)
			.AddIngredient(ModContent.ItemType<SoulofWisdom>())
			.AddTile(TileID.AdamantiteForge)
			.Register();
	}
}
