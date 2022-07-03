using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace FabusMod.Items.Vanity.FoxEars;

[AutoloadEquip(EquipType.Head)]
public class BlueFoxEars : ModItem
{
	public override void SetStaticDefaults()
	{
		DisplayName.SetDefault("Blue Fox Ears");
		Tooltip.SetDefault("Now in blue!");

		ArmorIDs.Head.Sets.DrawFullHair[Item.headSlot] = true;
	}

	public override void SetDefaults()
	{
		Item.width = 26;
		Item.height = 22;
		Item.rare = ItemRarityID.Blue;
		Item.vanity = true;
		Item.value = Item.sellPrice(0, 0, 12, 0);
	}
}
