using FabusMod.Projectiles.Shortsword;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace FabusMod.Items.Weapons.Melee.Shortswords;

public class GoldenDagger : ModItem
{
	public override void SetStaticDefaults()
	{
		DisplayName.SetDefault("Golden Dagger");
		Tooltip.SetDefault("[c/B6FF00:Autoswings]\nThrows two short-ranged golden knives in any direction, as well as one very fast dagger \nShortsword hits steal a small amount of life, and inflict the [c/007700:Poison] debuff for 10 seconds \nGolden knives do not steal life  \nGrants the [c/FC3A3A:Rage] buff for 8 seconds upon hitting an enemy with the Shortsword \nGrants the [c/FC8719:Inferno] buff for 6 seconds upon hitting an enemy with the Shortsword");
	}

	public override void SetDefaults()
	{
		Item.damage = 95;
		Item.width = 40;
		Item.height = 40;
		Item.useTime = 12;
		Item.useAnimation = 12;
		Item.useStyle = ItemUseStyleID.Thrust;
		Item.knockBack = 6f;
		Item.value = Item.sellPrice(0, 54, 96, 0);
		Item.rare = ItemRarityID.Yellow;
		Item.shoot = ModContent.ProjectileType<GoldenKnife>();
		Item.shootSpeed = 50f;
		Item.UseSound = SoundID.Item1;
		Item.autoReuse = true;
	}

	public override void MeleeEffects(Player player, Rectangle hitbox)
	{
		if (Main.rand.NextBool(3))
		{
			int num1 = Dust.NewDust(new Vector2(hitbox.X, hitbox.Y), hitbox.Width, hitbox.Height, ModContent.DustType<Dusts.MeatDust>(), 0f, 0f, 0, default, 1f);
			Main.dust[num1].scale = 1f;
			Main.dust[num1].velocity.Y = 0f;
			Main.dust[num1].velocity.X = 0.5f;
			Main.dust[num1].noGravity = true;
		}
	}

    public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
    {
		float numberProjectiles = 2f;
		float rotation = MathHelper.ToRadians(4f);
		position += Vector2.Normalize(new Vector2(velocity.X, velocity.Y)) * 6f;
		for (int i = 0; i < numberProjectiles; i++)
		{
			Vector2 perturbedSpeed = Utils.RotatedBy(new Vector2(velocity.X, velocity.Y), (double)MathHelper.Lerp(0f - rotation, rotation, i / (numberProjectiles - 1f)), default) * 0.2f;
			Projectile.NewProjectile(source, position.X, position.Y, perturbedSpeed.X, perturbedSpeed.Y, type, damage, knockback, player.whoAmI, 0f, 0f);
			Vector2 muzzleOffset = Vector2.Normalize(new Vector2(velocity.X, velocity.Y)) * 55f;
			if (Collision.CanHit(position, 0, 0, position + muzzleOffset, 0, 0))
			{
				position += muzzleOffset;
			}
		}
		return true;
	}

	public override void OnHitNPC(Player player, NPC target, int damage, float knockback, bool crit)
	{
		int healingAmount = damage / 17;
		player.statLife += healingAmount;
		player.HealEffect(healingAmount, true);
        target.AddBuff(20, 600, false);
		player.AddBuff(115, 480, true);
		player.AddBuff(116, 360, true);
	}

	public override void AddRecipes()
	{
		Recipe val = CreateRecipe();
		val.AddIngredient(ModContent.ItemType<OniDagger>());
		val.AddIngredient(ModContent.ItemType<Items.CraftingIngredients.GoddessGold>(), 6);
		val.AddIngredient(ModContent.ItemType<Items.CraftingIngredients.SoulofWisdom>(), 4);
		val.AddTile(TileID.AdamantiteForge);
		val.Register();
	}
}
