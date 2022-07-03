using Terraria;
using Terraria.ModLoader;

namespace FabusMod.Buffs.ShimadaSword;

public class AdvancedBloodLoss : ModBuff
{
    public override void SetStaticDefaults()
    {
        DisplayName.SetDefault("Advanced Blood Loss");
        Description.SetDefault(" - Losing life!");
        Main.buffNoTimeDisplay[Type] = false;
    }

    public override void Update(NPC npc, ref int buffIndex)
    {
        npc.lifeRegen -= 15;
        int dust = Dust.NewDust(npc.position, npc.width, npc.height, ModContent.DustType<Dusts.BloodCutterDust>());
        Main.dust[dust].scale = 2f;
        Dust obj = Main.dust[dust];
        obj.velocity *= 0.1f;
        Main.dust[dust].noGravity = false;
    }

    public override void Update(Player player, ref int buffIndex)
    {
        player.lifeRegen -= 15;
        int dust = Dust.NewDust(player.position, player.width, player.height, ModContent.DustType<Dusts.BloodCutterDust>());
        Main.dust[dust].scale = 2f;
        Dust obj = Main.dust[dust];
        obj.velocity *= 0.1f;
        Main.dust[dust].noGravity = false;
    }
}
