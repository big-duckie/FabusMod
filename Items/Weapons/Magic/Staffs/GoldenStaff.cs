using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace FabusMod.Items.Weapons.Magic.Staffs;

public class GoldenStaff : ModItem
{
	public override void SetStaticDefaults()
	{
		// Tooltip.SetDefault("[c/B6FF00:Autoshoots] \nShoots four oval-shaped magic projectiles twice in quick succession \nHas a high critical hit chance");
		Item.staff[Type] = true;
	}

	public override void SetDefaults()
	{
		Item.damage = 46;
		Item.DamageType = DamageClass.Magic;
		Item.noMelee = true;
		Item.mana = 6;
		Item.crit = 52;
		Item.width = 58;
		Item.height = 58;
		Item.useTime = 8;
		Item.useAnimation = 16;
		Item.reuseDelay = 12;
		Item.useStyle = ItemUseStyleID.Shoot;
		Item.noMelee = true;
		Item.knockBack = 5f;
		Item.value = Item.sellPrice(0, 25, 30, 0);
		Item.UseSound = SoundID.Item20;
		Item.autoReuse = true;
		Item.shoot = ModContent.ProjectileType<Projectiles.SorcerousStaff.GoldenStaffProj>();
		Item.shootSpeed = 40f;
		Item.rare = ItemRarityID.Expert;
	}

	public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
	{
		int numberProjectiles = 4;
		for (int i = 0; i < numberProjectiles; i++)
		{
			Vector2 perturbedSpeed = Utils.RotatedByRandom(velocity, (double)MathHelper.ToRadians(10f));
			Projectile.NewProjectile(source, position, perturbedSpeed, type, damage, knockback, player.whoAmI);
		}
		return false;
	}

	public override void AddRecipes()
	{
		CreateRecipe()
			.AddIngredient(ModContent.ItemType<NatureStaff>())
			.AddIngredient(ModContent.ItemType<Items.CraftingIngredients.GoddessGold>(), 6)
			.AddTile(TileID.MythrilAnvil)
			.Register();
	}
}
