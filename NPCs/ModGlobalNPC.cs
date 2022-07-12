using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria.DataStructures;

namespace FabusMod.NPCs;

public class ModGlobalNPC : GlobalNPC
{
	public override void OnKill(NPC npc)
	{
		if (npc.type == NPCID.SkeletronPrime && Utils.NextFloat(Main.rand) < 0.1f)
		{
			Item.NewItem(new EntitySource_Misc(""), npc.position, npc.width, npc.height, ModContent.ItemType<Items.Items.PetSummons.SuspiciousLookingScrew>());
		}
		if (npc.type == NPCID.TheDestroyer && Utils.NextFloat(Main.rand) < 0.1f)
		{
			Item.NewItem(new EntitySource_Misc(""), npc.position, npc.width, npc.height, ModContent.ItemType<Items.Items.PetSummons.SuspiciousLookingScrew>());
		}
		if (npc.type == NPCID.Retinazer && Utils.NextFloat(Main.rand) < 0.1f)
		{
			Item.NewItem(new EntitySource_Misc(""), npc.position, npc.width, npc.height, ModContent.ItemType<Items.Items.PetSummons.SuspiciousLookingScrew>());
		}
		if (npc.type == NPCID.Spazmatism && Utils.NextFloat(Main.rand) < 0.1f)
		{
			Item.NewItem(new EntitySource_Misc(""), npc.position, npc.width, npc.height, ModContent.ItemType<Items.Items.PetSummons.SuspiciousLookingScrew>());
		}
		if (npc.type == NPCID.Unicorn && Utils.NextFloat(Main.rand) < 0.3f && Main.expertMode)
		{
			Item.NewItem(new EntitySource_Misc(""), npc.position, npc.width, npc.height, ModContent.ItemType<Items.Items.CraftingIngredients.RainbowDust>(), Main.rand.Next(1, 5));
		}
	}
}
