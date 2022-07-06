using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;

namespace FabusMod.Projectiles.SorcerousStaff;

public class SorcerousHellstaffProjWhite : ModProjectile
{
	public override void SetDefaults()
	{
		Projectile.width = 10;
		Projectile.height = 10;
		Projectile.light = 1f;
        AIType = 1;
		Projectile.aiStyle = 1;
		Projectile.friendly = true;
		Projectile.penetrate = 1;
		Projectile.timeLeft = 600;
	}

	public override void AI()
	{
		if (Main.rand.NextBool(3))
		{
			int dust = Dust.NewDust(Projectile.position, Projectile.width, Projectile.height, ModContent.DustType<Dusts.SorcerousHellDustWhite>());
			Main.dust[dust].scale = 0.9f;
			Main.dust[dust].velocity *= 0.1f;
			Main.dust[dust].noGravity = true;
		}
		if (Main.rand.NextBool(4))
		{
			int dust = Dust.NewDust(Projectile.position, Projectile.width, Projectile.height, ModContent.DustType<Dusts.SorcerousHellDustPurple>());
			Main.dust[dust].scale = 0.9f;
			Main.dust[dust].velocity *= 0.1f;
			Main.dust[dust].noGravity = true;
		}
	}

	public override bool OnTileCollide(Vector2 oldVelocity)
	{
		Projectile.penetrate--;
		if (Projectile.penetrate <= 0)
		{
			Projectile.Kill();
		}
		else
		{
			Projectile.ai[0] += 0.1f;
			if (Projectile.velocity.X != oldVelocity.X)
			{
				Projectile.velocity.X = 0f - oldVelocity.X;
			}
			if (Projectile.velocity.Y != oldVelocity.Y)
			{
				Projectile.velocity.Y = 0f - oldVelocity.Y;
			}
			Projectile.velocity *= 0.75f;
			SoundEngine.PlaySound(SoundID.Item27, Projectile.position);
		}
		return false;
	}

	public override void Kill(int timeLeft)
	{
		for (int i = 0; i < 5; i++)
		{
			int dust = Dust.NewDust(Projectile.position, Projectile.width, Projectile.height, ModContent.DustType<Dusts.SorcerousHellDustWhite>());
			Main.dust[dust].scale = 0.9f;
			Main.dust[dust].velocity *= 0.1f;
			Main.dust[dust].noGravity = true;
		}
		SoundEngine.PlaySound(SoundID.Item27, Projectile.position);
	}

	public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
	{
		if (Main.rand.NextBool(6))
		{
			target.AddBuff(BuffID.OnFire, 180, false);
		}
	}
}
