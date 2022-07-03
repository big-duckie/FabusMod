using Terraria;
using Terraria.ModLoader;

namespace FabusMod.Buffs.LunarBow;

public class SpectralMoonsGrace : ModBuff
{
    public override void SetStaticDefaults()
    {
        DisplayName.SetDefault("Spectral Moon's Grace");
        Description.SetDefault(" - Falling slowly!\n - Immune to knockback");
        Main.debuff[Type] = false;
        Main.buffNoTimeDisplay[Type] = true;
    }

    public override void Update(Player player, ref int buffIndex)
    {
        player.slowFall = true;
        player.noKnockback = true;
        int num1 = Dust.NewDust(player.position, player.width, player.height, ModContent.DustType<Dusts.CrystalDust>());
        Main.dust[num1].scale = 1f;
        Dust obj = Main.dust[num1];
        obj.velocity *= 0.1f;
        Main.dust[num1].noGravity = true;
    }
}
