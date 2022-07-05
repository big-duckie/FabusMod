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
		Item.DamageType = DamageClass.Melee;
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
			int dust = Dust.NewDust(new Vector2(hitbox.X, hitbox.Y), hitbox.Width, hitbox.Height, ModContent.DustType<Dusts.RyuuDust>());
			Main.dust[dust].scale = 1f;
			Main.dust[dust].velocity.Y = 0f;
			Main.dust[dust].velocity.X = 0.5f;
			Main.dust[dust].noGravity = true;
		}
	}

	public override void OnHitNPC(Player player, NPC target, int damage, float knockback, bool crit)
	{
		target.AddBuff(20, 300, false);
	}

	public override void AddRecipes()
	{
		Recipe recipe = CreateRecipe();
		recipe.AddIngredient(ModContent.ItemType<StonePlatedShortsword>());
		recipe.AddRecipeGroup("IronBar", 6);
		recipe.AddIngredient(ItemID.Emerald, 2);
		recipe.AddTile(TileID.Anvils);
		recipe.Register();
	}
}
