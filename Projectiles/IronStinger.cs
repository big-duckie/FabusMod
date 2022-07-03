using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;

namespace FabusMod.Projectiles;

public class IronStinger : ModProjectile
{
	public override void SetDefaults()
	{
		Projectile.width = 22;
		Projectile.height = 32;
		Projectile.friendly = true;
		Projectile.tileCollide = true;
		Projectile.ignoreWater = false;
		Projectile.timeLeft = 300;
		Projectile.light = 1f;
		Projectile.penetrate = -1;
        AIType = 1;
		Projectile.aiStyle = 1;
	}

	public override void Kill(int timeLeft)
	{
		SoundEngine.PlaySound(SoundID.Dig, Projectile.position);
	}
}
