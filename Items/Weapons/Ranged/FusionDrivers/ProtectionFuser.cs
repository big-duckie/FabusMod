using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace FabusMod.Items.Weapons.Ranged.FusionDrivers;

public class ProtectionFuser : ModItem
{
	public override void SetStaticDefaults()
	{
		// DisplayName.SetDefault("Protective Fusion");
		// Tooltip.SetDefault("[c/B6FF00:Autoshoots, dyeable] \n42% chance to not consume ammo");
	}

	public override void SetDefaults()
	{
		Item.damage = 36;
		Item.DamageType = DamageClass.Ranged;
		Item.width = 72;
		Item.height = 32;
		Item.useTime = 5;
		Item.useAnimation = 5;
		Item.useStyle = ItemUseStyleID.Shoot;
		Item.noMelee = true;
		Item.knockBack = 4f;
		Item.value = Item.sellPrice(0, 15, 66, 0);
		Item.rare = ItemRarityID.LightRed;
		Item.UseSound = SoundID.Item11;
		Item.autoReuse = true;
		Item.shoot = ProjectileID.PurificationPowder;
		Item.shootSpeed = 20f;
		Item.useAmmo = AmmoID.Bullet;
	}

	public override Vector2? HoldoutOffset()
	{
		return new Vector2(-2f, 2f);
	}

	public override bool CanConsumeAmmo(Item ammo, Player player)
	{
		return Utils.NextFloat(Main.rand) >= 0.42f;
	}

	public override void AddRecipes()
	{
		CreateRecipe()
			.AddIngredient(ModContent.ItemType<DynasticFuser>())
			.AddRecipeGroup("FabusMod:AdamantiteBar", 12)
			.AddTile(TileID.MythrilAnvil)
			.Register();

		CreateRecipe()
			.AddIngredient(ModContent.ItemType<ProtectionFuserCarbonFiber>())
			.AddIngredient(ItemID.SilverDye)
			.AddTile(TileID.DyeVat)
			.Register();
	}
}
