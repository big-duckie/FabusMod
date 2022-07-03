using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace FabusMod.Items.Bars;

public class RainbowChunk : ModItem
{
	public override void SetStaticDefaults()
	{
		DisplayName.SetDefault("Rainbow Chunk");
		Tooltip.SetDefault("[c/C9FF4C:Crafting Ingredient]\nFull of colors!");
	}

	public override void SetDefaults()
	{
		Item.width = 30;
		Item.height = 24;
		Item.maxStack = 99;
		Item.value = Item.sellPrice(0, 21, 0, 0);
		Item.expert = true;
	}

	public override void AddRecipes()
	{
		Recipe val = CreateRecipe();
		val.AddIngredient(ModContent.ItemType<Items.CraftingIngredients.RainbowDust>(), 4);
		val.AddIngredient(ItemID.LunarBar);
		val.AddIngredient(ItemID.FragmentNebula);
		val.AddIngredient(ItemID.FragmentSolar);
		val.AddIngredient(ItemID.FragmentVortex);
		val.AddIngredient(ItemID.FragmentStardust);
		val.AddTile(TileID.LunarCraftingStation);
		val.Register();
	}
}
