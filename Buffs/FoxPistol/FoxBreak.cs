using Terraria;
using Terraria.ModLoader;

namespace FabusMod.Buffs.FoxPistol;

public class FoxBreak : ModBuff
{
    public override void SetStaticDefaults()
    {
        DisplayName.SetDefault("Fox Break");
        Description.SetDefault(" - Lowered Movement Speed");
        Main.buffNoTimeDisplay[Type] = false;
        Main.debuff[Type] = true;
    }

    public override void Update(Player player, ref int buffIndex)
    {
        player.moveSpeed -= 0.7f;
        int dust = Dust.NewDust(player.position, player.width, player.height, ModContent.DustType<Dusts.FoxBreakDust>());
        Main.dust[dust].scale = 1.4f;
        Dust obj = Main.dust[dust];
        obj.velocity *= 0.1f;
        Main.dust[dust].noGravity = true;
    }
}
