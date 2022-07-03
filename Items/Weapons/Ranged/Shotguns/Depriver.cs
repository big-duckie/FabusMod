using FabusMod.Projectiles;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace FabusMod.Items.Weapons.Ranged.Shotguns;

public class Depriver : ModItem
{
	public override void SetStaticDefaults()
	{
		DisplayName.SetDefault("Color Splash");
		Tooltip.SetDefault("[c/B6FF00:Autoshoots] \nFires a spread of 8 bullets \nUsing <right> grants the [c/8A8A8A:Ultracharging] buff, which has the following effects:\n - After 2 seconds of not being able to use items, grants the [c/AB2C2C:U][c/F3821B:l][c/E6AF31:t][c/63B465:r][c/82E8E8:a][c/9EF3EF:c][c/2BA0B5:h][c/734679:a][c/AB2C2C:r][c/F3821B:g][c/E6AF31:e] buff\n - [c/AB2C2C:U][c/F3821B:l][c/E6AF31:t][c/63B465:r][c/82E8E8:a][c/9EF3EF:c][c/2BA0B5:h][c/734679:a][c/AB2C2C:r][c/F3821B:g][c/E6AF31:e] increases damage dealt by Color Splasher by 12%, and reduces Color Splasher's use time by 20% \n[c/AB2C2C:U][c/F3821B:l][c/E6AF31:t][c/63B465:r][c/82E8E8:a][c/9EF3EF:c][c/2BA0B5:h][c/734679:a][c/AB2C2C:r][c/F3821B:g][c/E6AF31:e] has a cooldown of [c/CA4646:40 seconds] once the effect ends\nConverts Musket Balls into homing Rainbow Bullets \nOnly uses one Bullet per use");
	}

	public override void SetDefaults()
	{
		Item.damage = 120;
		Item.width = 70;
		Item.height = 36;
		Item.useTime = 18;
		Item.useAnimation = 18;
		Item.useStyle = ItemUseStyleID.Shoot;
		Item.noMelee = true;
		Item.knockBack = 4f;
		Item.value = Item.sellPrice(2, 14, 0, 0);
		Item.expert = true;
		Item.UseSound = SoundID.Item38;
		Item.autoReuse = true;
		Item.shoot = ProjectileID.PurificationPowder;
		Item.shootSpeed = 35f;
		Item.useAmmo = AmmoID.Bullet;
	}

    public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
	{
		if (type == 14)
		{
			type = ModContent.ProjectileType<RainbowBullet>();
		}
		int numberProjectiles = 8;
		for (int i = 0; i < numberProjectiles; i++)
		{
			Vector2 perturbedSpeed = Utils.RotatedByRandom(new Vector2(velocity.X, velocity.Y), (double)MathHelper.ToRadians(10f));
			Projectile.NewProjectile(source, position.X, position.Y, perturbedSpeed.X, perturbedSpeed.Y, type, damage, knockback, player.whoAmI);
		}
		return false;
	}

	public override bool AltFunctionUse(Player player)
	{
		return true;
	}

	public override bool CanUseItem(Player player)
	{
		if (player.altFunctionUse == 2)
		{
			if (!player.HasBuff(ModContent.BuffType<Buffs.Shotgun.UltrachargeCooldown>()) && !player.HasBuff(ModContent.BuffType<Buffs.Shotgun.Ultracharge>()) && !player.HasBuff(ModContent.BuffType<Buffs.Shotgun.Ultracharging>()))
			{
				player.AddBuff(ModContent.BuffType<Buffs.Shotgun.Ultracharging>(), 140, true);
			}
		}
		else if (player.HasBuff(ModContent.BuffType<Buffs.Shotgun.Ultracharge>()))
		{
			Item.damage = 134;
			Item.useTime = 16;
			Item.useAnimation = 16;
		}
		else
		{
			Item.damage = 120;
			Item.useTime = 20;
			Item.useAnimation = 20;
		}
		return CanUseItem(player);
	}

	public override Vector2? HoldoutOffset()
	{
		return new Vector2(-2f, -5f);
	}

	public override void AddRecipes()
	{
		Recipe val = CreateRecipe();
		val.AddIngredient(ModContent.ItemType<GoldenShotgun>());
		val.AddIngredient(ModContent.ItemType<Bars.RainbowChunk>(), 8);
		val.AddTile(ModContent.TileType<global::FabusMod.Tiles.RainbowStation>());
		val.Register();
	}
}
