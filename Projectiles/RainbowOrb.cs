using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace FabusMod.Projectiles;

public class RainbowOrb : ModProjectile
{
	public override void SetStaticDefaults()
	{
		//Sets.Homing[Projectile.type] = true;
		Main.projFrames[Projectile.type] = 4;
	}

	public override void SetDefaults()
	{
		Projectile.width = 40;
		Projectile.height = 42;
		Projectile.alpha = 255;
		Projectile.friendly = true;
		Projectile.tileCollide = false;
		Projectile.ignoreWater = true;
		Projectile.timeLeft = 300;
	}

	public override void AI()
	{
		if (Projectile.alpha > 70)
		{
			Projectile projectile = Projectile;
			projectile.alpha -= 15;
			if (Projectile.alpha < 70)
			{
				Projectile.alpha = 70;
			}
		}
		if (Projectile.localAI[0] == 0f)
		{
			AdjustMagnitude(ref Projectile.velocity);
			Projectile.localAI[0] = 1f;
		}
		Vector2 move = Vector2.Zero;
		float distance = 200f;
		bool target = false;
		for (int i = 0; i < 200; i++)
		{
			if (Main.npc[i].active && !Main.npc[i].dontTakeDamage && !Main.npc[i].friendly && Main.npc[i].lifeMax > 5)
			{
				Vector2 newMove = Main.npc[i].Center - Projectile.Center;
				float distanceTo = (float)Math.Sqrt(newMove.X * newMove.X + newMove.Y * newMove.Y);
				if (distanceTo < distance)
				{
					move = newMove;
					distance = distanceTo;
					target = true;
				}
			}
		}
		if (target)
		{
			AdjustMagnitude(ref move);
			Projectile.velocity = (10f * Projectile.velocity + move) / 11f;
			AdjustMagnitude(ref Projectile.velocity);
		}
		if (Utils.NextFloat(Main.rand) < 0.1f && Projectile.alpha <= 100)
		{
			int dust1 = Dust.NewDust(Projectile.position, Projectile.width, Projectile.height, ModContent.DustType<Dusts.RainbowDust>(), 0f, 0f, 0, default, 1f);
			int dust2 = Dust.NewDust(Projectile.position, Projectile.width, Projectile.height, ModContent.DustType<Dusts.RainbowDust2>(), 0f, 0f, 0, default, 1f);
			int dust3 = Dust.NewDust(Projectile.position, Projectile.width, Projectile.height, ModContent.DustType<Dusts.RainbowDust3>(), 0f, 0f, 0, default, 1f);
			Main.dust[dust1].scale = 0.9f;
			Dust obj = Main.dust[dust1];
			obj.velocity *= 0.1f;
			Main.dust[dust1].noGravity = true;
			Main.dust[dust2].scale = 0.9f;
			Dust obj2 = Main.dust[dust2];
			obj2.velocity *= 0.1f;
			Main.dust[dust2].noGravity = true;
			Main.dust[dust3].scale = 0.9f;
			Dust obj3 = Main.dust[dust3];
			obj3.velocity *= 0.1f;
			Main.dust[dust3].noGravity = true;
		}
		AnimateProjectile();
	}

	private void AdjustMagnitude(ref Vector2 vector)
	{
		float magnitude = (float)Math.Sqrt(vector.X * vector.X + vector.Y * vector.Y);
		if (magnitude > 6f)
		{
			vector *= 6f / magnitude;
		}
	}

	public void AnimateProjectile()
	{
		Projectile projectile = Projectile;
		projectile.frameCounter++;
		if (Projectile.frameCounter >= 5)
		{
			Projectile projectile2 = Projectile;
			projectile2.frame++;
			Projectile projectile3 = Projectile;
			projectile3.frame %= 3;
			Projectile.frameCounter = 0;
		}
	}
}
