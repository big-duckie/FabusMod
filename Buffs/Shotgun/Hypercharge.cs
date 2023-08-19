using Terraria;
using Terraria.ModLoader;

namespace FabusMod.Buffs.Shotgun;

public class Hypercharge : ModBuff
{
    public override void SetStaticDefaults()
    {
        // DisplayName.SetDefault("Hypercharge");
        // Description.SetDefault(" - +12% damage for Hellraiser & Golden Shotgun!\n - +12% faster use time for Hellraiser & Golden Shotgun!");
        Main.debuff[Type] = false;
        Main.buffNoTimeDisplay[Type] = false;
    }

    public override void Update(Player player, ref int buffIndex)
    {
        if (Utils.NextFloat(Main.rand) < 0.8f)
        {
            int dust = Dust.NewDust(player.position, player.width, player.height, ModContent.DustType<Dusts.MoltenWaraxeDust>());
            Main.dust[dust].scale = 1.8f;
            Main.dust[dust].velocity.X *= 1f;
            Main.dust[dust].velocity.Y -= 1f;
            Main.dust[dust].noGravity = true;
        }
    }
}
