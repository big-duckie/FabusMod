using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace FabusMod.Items.Bars;

public class RainbowChunk : ModItem
{
	public override void SetStaticDefaults()
	{
		Tooltip.SetDefault("[c/C9FF4C:Crafting Ingredient]\nFull of colors!");
	}

	public override void SetDefaults()
	{
		Item.width = 30;
		Item.height = 24;
		Item.maxStack = 99;
		Item.value = Item.sellPrice(0, 21, 0, 0);
		Item.rare = ItemRarityID.Expert;
	}

	public override void AddRecipes()
	{
		CreateRecipe()
			.AddIngredient(ModContent.ItemType<Items.CraftingIngredients.RainbowDust>(), 4)
			.AddIngredient(ItemID.LunarBar)
			.AddIngredient(ItemID.FragmentNebula)
			.AddIngredient(ItemID.FragmentSolar)
			.AddIngredient(ItemID.FragmentVortex)
			.AddIngredient(ItemID.FragmentStardust)
			.AddTile(TileID.LunarCraftingStation)
			.Register();
	}
}
