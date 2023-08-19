using Terraria;
using Terraria.ModLoader;

namespace FabusMod.Buffs.FoxPistol;

public class FoxMendingBlue : ModBuff
{
    public override void SetStaticDefaults()
    {
        // DisplayName.SetDefault("Fox Mending - Blue");
        // Description.SetDefault(" - Regenerating HP\n - Increased Movement Speed\n - -12% Damage");
        Main.debuff[Type] = true;
        Main.buffNoTimeDisplay[Type] = false;
    }

    public override void Update(Player player, ref int buffIndex)
    {
        player.GetDamage(DamageClass.Generic) += 0.88f;
        player.moveSpeed += 0.8f;
        if (!player.HasBuff(ModContent.BuffType<FoxWither>()))
        {
            player.lifeRegen = 16;
        }
        int num1 = Dust.NewDust(player.position, player.width, player.height, ModContent.DustType<Dusts.FoxMendingDustBlue>());
        Main.dust[num1].scale = 2f;
        Dust obj = Main.dust[num1];
        obj.velocity *= 0.1f;
        Main.dust[num1].noGravity = true;
    }
}
