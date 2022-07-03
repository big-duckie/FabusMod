using Terraria;
using Terraria.ModLoader;

namespace FabusMod.Buffs.ShimadaSword.Stacks;

public class EnrichmentFour : ModBuff
{
    public override void SetStaticDefaults()
    {
        DisplayName.SetDefault("Enrichment - Four");
        Description.SetDefault(" - Accumulating riches!\n - A stack of 6 will heal your HP and Mana");
        Main.debuff[Type] = false;
        Main.buffNoTimeDisplay[Type] = false;
    }

    public override void Update(Player player, ref int buffIndex)
    {
        if (Utils.NextFloat(Main.rand) < 0.8f)
        {
            int dust = Dust.NewDust(player.position, player.width, player.height, ModContent.DustType<Dusts.MeatDust>());
            Main.dust[dust].scale = 1.8f;
            Main.dust[dust].velocity.X *= 1f;
            Main.dust[dust].velocity.Y -= 1f;
            Main.dust[dust].noGravity = true;
        }
    }
}
