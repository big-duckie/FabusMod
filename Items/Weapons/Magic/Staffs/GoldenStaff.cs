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
		DisplayName.SetDefault("Golden Staff");
		Tooltip.SetDefault("[c/B6FF00:Autoshoots] \nShoots four oval-shaped magic projectiles twice in quick succession \nHas a high critical hit chance");
		Item.staff[Item.type] = true;
	}

	public override void SetDefaults()
	{
		Item.damage = 46;
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
		Item.expert = true;
		Item.UseSound = SoundID.Item20;
		Item.autoReuse = true;
		Item.shoot = ModContent.ProjectileType<Projectiles.SorcerousStaff.GoldenStaffProj>();
		Item.shootSpeed = 40f;
	}

    public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
    {
		int numberProjectiles = 4;
		for (int i = 0; i < numberProjectiles; i++)
		{
			Vector2 perturbedSpeed = Utils.RotatedByRandom(new Vector2(velocity.X, velocity.Y), (double)MathHelper.ToRadians(10f));
			Projectile.NewProjectile(source, position, perturbedSpeed, type, damage, knockback);
		}
		return false;
    }

	public override void AddRecipes()
	{
		Recipe val = CreateRecipe();
		val.AddIngredient(ModContent.ItemType<NatureStaff>());
		val.AddIngredient(ModContent.ItemType<Items.CraftingIngredients.GoddessGold>(), 6);
		val.AddTile(TileID.MythrilAnvil);
		val.Register();
	}
}
