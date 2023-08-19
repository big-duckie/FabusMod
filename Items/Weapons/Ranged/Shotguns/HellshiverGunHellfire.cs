using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace FabusMod.Items.Weapons.Ranged.Shotguns;

public class HellshiverGunHellfire : ModItem
{
	public override void SetStaticDefaults()
	{
		// DisplayName.SetDefault("Shivering Shotgun - Hellfire");
		// Tooltip.SetDefault("[c/B6FF00:Autoshoots] \nFires a spread of 6 bullets \nOnly uses one Bullet per use");
	}

	public override void SetDefaults()
	{
		Item.damage = 30;
		Item.DamageType = DamageClass.Ranged;
		Item.width = 78;
		Item.height = 28;
		Item.useTime = 35;
		Item.useAnimation = 35;
		Item.useStyle = ItemUseStyleID.Shoot;
		Item.noMelee = true;
		Item.knockBack = 4f;
		Item.value = Item.sellPrice(0, 4, 64, 0);
		Item.rare = ItemRarityID.LightRed;
		Item.UseSound = SoundID.Item36;
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
			Vector2 perturbedSpeed = Utils.RotatedByRandom(velocity, (double)MathHelper.ToRadians(10f));
			Projectile.NewProjectile(source, position, perturbedSpeed, type, damage, knockback, player.whoAmI);
		}
		return false;
	}

	public override Vector2? HoldoutOffset()
	{
		return new Vector2(-2f, -5f);
	}

	public override void AddRecipes()
	{
		CreateRecipe()
			.AddIngredient(ModContent.ItemType<HellshiverGun>())
			.AddIngredient(ItemID.FlameDye)
			.AddTile(TileID.DyeVat)
			.Register();
	}
}
