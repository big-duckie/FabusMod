using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace FabusMod.Items.Weapons.Magic.Staffs;

public class TheWhisperingIceDonator : ModItem
{
	public override void SetStaticDefaults()
	{
		DisplayName.SetDefault("The Whispering Ice");
		Tooltip.SetDefault("[c/B6FF00:Autoshoots] \nShoots three icicles that inflict Frostburn for 3 seconds \n'Guard your darkest thoughts well, for they are the cracks through which the Nightmare crawls.' \n~~ Donator Item ~~");
		Item.staff[Item.type] = true;
	}

	public override void SetDefaults()
	{
		Item.damage = 70;
		Item.noMelee = true;
		Item.mana = 8;
		Item.width = 54;
		Item.height = 56;
		Item.useTime = 13;
		Item.useAnimation = 13;
		Item.useStyle = ItemUseStyleID.Shoot;
		Item.noMelee = true;
		Item.knockBack = 5f;
		Item.value = Item.sellPrice(0, 6, 50, 0);
		Item.rare = ItemRarityID.Pink;
		Item.UseSound = SoundID.Item28;
		Item.autoReuse = true;
		Item.shoot = ModContent.ProjectileType<Projectiles.TheWhisperingIcicle>();
		Item.shootSpeed = 16f;
	}

    public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
    {
		int numberProjectiles = 3;
		for (int i = 0; i < numberProjectiles; i++)
		{
			Vector2 perturbedSpeed = Utils.RotatedByRandom(new Vector2(velocity.X, velocity.Y), (double)MathHelper.ToRadians(5f));
			Projectile.NewProjectile(source, position.X, position.Y, perturbedSpeed.X, perturbedSpeed.Y, type, damage, knockback, player.whoAmI, 0f, 0f);
		}
		return false;
	}

	public override void AddRecipes()
	{
		Recipe val = CreateRecipe();
		val.AddIngredient(ItemID.FrostCore, 2);
		val.AddRecipeGroup("FabusMod:AdamantiteBar", 6);
		val.AddTile(TileID.MythrilAnvil);
		val.Register();
	}
}
