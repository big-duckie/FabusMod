using Terraria;
using Terraria.DataStructures;
using Terraria.ModLoader;
using Terraria.ID;

namespace FabusMod.Items;

public class BossBags : GlobalItem
{
	public override void OpenVanillaBag(string context, Player player, int arg)
	{
		if (context == "bossBag" && arg == ItemID.KingSlimeBossBag && Utils.NextFloat(Main.rand) < 0.5f && Main.expertMode)
		{
			player.QuickSpawnItem(new EntitySource_Misc(""), ModContent.ItemType<Items.CraftingIngredients.OminousBook>());
		}

		if (context == "bossBag" && arg == ItemID.QueenBeeBossBag && Utils.NextFloat(Main.rand) < 0.4f)
		{
			player.QuickSpawnItem(new EntitySource_Misc(""), ModContent.ItemType<Items.CraftingIngredients.NatureToken>());
		}

		if (context == "bossBag" && arg == ItemID.SkeletronBossBag && Utils.NextFloat(Main.rand) < 0.4f)
		{
			player.QuickSpawnItem(new EntitySource_Misc(""), ModContent.ItemType<Weapons.Ranged.Bows.StormBows.StormBow>());
		}

		if (context == "bossBag" && arg == ItemID.QueenBeeBossBag && Utils.NextFloat(Main.rand) < 0.2f)
		{
			player.QuickSpawnItem(new EntitySource_Misc(""), ModContent.ItemType<Vanity.Leafy.LeafyHat>());
			player.QuickSpawnItem(new EntitySource_Misc(""), ModContent.ItemType<Vanity.Leafy.LeafyChest>());
			player.QuickSpawnItem(new EntitySource_Misc(""), ModContent.ItemType<Vanity.Leafy.LeafyLegs>());
		}
	}
}
