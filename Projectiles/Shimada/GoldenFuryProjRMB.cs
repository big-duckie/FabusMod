using FabusMod.Buffs.ShimadaSword.Stacks;
using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;

namespace FabusMod.Projectiles.Shimada;

public class GoldenFuryProjRMB : ModProjectile
{
	public override void SetStaticDefaults()
	{
		Main.projFrames[Projectile.type] = 14;
	}

	public override void SetDefaults()
	{
		Projectile.width = 300;
		Projectile.height = 132;
		Projectile.friendly = true;
		Projectile.hostile = false;
		Projectile.penetrate = -1;
		Projectile.timeLeft = 42;
		Projectile.alpha = 80;
		Projectile.light = 0.5f;
		Projectile.ignoreWater = true;
		Projectile.tileCollide = false;
		Projectile.extraUpdates = 0;
		Projectile.velocity = Projectile.velocity * 0f;
	}

	public override void AI()
	{
		AnimateProjectile();
		if (Main.rand.NextBool(2))
		{
			int num1 = Dust.NewDust(Projectile.position, Projectile.width, Projectile.height, ModContent.DustType<Dusts.MeatDust>(), 0f, 0f, 0, default, 1f);
			Main.dust[num1].scale = 1.9f;
			Main.dust[num1].velocity.Y -= 1.5f;
			Main.dust[num1].velocity.X = 0f;
			Main.dust[num1].noGravity = true;
		}
	}

	public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
	{
		if (Projectile.owner == Main.myPlayer)
		{
			Player player = Main.player[Projectile.owner];
			if (Utils.NextFloat(Main.rand) < 0.03f)
			{
				if (!player.HasBuff(ModContent.BuffType<EnrichmentOne>()) && !player.HasBuff(ModContent.BuffType<EnrichmentTwo>()) && !player.HasBuff(ModContent.BuffType<EnrichmentThree>()) && !player.HasBuff(ModContent.BuffType<EnrichmentFour>()) && !player.HasBuff(ModContent.BuffType<EnrichmentFive>()))
				{
					player.AddBuff(ModContent.BuffType<EnrichmentOne>(), 960, true);
				}
				else if (player.HasBuff(ModContent.BuffType<EnrichmentOne>()))
				{
					player.ClearBuff(ModContent.BuffType<EnrichmentOne>());
					player.AddBuff(ModContent.BuffType<EnrichmentTwo>(), 960, true);
				}
				else if (player.HasBuff(ModContent.BuffType<EnrichmentTwo>()))
				{
					player.ClearBuff(ModContent.BuffType<EnrichmentTwo>());
					player.AddBuff(ModContent.BuffType<EnrichmentThree>(), 960, true);
				}
				else if (player.HasBuff(ModContent.BuffType<EnrichmentThree>()))
				{
					player.ClearBuff(ModContent.BuffType<EnrichmentThree>());
					player.AddBuff(ModContent.BuffType<EnrichmentFour>(), 960, true);
				}
				else if (player.HasBuff(ModContent.BuffType<EnrichmentFour>()))
				{
					player.ClearBuff(ModContent.BuffType<EnrichmentFour>());
					player.AddBuff(ModContent.BuffType<EnrichmentFive>(), 960, true);
				}
				else if (player.HasBuff(ModContent.BuffType<EnrichmentFive>()))
				{
					player.ClearBuff(ModContent.BuffType<EnrichmentFive>());
					player.statLife += 75;
					player.statMana += 75;
					if (Main.myPlayer == player.whoAmI)
					{
						player.HealEffect(75, true);
						player.ManaEffect(75);
						SoundEngine.PlaySound(SoundID.Item3);
						SoundEngine.PlaySound(SoundID.Item4);
					}
				}
			}
		}
		target.AddBuff(72, 300, false);
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
			projectile3.frame %= 14;
			Projectile.frameCounter = 0;
		}
	}
}
