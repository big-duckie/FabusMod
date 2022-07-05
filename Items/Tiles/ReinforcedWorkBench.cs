using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace FabusMod.Items.Tiles;

public class ReinforcedWorkBench : ModItem
{
	public override void SetStaticDefaults()
	{
		Tooltip.SetDefault("Used to craft stone-plated weapons");
	}

	public override void SetDefaults()
	{
		Item.width = 36;
		Item.height = 20;
		Item.maxStack = 99;
		Item.useTurn = true;
		Item.autoReuse = true;
		Item.useAnimation = 15;
		Item.useTime = 15;
		Item.useStyle = ItemUseStyleID.Swing;
		Item.consumable = true;
		Item.createTile = ModContent.TileType<global::FabusMod.Tiles.ReinforcedWorkBench>();
	}

	public override void AddRecipes()
	{
		CreateRecipe()
			.AddIngredient(ItemID.WorkBench, 1)
			.AddIngredient(ItemID.StoneBlock, 12)
			.Register();
	}
}
