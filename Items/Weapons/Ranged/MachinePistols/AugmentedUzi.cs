using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace FabusMod.Items.Weapons.Ranged.MachinePistols;

public class AugmentedUzi : ModItem
{
	public override void SetStaticDefaults()
	{
		// DisplayName.SetDefault("Augmented Uzi");
		// Tooltip.SetDefault("[c/B6FF00:Autoshoots] \n70% chance to not consume ammo \nShoots incredibly fast");
	}

	public override void SetDefaults()
	{
		Item.damage = 32;
		Item.DamageType = DamageClass.Ranged;
		Item.width = 48;
		Item.height = 38;
		Item.useTime = 2;
		Item.useAnimation = 2;
		Item.useStyle = ItemUseStyleID.Shoot;
		Item.noMelee = true;
		Item.knockBack = 0f;
		Item.value = Item.sellPrice(0, 8, 20, 0);
		Item.UseSound = SoundID.Item11;
		Item.autoReuse = true;
		Item.shoot = ProjectileID.PurificationPowder;
		Item.shootSpeed = 18f;
		Item.useAmmo = AmmoID.Bullet;
		Item.rare = ItemRarityID.Lime;
	}

	public override Vector2? HoldoutOffset()
	{
		return new Vector2(-12f, -8f);
	}

	public override bool CanConsumeAmmo(Item ammo, Player player)
	{
		return Utils.NextFloat(Main.rand) >= 0.7f;
	}

	public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
	{
		velocity = Utils.RotatedByRandom(velocity, (double)MathHelper.ToRadians(6f));
		return true;
	}

	public override void AddRecipes()
	{
		CreateRecipe()
			.AddIngredient(ModContent.ItemType<MachinePistol>())
			.AddIngredient(ItemID.Uzi)
			.AddTile(TileID.MythrilAnvil)
			.Register();
	}
}
