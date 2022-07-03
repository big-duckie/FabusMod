using FabusMod.Projectiles;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace FabusMod.Items.Weapons.Ranged.MachinePistols;

public class CosmicHacker : ModItem
{
	public override void SetStaticDefaults()
	{
		DisplayName.SetDefault("Cosmic Uzi");
		Tooltip.SetDefault("[c/B6FF00:Autoshoots] \n90% chance to not consume ammo \nConverts Musket Balls into homing Rainbow Bullets");
	}

	public override void SetDefaults()
	{
		Item.damage = 82;
		Item.width = 48;
		Item.height = 36;
		Item.useTime = 2;
		Item.useAnimation = 2;
		Item.useStyle = ItemUseStyleID.Shoot;
		Item.noMelee = true;
		Item.knockBack = 0f;
		Item.value = Item.sellPrice(2, 30, 0, 0);
		Item.UseSound = SoundID.Item11;
		Item.autoReuse = true;
		Item.shoot = ProjectileID.PurificationPowder;
		Item.shootSpeed = 18f;
		Item.useAmmo = AmmoID.Bullet;
		Item.expert = true;
	}

	public override Vector2? HoldoutOffset()
	{
		return new Vector2(-8f, -8f);
	}

    public override bool CanConsumeAmmo(Item ammo, Player player)
	{
		return Utils.NextFloat(Main.rand) >= 0.9f;
	}

    public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
	{
		Vector2 perturbedSpeed = Utils.RotatedByRandom(new Vector2(velocity.X, velocity.Y), (double)MathHelper.ToRadians(5f));
		velocity.X = perturbedSpeed.X;
		velocity.Y = perturbedSpeed.Y;
		if (type == 14)
		{
			type = ModContent.ProjectileType<RainbowBullet>();
		}
		return true;
	}

	public override void AddRecipes()
	{
		Recipe val = CreateRecipe();
		val.AddIngredient(ModContent.ItemType<MachinePistolGolden>());
		val.AddIngredient(ModContent.ItemType<Bars.RainbowChunk>(), 10);
		val.AddTile(ModContent.TileType<global::FabusMod.Tiles.RainbowStation>());
		val.Register();
	}
}
