using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace FabusMod.Items.Items.CraftingIngredients;

public class RainbowHandle : ModItem
{
	public override void SetStaticDefaults()
	{
		Tooltip.SetDefault("[c/C9FF4C:Crafting Ingredient]\nUsed to craft The Rainbow Demon \n[c/FF2B6E:Currently Unobtainable]");
	}

	public override void SetDefaults()
	{
		Item.width = 35;
		Item.height = 37;
		Item.maxStack = 99;
		Item.value = Item.sellPrice(18, 0, 0, 0);
		Item.rare = ItemRarityID.Expert;
	}
}
