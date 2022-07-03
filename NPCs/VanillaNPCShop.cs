using Terraria;
using Terraria.ModLoader;

namespace FabusMod.NPCs;

public class VanillaNPCShop : GlobalNPC
{
	public override void SetupShop(int type, Chest shop, ref int nextSlot)
	{
        if (type == 17)
		{
			shop.item[nextSlot].SetDefaults(75, false);
			nextSlot++;
			shop.item[nextSlot].SetDefaults(150, false);
			shop.item[nextSlot].shopCustomPrice = 100;
			nextSlot++;
		}
		if (type == 20)
		{
			shop.item[nextSlot].SetDefaults(ModContent.ItemType<Items.Items.PetSummons.SuspiciousFlower>(), false);
			nextSlot++;
		}
	}
}
