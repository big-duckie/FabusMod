using FabusMod.Projectiles.Arrows;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace FabusMod.Items.Weapons.Ranged.Bows;

public class PiercingBow : ModItem
{
	public override void SetStaticDefaults()
	{
		// DisplayName.SetDefault("Piercing Bow");
		// Tooltip.SetDefault("Converts Wooden Arrows into Piercing Arrows");
	}

	public override void SetDefaults()
	{
		Item.damage = 10;
		Item.DamageType = DamageClass.Ranged;
		Item.width = 18;
		Item.height = 32;
		Item.useTime = 27;
		Item.useAnimation = 27;
		Item.useStyle = ItemUseStyleID.Shoot;
		Item.noMelee = true;
		Item.knockBack = 2f;
		Item.value = Item.sellPrice(0, 0, 15, 0);
		Item.rare = ItemRarityID.White;
		Item.UseSound = SoundID.Item5;
		Item.autoReuse = false;
		Item.shoot = ProjectileID.PurificationPowder;
		Item.shootSpeed = 7f;
		Item.useAmmo = AmmoID.Arrow;
	}

	public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
	{
		if (type == 1)
		{
			type = ModContent.ProjectileType<PiercingArrow>();
		}
		return true;
	}

	public override void AddRecipes()
	{
		CreateRecipe()
			.AddIngredient(ItemID.WoodenBow)
			.AddIngredient(ItemID.IronBow)
			.AddTile(TileID.Anvils)
			.Register();

		CreateRecipe()
			.AddIngredient(ItemID.WoodenBow)
			.AddIngredient(ItemID.LeadBow)
			.AddTile(TileID.Anvils)
			.Register();
	}
}
