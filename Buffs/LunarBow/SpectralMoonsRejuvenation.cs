using Terraria;
using Terraria.ModLoader;

namespace FabusMod.Buffs.LunarBow;

public class SpectralMoonsRejuvenation : ModBuff
{
    public override void SetStaticDefaults()
    {
        DisplayName.SetDefault("Spectral Moon's Rejuvenation");
        Description.SetDefault(" - Recovering 150 HP over 10 seconds\n - Increased ranged crit rate");
        Main.debuff[Type] = false;
        Main.buffNoTimeDisplay[Type] = false;
    }

    public override void Update(Player player, ref int buffIndex)
    {
        player.lifeRegen = 27;
        player.GetCritChance(DamageClass.Ranged) += 60;
        if (Main.rand.NextBool(3))
        {
            int num1 = Dust.NewDust(player.position, player.width, player.height, ModContent.DustType<Dusts.RainbowHealingDust>());
            Main.dust[num1].scale = 2f;
            Dust obj = Main.dust[num1];
            obj.velocity *= 0.1f;
            Main.dust[num1].noGravity = true;
        }
    }
}
