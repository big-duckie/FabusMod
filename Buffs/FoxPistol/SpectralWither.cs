using Terraria;
using Terraria.ModLoader;

namespace FabusMod.Buffs.FoxPistol;

public class SpectralWither : ModBuff
{
    public override void SetStaticDefaults()
    {
        // DisplayName.SetDefault("Spectral Wither");
        // Description.SetDefault(" - Losing life!");
        Main.buffNoTimeDisplay[Type] = false;
    }

    public override void Update(NPC npc, ref int buffIndex)
    {
        npc.lifeRegen -= 20;
        int dust1 = Dust.NewDust(npc.position, npc.width, npc.height, ModContent.DustType<Dusts.SpectralWitherDust>());
        int dust2 = Dust.NewDust(npc.position, npc.width, npc.height, ModContent.DustType<Dusts.RainbowDust>());
        int dust3 = Dust.NewDust(npc.position, npc.width, npc.height, ModContent.DustType<Dusts.RainbowDust2>());
        int dust4 = Dust.NewDust(npc.position, npc.width, npc.height, ModContent.DustType<Dusts.RainbowDust3>());
        Main.dust[dust1].scale = 1f;
        Dust obj = Main.dust[dust1];
        obj.velocity *= 0.1f;
        Main.dust[dust1].noGravity = true;
        Main.dust[dust2].scale = 0.6f;
        Dust obj2 = Main.dust[dust2];
        obj2.velocity *= 0.1f;
        Main.dust[dust2].noGravity = true;
        Main.dust[dust3].scale = 0.6f;
        Dust obj3 = Main.dust[dust3];
        obj3.velocity *= 0.1f;
        Main.dust[dust3].noGravity = true;
        Main.dust[dust4].scale = 0.6f;
        Dust obj4 = Main.dust[dust4];
        obj4.velocity *= 0.1f;
        Main.dust[dust4].noGravity = true;
    }

    public override void Update(Player player, ref int buffIndex)
    {
        player.lifeRegen -= 20;
        int dust1 = Dust.NewDust(player.position, player.width, player.height, ModContent.DustType<Dusts.SpectralWitherDust>());
        int dust2 = Dust.NewDust(player.position, player.width, player.height, ModContent.DustType<Dusts.RainbowDust>());
        int dust3 = Dust.NewDust(player.position, player.width, player.height, ModContent.DustType<Dusts.RainbowDust2>());
        int dust4 = Dust.NewDust(player.position, player.width, player.height, ModContent.DustType<Dusts.RainbowDust3>());
        Main.dust[dust1].scale = 1f;
        Dust obj = Main.dust[dust1];
        obj.velocity *= 0.1f;
        Main.dust[dust1].noGravity = true;
        Main.dust[dust2].scale = 0.6f;
        Dust obj2 = Main.dust[dust2];
        obj2.velocity *= 0.1f;
        Main.dust[dust2].noGravity = true;
        Main.dust[dust3].scale = 0.6f;
        Dust obj3 = Main.dust[dust3];
        obj3.velocity *= 0.1f;
        Main.dust[dust3].noGravity = true;
        Main.dust[dust4].scale = 0.6f;
        Dust obj4 = Main.dust[dust4];
        obj4.velocity *= 0.1f;
        Main.dust[dust4].noGravity = true;
    }
}
