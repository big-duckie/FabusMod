using Terraria;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.ID;

namespace FabusMod;

public class FabusMod : Mod
{
	public override void AddRecipeGroups()
	{
		RecipeGroup group = new(() => Language.GetTextValue("LegacyMisc.37") + " Fox Ears", new int[3] {
            Find<ModItem>("FoxEars").Type,
            Find<ModItem>("PinkFoxEars").Type,
            Find<ModItem>("BlueFoxEars").Type
		});
		RecipeGroup.RegisterGroup("FabusMod:FoxEars", group);

		RecipeGroup group2 = new(() => Language.GetTextValue("LegacyMisc.37") + " Punk's Pulse", new int[2] {
			Find<ModItem>("PunksPulse").Type,
			Find<ModItem>("PunksPulseUltraviolet").Type
		});
		RecipeGroup.RegisterGroup("FabusMod:PunksPulse", group2);

		RecipeGroup group3 = new(() => Language.GetTextValue("LegacyMisc.37") + " Pulse Sprayer", new int[2] {
			Find<ModItem>("PulseSprayer").Type,
			Find<ModItem>("PulseSprayerCadet").Type
		});
		RecipeGroup.RegisterGroup("FabusMod:PulseSprayer", group3);

		RecipeGroup group4 = new(() => Language.GetTextValue("LegacyMisc.37") + " Rainbow Demon", new int[6] {
			Find<ModItem>("TheRainbowDemon").Type,
			Find<ModItem>("TheRainbowDemonClaymore").Type,
			Find<ModItem>("TheRainbowDemonRanged").Type,
			Find<ModItem>("TheRainbowDemonThrowing").Type,
			Find<ModItem>("TheRainbowDemonMagic").Type,
			Find<ModItem>("TheRainbowDemonShredder").Type
		});
		RecipeGroup.RegisterGroup("FabusMod:TheRainbowDemon", group4);

		RecipeGroup group5 = new(() => Language.GetTextValue("LegacyMisc.37") + " The Stinger", new int[2] {
			Find<ModItem>("TheStinger").Type,
			Find<ModItem>("TheStingerBlackCat").Type
		});
		RecipeGroup.RegisterGroup("FabusMod:TheStinger", group5);

		RecipeGroup group6 = new(() => Language.GetTextValue("LegacyMisc.37") + " Shivering Shotgun", new int[2] {
			Find<ModItem>("HellshiverGun").Type,
			Find<ModItem>("HellshiverGunHellfire").Type
		});
		RecipeGroup.RegisterGroup("FabusMod:HellshiverGun", group6);

		RecipeGroup group7 = new(() => Language.GetTextValue("LegacyMisc.37") + " Hellraiser", new int[2] {
			Find<ModItem>("HellkinShotgun").Type,
			Find<ModItem>("HellkinShotgunDracula").Type
		});
		RecipeGroup.RegisterGroup("FabusMod:HellkinShotgun", group7);

		RecipeGroup group8 = new(() => Language.GetTextValue("LegacyMisc.37") + " Carbon Shuriken", new int[2] {
			Find<ModItem>("CarbonShuriken").Type,
			Find<ModItem>("CarbonShurikenNihon").Type
		});
		RecipeGroup.RegisterGroup("FabusMod:CarbonShuriken", group8);

		RecipeGroup group9 = new(() => Language.GetTextValue("LegacyMisc.37") + " Solitude", new int[2] {
			Find<ModItem>("Peacegunner").Type,
			Find<ModItem>("PeacegunnerAmerican").Type
		});
		RecipeGroup.RegisterGroup("FabusMod:Peacegunner", group9);

		RecipeGroup group10 = new(() => Language.GetTextValue("LegacyMisc.37") + " Silencer", new int[2] {
			Find<ModItem>("Peaceforcer").Type,
			Find<ModItem>("PeaceforcerVanHelsing").Type
		});
		RecipeGroup.RegisterGroup("FabusMod:Peaceforcer", group10);

        RecipeGroup group11 = new(() => Language.GetTextValue("LegacyMisc.37") + " Carbon Sword", new int[2] {
			Find<ModItem>("CarbonSword").Type,
			Find<ModItem>("CarbonSwordNihon").Type
		});
		RecipeGroup.RegisterGroup("FabusMod:CarbonSword", group11);

		RecipeGroup group12 = new(() => Language.GetTextValue("LegacyMisc.37") + " Light's Bane", new int[2] { 46, 795 });
		RecipeGroup.RegisterGroup("FabusMod:LightsBane", group12);

		RecipeGroup group13 = new(() => Language.GetTextValue("LegacyMisc.37") + " Carbon Dagger", new int[2] {
			Find<ModItem>("CarbonDagger").Type,
			Find<ModItem>("CarbonDaggerNihon").Type
		});
		RecipeGroup.RegisterGroup("FabusMod:CarbonDagger", group13);

		RecipeGroup group14 = new(() => Language.GetTextValue("LegacyMisc.37") + " Sorcerer's Hellstaff", new int[2] {
			Find<ModItem>("SorcerersHellstaff").Type,
			Find<ModItem>("SorcerersHellstaffWhite").Type
		});
		RecipeGroup.RegisterGroup("FabusMod:SorcerousHellstaff", group14);

		RecipeGroup group15 = new(() => Language.GetTextValue("LegacyMisc.37") + " Fox Pistol", new int[2] {
			Find<ModItem>("FoxPistol").Type,
			Find<ModItem>("FoxPistolBlue").Type
		});
		RecipeGroup.RegisterGroup("FabusMod:FoxPistol", group15);

		RecipeGroup group16 = new(() => Language.GetTextValue("LegacyMisc.37") + " Demonite Bar", new int[2] { 57, 1257 });
		RecipeGroup.RegisterGroup("FabusMod:DemoniteBar", group16);

		/*RecipeGroup group17 = new(() => Language.GetTextValue("LegacyMisc.37") + " Elemental Water Staff", new int[4] {
            Find<ModItem>("ElementalWaterStaff").Type,
            Find<ModItem>("ElementalWaterStaffRed").Type,
            Find<ModItem>("ElementalWaterStaffGreen").Type,
            Find<ModItem>("ElementalWaterStaffYellow").Type
		});
		RecipeGroup.RegisterGroup("FabusMod:ElementalWaterStaff", group17);*/

		RecipeGroup group18 = new(() => Language.GetTextValue("LegacyMisc.37") + " Gold Bar", new int[2] { 19, 706 });
		RecipeGroup.RegisterGroup("FabusMod:GoldBar", group18);

		RecipeGroup group19 = new(() => Language.GetTextValue("LegacyMisc.37") + " Adamantite Bar", new int[2] { 391, 1198 });
		RecipeGroup.RegisterGroup("FabusMod:AdamantiteBar", group19);

		RecipeGroup group20 = new(() => Language.GetTextValue("LegacyMisc.37") + " Protective Fusion", new int[2] {
            Find<ModItem>("ProtectionFuser").Type,
            Find<ModItem>("ProtectionFuserCarbonFiber").Type
		});
		RecipeGroup.RegisterGroup("FabusMod:ProtectionFuser", group20);

		RecipeGroup group21 = new(() => Language.GetTextValue("LegacyMisc.37") + " Orichalcum Bar", new int[2] { 1191, 382 });
		RecipeGroup.RegisterGroup("FabusMod:OrichalcumBar", group21);

		RecipeGroup group22 = new(() => Language.GetTextValue("LegacyMisc.37") + " Verano", new int[2] {
            Find<ModItem>("Verano").Type,
            Find<ModItem>("VeranoRime").Type
		});
		RecipeGroup.RegisterGroup("FabusMod:Verano", group22);
	}

	public override void AddRecipes()
	{
		Recipe val = Recipe.Create(ModContent.ItemType<Items.Vanity.FoxEars.FoxEars>());
		val.AddRecipeGroup("FabusMod:FoxEars", 1);
		val.AddIngredient(ItemID.OrangeDye, 1);
		val.AddTile(TileID.DyeVat);
		val.Register();

		Recipe val2 = Recipe.Create(ModContent.ItemType<Items.Vanity.FoxEars.PinkFoxEars>());
		val2.AddRecipeGroup("FabusMod:FoxEars", 1);
		val2.AddIngredient(ItemID.PinkDye, 1);
		val2.AddTile(TileID.DyeVat);
		val2.Register();

		Recipe val3 = Recipe.Create(ModContent.ItemType<Items.Vanity.FoxEars.BlueFoxEars>());
		val3.AddRecipeGroup("FabusMod:FoxEars", 1);
		val3.AddIngredient(ItemID.SkyBlueDye, 1);
		val3.AddTile(TileID.DyeVat);
		val3.Register();
	}
}
