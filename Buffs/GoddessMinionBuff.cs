using Terraria;
using Terraria.ModLoader;

namespace FabusMod.Buffs;

public class GoddessMinionBuff : ModBuff
{
	public override void SetStaticDefaults()
	{
		// DisplayName.SetDefault("Golden Servant");
		// Description.SetDefault("A Golden Servant, at your service!");
		Main.buffNoSave[Type] = true;
		Main.buffNoTimeDisplay[Type] = true;
	}

	public override void Update(Player player, ref int buffIndex)
	{
		FabuPlayer modPlayer = player.GetModPlayer<FabuPlayer>();
		if (player.ownedProjectileCounts[ModContent.ProjectileType<Projectiles.Minions.GoddessMinion>()] > 0)
		{
			modPlayer.goddessMinion = true;
		}
		if (!modPlayer.goddessMinion)
		{
			player.DelBuff(buffIndex);
			buffIndex--;
		}
		else
		{
			player.buffTime[buffIndex] = 18000;
		}
	}
}
