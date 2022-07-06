using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace FabusMod.Projectiles.Shimada;

public class BloodDrop : ModProjectile
{
	private const float maxTicks = 45f;

	private const int alphaReducation = 25;

	public override void SetDefaults()
	{
		Projectile.width = 16;
		Projectile.height = 20;
        AIType = 1;
		Projectile.aiStyle = 1;
		Projectile.friendly = true;
		Projectile.penetrate = 1;
	}

	public override bool? Colliding(Rectangle projHitbox, Rectangle targetHitbox)
	{
		if (targetHitbox.Width > 8 && targetHitbox.Height > 8)
		{
			targetHitbox.Inflate(-targetHitbox.Width / 8, -targetHitbox.Height / 8);
		}
		return projHitbox.Intersects(targetHitbox);
	}

	public override void AI()
	{
		if (Main.rand.NextBool(3)&& Projectile.alpha <= 100)
		{
			Dust.NewDust(Projectile.position, Projectile.width, Projectile.height, ModContent.DustType<Dusts.BloodDust>());
		}
	}
}
