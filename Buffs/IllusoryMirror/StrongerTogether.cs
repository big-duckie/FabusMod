using Terraria;
using Terraria.ModLoader;

namespace FabusMod.Buffs.IllusoryMirror;

public class StrongerTogether : ModBuff
{
    public override void SetStaticDefaults()
    {
        DisplayName.SetDefault("Stronger Together");
        Description.SetDefault(" - Buffed HP Regeneration!\n - +15% magic damage\n - Increased Attack Speed for Illusory Mirror");
        Main.debuff[Type] = true;
        Main.buffNoTimeDisplay[Type] = true;
    }

    public override void Update(Player player, ref int buffIndex)
    {
        player.lifeRegen = 30;
        player.GetDamage(DamageClass.Magic) += 0.15f;
        if (Main.rand.NextBool(5))
        {
            int dust1 = Dust.NewDust(player.position, player.width, player.height, ModContent.DustType<Dusts.HealingDust>());
            Main.dust[dust1].scale = 2f;
            Main.dust[dust1].velocity.Y -= 0.5f;
            Main.dust[dust1].velocity.X = 0f;
            Main.dust[dust1].noGravity = true;
            int dust2 = Dust.NewDust(player.position, player.width, player.height, ModContent.DustType<Dusts.IllusoryMirrorRMBDust>());
            Main.dust[dust2].scale = 1.5f;
            Main.dust[dust2].velocity.Y -= 0.1f;
            Main.dust[dust2].velocity.X *= 0.2f;
            Main.dust[dust2].noGravity = true;
        }
    }
}
