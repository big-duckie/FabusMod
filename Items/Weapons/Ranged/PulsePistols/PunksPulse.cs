using FabusMod.Projectiles;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace FabusMod.Items.Weapons.Ranged.PulsePistols;

public class PunksPulse : ModItem
{
	public override void SetStaticDefaults()
	{
		DisplayName.SetDefault("Punk's Pulse");
		Tooltip.SetDefault("[c/B6FF00:Autoshoots, dyeable] \n70% chance to not consume ammo \nShoots incredibly fast \nConverts Musket Balls into Pulse Bullets");
	}

	public override void SetDefaults()
	{
		Item.damage = 25;
		Item.DamageType = DamageClass.Ranged;
		Item.width = 40;
		Item.height = 28;
		Item.useTime = 2;
		Item.useAnimation = 2;
		Item.useStyle = ItemUseStyleID.Shoot;
		Item.noMelee = true;
		Item.knockBack = 0f;
		Item.value = Item.sellPrice(0, 8, 64, 0);
		Item.UseSound = SoundID.Item11;
		Item.autoReuse = true;
		Item.shoot = ProjectileID.PurificationPowder;
		Item.shootSpeed = 25f;
		Item.useAmmo = AmmoID.Bullet;
		Item.rare = ItemRarityID.Pink;
	}

	public override bool CanConsumeAmmo(Item ammo, Player player)
	{
		return Utils.NextFloat(Main.rand) >= 0.7f;
	}

	public override Vector2? HoldoutOffset()
	{
		return new Vector2(1f, -2f);
	}

	public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
	{
		velocity = Utils.RotatedByRandom(velocity, (double)MathHelper.ToRadians(8f));
		if (type == 14)
		{
			type = ModContent.ProjectileType<PulseBullet>();
		}
		return true;
	}

	public override void AddRecipes()
	{
		CreateRecipe()
			.AddIngredient(ModContent.ItemType<PulsePistol>())
			.AddIngredient(ItemID.HallowedBar, 8)
			.AddIngredient(ItemID.SoulofNight, 6)
			.AddTile(TileID.AdamantiteForge)
			.Register();

		CreateRecipe()
			.AddIngredient(ModContent.ItemType<PunksPulseUltraviolet>())
			.AddIngredient(ItemID.BlueDye)
			.AddTile(TileID.DyeVat)
			.Register();
	}
}
