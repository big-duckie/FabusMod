using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace FabusMod.NPCs;

public class VanillaNPCShop : GlobalNPC
{
    /*public override void ModifyActiveShop(NPC npc, string shopName, Item[] items)
    {
        if (npc.type == NPCID.Merchant)
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
    }*/

    public override void ModifyShop(NPCShop shop)
    {
        switch (shop.NpcType)
        {
            case NPCID.Merchant:
                shop.Add(ItemID.FallenStar);
                shop.Add(new Item(ItemID.Cobweb) { shopCustomPrice = 100 });
                break;
            case NPCID.Dryad:
                shop.Add(ModContent.ItemType<Items.Items.PetSummons.SuspiciousFlower>());
                break;
        }
    }
}
