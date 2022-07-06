using FabusMod.Projectiles.FoxPistol;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace FabusMod.Items.Weapons.Ranged.FoxPistols;

public class FoxPistolBlue : ModItem
{
	public override void SetStaticDefaults()
	{
		DisplayName.SetDefault("Fox Pistol - Blue");
		Tooltip.SetDefault("[c/B6FF00:Autoshoots, doesn't require ammo, dyeable]\nGrants the [c/37C8AB:Fox Mending] buff for 5 seconds, which regenerates HP and increases speed, but lowers damage by 12% \nUsing <right> increases damage and reduces use time, as well as: \n - Grants the [c/9E9E9E:Fox Break] debuff for 1 second, reducing movement speed \n - Grants the [c/732C73:Fox Wither] debuff for 1.3 seconds on self, and 4 seconds on hit enemies \n - [c/732C73:Fox Wither] debuff deals damage over time and nullifies the [c/37C8AB:Fox Mending] buff's regeneration");
	}

	public override void SetDefaults()
	{
		Item.damage = 22;
		Item.DamageType = DamageClass.Ranged;
		Item.width = 36;
		Item.height = 21;
		Item.useTime = 12;
		Item.useAnimation = 12;
		Item.useStyle = ItemUseStyleID.Shoot;
		Item.noMelee = true;
		Item.knockBack = 4f;
		Item.value = Item.sellPrice(0, 3, 80, 0);
		Item.UseSound = SoundID.Item11;
		Item.autoReuse = true;
		Item.shootSpeed = 7f;
		Item.shoot = ModContent.ProjectileType<BlueBolt>();
		Item.rare = ItemRarityID.Expert;
	}

	public override Vector2? HoldoutOffset()
	{
		return new Vector2(0f, -2f);
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
			player.AddBuff(ModContent.BuffType<Buffs.FoxPistol.FoxBreak>(), 60, true);
			player.AddBuff(ModContent.BuffType<Buffs.FoxPistol.FoxWither>(), 78, true);
		}
		else
		{
			player.AddBuff(ModContent.BuffType<Buffs.FoxPistol.FoxMendingBlue>(), 300, true);
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
			Item.useTime = 10;
			Item.useAnimation = 10;
			Item.damage = 28;
			Item.shoot = ModContent.ProjectileType<BlueBoltRMB>();
		}
		else
		{
			Item.useStyle = ItemUseStyleID.Shoot;
			Item.useTime = 12;
			Item.useAnimation = 12;
			Item.damage = 22;
			Item.shoot = ModContent.ProjectileType<BlueBolt>();
		}
		return base.CanUseItem(player);
	}

	public override void AddRecipes()
	{
		CreateRecipe()
			.AddIngredient(ModContent.ItemType<Items.CraftingIngredients.NatureToken>())
			.AddRecipeGroup("FabusMod:GoldBar", 10)
			.AddTile(TileID.Anvils)
			.Register();

		CreateRecipe()
			.AddIngredient(ModContent.ItemType<FoxPistol>())
			.AddIngredient(ItemID.BlueDye)
			.AddTile(TileID.DyeVat)
			.Register();
	}
}
