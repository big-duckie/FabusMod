using Terraria;
using Terraria.ModLoader;

namespace FabusMod.Buffs.FoxPistol;

public class SpectralMending : ModBuff
{
    public override void SetStaticDefaults()
    {
        DisplayName.SetDefault("Spectral Mending");
        Description.SetDefault(" - HP +200\n - Regenerating HP\n - Increased Movement Speed\n - -7% Damage");
        Main.debuff[Type] = true;
        Main.buffNoTimeDisplay[Type] = false;
    }

    public override void Update(Player player, ref int buffIndex)
    {
        player.GetDamage(DamageClass.Generic) += 0.93f;
        player.moveSpeed += 0.8f;
        player.statLifeMax2 += 200;
        if (!player.HasBuff(ModContent.BuffType<SpectralWither>()))
        {
            player.lifeRegen = 32;
        }
        int num1 = Dust.NewDust(player.position, player.width, player.height, ModContent.DustType<Dusts.RainbowWrathDust>());
        int num2 = Dust.NewDust(player.position, player.width, player.height, ModContent.DustType<Dusts.RainbowWrathDust2>());
        int num3 = Dust.NewDust(player.position, player.width, player.height, ModContent.DustType<Dusts.RainbowWrathDust3>());
        Main.dust[num1].scale = 0.6f;
        Dust obj = Main.dust[num1];
        obj.velocity *= 0.1f;
        Main.dust[num1].noGravity = true;
        Main.dust[num2].scale = 0.6f;
        Dust obj2 = Main.dust[num2];
        obj2.velocity *= 0.1f;
        Main.dust[num2].noGravity = true;
        Main.dust[num3].scale = 0.6f;
        Dust obj3 = Main.dust[num3];
        obj3.velocity *= 0.1f;
        Main.dust[num3].noGravity = true;
    }
}
