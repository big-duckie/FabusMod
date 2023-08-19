using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace FabusMod.Projectiles.Minions;

public class GoddessMinion : Minion
{
	public override void SetDefaults()
	{
		Projectile.netImportant = true;
		Projectile.CloneDefaults(388);
        AIType = 388;
		Projectile.width = 50;
		Projectile.height = 50;
		Main.projFrames[Projectile.type] = 8;
		Projectile.friendly = true;
		Projectile.minion = true;
		Projectile.minionSlots = 1f;
		Projectile.penetrate = -1;
		Projectile.timeLeft = 18000;
		Projectile.ignoreWater = true;
		Projectile.tileCollide = false;
		ProjectileID.Sets.MinionTargettingFeature[Projectile.type] = true;
		AnimateProjectile();
	}

	public override void SetStaticDefaults()
	{
		// DisplayName.SetDefault("Goddess' Summoner");
	}

	public override bool OnTileCollide(Vector2 oldVelocity)
	{
		if (Projectile.velocity.X != oldVelocity.X)
		{
			Projectile.velocity.X = oldVelocity.X;
		}
		if (Projectile.velocity.Y != oldVelocity.Y)
		{
			Projectile.velocity.Y = oldVelocity.Y;
		}
		return false;
	}

	public override void CheckActive()
	{
		Player player = Main.player[Projectile.owner];
		FabuPlayer modPlayer = player.GetModPlayer<FabuPlayer>();
		if (player.dead)
		{
			modPlayer.goddessMinion = false;
		}
		if (modPlayer.goddessMinion)
		{
			Projectile.timeLeft = 2;
		}
	}

	public void AnimateProjectile()
	{
		Projectile.frameCounter++;
		if (Projectile.frameCounter >= 2)
		{
			Projectile.frame++;
			Projectile.frame %= 3;
			Projectile.frameCounter = 0;
		}
	}
}
