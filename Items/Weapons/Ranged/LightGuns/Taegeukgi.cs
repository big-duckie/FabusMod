using FabusMod.Projectiles.LightBlasts;
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
		DisplayName.SetDefault("Taegeukgi");
		Tooltip.SetDefault("[c/B6FF00:Autoshoots]\nDoesn't require ammo\nShoots little light blasts");
	}

	public override void SetDefaults()
	{
		Item.damage = 40;
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
		Item.shoot = ModContent.ProjectileType<LightBlast>();
		Item.shootSpeed = 6f;
		Item.rare = ItemRarityID.LightRed;
	}

    public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
	{
		Vector2 muzzleOffset = Vector2.Normalize(new Vector2(velocity.X, velocity.Y)) * 32f;
		if (Collision.CanHit(position, 0, 0, position + muzzleOffset, 0, 0))
		{
			position += muzzleOffset;
		}
		return true;
	}

	public override void AddRecipes()
	{
		Recipe val = CreateRecipe();
		val.AddIngredient(ModContent.ItemType<LightGun>());
		val.AddRecipeGroup("FabusMod:OrichalcumBar", 6);
		val.AddIngredient(ItemID.Sapphire, 6);
		val.AddTile(TileID.MythrilAnvil);
		val.Register();
	}
}
