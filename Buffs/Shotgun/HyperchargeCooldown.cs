using Terraria;
using Terraria.ModLoader;

namespace FabusMod.Buffs.Shotgun;

public class HyperchargeCooldown : ModBuff
{
    public override void SetStaticDefaults()
    {
        // DisplayName.SetDefault("Hypercharge Cooldown");
        // Description.SetDefault("Unable to Hypercharge!");
        Main.debuff[Type] = true;
        Main.buffNoTimeDisplay[Type] = false;
    }

    public override void Update(Player player, ref int buffIndex)
    {
        if (Main.rand.NextBool(3))
        {
            int dust = Dust.NewDust(player.position, player.width, player.height, ModContent.DustType<Dusts.CurseDust>());
            Main.dust[dust].scale = 1f;
            Dust obj = Main.dust[dust];
            obj.velocity *= 0.1f;
            Main.dust[dust].noGravity = true;
        }
    }
}
