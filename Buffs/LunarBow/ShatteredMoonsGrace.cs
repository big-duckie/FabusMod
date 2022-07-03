using Terraria;
using Terraria.ModLoader;

namespace FabusMod.Buffs.LunarBow;

public class ShatteredMoonsGrace : ModBuff
{
    public override void SetStaticDefaults()
    {
        DisplayName.SetDefault("Shattered Moon's Grace");
        Description.SetDefault(" - Falling slowly!");
        Main.debuff[Type] = false;
        Main.buffNoTimeDisplay[Type] = true;
    }

    public override void Update(Player player, ref int buffIndex)
    {
        player.slowFall = true;
        int dust = Dust.NewDust(player.position, player.width, player.height, ModContent.DustType<Dusts.CrystalDust2>());
        Main.dust[dust].scale = 1f;
        Dust obj = Main.dust[dust];
        obj.velocity *= 0.1f;
        Main.dust[dust].noGravity = true;
    }
}
