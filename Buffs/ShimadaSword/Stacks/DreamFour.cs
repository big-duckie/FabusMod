using Terraria;
using Terraria.ModLoader;

namespace FabusMod.Buffs.ShimadaSword.Stacks;

public class DreamFour : ModBuff
{
    public override void SetStaticDefaults()
    {
        DisplayName.SetDefault("Dream Sap - Four");
        Description.SetDefault(" - Accumulating dreams!\n - A stack of 6 will heal your HP and Mana");
        Main.debuff[Type] = false;
        Main.buffNoTimeDisplay[Type] = false;
    }

    public override void Update(Player player, ref int buffIndex)
    {
        if (Utils.NextFloat(Main.rand) < 0.8f)
        {
            int num1 = Dust.NewDust(player.position, player.width, player.height, ModContent.DustType<Dusts.RainbowDust>());
            Main.dust[num1].scale = 1.8f;
            Main.dust[num1].velocity.X *= 1f;
            Main.dust[num1].velocity.Y -= 1f;
            Main.dust[num1].noGravity = true;
            int num2 = Dust.NewDust(player.position, player.width, player.height, ModContent.DustType<Dusts.RainbowDust2>());
            Main.dust[num2].scale = 1.8f;
            Main.dust[num2].velocity.X *= 1f;
            Main.dust[num2].velocity.Y -= 1f;
            Main.dust[num2].noGravity = true;
            int num3 = Dust.NewDust(player.position, player.width, player.height, ModContent.DustType<Dusts.RainbowDust3>());
            Main.dust[num3].scale = 1.8f;
            Main.dust[num3].velocity.X *= 1f;
            Main.dust[num3].velocity.Y -= 1f;
            Main.dust[num3].noGravity = true;
        }
    }
}
