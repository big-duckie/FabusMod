using Terraria;
using Terraria.ModLoader;

namespace FabusMod.Buffs;

public class RainbowsWrath : ModBuff
{
	public override void SetStaticDefaults()
	{
		DisplayName.SetDefault("Rainbow's Wrath");
		Description.SetDefault(" - Losing life\n - Lowered Movement Speed");
		Main.buffNoTimeDisplay[Type] = false;
	}

	public override void Update(NPC npc, ref int buffIndex)
	{
		npc.lifeRegen -= 30;
		int num1 = Dust.NewDust(npc.position, npc.width, npc.height, ModContent.DustType<Dusts.RainbowWrathDust>());
		int num2 = Dust.NewDust(npc.position, npc.width, npc.height, ModContent.DustType<Dusts.RainbowWrathDust2>());
		int num3 = Dust.NewDust(npc.position, npc.width, npc.height, ModContent.DustType<Dusts.RainbowWrathDust3>());
		Main.dust[num1].scale = 0.6f;
		Dust obj = Main.dust[num1];
		obj.velocity *= 1f;
		Main.dust[num1].noGravity = true;
		Main.dust[num2].scale = 0.6f;
		Dust obj2 = Main.dust[num2];
		obj2.velocity *= 1f;
		Main.dust[num2].noGravity = true;
		Main.dust[num3].scale = 0.6f;
		Dust obj3 = Main.dust[num3];
		obj3.velocity *= 1f;
		Main.dust[num3].noGravity = true;
	}

	public override void Update(Player player, ref int buffIndex)
	{
		player.lifeRegen -= 25;
		player.moveSpeed -= 0.8f;
		int num1 = Dust.NewDust(player.position, player.width, player.height, ModContent.DustType<Dusts.RainbowWrathDust>());
		int num2 = Dust.NewDust(player.position, player.width, player.height, ModContent.DustType<Dusts.RainbowWrathDust2>());
		int num3 = Dust.NewDust(player.position, player.width, player.height, ModContent.DustType<Dusts.RainbowWrathDust3>());
		Main.dust[num1].scale = 0.6f;
		Dust obj = Main.dust[num1];
		obj.velocity *= 1f;
		Main.dust[num1].noGravity = true;
		Main.dust[num2].scale = 0.6f;
		Dust obj2 = Main.dust[num2];
		obj2.velocity *= 1f;
		Main.dust[num2].noGravity = true;
		Main.dust[num3].scale = 0.6f;
		Dust obj3 = Main.dust[num3];
		obj3.velocity *= 1f;
		Main.dust[num3].noGravity = true;
	}
}
