using FabusMod.Projectiles;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace FabusMod.Items.Weapons.Ranged.PulsePistols;

public class GoldenPulse : ModItem
{
	public override void SetStaticDefaults()
	{
		DisplayName.SetDefault("Golden Pulse");
		Tooltip.SetDefault("[c/B6FF00:Autoshoots] \n90% chance to not consume ammo \nShoots incredibly fast \nConverts Musket Balls into golden Pulse Bullets");
	}

	public override void SetDefaults()
	{
		Item.damage = 66;
		Item.width = 40;
		Item.height = 28;
		Item.useTime = 2;
		Item.useAnimation = 2;
		Item.useStyle = ItemUseStyleID.Shoot;
		Item.noMelee = true;
		Item.knockBack = 0f;
		Item.value = Item.sellPrice(0, 15, 70, 0);
		Item.UseSound = SoundID.Item11;
		Item.autoReuse = true;
		Item.shoot = ProjectileID.VilethornTip;
		Item.shootSpeed = 25f;
		Item.useAmmo = AmmoID.Bullet;
		Item.rare = 12;
	}

    public override bool CanConsumeAmmo(Item ammo, Player player)
	{
		return Utils.NextFloat(Main.rand) >= 0.9f;
	}

	public override Vector2? HoldoutOffset()
	{
		return new Vector2(1f, -2f);
	}

    public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
	{
		Vector2 perturbedSpeed = Utils.RotatedByRandom(new Vector2(velocity.X, velocity.Y), (double)MathHelper.ToRadians(8f));
		velocity.X = perturbedSpeed.X;
		velocity.Y = perturbedSpeed.Y;
		if (type == 14)
		{
			type = ModContent.ProjectileType<PulseBulletGolden>();
		}
		return true;
	}

	public override void AddRecipes()
	{
		Recipe val = CreateRecipe();
		val.AddRecipeGroup("FabusMod:PulseSprayer", 1);
		val.AddIngredient(ModContent.ItemType<Items.CraftingIngredients.GoddessGold>(), 2);
		val.AddTile(TileID.LunarCraftingStation);
		val.Register();
	}
}
