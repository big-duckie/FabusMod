using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;

namespace FabusMod.Projectiles.Arrows;

public class PiercingArrow : ModProjectile
{
	public override void SetDefaults()
	{
		Projectile.width = 14;
		Projectile.height = 40;
		Projectile.friendly = true;
		Projectile.tileCollide = true;
		Projectile.ignoreWater = false;
		
		Projectile.timeLeft = 1000;
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
