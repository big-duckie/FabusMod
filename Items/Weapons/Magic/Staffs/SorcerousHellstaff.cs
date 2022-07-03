using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace FabusMod.Items.Weapons.Magic.Staffs;

public class SorcerousHellstaff : ModItem
{
	public override void SetStaticDefaults()
	{
		DisplayName.SetDefault("Sorcerer's Hellstaff");
		Tooltip.SetDefault("[c/B6FF00:Autoshoots, dyeable] \nShoots two oval-shaped magic projectiles in quick succession \nHas a 16% chance of inflicting the [c/DA0205:On Fire!] debuff for 3 seconds \nHas a high critical hit chance");
		Item.staff[Item.type] = true;
	}

	public override void SetDefaults()
	{
		Item.damage = 26;
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
		Recipe val = CreateRecipe();
		val.AddIngredient(ModContent.ItemType<SorcerousStaff>());
		val.AddIngredient(ItemID.HellstoneBar, 6);
		val.AddIngredient(ItemID.Obsidian, 4);
		val.AddTile(TileID.Anvils);
		val.Register();

		Recipe val2 = CreateRecipe();
		val2.AddIngredient(ModContent.ItemType<SorcerousHellstaffWhite>());
		val2.AddIngredient(ItemID.BlueDye);
		val2.AddIngredient(ItemID.RedDye);
		val2.AddTile(TileID.DyeVat);
		val2.Register();
	}
}
