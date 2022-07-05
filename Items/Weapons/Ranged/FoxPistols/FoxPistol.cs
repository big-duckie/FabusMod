using FabusMod.Projectiles.FoxPistol;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace FabusMod.Items.Weapons.Ranged.FoxPistols;

public class FoxPistol : ModItem
{
	public override void SetStaticDefaults()
	{
		DisplayName.SetDefault("Fox Pistol");
		Tooltip.SetDefault("[c/B6FF00:Autoshoots, doesn't require ammo, dyeable]\nGrants the [c/D78624:Fox Mending] buff for 5 seconds, which regenerates HP and increases speed, but lowers damage by 12% \nUsing <right> increases damage and reduces use time, as well as: \n - Grants the [c/9E9E9E:Fox Break] debuff for 1 second, reducing movement speed \n - Grants the [c/732C73:Fox Wither] debuff for 1.3 seconds on self, and 4 seconds on hit enemies \n - [c/732C73:Fox Wither] debuff deals damage over time and nullifies the [c/D78624:Fox Mending] buff's regeneration");
	}

	public override void SetDefaults()
	{
		Item.damage = 22;
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
		Item.expert = true;
		Item.shoot = ModContent.ProjectileType<OrangeBolt>();
	}

	public override Vector2? HoldoutOffset()
	{
		return new Vector2(0f, -2f);
	}

    public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
    {
		Vector2 muzzleOffset = Vector2.Normalize(new Vector2(velocity.X, velocity.Y)) * 32f;
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
			player.AddBuff(ModContent.BuffType<Buffs.FoxPistol.FoxMending>(), 300, true);
		}
		Vector2 perturbedSpeed = Utils.RotatedByRandom(new Vector2(velocity.X, velocity.Y), (double)MathHelper.ToRadians(3f));
		velocity.X = perturbedSpeed.X;
		velocity.Y = perturbedSpeed.Y;
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
			Item.shoot = ModContent.ProjectileType<OrangeBoltRMB>();
		}
		else
		{
			Item.useStyle = ItemUseStyleID.Shoot;
			Item.useTime = 12;
			Item.useAnimation = 12;
			Item.damage = 22;
			Item.shoot = ModContent.ProjectileType<OrangeBolt>();
		}
		return base.CanUseItem(player);
	}

	public override void AddRecipes()
	{
		Recipe val = CreateRecipe();
		val.AddIngredient(ModContent.ItemType<Items.CraftingIngredients.NatureToken>());
		val.AddRecipeGroup("FabusMod:GoldBar", 10);
		val.AddTile(TileID.Anvils);
		val.Register();

		Recipe val2 = CreateRecipe();
		val2.AddIngredient(ModContent.ItemType<FoxPistolBlue>());
		val2.AddIngredient(ItemID.OrangeDye, 1);
		val2.AddTile(TileID.DyeVat);
		val2.Register();
	}
}
