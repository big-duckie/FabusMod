using FabusMod.Projectiles.Shortsword;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace FabusMod.Items.Weapons.Melee.Shortswords;

public class CarbonDaggerNihon : ModItem
{
	public override void SetStaticDefaults()
	{
		DisplayName.SetDefault("Carbon Dagger - Nihon");
		Tooltip.SetDefault("[c/B6FF00:Autoswings]\nThrows a medium-ranged Carbon Knife that deals more damage the closer you are to the target \nShortsword hits inflict [c/007700:Poison] debuff for 8 seconds\n[c/FF0000:Shortsword hits steal a small amount of life] \nShortsword hits grant the [c/FC3A3A:Rage] buff for 8 seconds");
	}

	public override void SetDefaults()
	{
		Item.damage = 62;
		Item.width = 30;
		Item.height = 30;
		Item.useTime = 11;
		Item.useAnimation = 11;
		Item.useStyle = ItemUseStyleID.Thrust;
		Item.knockBack = 6f;
		Item.value = Item.sellPrice(0, 5, 22, 0);
		Item.rare = ItemRarityID.LightRed;
		Item.UseSound = SoundID.Item1;
		Item.autoReuse = true;
		Item.shoot = ModContent.ProjectileType<CarbonKnifeNihon>();
		Item.shootSpeed = 10f;
	}

	public override void MeleeEffects(Player player, Rectangle hitbox)
	{
		if (Main.rand.NextBool(3))
		{
			int num1 = Dust.NewDust(new Vector2(hitbox.X, hitbox.Y), hitbox.Width, hitbox.Height, ModContent.DustType<Dusts.OniDust>());
			Main.dust[num1].scale = 1f;
			Main.dust[num1].velocity.Y = 0f;
			Main.dust[num1].velocity.X = 0.5f;
			Main.dust[num1].noGravity = true;
		}
	}

	public override void OnHitNPC(Player player, NPC target, int damage, float knockback, bool crit)
	{
		int healingAmount = damage / 16;
		player.statLife += healingAmount;
		player.HealEffect(healingAmount, true);
		target.AddBuff(20, 480, false);
		player.AddBuff(115, 480, true);
	}

    public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
    {
		Vector2 muzzleOffset = Vector2.Normalize(new Vector2(velocity.X, velocity.Y)) * 45f;
		if (Collision.CanHit(position, 0, 0, position + muzzleOffset, 0, 0)) {
			position += muzzleOffset;
        }
		return true;
    }

	public override void AddRecipes()
	{
		Recipe recipe = Recipe.Create(Type);
		recipe.AddIngredient(ModContent.ItemType<CarbonDagger>());
		recipe.AddIngredient(ItemID.BlueDye, 1);
		recipe.AddTile(TileID.DyeVat);
		recipe.Register();
	}
}
