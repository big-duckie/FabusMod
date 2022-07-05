using FabusMod.Projectiles;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace FabusMod.Items.Weapons.Ranged.PulsePistols;

public class PulseSprayer : ModItem
{
	public override void SetStaticDefaults()
	{
		DisplayName.SetDefault("Pulse Sprayer");
		Tooltip.SetDefault("[c/B6FF00:Autoshoots, dyeable] \n80% chance to not consume ammo \nShoots incredibly fast \nConverts Musket Balls into dark blue Pulse Bullets");
	}

	public override void SetDefaults()
	{
		Item.damage = 54;
		Item.DamageType = DamageClass.Ranged;
		Item.width = 40;
		Item.height = 28;
		Item.useTime = 2;
		Item.useAnimation = 2;
		Item.useStyle = ItemUseStyleID.Shoot;
		Item.noMelee = true;
		Item.knockBack = 0f;
		Item.value = Item.sellPrice(0, 10, 20, 0);
		Item.UseSound = SoundID.Item11;
		Item.autoReuse = true;
		Item.shoot = ProjectileID.PurificationPowder;
		Item.shootSpeed = 25f;
		Item.useAmmo = AmmoID.Bullet;
		Item.rare = ItemRarityID.Red;
	}

	public override bool CanConsumeAmmo(Item ammo, Player player)
	{
		return Utils.NextFloat(Main.rand) >= 0.8f;
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
			type = ModContent.ProjectileType<PulseBulletBlue>();
		}
		return true;
	}

	public override void AddRecipes()
	{
		CreateRecipe()
			.AddRecipeGroup("FabusMod:PunksPulse")
			.AddIngredient(ItemID.FragmentVortex, 8)
			.AddTile(TileID.LunarCraftingStation)
			.Register();

		CreateRecipe()
			.AddIngredient(ModContent.ItemType<PulseSprayerCadet>())
			.AddIngredient(ItemID.BlueDye)
			.AddTile(TileID.DyeVat)
			.Register();
	}
}
