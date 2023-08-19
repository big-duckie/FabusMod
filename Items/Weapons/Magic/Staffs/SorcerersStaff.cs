using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace FabusMod.Items.Weapons.Magic.Staffs;

public class SorcerersStaff : ModItem
{
	public override void SetStaticDefaults()
	{
		// DisplayName.SetDefault("Sorcerer's Staff");
		// Tooltip.SetDefault("[c/B6FF00:Autoshoots] \nShoots two oval-shaped magic projectiles in quick succession \nHas a high critical hit chance");
		Item.staff[Item.type] = true;
	}

	public override void SetDefaults()
	{
		Item.damage = 13;
		Item.DamageType = DamageClass.Magic;
		Item.noMelee = true;
		Item.mana = 6;
		Item.crit = 26;
		Item.width = 54;
		Item.height = 54;
		Item.useTime = 13;
		Item.useAnimation = 26;
		Item.reuseDelay = 12;
		Item.useStyle = ItemUseStyleID.Shoot;
		Item.noMelee = true;
		Item.knockBack = 5f;
		Item.value = Item.sellPrice(0, 3, 0, 0);
		Item.rare = ItemRarityID.Green;
		Item.UseSound = SoundID.Item20;
		Item.autoReuse = true;
		Item.shoot = ModContent.ProjectileType<Projectiles.SorcerousStaff.SorcerousStaffProj>();
		Item.shootSpeed = 26f;
	}

	public override void AddRecipes()
	{
		CreateRecipe()
			.AddRecipeGroup("FabusMod:GoldBar", 8)
			.AddIngredient(ItemID.Sapphire, 6)
			.AddIngredient(ItemID.Emerald, 4)
			.AddTile(TileID.Anvils)
			.Register();
	}
}
