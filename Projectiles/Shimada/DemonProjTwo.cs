using FabusMod.Buffs.ShimadaSword.Stacks;
using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;

namespace FabusMod.Projectiles.Shimada;

public class DemonProjTwo : ModProjectile
{
	public override void SetDefaults()
	{
		Projectile.width = 46;
		Projectile.height = 28;
		Projectile.aiStyle = 1;
		Projectile.friendly = true;
		Projectile.hostile = false;
		//Projectile.melee = true;
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
		int dust1 = Dust.NewDust(Projectile.position, Projectile.width, Projectile.height, ModContent.DustType<Dusts.OniDust>());
		Main.dust[dust1].scale = 2f;
		Main.dust[dust1].velocity *= 0.1f;
		Main.dust[dust1].noGravity = true;

		int dust2 = Dust.NewDust(Projectile.position, Projectile.width, Projectile.height, ModContent.DustType<Dusts.OniDust>());
		Main.dust[dust2].scale = 2f;
		Main.dust[dust2].velocity *= 0.1f;
		Main.dust[dust2].noGravity = true;
	}

	public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone)
	{
		if (Projectile.owner != Main.myPlayer)
		{
			return;
		}
		Player player = Main.player[Projectile.owner];
		if (!player.HasBuff(ModContent.BuffType<SouleaterOne>()) && !player.HasBuff(ModContent.BuffType<SouleaterTwo>()) && !player.HasBuff(ModContent.BuffType<SouleaterThree>()) && !player.HasBuff(ModContent.BuffType<SouleaterFour>()) && !player.HasBuff(ModContent.BuffType<SouleaterFive>()))
		{
			player.AddBuff(ModContent.BuffType<SouleaterOne>(), 960, true);
		}
		else if (player.HasBuff(ModContent.BuffType<SouleaterOne>()))
		{
			player.ClearBuff(ModContent.BuffType<SouleaterOne>());
			player.AddBuff(ModContent.BuffType<SouleaterTwo>(), 960, true);
		}
		else if (player.HasBuff(ModContent.BuffType<SouleaterTwo>()))
		{
			player.ClearBuff(ModContent.BuffType<SouleaterTwo>());
			player.AddBuff(ModContent.BuffType<SouleaterThree>(), 960, true);
		}
		else if (player.HasBuff(ModContent.BuffType<SouleaterThree>()))
		{
			player.ClearBuff(ModContent.BuffType<SouleaterThree>());
			player.AddBuff(ModContent.BuffType<SouleaterFour>(), 960, true);
		}
		else if (player.HasBuff(ModContent.BuffType<SouleaterFour>()))
		{
			player.ClearBuff(ModContent.BuffType<SouleaterFour>());
			player.AddBuff(ModContent.BuffType<SouleaterFive>(), 960, true);
		}
		else if (player.HasBuff(ModContent.BuffType<SouleaterFive>()))
		{
			player.ClearBuff(ModContent.BuffType<SouleaterFive>());
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
