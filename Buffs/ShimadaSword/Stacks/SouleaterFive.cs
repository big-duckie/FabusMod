using Terraria;
using Terraria.ModLoader;

namespace FabusMod.Buffs.ShimadaSword.Stacks;

public class SouleaterFive : ModBuff
{
    public override void SetStaticDefaults()
    {
        DisplayName.SetDefault("Souleater - Five");
        Description.SetDefault(" - Accumulating souls!\n - A stack of 6 will heal your HP and Mana");
        Main.debuff[Type] = false;
        Main.buffNoTimeDisplay[Type] = false;
    }

    public override void Update(Player player, ref int buffIndex)
    {
        int dust = Dust.NewDust(player.position, player.width, player.height, ModContent.DustType<Dusts.OniDust>());
        Main.dust[dust].scale = 2f;
        Main.dust[dust].velocity.X *= 1.5f;
        Main.dust[dust].velocity.Y -= 1.4f;
        Main.dust[dust].noGravity = true;
    }
}
