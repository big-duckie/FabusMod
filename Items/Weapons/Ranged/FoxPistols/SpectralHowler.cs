using FabusMod.Projectiles.FoxPistol;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace FabusMod.Items.Weapons.Ranged.FoxPistols;

public class SpectralHowler : ModItem
{
	public override void SetStaticDefaults()
	{
		DisplayName.SetDefault("Spectral Howler");
		Tooltip.SetDefault("[c/B6FF00:Autoshoots, doesn't require ammo]\nGrants the [c/AB2C2C:S][c/F3821B:p][c/E6AF31:e][c/63B465:c][c/82E8E8:t][c/9EF3EF:r][c/2BA0B5:a][c/734679:l ][c/AB2C2C:M][c/F3821B:e][c/E6AF31:n][c/63B465:d][c/82E8E8:i][c/9EF3EF:n][c/2BA0B5:g] buff for 7 seconds, which has the following effects:\n - Increases max HP by 200, regenerates HP, and increases movement speed, but lowers damage by 7% \nUsing <right> increases damage and reduces use time, as well as: \n - Grants the [c/8F77AF:Spectral Wither] debuff for 0.4 seconds, dealing damage over time and nullifying [c/AB2C2C:S][c/F3821B:p][c/E6AF31:e][c/63B465:c][c/82E8E8:t][c/9EF3EF:r][c/2BA0B5:a][c/734679:l ][c/AB2C2C:M][c/F3821B:e][c/E6AF31:n][c/63B465:d][c/82E8E8:i][c/9EF3EF:n][c/2BA0B5:g]'s regeneration\n - Inflicts the [c/AB2C2C:R][c/F3821B:a][c/E6AF31:i][c/63B465:n][c/82E8E8:b][c/9EF3EF:o][c/2BA0B5:w][c/734679:'s ][c/AB2C2C:W][c/F3821B:r][c/E6AF31:a][c/63B465:t][c/82E8E8:h] debuff on hit enemies for 8 seconds, dealing damage over time");
	}

	public override void SetDefaults()
	{
		Item.damage = 260;
		Item.DamageType = DamageClass.Ranged;
		Item.width = 36;
		Item.height = 21;
		Item.useTime = 6;
		Item.useAnimation = 6;
		Item.useStyle = ItemUseStyleID.Shoot;
		Item.noMelee = true;
		Item.knockBack = 4f;
		Item.value = Item.sellPrice(0, 97, 60, 0);
		Item.UseSound = SoundID.Item11;
		Item.autoReuse = true;
		Item.shootSpeed = 8f;
		Item.expert = true;
		Item.shoot = ModContent.ProjectileType<RainbowBolt>();
	}

	public override Vector2? HoldoutOffset()
	{
		return new Vector2(-6f, -2f);
	}

	public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
	{
		Vector2 muzzleOffset = Vector2.Normalize(velocity) * 32f;
		if (Collision.CanHit(position, 0, 0, position + muzzleOffset, 0, 0))
		{
			position += muzzleOffset;
		}
		if (player.altFunctionUse == 2)
		{
			player.AddBuff(ModContent.BuffType<Buffs.FoxPistol.SpectralWither>(), 24, true);
		}
		else
		{
			player.AddBuff(ModContent.BuffType<Buffs.FoxPistol.SpectralMending>(), 420, true);
		}
		velocity = Utils.RotatedByRandom(velocity, (double)MathHelper.ToRadians(3f));
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
			Item.useStyle = ItemUseStyleID.Shoot;
			Item.useTime = 4;
			Item.useAnimation = 4;
			Item.damage = 270;
			Item.shoot = ModContent.ProjectileType<RainbowBoltRMB>();
		}
		else
		{
			Item.useStyle = ItemUseStyleID.Shoot;
			Item.useTime = 6;
			Item.useAnimation = 6;
			Item.damage = 260;
			Item.shoot = ModContent.ProjectileType<RainbowBolt>();
		}
		return base.CanUseItem(player);
	}

	public override void AddRecipes()
	{
		CreateRecipe()
			.AddRecipeGroup("FabusMod:FoxPistol")
			.AddIngredient(ModContent.ItemType<Items.CraftingIngredients.RainbowToken>())
			.AddIngredient(ModContent.ItemType<Bars.RainbowChunk>(), 4)
			.AddTile(ModContent.TileType<global::FabusMod.Tiles.RainbowStation>())
			.Register();
	}
}
