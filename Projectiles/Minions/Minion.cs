using Terraria.ModLoader;

namespace FabusMod.Projectiles.Minions;

public abstract class Minion : ModProjectile
{
	public override void AI()
	{
		CheckActive();
	}

	public abstract void CheckActive();
}
