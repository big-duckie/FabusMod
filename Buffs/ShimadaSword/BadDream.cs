using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace FabusMod.Buffs.ShimadaSword;

public class BadDream : ModBuff
{
    public override void SetStaticDefaults()
    {
        // DisplayName.SetDefault("Bad Dream");
        // Description.SetDefault(" - Losing life!\n - Sweating!");
        Main.buffNoTimeDisplay[Type] = false;
    }

    public override void Update(NPC npc, ref int buffIndex)
    {
        npc.lifeRegen -= 20;
        npc.color = Color.Gainsboro;
    }

    public override void Update(Player player, ref int buffIndex)
    {
        player.lifeRegen -= 20;
    }
}
