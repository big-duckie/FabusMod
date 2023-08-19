using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace FabusMod.Items.Vanity.Leafy;

[AutoloadEquip(EquipType.Body)]
public class LeafyChest : ModItem
{
	public override void SetStaticDefaults()
	{
		// DisplayName.SetDefault("Leafia Chest");
		// Tooltip.SetDefault("~~ Donator Item ~~");
	}

	public override void SetDefaults()
	{
		Item.width = 30;
		Item.height = 22;
		Item.rare = ItemRarityID.Blue;
		Item.vanity = true;
		Item.value = Item.sellPrice(0, 0, 20, 0);
	}
}
