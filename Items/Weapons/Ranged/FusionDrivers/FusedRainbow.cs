using FabusMod.Projectiles;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace FabusMod.Items.Weapons.Ranged.FusionDrivers;

public class FusedRainbow : ModItem
{
	public override void SetStaticDefaults()
	{
		DisplayName.SetDefault("Cosmic Fusion");
		Tooltip.SetDefault("[c/B6FF00:Autoshoots] \n80% chance to not consume ammo \nConverts Musket Balls into homing rainbow bullets");
	}

	public override void SetDefaults()
	{
		Item.damage = 85;
		Item.DamageType = DamageClass.Ranged;
		Item.width = 70;
		Item.height = 32;
		Item.useTime = 2;
		Item.useAnimation = 2;
		Item.useStyle = ItemUseStyleID.Shoot;
		Item.noMelee = true;
		Item.knockBack = 4f;
		Item.value = Item.sellPrice(2, 80, 0, 0);
		Item.UseSound = SoundID.Item11;
		Item.autoReuse = true;
		Item.shoot = ProjectileID.PurificationPowder;
		Item.shootSpeed = 18f;
		Item.useAmmo = AmmoID.Bullet;
		Item.rare = ItemRarityID.Expert;
	}

	public override Vector2? HoldoutOffset()
	{
		return new Vector2(-2f, 2f);
	}

	public override bool CanConsumeAmmo(Item ammo, Player player)
	{
		return Utils.NextFloat(Main.rand) >= 0.8f;
	}

	public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
	{
		if (type == 14)
		{
			type = ModContent.ProjectileType<RainbowBullet>();
		}
		return true;
	}

	public override void AddRecipes()
	{
		CreateRecipe()
			.AddIngredient(ModContent.ItemType<DynasticFuserGolden>())
			.AddIngredient(ModContent.ItemType<Bars.RainbowChunk>(), 12)
			.AddTile(ModContent.TileType<global::FabusMod.Tiles.RainbowStation>())
			.Register();
	}
}
