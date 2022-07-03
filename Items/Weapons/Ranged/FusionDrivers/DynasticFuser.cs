using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace FabusMod.Items.Weapons.Ranged.FusionDrivers;

public class DynasticFuser : ModItem
{
	public override void SetStaticDefaults()
	{
		DisplayName.SetDefault("Dynastic Fusion");
		Tooltip.SetDefault("[c/B6FF00:Autoshoots] \n30% chance to not consume ammo");
	}

	public override void SetDefaults()
	{
		Item.damage = 14;
		Item.width = 72;
		Item.height = 32;
		Item.useTime = 7;
		Item.useAnimation = 7;
		Item.useStyle = ItemUseStyleID.Shoot;
		Item.noMelee = true;
		Item.knockBack = 4f;
		Item.value = Item.sellPrice(0, 6, 66, 0);
		Item.rare = ItemRarityID.Orange;
		Item.UseSound = SoundID.Item11;
		Item.autoReuse = true;
		Item.shoot = ProjectileID.PurificationPowder;
		Item.shootSpeed = 30f;
		Item.useAmmo = AmmoID.Bullet;
	}

	public override Vector2? HoldoutOffset()
	{
		return new Vector2(-2f, 2f);
	}

    public override bool CanConsumeAmmo(Item ammo, Player player)
	{
		return Utils.NextFloat(Main.rand) >= 0.3f;
	}

	public override void AddRecipes()
	{
		Recipe val = CreateRecipe();
		val.AddIngredient(ModContent.ItemType<FusionDriver>());
		val.AddIngredient(ItemID.HellstoneBar, 12);
		val.AddIngredient(ItemID.Sapphire, 8);
		val.AddTile(TileID.Anvils);
		val.Register();
	}
}
