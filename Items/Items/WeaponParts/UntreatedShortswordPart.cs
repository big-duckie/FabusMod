using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace FabusMod.Items.Items.WeaponParts;

public class UntreatedShortswordPart : ModItem
{
	public override void SetStaticDefaults()
	{
		// Tooltip.SetDefault("[c/C9FF4C:Crafting Ingredient]");
	}

	public override void SetDefaults()
	{
		Item.width = 28;
		Item.height = 26;
		Item.maxStack = 99;
		Item.value = Item.sellPrice(0, 0, 0, 20);
		Item.rare = ItemRarityID.White;
	}

	public override void AddRecipes()
	{
		CreateRecipe()
			.AddRecipeGroup("Wood", 6)
			.AddTile(TileID.WorkBenches)
			.Register();
	}
}
