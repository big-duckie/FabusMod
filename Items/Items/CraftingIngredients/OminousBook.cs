using Terraria;
using Terraria.ModLoader;

namespace FabusMod.Items.Items.CraftingIngredients;

public class OminousBook : ModItem
{
	public override void SetStaticDefaults()
	{
		DisplayName.SetDefault("Ominous Book");
		Tooltip.SetDefault("[c/C9FF4C:Crafting Ingredient]\nAn ominous presence emits from this book. Maybe pack some gems and bring it to an altar?");
	}

	public override void SetDefaults()
	{
		Item.width = 28;
		Item.height = 30;
		Item.maxStack = 99;
		Item.value = Item.sellPrice(0, 2, 0, 0);
		Item.expert = true;
	}
}
