using FabusMod.Projectiles.LightBlasts;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace FabusMod.Items.Weapons.Ranged.LightGuns;

public class LightGun : ModItem
{
	public override void SetStaticDefaults()
	{
		DisplayName.SetDefault("Light Gun");
		Tooltip.SetDefault("[c/B6FF00:Autoshoots] \nDoesn't require ammo \nShoots little light blasts");
	}

	public override void SetDefaults()
	{
		Item.damage = 14;
		Item.width = 32;
		Item.height = 38;
		Item.useTime = 7;
		Item.useAnimation = 7;
		Item.useStyle = ItemUseStyleID.Shoot;
		Item.noMelee = true;
		Item.knockBack = 0f;
		Item.value = Item.sellPrice(0, 5, 0, 0);
		Item.UseSound = SoundID.Item11;
		Item.autoReuse = true;
		Item.shoot = ModContent.ProjectileType<LightBlast>();
		Item.shootSpeed = 7f;
		Item.rare = ItemRarityID.Green;
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
		val.AddRecipeGroup("FabusMod:GoldBar", 20);
		val.AddIngredient(ItemID.Diamond, 4);
		val.AddIngredient(ItemID.Amethyst, 6);
		val.AddTile(TileID.Anvils);
		val.Register();
	}
}
