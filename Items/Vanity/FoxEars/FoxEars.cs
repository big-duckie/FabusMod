using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace FabusMod.Items.Vanity.FoxEars;

[AutoloadEquip(EquipType.Head)]
public class FoxEars : ModItem
{
	public override void SetStaticDefaults()
	{
		DisplayName.SetDefault("Fox Ears");
		Tooltip.SetDefault("[c/B6FF00:Dyeable]");

		ArmorIDs.Head.Sets.DrawFullHair[Item.headSlot] = true;
	}

	public override void SetDefaults()
	{
		Item.width = 26;
		Item.height = 22;
		Item.rare = ItemRarityID.Blue;
		Item.vanity = true;
		Item.value = Item.sellPrice(0, 0, 10, 0);
	}

	public override void AddRecipes()
	{
		Recipe val = CreateRecipe();
		val.AddIngredient(ItemID.Leather, 2);
		val.AddTile(TileID.WorkBenches);
		val.Register();
	}
}
