using Terraria;
using Terraria.ModLoader;

namespace FabusMod.Buffs;

public class HolySmite : ModBuff
{
	public override void SetStaticDefaults()
	{
		DisplayName.SetDefault("Holy Smite");
		Description.SetDefault(" - Losing life!\n - Lowered Movement Speed");
		Main.buffNoTimeDisplay[Type] = false;
	}

	public override void Update(NPC npc, ref int buffIndex)
	{
		npc.lifeRegen -= 26;
		int num1 = Dust.NewDust(npc.position, npc.width, npc.height, ModContent.DustType<Dusts.HolyDust>());
		Main.dust[num1].scale = 0.9f;
		Dust obj = Main.dust[num1];
		obj.velocity *= 1f;
		Main.dust[num1].noGravity = true;
	}

	public override void Update(Player player, ref int buffIndex)
	{
		player.lifeRegen -= 20;
		player.moveSpeed -= 0.7f;
		int num1 = Dust.NewDust(player.position, player.width, player.height, ModContent.DustType<Dusts.HolyDust>());
		Main.dust[num1].scale = 0.9f;
		Dust obj = Main.dust[num1];
		obj.velocity *= 1f;
		Main.dust[num1].noGravity = true;
	}
}
