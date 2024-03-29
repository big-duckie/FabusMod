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
		// DisplayName.SetDefault("Cosmic Uzi");
		// Tooltip.SetDefault("[c/B6FF00:Autoshoots] \n90% chance to not consume ammo \nConverts Musket Balls into homing Rainbow Bullets");
	}

	public override void SetDefaults()
	{
		Item.damage = 82;
		Item.DamageType = DamageClass.Ranged;
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
		Item.rare = ItemRarityID.Expert;
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
		velocity = Utils.RotatedByRandom(velocity, (double)MathHelper.ToRadians(5f));
		if (type == 14)
		{
			type = ModContent.ProjectileType<Projectiles.RainbowBullet>();
		}
		return true;
	}

	public override void AddRecipes()
	{
		CreateRecipe()
			.AddIngredient(ModContent.ItemType<MachinePistolGolden>())
			.AddIngredient(ModContent.ItemType<Bars.RainbowChunk>(), 10)
			.AddTile(ModContent.TileType<global::FabusMod.Tiles.RainbowStation>())
			.Register();
	}
}
