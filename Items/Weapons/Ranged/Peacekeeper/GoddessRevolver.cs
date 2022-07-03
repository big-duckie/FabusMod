using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace FabusMod.Items.Weapons.Ranged.Peacekeeper;

public class GoddessRevolver : ModItem
{
	public override void SetStaticDefaults()
	{
		DisplayName.SetDefault("Goddess' Revolver");
		Tooltip.SetDefault("[c/B6FF00:Autoshoots] \nShoots 6 bullets in quick succession \n50% chance to not consume ammo \nConverts Musket Balls into High Velocity Bullets");
	}

	public override void SetDefaults()
	{
		Item.damage = 86;
		Item.width = 50;
		Item.height = 28;
		Item.useTime = 2;
		Item.useAnimation = 12;
		Item.useStyle = ItemUseStyleID.Shoot;
		Item.noMelee = true;
		Item.knockBack = 4f;
		Item.value = Item.sellPrice(0, 58, 20, 0);
		Item.rare = ItemRarityID.Yellow;
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
		Vector2 muzzleOffset = Vector2.Normalize(new Vector2(velocity.X, velocity.Y)) * 35f;
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
		Recipe val = CreateRecipe();
		val.AddRecipeGroup("FabusMod:Peaceforcer", 1);
		val.AddIngredient(ModContent.ItemType<Items.CraftingIngredients.GoddessGold>(), 8);
		val.AddIngredient(ModContent.ItemType<Items.CraftingIngredients.SoulofWisdom>(), 6);
		val.AddTile(TileID.AdamantiteForge);
		val.Register();
	}
}
