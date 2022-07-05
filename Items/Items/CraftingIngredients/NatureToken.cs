using Terraria;
using Terraria.ModLoader;

namespace FabusMod.Items.Items.CraftingIngredients;

public class NatureToken : ModItem
{
	public override void SetStaticDefaults()
	{
		Tooltip.SetDefault("[c/C9FF4C:Crafting Ingredient]\nUsed to convert the raw power of nature into weapons");
	}

	public override void SetDefaults()
	{
		Item.width = 30;
		Item.height = 30;
		Item.maxStack = 99;
		Item.value = Item.sellPrice(0, 2, 0, 0);
		Item.expert = true;
	}
}
