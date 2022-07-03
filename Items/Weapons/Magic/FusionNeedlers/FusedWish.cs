using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace FabusMod.Items.Weapons.Magic.FusionNeedlers;

public class FusedWish : ModItem
{
	public override void SetStaticDefaults()
	{
		DisplayName.SetDefault("Fused Wish");
		Tooltip.SetDefault("[c/B6FF00:Autoshoots] \nShoots homing rainbow needles\n[c/FF0000:Watch your mana!]");
	}

	public override void SetDefaults()
	{
		Item.damage = 160;
		Item.mana = 3;
		Item.width = 80;
		Item.height = 54;
		Item.useTime = 3;
		Item.useAnimation = 4;
		Item.useStyle = ItemUseStyleID.Shoot;
		Item.noMelee = true;
		Item.knockBack = 2f;
		Item.value = Item.sellPrice(2, 60, 0, 0);
		Item.UseSound = SoundID.Item39;
		Item.autoReuse = true;
		Item.shoot = ModContent.ProjectileType<Projectiles.WishNeedle>();
		Item.shootSpeed = 16f;
		Item.expert = true;
	}

	public override Vector2? HoldoutOffset()
	{
		return new Vector2(-2f, 2f);
	}

	public override void AddRecipes()
	{
		Recipe val = CreateRecipe();
		val.AddIngredient(ModContent.ItemType<FusedXmas>());
		val.AddIngredient(ModContent.ItemType<Bars.RainbowChunk>(), 12);
		val.AddTile(ModContent.TileType<global::FabusMod.Tiles.RainbowStation>());
		val.Register();
	}
}
