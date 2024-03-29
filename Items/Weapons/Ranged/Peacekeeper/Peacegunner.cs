using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace FabusMod.Items.Weapons.Ranged.Peacekeeper;

public class Peacegunner : ModItem
{
	public override void SetStaticDefaults()
	{
		// DisplayName.SetDefault("Solitude");
		// Tooltip.SetDefault("[c/B6FF00:Autoshoots, dyeable]");
	}

	public override void SetDefaults()
	{
		Item.damage = 32;
		Item.DamageType = DamageClass.Ranged;
		Item.width = 50;
		Item.height = 28;
		Item.useTime = 12;
		Item.useAnimation = 12;
		Item.useStyle = ItemUseStyleID.Shoot;
		Item.noMelee = true;
		Item.knockBack = 4f;
		Item.value = Item.sellPrice(0, 4, 60, 0);
		Item.rare = ItemRarityID.Orange;
		Item.UseSound = SoundID.Item11;
		Item.autoReuse = true;
		Item.shoot = ProjectileID.PurificationPowder;
		Item.shootSpeed = 40f;
		Item.useAmmo = AmmoID.Bullet;
	}

	public override Vector2? HoldoutOffset()
	{
		return new Vector2(-2f, -2f);
	}

	public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
	{
		Vector2 muzzleOffset = Vector2.Normalize(velocity) * 35f;
		if (Collision.CanHit(position, 0, 0, position + muzzleOffset, 0, 0))
		{
			position += muzzleOffset;
		}
		return true;
	}

	public override void AddRecipes()
	{
		Recipe recipe1 = CreateRecipe();
		recipe1.AddIngredient(ModContent.ItemType<Peacekeeper>());
		recipe1.AddIngredient(ItemID.HellstoneBar, 10);
		recipe1.AddTile(TileID.Anvils);
		recipe1.Register();

		Recipe recipe2 = CreateRecipe();
		recipe2.AddIngredient(ModContent.ItemType<PeacegunnerAmerican>());
		recipe2.AddIngredient(ItemID.SilverDye);
		recipe2.AddTile(TileID.DyeVat);
		recipe2.Register();
	}
}
