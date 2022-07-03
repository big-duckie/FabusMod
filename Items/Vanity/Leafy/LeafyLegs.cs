using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace FabusMod.Items.Vanity.Leafy;

[AutoloadEquip(EquipType.Legs)]
public class LeafyLegs : ModItem
{
	public override void SetStaticDefaults()
	{
		DisplayName.SetDefault("Leafia Legs");
		Tooltip.SetDefault("~~ Donator Item ~~");
	}

	public override void SetDefaults()
	{
		Item.width = 22;
		Item.height = 18;
		Item.rare = ItemRarityID.Blue;
		Item.vanity = true;
		Item.value = Item.sellPrice(0, 0, 20, 0);
	}
}
