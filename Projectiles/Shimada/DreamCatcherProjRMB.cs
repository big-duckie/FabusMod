using FabusMod.Buffs.ShimadaSword.Stacks;
using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;

namespace FabusMod.Projectiles.Shimada;

public class DreamCatcherProjRMB : ModProjectile
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
			int dust1 = Dust.NewDust(Projectile.position, Projectile.width, Projectile.height, ModContent.DustType<Dusts.RainbowDust>());
			Main.dust[dust1].scale = 1.9f;
			Main.dust[dust1].velocity.Y -= 1.5f;
			Main.dust[dust1].velocity.X = 0f;
			Main.dust[dust1].noGravity = true;

			int dust2 = Dust.NewDust(Projectile.position, Projectile.width, Projectile.height, ModContent.DustType<Dusts.RainbowDust2>());
			Main.dust[dust2].scale = 1.9f;
			Main.dust[dust2].velocity.Y -= 1.5f;
			Main.dust[dust2].velocity.X = 0f;
			Main.dust[dust2].noGravity = true;
			
			int dust3 = Dust.NewDust(Projectile.position, Projectile.width, Projectile.height, ModContent.DustType<Dusts.RainbowDust3>());
			Main.dust[dust3].scale = 1.9f;
			Main.dust[dust3].velocity.Y -= 1.5f;
			Main.dust[dust3].velocity.X = 0f;
			Main.dust[dust3].noGravity = true;
		}
	}

	public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone)
	{
		if (Projectile.owner == Main.myPlayer)
		{
			Player player = Main.player[Projectile.owner];
			if (Utils.NextFloat(Main.rand) < 0.03f)
			{
				if (!player.HasBuff(ModContent.BuffType<DreamOne>()) && !player.HasBuff(ModContent.BuffType<DreamTwo>()) && !player.HasBuff(ModContent.BuffType<DreamThree>()) && !player.HasBuff(ModContent.BuffType<DreamFour>()) && !player.HasBuff(ModContent.BuffType<DreamFive>()))
				{
					player.AddBuff(ModContent.BuffType<DreamOne>(), 960, true);
				}
				else if (player.HasBuff(ModContent.BuffType<DreamOne>()))
				{
					player.ClearBuff(ModContent.BuffType<DreamOne>());
					player.AddBuff(ModContent.BuffType<DreamTwo>(), 960, true);
				}
				else if (player.HasBuff(ModContent.BuffType<DreamTwo>()))
				{
					player.ClearBuff(ModContent.BuffType<DreamTwo>());
					player.AddBuff(ModContent.BuffType<DreamThree>(), 960, true);
				}
				else if (player.HasBuff(ModContent.BuffType<DreamThree>()))
				{
					player.ClearBuff(ModContent.BuffType<DreamThree>());
					player.AddBuff(ModContent.BuffType<DreamFour>(), 960, true);
				}
				else if (player.HasBuff(ModContent.BuffType<DreamFour>()))
				{
					player.ClearBuff(ModContent.BuffType<DreamFour>());
					player.AddBuff(ModContent.BuffType<DreamFive>(), 960, true);
				}
				else if (player.HasBuff(ModContent.BuffType<DreamFive>()))
				{
					player.ClearBuff(ModContent.BuffType<DreamFive>());
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
		}
		target.AddBuff(72, 300, false);
	}

	public void AnimateProjectile()
	{
		Projectile.frameCounter++;
		if (Projectile.frameCounter >= 3)
		{
			Projectile.frame++;
			Projectile.frame %= 14;
			Projectile.frameCounter = 0;
		}
	}
}
