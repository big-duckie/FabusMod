using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.Audio;
using Terraria.Enums;
using Terraria.GameContent;
using Terraria.ModLoader;
using Terraria.ID;

namespace FabusMod.Projectiles.Lasers;

public class HellfireBeamProj : ModProjectile
{
	private const int MAX_CHARGE = 50;

	private const float MOVE_DISTANCE = 60f;

	public float Distance
	{
		get
		{
			return Projectile.ai[0];
		}
		set
		{
			Projectile.ai[0] = value;
		}
	}

	public float Charge
	{
		get
		{
			return Projectile.localAI[0];
		}
		set
		{
			Projectile.localAI[0] = value;
		}
	}

	public override void SetDefaults()
	{
		Projectile.width = 10;
		Projectile.height = 10;
		Projectile.friendly = true;
		Projectile.penetrate = -1;
		Projectile.tileCollide = false;
		Projectile.hide = true;
	}

	public override bool PreDraw(ref Color lightColor)
	{
		if (Charge == MAX_CHARGE)
		{
			DrawLaser(TextureAssets.Projectile[Projectile.type].Value, Main.player[Projectile.owner].Center, Projectile.velocity, 10f, Projectile.damage, -1.57f, 1f, 1000f, Color.White, 60);
		}
		return false;
	}

	public void DrawLaser(Texture2D texture, Vector2 start, Vector2 unit, float step, int damage, float rotation = 0f, float scale = 1f, float maxDist = 2000f, Color color = default, int transDist = 50)
	{
        float r = Utils.ToRotation(unit) + rotation;
		for (float i = transDist; i <= Distance; i += step)
		{
            Vector2 origin = start + i * unit;
            Main.EntitySpriteDraw(texture, origin - Main.screenPosition, (Rectangle?)new Rectangle(0, 26, 28, 26), (i < transDist) ? Color.Transparent : color, r, new Vector2(14f, 13f), scale, SpriteEffects.None, 0);
		}
		Main.EntitySpriteDraw(texture, start + unit * (transDist - step) - Main.screenPosition, (Rectangle?)new Rectangle(0, 0, 28, 26), Color.White, r, new Vector2(14f, 13f), scale, SpriteEffects.None, 0);
		Main.EntitySpriteDraw(texture, start + (Distance + step) * unit - Main.screenPosition, (Rectangle?)new Rectangle(0, 52, 28, 26), Color.White, r, new Vector2(14f, 13f), scale, SpriteEffects.None, 0);
	}

	public override bool? Colliding(Rectangle projHitbox, Rectangle targetHitbox)
	{
		if (Charge == MAX_CHARGE)
		{
			Player player = Main.player[Projectile.owner];
			float point = 0f;
			if (Collision.CheckAABBvLineCollision(Utils.TopLeft(targetHitbox), Utils.Size(targetHitbox), player.Center, player.Center + Projectile.velocity * Distance, 22f, ref point))
			{
				return true;
			}
		}
		return false;
	}

	public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone)
	{
		target.immune[Projectile.owner] = 5;
		target.AddBuff(24, 120, false);
	}

	public override void AI()
	{
		Vector2 mousePos = Main.MouseWorld;
		Player player = Main.player[Projectile.owner];
		if (Projectile.owner == Main.myPlayer)
		{
			Projectile.velocity = mousePos - player.Center;
			Projectile.velocity.Normalize();
			Projectile.direction = (Main.MouseWorld.X > player.position.X) ? 1 : (-1);
			Projectile.netUpdate = true;
		}
		Projectile.position = player.Center + Projectile.velocity * MOVE_DISTANCE;
		Projectile.timeLeft = 2;
		int dir = Projectile.direction;
		player.ChangeDir(dir);
		player.heldProj = Projectile.whoAmI;
		player.itemTime = 2;
		player.itemAnimation = 2;
		player.itemRotation = (float)Math.Atan2(Projectile.velocity.Y * dir, Projectile.velocity.X * dir);
		if (!player.channel)
		{
			Projectile.Kill();
		}
		else
		{
			if (Main.time % 10.0 < 1.0 && !player.CheckMana(player.inventory[player.selectedItem].mana, true, false))
			{
				Projectile.Kill();
			}
			Vector2 offset = Projectile.velocity * 40f;
			Vector2 pos = player.Center + offset - new Vector2(10f, 10f);
			if (Charge < MAX_CHARGE)
			{
				Charge++;
			}
			int chargeFact = (int)(Charge / 20f);
			Vector2 dustVelocity = Vector2.UnitX * 18f;
			dustVelocity = Utils.RotatedBy(dustVelocity, (double)(Projectile.rotation - 1.57f), default);
			Vector2 spawnPos = Projectile.Center + dustVelocity;
			for (int j = 0; j < chargeFact + 1; j++)
			{
				Vector2 spawn = spawnPos + Utils.ToRotationVector2((float)Main.rand.NextDouble() * 6.28f) * (12f - chargeFact * 2);
				Dust obj = Main.dust[Dust.NewDust(pos, 20, 20, DustID.YellowTorch, Projectile.velocity.X / 2f, Projectile.velocity.Y / 2f)];
				obj.velocity = Vector2.Normalize(spawnPos - spawn) * 1.5f * (10f - chargeFact * 2f) / 10f;
				obj.noGravity = true;
				obj.scale = Main.rand.Next(10, 20) * 0.05f;
			}
		}
		if (Charge < MAX_CHARGE)
		{
			return;
		}
		Vector2 start = player.Center;
		for (Distance = MOVE_DISTANCE; Distance <= 2200f; Distance += 5f)
		{
			start = player.Center + Projectile.velocity * Distance;
			if (!Collision.CanHit(player.Center, 1, 1, start, 1, 1))
			{
				Distance -= 5f;
				break;
			}
		}
		if (Projectile.soundDelay <= 0)
		{
			SoundEngine.PlaySound(SoundID.Item15, Projectile.Center);
			Projectile.soundDelay = 40;
		}
		for (int i = 0; i < 2; i++)
		{
			Dust.NewDust(Projectile.position, Projectile.width, Projectile.height, ModContent.DustType<Dusts.BloodDust>());
			Dust.NewDust(Projectile.position, Projectile.width, Projectile.height, ModContent.DustType<Dusts.FoxWitherDust>());
		}
		DelegateMethods.v3_1 = new Vector3(0.8f, 0.8f, 1f);
		Utils.PlotTileLine(Projectile.Center, Projectile.Center + Projectile.velocity * (Distance - MOVE_DISTANCE), 26f, new Utils.TileActionAttempt(DelegateMethods.CastLight));
	}

	public override bool ShouldUpdatePosition()
	{
		return false;
	}

	public override void CutTiles()
	{
		DelegateMethods.tilecut_0 = TileCuttingContext.AttackProjectile;
		Utils.PlotTileLine(Projectile.Center, Projectile.Center + Projectile.velocity * Distance, (Projectile.width + 16) * Projectile.scale, new Utils.TileActionAttempt(DelegateMethods.CutTiles));
	}
}
