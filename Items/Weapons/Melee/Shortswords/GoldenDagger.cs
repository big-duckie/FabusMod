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
		Item.DamageType = DamageClass.Melee;
		Item.width = 40;
		Item.height = 40;
		Item.useTime = 12;
		Item.useAnimation = 12;
		Item.useStyle = ItemUseStyleID.Thrust;
		Item.knockBack = 6f;
		Item.value = Item.sellPrice(0, 54, 96, 0);
		Item.rare = ItemRarityID.Yellow;
		Item.shoot = ModContent.ProjectileType<Projectiles.Shortsword.GoldenKnife>();
		Item.shootSpeed = 50f;
		Item.UseSound = SoundID.Item1;
		Item.autoReuse = true;
	}

	public override void MeleeEffects(Player player, Rectangle hitbox)
	{
		if (Main.rand.NextBool(3))
		{
			int dust = Dust.NewDust(new Vector2(hitbox.X, hitbox.Y), hitbox.Width, hitbox.Height, ModContent.DustType<Dusts.MeatDust>());
			Main.dust[dust].scale = 1f;
			Main.dust[dust].velocity.Y = 0f;
			Main.dust[dust].velocity.X = 0.5f;
			Main.dust[dust].noGravity = true;
		}
	}

    public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
    {
		float numberProjectiles = 2f;
		float rotation = MathHelper.ToRadians(4f);
		position += Vector2.Normalize(velocity) * 6f;
		for (int i = 0; i < numberProjectiles; i++)
		{
			Vector2 perturbedSpeed = Utils.RotatedBy(velocity, (double)MathHelper.Lerp(0f - rotation, rotation, i / (numberProjectiles - 1f)), default) * 0.2f;
			Projectile.NewProjectile(source, position, perturbedSpeed, type, damage, knockback, player.whoAmI);
			Vector2 muzzleOffset = Vector2.Normalize(velocity) * 55f;
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
		CreateRecipe()
			.AddIngredient(ModContent.ItemType<OniDagger>())
			.AddIngredient(ModContent.ItemType<Items.CraftingIngredients.GoddessGold>(), 6)
			.AddIngredient(ModContent.ItemType<Items.CraftingIngredients.SoulofWisdom>(), 4)
			.AddTile(TileID.AdamantiteForge)
			.Register();
	}
}
