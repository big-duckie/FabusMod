using Terraria;
using Terraria.ModLoader;

namespace FabusMod.Buffs.ShimadaSword;

public class SpectralRage : ModBuff
{
    public override void SetStaticDefaults()
    {
        // DisplayName.SetDefault("Spectral Rage");
        // Description.SetDefault(" - +10% damage!");
        Main.debuff[Type] = false;
        Main.buffNoTimeDisplay[Type] = false;
    }

    public override void Update(Player player, ref int buffIndex)
    {
        player.GetDamage(DamageClass.Melee) += 1.1f;
        int dust1 = Dust.NewDust(player.position, player.width, player.height, ModContent.DustType<Dusts.RainbowWrathDust>());
        int dust2 = Dust.NewDust(player.position, player.width, player.height, ModContent.DustType<Dusts.RainbowWrathDust2>());
        int dust3 = Dust.NewDust(player.position, player.width, player.height, ModContent.DustType<Dusts.RainbowWrathDust3>());
        Main.dust[dust1].scale = 0.6f;
        Dust obj = Main.dust[dust1];
        obj.velocity *= 1f;
        Main.dust[dust1].noGravity = true;
        Main.dust[dust2].scale = 0.6f;
        Dust obj2 = Main.dust[dust2];
        obj2.velocity *= 1f;
        Main.dust[dust2].noGravity = true;
        Main.dust[dust3].scale = 0.6f;
        Dust obj3 = Main.dust[dust3];
        obj3.velocity *= 1f;
        Main.dust[dust3].noGravity = true;
    }
}
