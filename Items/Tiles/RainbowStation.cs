using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace FabusMod.Items.Tiles;

public class RainbowStation : ModItem
{
	public override void SetStaticDefaults()
	{
		Tooltip.SetDefault("Used to craft rainbow weapons");
	}

	public override void SetDefaults()
	{
		Item.width = 40;
		Item.height = 24;
		Item.maxStack = 99;
		Item.useTurn = true;
		Item.autoReuse = true;
		Item.useAnimation = 15;
		Item.useTime = 10;
		Item.useStyle = ItemUseStyleID.Swing;
		Item.consumable = true;
		Item.rare = ItemRarityID.Expert;
		Item.createTile = ModContent.TileType<global::FabusMod.Tiles.RainbowStation>();
	}

	public override void AddRecipes()
	{
		CreateRecipe()
			.AddIngredient(ItemID.LunarCraftingStation)
			.AddIngredient(ModContent.ItemType<Bars.RainbowChunk>(), 12)
			.AddTile(TileID.LunarCraftingStation)
			.Register();
	}
}
