using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.Audio;
using Terraria.Enums;
using Terraria.GameContent;
using Terraria.ID;
using Terraria.ModLoader;

namespace FabusMod.Projectiles.Lasers;

public class RainbowBeam : ModProjectile
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
			Vector2 unit = Projectile.velocity;
			DrawLaser(TextureAssets.Projectile[Projectile.type].Value, Main.player[Projectile.owner].Center, unit, 10f, Projectile.damage, -1.57f, 1f, 1000f, Color.White, 60);
		}
		return false;
	}

    public void DrawLaser(Texture2D texture, Vector2 start, Vector2 unit, float step, int damage, float rotation = 0f, float scale = 1f, float maxDist = 2000f, Color color = default, int transDist = 50)
	{
        float r = Utils.ToRotation(unit) + rotation;
		for (float i = transDist; i <= Distance; i += step)
		{
			Color c = Color.White;
            Vector2 origin = start + i * unit;
            Main.EntitySpriteDraw(texture, origin - Main.screenPosition, new Rectangle(0, 26, 28, 26), (i < transDist) ? Color.Transparent : c, r, new Vector2(14f, 13f), scale, SpriteEffects.None, 0);
		}
		Main.EntitySpriteDraw(texture, start + unit * (transDist - step) - Main.screenPosition, new Rectangle(0, 0, 28, 26), Color.White, r, new Vector2(14f, 13f), scale, SpriteEffects.None, 0);
		Main.EntitySpriteDraw(texture, start + (Distance + step) * unit - Main.screenPosition, new Rectangle(0, 52, 28, 26), Color.White, r, new Vector2(14f, 13f), scale, SpriteEffects.None, 0);
	}

	public override bool? Colliding(Rectangle projHitbox, Rectangle targetHitbox)
	{
		if (Charge == MAX_CHARGE)
		{
			Player p = Main.player[Projectile.owner];
			Vector2 unit = Projectile.velocity;
			float point = 0f;
			if (Collision.CheckAABBvLineCollision(Utils.TopLeft(targetHitbox), Utils.Size(targetHitbox), p.Center, p.Center + unit * Distance, 22f, ref point))
			{
				return true;
			}
		}
		return false;
	}

	public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
	{
		target.immune[Projectile.owner] = 3;
		target.AddBuff(72, 180, false);
		target.AddBuff(ModContent.BuffType<Buffs.RainbowsWrath>(), 120, false);
	}

	public override void AI()
	{
		Vector2 mousePos = Main.MouseWorld;
		Player player = Main.player[Projectile.owner];
		if (Projectile.owner == Main.myPlayer)
		{
			Vector2 diff = mousePos - player.Center;
			diff.Normalize();
			Projectile.velocity = diff;
			Projectile.direction = ((Main.MouseWorld.X > player.position.X) ? 1 : (-1));
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
			Vector2 offset = Projectile.velocity;
			offset *= 40f;
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
				Dust obj = Main.dust[Dust.NewDust(pos, 20, 20, DustID.YellowTorch, Projectile.velocity.X / 2f, Projectile.velocity.Y / 2f, 0, default, 1f)];
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
		_ = Projectile.velocity * -1f;
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
			float num1 = Utils.ToRotation(Projectile.velocity) + ((Main.rand.NextBool(2)) ? (-1f) : 1f) * 1.57f;
			float num2 = (float)(Main.rand.NextDouble() * 0.800000011920929 + 1.0);
			//new Vector2((float)Math.Cos(num1) * num2, (float)Math.Sin(num1) * num2);
			Dust.NewDust(Projectile.position, Projectile.width, Projectile.height, ModContent.DustType<Dusts.RainbowDust>(), 0f, 0f, 0, default, 1f);
			Dust.NewDust(Projectile.position, Projectile.width, Projectile.height, ModContent.DustType<Dusts.RainbowDust2>(), 0f, 0f, 0, default, 1f);
			Dust.NewDust(Projectile.position, Projectile.width, Projectile.height, ModContent.DustType<Dusts.RainbowDust3>(), 0f, 0f, 0, default, 1f);
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
		DelegateMethods.tilecut_0 = (TileCuttingContext)2;
		Vector2 unit = Projectile.velocity;
		Utils.PlotTileLine(Projectile.Center, Projectile.Center + unit * Distance, (Projectile.width + 16) * Projectile.scale, new Utils.TileActionAttempt(DelegateMethods.CutTiles));
	}
}
