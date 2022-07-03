using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace FabusMod.Items.Items.WeaponParts;

public class UntreatedBowPart : ModItem
{
	public override void SetStaticDefaults()
	{
		DisplayName.SetDefault("Untreated Bow Part");
		Tooltip.SetDefault("[c/C9FF4C:Crafting Ingredient]");
	}

	public override void SetDefaults()
	{
		Item.width = 14;
		Item.height = 20;
		Item.maxStack = 99;
		Item.value = Item.sellPrice(0, 0, 0, 20);
		Item.rare = ItemRarityID.White;
	}

	public override void AddRecipes()
	{
		Recipe val = CreateRecipe();
		val.AddRecipeGroup("Wood", 2);
		val.AddTile(TileID.WorkBenches);
		val.Register();
	}
}
