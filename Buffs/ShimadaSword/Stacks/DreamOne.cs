using Terraria;
using Terraria.ModLoader;

namespace FabusMod.Buffs.ShimadaSword.Stacks;

public class DreamOne : ModBuff
{
    public override void SetStaticDefaults()
    {
        // DisplayName.SetDefault("Dream Sap - One");
        // Description.SetDefault(" - Accumulating dreams!\n - A stack of 6 will heal your HP and Mana");
        Main.debuff[Type] = false;
        Main.buffNoTimeDisplay[Type] = false;
    }

    public override void Update(Player player, ref int buffIndex)
    {
        if (Utils.NextFloat(Main.rand) < 0.2f)
        {
            int dust1 = Dust.NewDust(player.position, player.width, player.height, ModContent.DustType<Dusts.RainbowDust>());
            Main.dust[dust1].scale = 1.2f;
            Main.dust[dust1].velocity.X = 0f;
            Main.dust[dust1].velocity.Y -= 0.4f;
            Main.dust[dust1].noGravity = true;
            int dust2 = Dust.NewDust(player.position, player.width, player.height, ModContent.DustType<Dusts.RainbowDust2>());
            Main.dust[dust2].scale = 1.2f;
            Main.dust[dust2].velocity.X = 0f;
            Main.dust[dust2].velocity.Y -= 0.4f;
            Main.dust[dust2].noGravity = true;
            int dust3 = Dust.NewDust(player.position, player.width, player.height, ModContent.DustType<Dusts.RainbowDust3>());
            Main.dust[dust3].scale = 1.2f;
            Main.dust[dust3].velocity.X = 0f;
            Main.dust[dust3].velocity.Y -= 0.4f;
            Main.dust[dust3].noGravity = true;
        }
    }
}
