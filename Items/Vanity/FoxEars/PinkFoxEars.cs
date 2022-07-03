using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace FabusMod.Items.Vanity.FoxEars;

[AutoloadEquip(EquipType.Head)]
public class PinkFoxEars : ModItem
{
	public override void SetStaticDefaults()
	{
		DisplayName.SetDefault("Pink Fox Ears");
		Tooltip.SetDefault("Now in pink!");

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
