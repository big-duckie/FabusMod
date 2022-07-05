using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace FabusMod.Items.Accessories;

[AutoloadEquip(EquipType.Front)]
public class IronBand : ModItem
{
	public override void SetStaticDefaults()
	{
	}

	public override void SetDefaults()
	{
		Item.width = 30;
		Item.height = 30;
		Item.value = Item.sellPrice(0, 0, 6, 0);
		Item.rare = ItemRarityID.Blue;
		Item.accessory = true;
		Item.defense = 2;
	}

	public override void AddRecipes()
	{
		CreateRecipe()
			.AddIngredient(ModContent.ItemType<Items.CraftingIngredients.BrokenBand>())
			.AddRecipeGroup("IronBar", 3)
			.AddTile(TileID.Anvils)
			.Register();
	}
}
