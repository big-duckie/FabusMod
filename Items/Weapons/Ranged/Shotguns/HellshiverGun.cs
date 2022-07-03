using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace FabusMod.Items.Weapons.Ranged.Shotguns;

public class HellshiverGun : ModItem
{
	public override void SetStaticDefaults()
	{
		DisplayName.SetDefault("Shivering Shotgun");
		Tooltip.SetDefault("[c/B6FF00:Autoshoots, dyeable] \nFires a spread of 6 bullets \nOnly uses one Bullet per use");
	}

	public override void SetDefaults()
	{
		Item.damage = 30;
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
			Vector2 perturbedSpeed = Utils.RotatedByRandom(new Vector2(velocity.X, velocity.Y), (double)MathHelper.ToRadians(10f));
			Projectile.NewProjectile(source, position.X, position.Y, perturbedSpeed.X, perturbedSpeed.Y, type, damage, knockback, player.whoAmI, 0f, 0f);
		}
		return false;
	}

	public override Vector2? HoldoutOffset()
	{
		return new Vector2(-2f, -5f);
	}

	public override void AddRecipes()
	{
		Recipe val = CreateRecipe();
		val.AddIngredient(ModContent.ItemType<HellfireShotgun>());
		val.AddRecipeGroup("FabusMod:OrichalcumBar", 6);
		val.AddIngredient(ItemID.IceBlock, 20);
		val.AddTile(TileID.MythrilAnvil);
		val.Register();

		Recipe val2 = CreateRecipe();
		val2.AddIngredient(ModContent.ItemType<HellshiverGunHellfire>());
		val2.AddIngredient(ItemID.BlueFlameDye, 1);
		val2.AddTile(TileID.DyeVat);
		val2.Register();
	}
}
