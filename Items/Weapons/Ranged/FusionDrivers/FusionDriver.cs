using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace FabusMod.Items.Weapons.Ranged.FusionDrivers;

public class FusionDriver : ModItem
{
	public override void SetStaticDefaults()
	{
		// DisplayName.SetDefault("Fusion Driver");
		// Tooltip.SetDefault("[c/B6FF00:Autoshoots]");
	}

	public override void SetDefaults()
	{
		Item.damage = 5;
		Item.DamageType = DamageClass.Ranged;
		Item.width = 72;
		Item.height = 32;
		Item.useTime = 8;
		Item.useAnimation = 8;
		Item.useStyle = ItemUseStyleID.Shoot;
		Item.noMelee = true;
		Item.knockBack = 4f;
		Item.value = Item.sellPrice(0, 0, 96, 0);
		Item.rare = ItemRarityID.Blue;
		Item.UseSound = SoundID.Item11;
		Item.autoReuse = true;
		Item.shoot = ProjectileID.PurificationPowder;
		Item.shootSpeed = 30f;
		Item.useAmmo = AmmoID.Bullet;
	}

	public override Vector2? HoldoutOffset()
	{
		return new Vector2(-2f, 2f);
	}

	public override void AddRecipes()
	{
		CreateRecipe()
			.AddRecipeGroup("IronBar", 12)
			.AddIngredient(ItemID.Emerald, 4)
			.AddTile(TileID.Anvils)
			.Register();
	}
}
