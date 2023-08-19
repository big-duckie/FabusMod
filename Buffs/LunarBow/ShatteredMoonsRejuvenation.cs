using Terraria;
using Terraria.ModLoader;

namespace FabusMod.Buffs.LunarBow;

public class ShatteredMoonsRejuvenation : ModBuff
{
    public override void SetStaticDefaults()
    {
        // DisplayName.SetDefault("Shattered Moon's Rejuvenation");
        // Description.SetDefault(" - Recovering 100 HP over 10 seconds");
        Main.debuff[Type] = false;
        Main.buffNoTimeDisplay[Type] = false;
    }

    public override void Update(Player player, ref int buffIndex)
    {
        player.lifeRegen = 18;
        if (Main.rand.NextBool(3))
        {
            int dust = Dust.NewDust(player.position, player.width, player.height, ModContent.DustType<Dusts.HealingDust>());
            Main.dust[dust].scale = 2f;
            Dust obj = Main.dust[dust];
            obj.velocity *= 0.1f;
            Main.dust[dust].noGravity = true;
        }
    }
}
