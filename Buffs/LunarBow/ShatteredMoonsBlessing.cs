using Terraria;
using Terraria.ModLoader;

namespace FabusMod.Buffs.LunarBow;

public class ShatteredMoonsBlessing : ModBuff
{
    public override void SetStaticDefaults()
    {
        DisplayName.SetDefault("Shattered Moon's Blessing");
        Description.SetDefault(" - Recovering HP rapidly!\n - Can't use items");
        Main.debuff[Type] = true;
        Main.buffNoTimeDisplay[Type] = false;
    }

    public override void Update(Player player, ref int buffIndex)
    {
        if (!player.HasBuff(ModContent.BuffType<ShatteredMoonsCurse>()) && player.statLife < player.statLifeMax2)
        {
            player.noItems = true;
            player.statLife += 2;
            if (Main.myPlayer == player.whoAmI)
            {
                player.HealEffect(2, true);
            }
            int dust = Dust.NewDust(player.position, player.width, player.height, ModContent.DustType<Dusts.HealingDust>());
            Main.dust[dust].scale = 2f;
            Dust obj = Main.dust[dust];
            obj.velocity *= 0.1f;
            Main.dust[dust].noGravity = true;
        }
    }
}
