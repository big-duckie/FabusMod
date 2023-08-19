using FabusMod.Projectiles;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace FabusMod.Items.Weapons.Melee.Swords;

public class GoldenSlasher : ModItem
{
	public override void SetStaticDefaults()
	{
		// Tooltip.SetDefault("[c/B6FF00:Autoswings] \nShoots two homing golden orbs in a medium-sized spread on swing");
	}

	public override void SetDefaults()
	{
		Item.damage = 110;
		Item.width = 64;
		Item.height = 72;
		Item.useTime = 15;
		Item.useAnimation = 15;
		Item.useStyle = ItemUseStyleID.Swing;
		Item.knockBack = 3f;
		Item.value = Item.sellPrice(0, 40, 0, 0);
		Item.rare = ItemRarityID.Yellow;
		Item.UseSound = SoundID.Item1;
		Item.autoReuse = true;
		Item.shoot = ModContent.ProjectileType<GoldenOrb>();
		Item.shootSpeed = 15f;
	}

	public override void MeleeEffects(Player player, Rectangle hitbox)
	{
		if (Main.rand.NextBool(4))
		{
			Dust.NewDust(new Vector2(hitbox.X, hitbox.Y), hitbox.Width, hitbox.Height, ModContent.DustType<Dusts.MeatDust>());
		}
	}

	public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
	{
		float numberProjectiles = 2f;
		float rotation = MathHelper.ToRadians(25f);
		position += Vector2.Normalize(velocity) * 45f;
		for (int i = 0; i < numberProjectiles; i++)
		{
			Vector2 perturbedSpeed = Utils.RotatedBy(velocity, (double)MathHelper.Lerp(0f - rotation, rotation, i / (numberProjectiles - 1f)), default) * 0.2f;
			Projectile.NewProjectile(source, position, perturbedSpeed, type, damage, knockback, player.whoAmI);
		}
		return false;
	}

	public override void AddRecipes()
	{
		CreateRecipe()
			.AddIngredient(ModContent.ItemType<Items.CraftingIngredients.GoddessGold>(), 14)
			.AddTile(TileID.AdamantiteForge)
			.Register();
	}
}
