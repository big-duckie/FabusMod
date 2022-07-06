using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace FabusMod.Items.Weapons.RainbowDemon;

public class TheRainbowDemonThrowing : ModItem
{
	public override void SetStaticDefaults()
	{
		DisplayName.SetDefault("The Rainbow Demon - Throwing");
		Tooltip.SetDefault("[c/B6FF00:Autoshoots] \nUnleashes a barrage of rainbow daggers \nDoes not require ammo \nClass and projectiles fired can be changed via crafting \n[c/FF2B6E:Currently Unobtainable]");
	}

	public override void SetDefaults()
	{
		Item.damage = 82;
		Item.DamageType = DamageClass.Throwing;
		Item.noMelee = true;
		Item.width = 82;
		Item.height = 39;
		Item.useTime = 4;
		Item.useAnimation = 4;
		Item.useStyle = ItemUseStyleID.Shoot;
		Item.noMelee = true;
		Item.knockBack = 0f;
		Item.value = Item.sellPrice(40, 0, 0, 0);
		Item.UseSound = SoundID.Item11;
		Item.autoReuse = true;
		Item.shoot = ProjectileID.PurificationPowder;
		Item.shootSpeed = 25f;
		Item.shoot = ModContent.ProjectileType<Projectiles.RainbowDemon.RainbowDemonKnife>();
		Item.expert = true;
	}

	public override Vector2? HoldoutOffset()
	{
		return new Vector2(7f, -5f);
	}

    public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
    {
		int numberProjectiles = 10;
		for (int i = 0; i < numberProjectiles; i++)
		{
			Vector2 perturbedSpeed = Utils.RotatedByRandom(velocity, (double)MathHelper.ToRadians(30f));
			Projectile.NewProjectile(source, position, perturbedSpeed, type, damage, knockback, player.whoAmI);
		}
		return false;
	}

	public override void AddRecipes()
	{
		CreateRecipe()
			.AddRecipeGroup("FabusMod:TheRainbowDemon")
			.AddIngredient(ItemID.FragmentSolar)
			.AddIngredient(ItemID.FragmentVortex)
			.AddTile(ModContent.TileType<global::FabusMod.Tiles.RainbowStation>())
			.Register();
	}
}
