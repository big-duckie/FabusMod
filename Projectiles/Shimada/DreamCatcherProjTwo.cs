using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;

namespace FabusMod.Projectiles.Shimada;

public class DreamCatcherProjTwo : ModProjectile
{
	public override void SetStaticDefaults()
	{
		//Sets.Homing[Projectile.type] = true;
	}

	public override void SetDefaults()
	{
		Projectile.width = 46;
		Projectile.height = 28;
		Projectile.aiStyle = 1;
		Projectile.friendly = true;
		Projectile.hostile = false;
		Projectile.penetrate = 1;
		Projectile.timeLeft = 600;
		Projectile.alpha = 255;
		Projectile.light = 0.5f;
		Projectile.ignoreWater = true;
		Projectile.tileCollide = true;
		Projectile.extraUpdates = 2;
        AIType = 14;
	}

	public override void AI()
	{
		if (Projectile.localAI[0] == 0f)
		{
			AdjustMagnitude(ref Projectile.velocity);
			Projectile.localAI[0] = 1f;
		}
		Vector2 move = Vector2.Zero;
		float distance = 400f;
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
		int dust1 = Dust.NewDust(Projectile.position, Projectile.width, Projectile.height, ModContent.DustType<Dusts.RainbowDust>());
		Main.dust[dust1].scale = 2f;
		Main.dust[dust1].velocity *= 0.1f;
		Main.dust[dust1].noGravity = true;

		int dust2 = Dust.NewDust(Projectile.position, Projectile.width, Projectile.height, ModContent.DustType<Dusts.RainbowDust>());
		Main.dust[dust2].scale = 2f;
		Main.dust[dust2].velocity *= 0.1f;
		Main.dust[dust2].noGravity = true;

		int dust3 = Dust.NewDust(Projectile.position, Projectile.width, Projectile.height, ModContent.DustType<Dusts.RainbowDust2>());
		Main.dust[dust3].scale = 2f;
		Main.dust[dust3].velocity *= 0.1f;
		Main.dust[dust3].noGravity = true;

		int dust4 = Dust.NewDust(Projectile.position, Projectile.width, Projectile.height, ModContent.DustType<Dusts.RainbowDust2>());
		Main.dust[dust4].scale = 2f;
		Main.dust[dust4].velocity *= 0.1f;
		Main.dust[dust4].noGravity = true;

		int dust5 = Dust.NewDust(Projectile.position, Projectile.width, Projectile.height, ModContent.DustType<Dusts.RainbowDust3>());
		Main.dust[dust5].scale = 2f;
		Main.dust[dust5].velocity *= 0.1f;
		Main.dust[dust5].noGravity = true;

		int dust6 = Dust.NewDust(Projectile.position, Projectile.width, Projectile.height, ModContent.DustType<Dusts.RainbowDust3>());
		Main.dust[dust6].scale = 2f;
		Main.dust[dust6].velocity *= 0.1f;
		Main.dust[dust6].noGravity = true;
	}

	public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
	{
		if (Projectile.owner != Main.myPlayer)
		{
			return;
		}
		Player player = Main.player[Projectile.owner];
		player.statLife += 20;
		if (Main.myPlayer == player.whoAmI)
		{
			player.HealEffect(20, true);
			SoundEngine.PlaySound(SoundID.Item3);
		}
		if (!player.HasBuff(ModContent.BuffType<Buffs.ShimadaSword.Stacks.DreamOne>()) && !player.HasBuff(ModContent.BuffType<Buffs.ShimadaSword.Stacks.DreamTwo>()) && !player.HasBuff(ModContent.BuffType<Buffs.ShimadaSword.Stacks.DreamThree>()) && !player.HasBuff(ModContent.BuffType<Buffs.ShimadaSword.Stacks.DreamFour>()) && !player.HasBuff(ModContent.BuffType<Buffs.ShimadaSword.Stacks.DreamFive>()))
		{
			player.AddBuff(ModContent.BuffType<Buffs.ShimadaSword.Stacks.DreamOne>(), 960, true);
		}
		else if (player.HasBuff(ModContent.BuffType<Buffs.ShimadaSword.Stacks.DreamOne>()))
		{
			player.ClearBuff(ModContent.BuffType<Buffs.ShimadaSword.Stacks.DreamOne>());
			player.AddBuff(ModContent.BuffType<Buffs.ShimadaSword.Stacks.DreamTwo>(), 960, true);
		}
		else if (player.HasBuff(ModContent.BuffType<Buffs.ShimadaSword.Stacks.DreamTwo>()))
		{
			player.ClearBuff(ModContent.BuffType<Buffs.ShimadaSword.Stacks.DreamTwo>());
			player.AddBuff(ModContent.BuffType<Buffs.ShimadaSword.Stacks.DreamThree>(), 960, true);
		}
		else if (player.HasBuff(ModContent.BuffType<Buffs.ShimadaSword.Stacks.DreamThree>()))
		{
			player.ClearBuff(ModContent.BuffType<Buffs.ShimadaSword.Stacks.DreamThree>());
			player.AddBuff(ModContent.BuffType<Buffs.ShimadaSword.Stacks.DreamFour>(), 960, true);
		}
		else if (player.HasBuff(ModContent.BuffType<Buffs.ShimadaSword.Stacks.DreamFour>()))
		{
			player.ClearBuff(ModContent.BuffType<Buffs.ShimadaSword.Stacks.DreamFour>());
			player.AddBuff(ModContent.BuffType<Buffs.ShimadaSword.Stacks.DreamFive>(), 960, true);
		}
		else if (player.HasBuff(ModContent.BuffType<Buffs.ShimadaSword.Stacks.DreamFive>()))
		{
			player.ClearBuff(ModContent.BuffType<Buffs.ShimadaSword.Stacks.DreamFive>());
			player.AddBuff(ModContent.BuffType<Buffs.ShimadaSword.SpectralRage>(), 480, true);
			player.statLife += 85;
			player.statMana += 85;
			if (Main.myPlayer == player.whoAmI)
			{
				player.HealEffect(85, true);
				player.ManaEffect(85);
				SoundEngine.PlaySound(SoundID.Item3);
				SoundEngine.PlaySound(SoundID.Item4);
			}
		}
	}

	private void AdjustMagnitude(ref Vector2 vector)
	{
		float magnitude = (float)Math.Sqrt(vector.X * vector.X + vector.Y * vector.Y);
		if (magnitude > 6f)
		{
			vector *= 6f / magnitude;
		}
	}
}
