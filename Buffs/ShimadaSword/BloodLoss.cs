using Terraria;
using Terraria.ModLoader;

namespace FabusMod.Buffs.ShimadaSword;

public class BloodLoss : ModBuff
{
    public override void SetStaticDefaults()
    {
        DisplayName.SetDefault("Blood Loss");
        Description.SetDefault(" - Losing life!");
        Main.buffNoTimeDisplay[Type] = false;
    }

    public override void Update(NPC npc, ref int buffIndex)
    {
        npc.lifeRegen -= 5;
        int dust = Dust.NewDust(npc.position, npc.width, npc.height, ModContent.DustType<Dusts.BloodCutterDust>());
        Main.dust[dust].scale = 1f;
        Dust obj = Main.dust[dust];
        obj.velocity *= 0f;
        Main.dust[dust].noGravity = false;
    }

    public override void Update(Player player, ref int buffIndex)
    {
        player.lifeRegen -= 5;
        int dust = Dust.NewDust(player.position, player.width, player.height, ModContent.DustType<Dusts.BloodCutterDust>());
        Main.dust[dust].scale = 1f;
        Dust obj = Main.dust[dust];
        obj.velocity *= 0f;
        Main.dust[dust].noGravity = false;
    }
}
