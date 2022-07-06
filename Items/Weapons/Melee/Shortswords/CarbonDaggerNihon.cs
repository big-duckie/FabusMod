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
		Item.DamageType = DamageClass.Melee;
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
		Item.shoot = ModContent.ProjectileType<Projectiles.Shortsword.CarbonKnifeNihon>();
		Item.shootSpeed = 10f;
	}

	public override void MeleeEffects(Player player, Rectangle hitbox)
	{
		if (Main.rand.NextBool(3))
		{
			int dust = Dust.NewDust(new Vector2(hitbox.X, hitbox.Y), hitbox.Width, hitbox.Height, ModContent.DustType<Dusts.OniDust>());
			Main.dust[dust].scale = 1f;
			Main.dust[dust].velocity.Y = 0f;
			Main.dust[dust].velocity.X = 0.5f;
			Main.dust[dust].noGravity = true;
		}
	}

	public override void OnHitNPC(Player player, NPC target, int damage, float knockback, bool crit)
	{
		int healingAmount = damage / 16;
		player.statLife += healingAmount;
		player.HealEffect(healingAmount, true);
		target.AddBuff(BuffID.Poisoned, 480, false);
		player.AddBuff(BuffID.Rage, 480, true);
	}

    public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
    {
		Vector2 muzzleOffset = Vector2.Normalize(velocity) * 45f;
		if (Collision.CanHit(position, 0, 0, position + muzzleOffset, 0, 0)) {
			position += muzzleOffset;
        }
		return true;
    }

	public override void AddRecipes()
	{
		CreateRecipe()
			.AddIngredient(ModContent.ItemType<CarbonDagger>())
			.AddIngredient(ItemID.BlueDye)
			.AddTile(TileID.DyeVat)
			.Register();
	}
}
