using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace FabusMod.Items.Weapons.Ranged.Peacekeeper;

public class Peaceforcer : ModItem
{
	public override void SetStaticDefaults()
	{
		DisplayName.SetDefault("The Silencer");
		Tooltip.SetDefault("[c/B6FF00:Autoshoots, dyeable] \nShoots 6 bullets in quick succession \n50% chance to not consume ammo \nConverts Musket Balls into High Velocity Bullets");
	}

	public override void SetDefaults()
	{
		Item.damage = 48;
		Item.DamageType = DamageClass.Ranged;
		Item.width = 50;
		Item.height = 30;
		Item.useTime = 2;
		Item.useAnimation = 12;
		Item.useStyle = ItemUseStyleID.Shoot;
		Item.noMelee = true;
		Item.knockBack = 4f;
		Item.value = Item.sellPrice(0, 21, 80, 0);
		Item.rare = ItemRarityID.Pink;
		Item.UseSound = SoundID.Item11;
		Item.autoReuse = true;
		Item.shoot = ProjectileID.PurificationPowder;
		Item.shootSpeed = 40f;
		Item.reuseDelay = 12;
		Item.useAmmo = AmmoID.Bullet;
	}

	public override Vector2? HoldoutOffset()
	{
		return new Vector2(-2f, -2f);
	}

	public override bool CanConsumeAmmo(Item ammo, Player player)
	{
		return Utils.NextFloat(Main.rand) >= 0.5f;
	}

	public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
	{
		Vector2 muzzleOffset = Vector2.Normalize(velocity) * 35f;
		if (Collision.CanHit(position, 0, 0, position + muzzleOffset, 0, 0))
		{
			position += muzzleOffset;
		}
		if (type == 14)
		{
			type = 242;
		}
		return true;
	}

	public override void AddRecipes()
	{
		CreateRecipe()
			.AddRecipeGroup("FabusMod:Peacegunner")
			.AddRecipeGroup("FabusMod:AdamantiteBar", 8)
			.AddIngredient(ItemID.SoulofNight, 6)
			.AddIngredient(ModContent.ItemType<Items.CraftingIngredients.SoulofWisdom>(), 4)
			.AddTile(TileID.MythrilAnvil)
			.Register();

		CreateRecipe()
			.AddIngredient(ModContent.ItemType<PeaceforcerVanHelsing>())
			.AddIngredient(ItemID.SilverDye)
			.AddTile(TileID.DyeVat)
			.Register();
	}
}
