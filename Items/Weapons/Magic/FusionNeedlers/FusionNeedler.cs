using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace FabusMod.Items.Weapons.Magic.FusionNeedlers;

public class FusionNeedler : ModItem
{
	public override void SetStaticDefaults()
	{
		DisplayName.SetDefault("Fusion Needler");
		Tooltip.SetDefault("[c/B6FF00:Autoshoots]\n[c/FF0000:Watch your mana!]");
	}

	public override void SetDefaults()
	{
		Item.damage = 120;
		Item.DamageType = DamageClass.Magic;
		Item.mana = 3;
		Item.width = 76;
		Item.height = 44;
		Item.useTime = 6;
		Item.useAnimation = 6;
		Item.useStyle = ItemUseStyleID.Shoot;
		Item.noMelee = true;
		Item.knockBack = 2f;
		Item.value = Item.sellPrice(0, 6, 0, 0);
		Item.rare = ItemRarityID.Yellow;
		Item.UseSound = SoundID.Item39;
		Item.autoReuse = true;
		Item.shoot = ProjectileID.PineNeedleFriendly;
		Item.shootSpeed = 26f;
	}

	public override Vector2? HoldoutOffset()
	{
		return new Vector2(-2f, 2f);
	}

	public override void AddRecipes()
	{
		Recipe recipe = CreateRecipe();
		recipe.AddIngredient(ModContent.ItemType<Ranged.FusionDrivers.FusionDriver>());
		recipe.AddIngredient(ItemID.Razorpine);
		recipe.AddTile(TileID.AdamantiteForge);
		recipe.Register();
	}
}
