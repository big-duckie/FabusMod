using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace FabusMod.Items.Items.CraftingIngredients;

public class RainbowMuzzle : ModItem
{
	public override void SetStaticDefaults()
	{
		Tooltip.SetDefault("[c/C9FF4C:Crafting Ingredient]\nUsed to craft The Rainbow Demon \n[c/FF2B6E:Currently Unobtainable]");
	}

	public override void SetDefaults()
	{
		Item.width = 48;
		Item.height = 33;
		Item.maxStack = 99;
		Item.value = Item.sellPrice(21, 0, 0, 0);
		Item.rare = ItemRarityID.Expert;
	}
}
