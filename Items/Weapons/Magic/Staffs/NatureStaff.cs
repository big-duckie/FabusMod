using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace FabusMod.Items.Weapons.Magic.Staffs;

public class NatureStaff : ModItem
{
	public override void SetStaticDefaults()
	{
		// Tooltip.SetDefault("[c/B6FF00:Autoshoots] \nShoots three oval-shaped magic projectiles twice in quick succession \nHas a 25% chance of inflicting the [c/0E3517:Poisoned] debuff for 3 seconds \nHas a high critical hit chance");
		Item.staff[Item.type] = true;
	}

	public override void SetDefaults()
	{
		Item.damage = 36;
		Item.DamageType = DamageClass.Magic;
		Item.noMelee = true;
		Item.mana = 6;
		Item.crit = 42;
		Item.width = 58;
		Item.height = 58;
		Item.useTime = 9;
		Item.useAnimation = 18;
		Item.reuseDelay = 16;
		Item.useStyle = ItemUseStyleID.Shoot;
		Item.noMelee = true;
		Item.knockBack = 5f;
		Item.value = Item.sellPrice(0, 8, 80, 0);
		Item.rare = ItemRarityID.Expert;
		Item.UseSound = SoundID.Item20;
		Item.autoReuse = true;
		Item.shoot = ModContent.ProjectileType<Projectiles.SorcerousStaff.NatureStaffProj>();
		Item.shootSpeed = 40f;
	}

	public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
	{
		int numberProjectiles = 3;
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
			.AddRecipeGroup("FabusMod:SorcerousHellstaff")
			.AddIngredient(ItemID.HallowedBar, 6)
			.AddIngredient(ModContent.ItemType<Items.CraftingIngredients.NatureToken>())
			.AddTile(TileID.MythrilAnvil)
			.Register();
	}
}
