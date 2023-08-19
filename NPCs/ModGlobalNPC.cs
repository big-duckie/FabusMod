using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria.GameContent.ItemDropRules;

namespace FabusMod.NPCs;

public class ModGlobalNPC : GlobalNPC
{
	/*public override void OnKill(NPC npc)
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
	}*/

    public override void ModifyNPCLoot(NPC npc, NPCLoot npcLoot)
    {
        switch (npc.type)
		{
			case NPCID.KingSlime:
				npcLoot.Add(ItemDropRule.ByCondition(new Conditions.IsExpert(), ModContent.ItemType<Items.Items.CraftingIngredients.OminousBook>(), 2));
				break;
			case NPCID.QueenBee:
				npcLoot.Add(ItemDropRule.ByCondition(new Conditions.IsExpert(), ModContent.ItemType<Items.Items.CraftingIngredients.NatureToken>(), 5, 1, 1, 2));
				npcLoot.Add(ItemDropRule.ByCondition(new Conditions.IsExpert(), ModContent.ItemType<Items.Vanity.Leafy.LeafyHat>(), 5));
				npcLoot.Add(ItemDropRule.ByCondition(new Conditions.IsExpert(), ModContent.ItemType<Items.Vanity.Leafy.LeafyChest>(), 5));
				npcLoot.Add(ItemDropRule.ByCondition(new Conditions.IsExpert(), ModContent.ItemType<Items.Vanity.Leafy.LeafyLegs>(), 5));
				break;
			case NPCID.SkeletronHead:
				npcLoot.Add(ItemDropRule.ByCondition(new Conditions.IsExpert(), ModContent.ItemType<Items.Weapons.Ranged.Bows.StormBows.StormBow>(), 5, 1, 1, 2));
				break;
			case NPCID.SkeletronPrime:
				npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<Items.Items.PetSummons.SuspiciousLookingScrew>(), 10));
				break;
			case NPCID.TheDestroyer:
				npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<Items.Items.PetSummons.SuspiciousLookingScrew>(), 10));
				break;
			case NPCID.Retinazer:
				npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<Items.Items.PetSummons.SuspiciousLookingScrew>(), 10));
				break;
			case NPCID.Spazmatism:
				npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<Items.Items.PetSummons.SuspiciousLookingScrew>(), 10));
				break;
			case NPCID.Unicorn:
				npcLoot.Add(ItemDropRule.ByCondition(new Conditions.IsExpert(), ModContent.ItemType<Items.Items.CraftingIngredients.RainbowDust>(), 3));
				break;
		}
    }
}
