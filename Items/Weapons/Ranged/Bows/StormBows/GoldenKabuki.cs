using FabusMod.Projectiles.Arrows;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace FabusMod.Items.Weapons.Ranged.Bows.StormBows;

public class GoldenKabuki : ModItem
{
	public override void SetStaticDefaults()
	{
		// DisplayName.SetDefault("Golden Kabuki");
		// Tooltip.SetDefault("[c/B6FF00:Autoshoots] \nDoesn't use ammo \nAlways shoots Holy Arrows (except with <right>) \nPressing <right> fires 16 spiritual, golden arrows in quick succession, but it has lower damage and a 1 second cooldown");
	}

	public override void SetDefaults()
	{
		Item.damage = 58;
		Item.DamageType = DamageClass.Ranged;
		Item.width = 18;
		Item.height = 38;
		Item.useTime = 12;
		Item.useAnimation = 12;
		Item.useStyle = ItemUseStyleID.Shoot;
		Item.noMelee = true;
		Item.knockBack = 3f;
		Item.value = Item.sellPrice(0, 22, 0, 0);
		Item.UseSound = SoundID.Item5;
		Item.autoReuse = true;
		Item.shootSpeed = 18f;
		Item.rare = ItemRarityID.Expert;
	}

	public override bool AltFunctionUse(Player player)
	{
		return true;
	}

	public override bool CanUseItem(Player player)
	{
		if (player.altFunctionUse == 2)
		{
			Item.useStyle = ItemUseStyleID.Shoot;
			Item.useTime = 2;
			Item.useAnimation = 32;
			Item.damage = 54;
			Item.reuseDelay = 30;
			Item.shoot = ModContent.ProjectileType<GoldenSpiritArrow>();
		}
		else
		{
			Item.reuseDelay = 0;
			Item.useStyle = ItemUseStyleID.Shoot;
			Item.useTime = 12;
			Item.useAnimation = 12;
			Item.damage = 58;
			Item.shoot = ProjectileID.HolyArrow;
		}
		return base.CanUseItem(player);
	}

	public override void AddRecipes()
	{
		CreateRecipe()
			.AddIngredient(ModContent.ItemType<Kabuki>())
			.AddIngredient(ModContent.ItemType<Items.CraftingIngredients.GoddessGold>(), 6)
			.AddTile(TileID.MythrilAnvil)
			.Register();
	}
}
