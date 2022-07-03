using Terraria;
using Terraria.ModLoader;

namespace FabusMod.Projectiles;

public class PulseBulletBlue : ModProjectile
{
	public override void SetDefaults()
	{
		Projectile.width = 2;
		Projectile.height = 20;
		Projectile.aiStyle = 1;
		Projectile.friendly = true;
		Projectile.hostile = false;
		
		Projectile.penetrate = 1;
		Projectile.timeLeft = 600;
		Projectile.alpha = 255;
		Projectile.light = 0.5f;
		Projectile.ignoreWater = false;
		Projectile.tileCollide = true;
		Projectile.extraUpdates = 2;
        AIType = 14;
	}
}
