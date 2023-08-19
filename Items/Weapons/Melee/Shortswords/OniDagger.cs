using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace FabusMod.Items.Weapons.Melee.Shortswords;

public class OniDagger : ModItem
{
	public override void SetStaticDefaults()
	{
		// DisplayName.SetDefault("Demon's Dagger");
		// Tooltip.SetDefault("[c/B6FF00:Autoswings]\nThrows a vampire knife that deals more damage the closer you are to the target \nInflicts the [c/007700:Poison] debuff for 10 seconds on hit \n[c/FF0000:Steals a small amount of life] \nGrants the [c/FC3A3A:Rage] buff for 8 seconds upon hitting an enemy \nGrants the [c/FC8719:Inferno] buff for 6 seconds upon hitting an enemy");
	}

	public override void SetDefaults()
	{
		Item.damage = 92;
		Item.DamageType = DamageClass.Melee;
		Item.width = 40;
		Item.height = 40;
		Item.useTime = 11;
		Item.useAnimation = 11;
		Item.useStyle = ItemUseStyleID.Thrust;
		Item.knockBack = 6f;
		Item.value = Item.sellPrice(0, 18, 54, 0);
		Item.rare = ItemRarityID.Pink;
		Item.shoot = ProjectileID.VampireKnife;
		Item.shootSpeed = 16f;
		Item.UseSound = SoundID.Item1;
		Item.autoReuse = true;
	}

	public override void MeleeEffects(Player player, Rectangle hitbox)
	{
		if (Main.rand.NextBool(3))
		{
			int dust = Dust.NewDust(new Vector2(hitbox.X, hitbox.Y), hitbox.Width, hitbox.Height, ModContent.DustType<Dusts.RyuuDust3>());
			Main.dust[dust].scale = 1f;
			Main.dust[dust].velocity.Y = 0f;
			Main.dust[dust].velocity.X = 0.5f;
			Main.dust[dust].noGravity = true;
		}
	}

	public override void OnHitNPC(Player player, NPC target, NPC.HitInfo hit, int damageDone)
	{
		int healingAmount = damageDone / 18;
		player.statLife += healingAmount;
		player.HealEffect(healingAmount, true);
		target.AddBuff(20, 600, false);
		player.AddBuff(115, 480, true);
		player.AddBuff(116, 360, true);
	}

    public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
    {
		Vector2 muzzleOffset = Vector2.Normalize(velocity) * 55f;
		if (Collision.CanHit(position, 0, 0, position + muzzleOffset, 0, 0))
		{
			position += muzzleOffset;
		}
		return true;
	}

	public override void AddRecipes()
	{
		CreateRecipe()
			.AddRecipeGroup("FabusMod:CarbonDagger")
			.AddRecipeGroup("FabusMod:AdamantiteBar", 6)
			.AddIngredient(ItemID.SoulofNight, 4)
			.AddIngredient(ModContent.ItemType<Items.CraftingIngredients.SoulofWisdom>(), 2)
			.AddTile(TileID.MythrilAnvil)
			.Register();
	}
}
