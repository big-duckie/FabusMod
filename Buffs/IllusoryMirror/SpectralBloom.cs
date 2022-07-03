using Terraria;
using Terraria.ModLoader;

namespace FabusMod.Buffs.IllusoryMirror;

public class SpectralBloom : ModBuff
{
    public override void SetStaticDefaults()
    {
        DisplayName.SetDefault("SpectralBloom");
        Description.SetDefault(" - Buffed HP Regeneration!\n - +18% magic damage\n - Increased Attack Speed for Spectral Illusion\n - Longer Invincibility after being hit");
        Main.debuff[Type] = true;
        Main.buffNoTimeDisplay[Type] = true;
    }

    public override void Update(Player player, ref int buffIndex)
    {
        player.lifeRegen = 35;
        player.GetDamage(DamageClass.Magic) += 0.18f;
        player.longInvince = true;
        if (Main.rand.NextBool(5))
        {
            int dust1 = Dust.NewDust(player.position, player.width, player.height, ModContent.DustType<Dusts.RainbowHealingDust>());
            Main.dust[dust1].scale = 2f;
            Main.dust[dust1].velocity.Y -= 0.5f;
            Main.dust[dust1].velocity.X = 0f;
            Main.dust[dust1].noGravity = true;
            int dust2 = Dust.NewDust(player.position, player.width, player.height, ModContent.DustType<Dusts.RainbowDust>());
            Main.dust[dust2].scale = 1.5f;
            Main.dust[dust2].velocity.Y -= 0.1f;
            Main.dust[dust2].velocity.X *= 0.2f;
            Main.dust[dust2].noGravity = true;
            int dust3 = Dust.NewDust(player.position, player.width, player.height, ModContent.DustType<Dusts.RainbowDust2>());
            Main.dust[dust3].scale = 1.5f;
            Main.dust[dust3].velocity.Y -= 0.1f;
            Main.dust[dust3].velocity.X *= 0.2f;
            Main.dust[dust3].noGravity = true;
            int dust4 = Dust.NewDust(player.position, player.width, player.height, ModContent.DustType<Dusts.RainbowDust3>());
            Main.dust[dust4].scale = 1.5f;
            Main.dust[dust4].velocity.Y -= 0.1f;
            Main.dust[dust4].velocity.X *= 0.2f;
            Main.dust[dust4].noGravity = true;
        }
    }
}
