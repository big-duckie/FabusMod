using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace FabusMod.Items.Weapons.Magic.Staffs;

public class PiercingStaff : ModItem
{
	public override void SetStaticDefaults()
	{
		DisplayName.SetDefault("Piercing Staff");
		Tooltip.SetDefault("Fires gravity-affected, piercing iron stingers");
		Item.staff[Item.type] = true;
	}

	public override void SetDefaults()
	{
		Item.damage = 16;
		Item.DamageType = DamageClass.Magic;
		Item.noMelee = true;
		Item.mana = 3;
		Item.width = 40;
		Item.height = 40;
		Item.useTime = 25;
		Item.useAnimation = 25;
		Item.useStyle = ItemUseStyleID.Shoot;
		Item.noMelee = true;
		Item.knockBack = 2f;
		Item.value = Item.sellPrice(0, 0, 16, 0);
		Item.rare = ItemRarityID.White;
		Item.UseSound = SoundID.Item20;
		Item.autoReuse = true;
		Item.shoot = ModContent.ProjectileType<Projectiles.IronStinger>();
		Item.shootSpeed = 10f;
	}

	public override void AddRecipes()
	{
		Recipe recipe = CreateRecipe();
		recipe.AddIngredient(ItemID.WandofSparking, 1);
		recipe.AddRecipeGroup("IronBar", 3);
		recipe.AddTile(TileID.Anvils);
		recipe.Register();
	}
}
