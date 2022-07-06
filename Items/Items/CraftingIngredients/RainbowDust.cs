using Terraria;
using Terraria.ModLoader;

namespace FabusMod.Items.Items.CraftingIngredients;

public class RainbowDust : ModItem
{
	public override void SetStaticDefaults()
	{
		Tooltip.SetDefault("[c/C9FF4C:Crafting Ingredient]\nDon't inhale it!");
	}

	public override void SetDefaults()
	{
		Item.width = 24;
		Item.height = 24;
		Item.maxStack = 999;
		Item.rare = ItemRarityID.Expert;
		Item.value = Item.sellPrice(0, 0, 4, 50);
	}
}
