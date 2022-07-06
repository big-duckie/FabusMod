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
		Item.rare = ItemRarityID.Expert;
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
			Vector2 perturbedSpeed = Utils.RotatedByRandom(velocity, (double)MathHelper.ToRadians(10f));
			Projectile.NewProjectile(source, position, perturbedSpeed, type, damage, knockback, player.whoAmI);
		}
		return false;
	}

	public override void AddRecipes()
	{
		CreateRecipe()
			.AddIngredient(ModContent.ItemType<GoldenStaff>())
			.AddIngredient(ModContent.ItemType<Bars.RainbowChunk>(), 6)
			.AddTile(ModContent.TileType<global::FabusMod.Tiles.RainbowStation>())
			.Register();
	}
}
