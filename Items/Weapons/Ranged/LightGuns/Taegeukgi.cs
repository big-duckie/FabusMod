using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace FabusMod.Items.Weapons.Ranged.LightGuns;

public class Taegeukgi : ModItem
{
	public override void SetStaticDefaults()
	{
		// DisplayName.SetDefault("Taegeukgi");
		// Tooltip.SetDefault("[c/B6FF00:Autoshoots]\nDoesn't require ammo\nShoots little light blasts");
	}

	public override void SetDefaults()
	{
		Item.damage = 40;
		Item.DamageType = DamageClass.Ranged;
		Item.width = 32;
		Item.height = 38;
		Item.useTime = 5;
		Item.useAnimation = 5;
		Item.useStyle = ItemUseStyleID.Shoot;
		Item.noMelee = true;
		Item.knockBack = 0f;
		Item.value = Item.sellPrice(0, 8, 25, 0);
		Item.UseSound = SoundID.Item11;
		Item.autoReuse = true;
		Item.shoot = ModContent.ProjectileType<Projectiles.LightBlasts.LightBlast>();
		Item.shootSpeed = 6f;
		Item.rare = ItemRarityID.LightRed;
	}

	public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
	{
		Vector2 muzzleOffset = Vector2.Normalize(velocity) * 32f;
		if (Collision.CanHit(position, 0, 0, position + muzzleOffset, 0, 0))
		{
			position += muzzleOffset;
		}
		return true;
	}

	public override void AddRecipes()
	{
		CreateRecipe()
			.AddIngredient(ModContent.ItemType<LightGun>())
			.AddRecipeGroup("FabusMod:MythrilBar", 6)
			.AddIngredient(ItemID.Sapphire, 6)
			.AddTile(TileID.MythrilAnvil)
			.Register();
	}
}
