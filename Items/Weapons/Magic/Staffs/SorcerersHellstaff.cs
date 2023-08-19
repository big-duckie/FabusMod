using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace FabusMod.Items.Weapons.Magic.Staffs;

public class SorcerersHellstaff : ModItem
{
	public override void SetStaticDefaults()
	{
		// DisplayName.SetDefault("Sorcerer's Hellstaff");
		// Tooltip.SetDefault("[c/B6FF00:Autoshoots, dyeable] \nShoots two oval-shaped magic projectiles in quick succession \nHas a 16% chance of inflicting the [c/DA0205:On Fire!] debuff for 3 seconds \nHas a high critical hit chance");
		Item.staff[Item.type] = true;
	}

	public override void SetDefaults()
	{
		Item.damage = 26;
		Item.DamageType = DamageClass.Magic;
		Item.noMelee = true;
		Item.mana = 6;
		Item.crit = 32;
		Item.width = 54;
		Item.height = 54;
		Item.useTime = 12;
		Item.useAnimation = 24;
		Item.reuseDelay = 12;
		Item.useStyle = ItemUseStyleID.Shoot;
		Item.noMelee = true;
		Item.knockBack = 5f;
		Item.value = Item.sellPrice(0, 4, 40, 0);
		Item.rare = ItemRarityID.Orange;
		Item.UseSound = SoundID.Item20;
		Item.autoReuse = true;
		Item.shoot = ModContent.ProjectileType<Projectiles.SorcerousStaff.SorcerousHellstaffProj>();
		Item.shootSpeed = 26f;
	}

	public override void AddRecipes()
	{
		CreateRecipe()
			.AddIngredient(ModContent.ItemType<SorcerersStaff>())
			.AddIngredient(ItemID.HellstoneBar, 6)
			.AddIngredient(ItemID.Obsidian, 4)
			.AddTile(TileID.Anvils)
			.Register();

		CreateRecipe()
			.AddIngredient(ModContent.ItemType<SorcerersHellstaffWhite>())
			.AddIngredient(ItemID.BlueDye)
			.AddIngredient(ItemID.RedDye)
			.AddTile(TileID.DyeVat)
			.Register();
	}
}
