using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace FabusMod.Items.Weapons.Ranged.Shotguns;

public class HellfireShotgun : ModItem
{
	public override void SetStaticDefaults()
	{
		DisplayName.SetDefault("Hellfire Shotgun");
		Tooltip.SetDefault("Fires a spread of 5 bullets \nOnly uses one Bullet per use");
	}

	public override void SetDefaults()
	{
		Item.damage = 21;
		Item.DamageType = DamageClass.Ranged;
		Item.width = 78;
		Item.height = 28;
		Item.useTime = 45;
		Item.useAnimation = 45;
		Item.useStyle = ItemUseStyleID.Shoot;
		Item.noMelee = true;
		Item.knockBack = 4f;
		Item.value = Item.sellPrice(0, 2, 0, 0);
		Item.rare = ItemRarityID.Orange;
		Item.UseSound = SoundID.Item36;
		Item.autoReuse = false;
		Item.shoot = ProjectileID.PurificationPowder;
		Item.shootSpeed = 35f;
		Item.useAmmo = AmmoID.Bullet;
	}

	public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
	{
		int numberProjectiles = 5;
		for (int i = 0; i < numberProjectiles; i++)
		{
			Vector2 perturbedSpeed = Utils.RotatedByRandom(velocity, (double)MathHelper.ToRadians(12f));
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
			.AddIngredient(ItemID.Obsidian, 16)
			.AddIngredient(ItemID.HellstoneBar, 4)
			.AddTile(TileID.Anvils)
			.Register();
	}
}
