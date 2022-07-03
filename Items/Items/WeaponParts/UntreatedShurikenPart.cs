using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace FabusMod.Items.Items.WeaponParts;

public class UntreatedShurikenPart : ModItem
{
	public override void SetStaticDefaults()
	{
		DisplayName.SetDefault("Untreated Shuriken Part");
		Tooltip.SetDefault("[c/C9FF4C:Crafting Ingredient]");
	}

	public override void SetDefaults()
	{
		Item.width = 26;
		Item.height = 26;
		Item.maxStack = 99;
		Item.value = Item.sellPrice(0, 0, 0, 20);
		Item.rare = ItemRarityID.White;
	}

	public override void AddRecipes()
	{
		Recipe val = CreateRecipe();
		val.AddRecipeGroup("Wood", 3);
		val.AddTile(TileID.WorkBenches);
		val.Register();
	}
}
