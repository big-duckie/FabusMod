using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace FabusMod.Items.Weapons.Ranged.FusionDrivers;

public class ProtectionFuserCarbonFiber : ModItem
{
	public override void SetStaticDefaults()
	{
		DisplayName.SetDefault("Protective Fusion - Carbon Fiber");
		Tooltip.SetDefault("[c/B6FF00:Autoshoots] \n42% chance to not consume ammo");
	}

	public override void SetDefaults()
	{
		Item.damage = 36;
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
		Recipe val = CreateRecipe();
		val.AddIngredient(ModContent.ItemType<ProtectionFuser>());
		val.AddIngredient(ItemID.BlackDye, 1);
		val.AddTile(TileID.DyeVat);
		val.Register();
	}
}
