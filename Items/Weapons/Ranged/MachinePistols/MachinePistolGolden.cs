using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace FabusMod.Items.Weapons.Ranged.MachinePistols;

public class MachinePistolGolden : ModItem
{
	public override void SetStaticDefaults()
	{
		DisplayName.SetDefault("Golden Machine Pistol");
		Tooltip.SetDefault("[c/B6FF00:Autoshoots] \n80% chance to not consume ammo \nShoots incredibly fast");
	}

	public override void SetDefaults()
	{
		Item.damage = 66;
		Item.width = 50;
		Item.height = 38;
		Item.useTime = 2;
		Item.useAnimation = 2;
		Item.useStyle = ItemUseStyleID.Shoot;
		Item.noMelee = true;
		Item.knockBack = 0f;
		Item.value = Item.sellPrice(0, 16, 50, 0);
		Item.UseSound = SoundID.Item11;
		Item.autoReuse = true;
		Item.shoot = ProjectileID.PurificationPowder;
		Item.shootSpeed = 18f;
		Item.useAmmo = AmmoID.Bullet;
		Item.rare = 12;
	}

	public override Vector2? HoldoutOffset()
	{
		return new Vector2(-12f, -8f);
	}

    public override bool CanConsumeAmmo(Item ammo, Player player)
	{
		return Utils.NextFloat(Main.rand) >= 0.8f;
	}

    public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
	{
		Vector2 perturbedSpeed = Utils.RotatedByRandom(new Vector2(velocity.X, velocity.Y), (double)MathHelper.ToRadians(5f));
		velocity.X = perturbedSpeed.X;
		velocity.Y = perturbedSpeed.Y;
		return true;
	}

	public override void AddRecipes()
	{
		Recipe val = CreateRecipe();
		val.AddRecipeGroup("FabusMod:Verano", 1);
		val.AddIngredient(ModContent.ItemType<Items.CraftingIngredients.GoddessGold>(), 6);
		val.AddTile(TileID.LunarCraftingStation);
		val.Register();
	}
}
