using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace FabusMod.Items.Weapons.Melee.Shortswords;

public class Wakizashi : ModItem
{
	public override void SetStaticDefaults()
	{
		DisplayName.SetDefault("Wakizashi");
		Tooltip.SetDefault("Inflicts [c/007700:Poison] debuff for 5 seconds on hit");
	}

	public override void SetDefaults()
	{
		Item.damage = 15;
		Item.width = 30;
		Item.height = 30;
		Item.useTime = 13;
		Item.useAnimation = 13;
		Item.useStyle = ItemUseStyleID.Thrust;
		Item.knockBack = 5f;
		Item.value = Item.sellPrice(0, 0, 50, 0);
		Item.rare = ItemRarityID.Blue;
		Item.UseSound = SoundID.Item1;
		Item.autoReuse = false;
	}

	public override void MeleeEffects(Player player, Rectangle hitbox)
	{
		if (Main.rand.NextBool(3))
		{
			int num1 = Dust.NewDust(new Vector2(hitbox.X, hitbox.Y), hitbox.Width, hitbox.Height, ModContent.DustType<Dusts.RyuuDust>());
			Main.dust[num1].scale = 1f;
			Main.dust[num1].velocity.Y = 0f;
			Main.dust[num1].velocity.X = 0.5f;
			Main.dust[num1].noGravity = true;
		}
	}

	public override void OnHitNPC(Player player, NPC target, int damage, float knockback, bool crit)
	{
		target.AddBuff(20, 300, false);
	}

	public override void AddRecipes()
	{
		Recipe val = CreateRecipe();
		val.AddIngredient(ModContent.ItemType<StonePlatedShortsword>());
		val.AddRecipeGroup("IronBar", 6);
		val.AddIngredient(ItemID.Emerald, 2);
		val.AddTile(TileID.Anvils);
		val.Register();
	}
}
