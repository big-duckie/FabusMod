using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace FabusMod.Items.Items.CraftingIngredients;

public class GoddessGold : ModItem
{
	public override void SetStaticDefaults()
	{
		DisplayName.SetDefault("Goddess Gold");
		Tooltip.SetDefault("[c/C9FF4C:Crafting Ingredient]\nGold to fit a goddess!");
	}

	public override void SetDefaults()
	{
		Item.width = 28;
		Item.height = 26;
		Item.maxStack = 99;
		Item.value = Item.sellPrice(0, 2, 75, 25);
		Item.rare = ItemRarityID.Yellow;
	}

	public override void AddRecipes()
	{
		Recipe val = CreateRecipe();
		val.AddIngredient(ItemID.Ectoplasm);
		val.AddIngredient(ItemID.GoldBar, 2);
		val.AddIngredient(ModContent.ItemType<SoulofWisdom>());
		val.AddTile(TileID.AdamantiteForge);
		val.Register();

		Recipe val2 = CreateRecipe();
		val2.AddIngredient(ItemID.Ectoplasm);
		val2.AddIngredient(ItemID.PlatinumBar, 2);
		val2.AddIngredient(ModContent.ItemType<SoulofWisdom>());
		val2.AddTile(TileID.AdamantiteForge);
		val2.Register();
	}
}
