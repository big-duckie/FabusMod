using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace FabusMod.Items.Weapons.Ranged.MachinePistols;

public class Verano : ModItem
{
	public override void SetStaticDefaults()
	{
		// DisplayName.SetDefault("Verano");
		// Tooltip.SetDefault("[c/B6FF00:Autoshoots, dyeable] \n80% chance to not consume ammo \nShoots incredibly fast");
	}

	public override void SetDefaults()
	{
		Item.damage = 60;
		Item.DamageType = DamageClass.Ranged;
		Item.width = 48;
		Item.height = 36;
		Item.useTime = 2;
		Item.useAnimation = 2;
		Item.useStyle = ItemUseStyleID.Shoot;
		Item.noMelee = true;
		Item.knockBack = 0f;
		Item.value = Item.sellPrice(0, 10, 60, 0);
		Item.UseSound = SoundID.Item11;
		Item.autoReuse = true;
		Item.shoot = ProjectileID.PurificationPowder;
		Item.shootSpeed = 18f;
		Item.useAmmo = AmmoID.Bullet;
		Item.rare = ItemRarityID.Cyan;
	}

	public override Vector2? HoldoutOffset()
	{
		return new Vector2(-12f, -8f);
	}

	public override bool CanConsumeAmmo(Item ammo, Player player)
	{
		return Utils.NextFloat(Main.rand) >= 0.8f;
	}

	public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
	{
		velocity = Utils.RotatedByRandom(velocity, (double)MathHelper.ToRadians(5f));
		return true;
	}

	public override void AddRecipes()
	{
		CreateRecipe()
			.AddIngredient(ModContent.ItemType<AugmentedUzi>())
			.AddIngredient(ItemID.FragmentVortex, 12)
			.AddTile(TileID.LunarCraftingStation)
			.Register();

		CreateRecipe()
			.AddIngredient(ModContent.ItemType<VeranoRime>())
			.AddIngredient(ItemID.GreenDye)
			.AddTile(TileID.DyeVat)
			.Register();
	}
}
