using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;

namespace FabusMod.Projectiles;

public class TheWhisperingIcicle : ModProjectile
{
	public override void SetStaticDefaults()
	{
		//Sets.Homing[Projectile.type] = true;
		Main.projFrames[Projectile.type] = 17;
	}

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
			int dust1 = Dust.NewDust(Projectile.position, Projectile.width, Projectile.height, ModContent.DustType<Dusts.CrystalDust2>(), 0f, 0f, 0, default, 1f);
			Main.dust[dust1].scale = 0.9f;
			Dust obj = Main.dust[dust1];
			obj.velocity *= 0.1f;
			Main.dust[dust1].noGravity = true;
		}
		AnimateProjectile();
	}

	public override bool OnTileCollide(Vector2 oldVelocity)
	{
		Projectile projectile = Projectile;
		projectile.penetrate--;
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
			Projectile projectile2 = Projectile;
            projectile2.velocity *= 0.75f;
			SoundEngine.PlaySound(SoundID.Item27, Projectile.position);
		}
		return false;
	}

	public override void Kill(int timeLeft)
	{
		for (int i = 0; i < 5; i++)
		{
			int dust1 = Dust.NewDust(Projectile.position, Projectile.width, Projectile.height, ModContent.DustType<Dusts.CrystalDust2>(), 0f, 0f, 0, default, 1f);
			Main.dust[dust1].scale = 0.9f;
			Dust obj = Main.dust[dust1];
			obj.velocity *= 0.1f;
			Main.dust[dust1].noGravity = true;
		}
		SoundEngine.PlaySound(SoundID.Item27, Projectile.position);
	}

	public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
	{
		Projectile.ai[0] += 0.1f;
		Projectile.velocity *= 0.75f;
		if (Main.rand.NextBool(1))
		{
			target.AddBuff(44, 180, false);
		}
	}

	public void AnimateProjectile()
	{
		Projectile projectile = Projectile;
		projectile.frameCounter++;
		if (Projectile.frameCounter >= 3)
		{
			Projectile projectile2 = Projectile;
			projectile2.frame++;
			Projectile projectile3 = Projectile;
			projectile3.frame %= 16;
			Projectile.frameCounter = 0;
		}
	}
}
