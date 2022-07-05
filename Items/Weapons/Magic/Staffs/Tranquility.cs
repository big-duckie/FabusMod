using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace FabusMod.Items.Weapons.Magic.Staffs;

public class Tranquility : ModItem
{
	public override void SetStaticDefaults()
	{
		DisplayName.SetDefault("Tranquility");
		Tooltip.SetDefault("[c/B6FF00:Autoshoots] \nShoots six oval-shaped rainbow projectiles three times in quick succession \nHas a high critical hit chance");
		Item.staff[Item.type] = true;
	}

	public override void SetDefaults()
	{
		Item.damage = 58;
		Item.DamageType = DamageClass.Magic;
		Item.noMelee = true;
		Item.mana = 7;
		Item.crit = 52;
		Item.width = 62;
		Item.height = 62;
		Item.useTime = 4;
		Item.useAnimation = 12;
		Item.reuseDelay = 8;
		Item.useStyle = ItemUseStyleID.Shoot;
		Item.noMelee = true;
		Item.knockBack = 5f;
		Item.value = Item.sellPrice(1, 50, 0, 0);
		Item.expert = true;
		Item.UseSound = SoundID.Item20;
		Item.autoReuse = true;
		Item.shoot = ModContent.ProjectileType<Projectiles.SorcerousStaff.TranquilityProj>();
		Item.shootSpeed = 40f;
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

	public override void AddRecipes()
	{
		Recipe recipe = CreateRecipe();
		recipe.AddIngredient(ModContent.ItemType<GoldenStaff>());
		recipe.AddIngredient(ModContent.ItemType<Bars.RainbowChunk>(), 6);
		recipe.AddTile(ModContent.TileType<global::FabusMod.Tiles.RainbowStation>());
		recipe.Register();
	}
}
