using Terraria;
using Terraria.ModLoader;

namespace FabusMod.Buffs.FoxPistol;

public class FoxWither : ModBuff
{
    public override void SetStaticDefaults()
    {
        // DisplayName.SetDefault("Fox Wither");
        // Description.SetDefault(" - Losing life!");
        Main.buffNoTimeDisplay[Type] = false;
    }

    public override void Update(NPC npc, ref int buffIndex)
    {
        npc.lifeRegen -= 22;
        int dust = Dust.NewDust(npc.position, npc.width, npc.height, ModContent.DustType<Dusts.FoxWitherDust>());
        Main.dust[dust].scale = 1.6f;
        Dust obj = Main.dust[dust];
        obj.velocity *= 1f;
        Main.dust[dust].noGravity = true;
    }

    public override void Update(Player player, ref int buffIndex)
    {
        player.lifeRegen -= 22;
        int dust = Dust.NewDust(player.position, player.width, player.height, ModContent.DustType<Dusts.FoxWitherDust>());
        Main.dust[dust].scale = 1.6f;
        Dust obj = Main.dust[dust];
        obj.velocity *= 0.1f;
        Main.dust[dust].noGravity = true;
    }
}
