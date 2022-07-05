using Terraria;
using Terraria.ModLoader;

namespace FabusMod.Items.Items.CraftingIngredients;

public class RainbowToken : ModItem
{
	public override void SetStaticDefaults()
	{
		Tooltip.SetDefault("[c/C9FF4C:Crafting Ingredient]\nUsed to convert the raw power of rainbows into weapons");
	}

	public override void SetDefaults()
	{
		Item.width = 30;
		Item.height = 30;
		Item.maxStack = 99;
		Item.value = Item.sellPrice(0, 9, 80, 0);
		Item.expert = true;
	}

	public override void AddRecipes()
	{
		CreateRecipe()
			.AddIngredient(ModContent.ItemType<NatureToken>(), 4)
			.AddIngredient(ModContent.ItemType<RainbowDust>(), 40)
			.AddTile(ModContent.TileType<global::FabusMod.Tiles.RainbowStation>())
			.Register();
	}
}
