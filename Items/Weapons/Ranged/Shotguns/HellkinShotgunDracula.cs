using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace FabusMod.Items.Weapons.Ranged.Shotguns;

public class HellkinShotgunDracula : ModItem
{
	public override void SetStaticDefaults()
	{
		DisplayName.SetDefault("Hellraiser - Dracula");
		Tooltip.SetDefault("[c/B6FF00:Autoshoots] \nFires a spread of 6 bullets \nUsing <right> grants the [c/8A8A8A:Hypercharging] buff, which has the following effects:\n - After 2 seconds of not being able to use items, grants the [c/FF9300:Hypercharge] buff\n - [c/FF9300:Hypercharge] increases damage dealt by Hellraiser by 12%, and reduces Hellraiser's use time by 20% \n[c/FF9300:Hypercharge] has a cooldown of [c/CA4646:40 seconds] once the effect ends\nOnly uses one Bullet per use");
	}

	public override void SetDefaults()
	{
		Item.damage = 46;
		Item.DamageType = DamageClass.Ranged;
		Item.width = 78;
		Item.height = 30;
		Item.useTime = 28;
		Item.useAnimation = 28;
		Item.useStyle = ItemUseStyleID.Shoot;
		Item.noMelee = true;
		Item.knockBack = 4f;
		Item.value = Item.sellPrice(0, 14, 20, 0);
		Item.rare = ItemRarityID.LightPurple;
		Item.UseSound = SoundID.Item38;
		Item.autoReuse = true;
		Item.shoot = ProjectileID.PurificationPowder;
		Item.shootSpeed = 35f;
		Item.useAmmo = AmmoID.Bullet;
	}

	public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
	{
		int numberProjectiles = 6;
		for (int i = 0; i < numberProjectiles; i++)
		{
			Vector2 perturbedSpeed = Utils.RotatedByRandom(velocity, (double)MathHelper.ToRadians(8f));
			Projectile.NewProjectile(source, position, perturbedSpeed, type, damage, knockback, player.whoAmI);
		}
		return true;
	}

	public override bool AltFunctionUse(Player player)
	{
		return true;
	}

	public override bool CanUseItem(Player player)
	{
		if (player.altFunctionUse == 2)
		{
			if (!player.HasBuff(ModContent.BuffType<Buffs.Shotgun.HyperchargeCooldown>()) && !player.HasBuff(ModContent.BuffType<Buffs.Shotgun.Hypercharge>()) && !player.HasBuff(ModContent.BuffType<Buffs.Shotgun.Hypercharging>()))
			{
				player.AddBuff(ModContent.BuffType<Buffs.Shotgun.Hypercharging>(), 140, true);
			}
		}
		else if (player.HasBuff(ModContent.BuffType<Buffs.Shotgun.Hypercharge>()))
		{
			Item.damage = 52;
			Item.useTime = 25;
			Item.useAnimation = 25;
		}
		else
		{
			Item.damage = 46;
			Item.useTime = 28;
			Item.useAnimation = 28;
		}
		return base.CanUseItem(player);
	}

	public override Vector2? HoldoutOffset()
	{
		return new Vector2(-2f, -5f);
	}

	public override void AddRecipes()
	{
		CreateRecipe()
			.AddIngredient(ModContent.ItemType<HellkinShotgun>())
			.AddIngredient(ItemID.RedDye)
			.AddTile(TileID.DyeVat)
			.Register();
	}
}
