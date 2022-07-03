using Terraria;
using Terraria.ModLoader;

namespace FabusMod.Buffs.Shotgun;

public class Ultracharging : ModBuff
{
    public override void SetStaticDefaults()
    {
        DisplayName.SetDefault("Ultracharging...");
        Description.SetDefault("- Charging your weapon!\n - Can't use items!");
        Main.debuff[Type] = true;
        Main.buffNoTimeDisplay[Type] = false;
    }

    public override void Update(Player player, ref int buffIndex)
    {
        if (!player.HasBuff(ModContent.BuffType<UltrachargeCooldown>()))
        {
            player.noItems = true;
            int dust = Dust.NewDust(player.position, player.width, player.height, ModContent.DustType<Dusts.SorcerousHellDust2>());
            Main.dust[dust].scale = 2f;
            Main.dust[dust].velocity.Y = -2f;
            Main.dust[dust].velocity.X = 0f;
            Main.dust[dust].noGravity = true;
        }
    }
}
