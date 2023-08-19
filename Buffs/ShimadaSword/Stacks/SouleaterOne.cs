using Terraria;
using Terraria.ModLoader;

namespace FabusMod.Buffs.ShimadaSword.Stacks;

public class SouleaterOne : ModBuff
{
    public override void SetStaticDefaults()
    {
        // DisplayName.SetDefault("Souleater - One");
        // Description.SetDefault(" - Accumulating souls!\n - A stack of 6 will heal your HP and Mana");
        Main.debuff[Type] = false;
        Main.buffNoTimeDisplay[Type] = false;
    }

    public override void Update(Player player, ref int buffIndex)
    {
        if (Utils.NextFloat(Main.rand) < 0.2f)
        {
            int dust = Dust.NewDust(player.position, player.width, player.height, ModContent.DustType<Dusts.OniDust>());
            Main.dust[dust].scale = 1.2f;
            Main.dust[dust].velocity.X = 0f;
            Main.dust[dust].velocity.Y -= 0.4f;
            Main.dust[dust].noGravity = true;
        }
    }
}
