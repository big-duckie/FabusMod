using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace FabusMod.Items.Weapons.Melee.Swords.ShimadaSwords;

public class ShimadaSword : ModItem
{
	public override void SetStaticDefaults()
	{
		Tooltip.SetDefault("Inflicts [c/7B2D2F:Blood Loss] for 3 seconds on hit, dealing damage over time");
	}

	public override void SetDefaults()
	{
		Item.damage = 18;
		Item.DamageType = DamageClass.Melee;
		Item.crit = 8;
		Item.width = 54;
		Item.height = 68;
		Item.useTime = 22;
		Item.useAnimation = 22;
		Item.useStyle = ItemUseStyleID.Swing;
		Item.knockBack = 2f;
		Item.value = Item.sellPrice(0, 1, 80, 0);
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
		target.AddBuff(ModContent.BuffType<Buffs.ShimadaSword.BloodLoss>(), 180, false);
	}

	public override void AddRecipes()
	{
		CreateRecipe()
			.AddIngredient(ModContent.ItemType<StonePlatedKatana>())
			.AddRecipeGroup("FabusMod:LightsBane")
			.AddIngredient(ItemID.Emerald, 10)
			.AddTile(TileID.Anvils)
			.Register();
	}
}
