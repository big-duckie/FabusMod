using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace FabusMod.Items.Weapons.Ranged.FusionDrivers;

public class DynasticFuserGolden : ModItem
{
	public override void SetStaticDefaults()
	{
		DisplayName.SetDefault("Golden Fusion");
		Tooltip.SetDefault("[c/B6FF00:Autoshoots] \n55% chance to not consume ammo");
	}

	public override void SetDefaults()
	{
		Item.damage = 72;
		Item.DamageType = DamageClass.Ranged;
		Item.width = 70;
		Item.height = 32;
		Item.useTime = 4;
		Item.useAnimation = 4;
		Item.useStyle = ItemUseStyleID.Shoot;
		Item.noMelee = true;
		Item.knockBack = 4f;
		Item.value = Item.sellPrice(0, 30, 0, 0);
		Item.rare = ItemRarityID.Yellow;
		Item.UseSound = SoundID.Item11;
		Item.autoReuse = true;
		Item.shoot = ProjectileID.PurificationPowder;
		Item.shootSpeed = 18f;
		Item.useAmmo = AmmoID.Bullet;
	}

	public override Vector2? HoldoutOffset()
	{
		return new Vector2(-2f, 2f);
	}

	public override bool CanConsumeAmmo(Item ammo, Player player)
	{
		return Utils.NextFloat(Main.rand) >= 0.55f;
	}

	public override void AddRecipes()
	{
		CreateRecipe()
			.AddRecipeGroup("FabusMod:ProtectionFuser")
			.AddIngredient(ModContent.ItemType<Items.CraftingIngredients.GoddessGold>(), 8)
			.AddTile(TileID.AdamantiteForge)
			.Register();
	}
}
