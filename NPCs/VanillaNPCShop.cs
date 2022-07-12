using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace FabusMod.NPCs;

public class VanillaNPCShop : GlobalNPC
{
	public override void SetupShop(int type, Chest shop, ref int nextSlot)
	{
        if (type == NPCID.Merchant)
		{
			shop.item[nextSlot].SetDefaults(ItemID.FallenStar);
			nextSlot++;
			shop.item[nextSlot].SetDefaults(ItemID.Cobweb);
			shop.item[nextSlot].shopCustomPrice = 100;
			nextSlot++;
		}
		if (type == NPCID.Dryad)
		{
			shop.item[nextSlot].SetDefaults(ModContent.ItemType<Items.Items.PetSummons.SuspiciousFlower>());
			nextSlot++;
		}
	}
}
