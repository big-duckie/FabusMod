using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace FabusMod.Items.Items.CraftingIngredients;

public class BrokenBand : ModItem
{
	public override void SetStaticDefaults()
	{
		Tooltip.SetDefault("[c/C9FF4C:Crafting Ingredient]\n'This broken band feels oddly important to you...' \nIt would be wise to keep it.");
	}

	public override void SetDefaults()
	{
		Item.width = 30;
		Item.height = 30;
		Item.maxStack = 99;
		Item.value = Item.sellPrice(0, 0, 0, 10);
		Item.rare = ItemRarityID.White;
	}
}
