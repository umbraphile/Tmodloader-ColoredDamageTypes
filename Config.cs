/*using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.IO;


namespace _ColoredDamageTypes
{
	class Config
	{
		static string ConfigPath = Path.Combine(Main.SavePath, "Mod Configs", "ColoredDamageTypes.json");
		static Preferences Configuration = new Preferences(ConfigPath);
		static int Version = 4;
		static int DebugMode = 0;
		public static String	TooltipDefense,
								TooltipMelee,
								TooltipRanged,
								TooltipMagic,
								TooltipThrown,
								TooltipSummon,
								TooltipSentry,
								TooltipRadiant,
								TooltipSymphonic,
								TooltipTrue,
								TooltipAlchemic,

								DamageMelee,
								DamageRanged,
								DamageMagic,
								DamageThrown,
								DamageSummon,
								DamageSentry,
								DamageRadiant,
								DamageSymphonic,
								DamageTrue,
								DamageAlchemic,

								CritDamageMelee,
								CritDamageRanged,
								CritDamageMagic,
								CritDamageThrown,
								CritDamageSummon,
								CritDamageSentry,
								CritDamageRadiant,
								CritDamageSymphonic,
								CritDamageTrue,
								CritDamageAlchemic;

		public static void Load()
		{
			string message = "Failed to read config file! Recreating config...";
			bool newfile = false;
			var curversion = Version;
			if (!ReadConfig()) newfile = true;
			else {
				if(Version < curversion) {
					message = "Config has been updated. Generating new config file.";
					newfile = true;
					Version = curversion;
				}
			}

			if (newfile) {
				ColoredDamageTypes.Log(message);
				SaveConfig();
			}
		}

		static bool ReadConfig()
		{
			if (Configuration.Load()) {
				Configuration.Get("Debug", ref DebugMode);
				Configuration.Get("Version", ref Version);
				Configuration.Get("ChangeTooltipColor", ref ColoredDamageTypes.ChangeTooltipColor);
				Configuration.Get("ChangeDamageColor", ref ColoredDamageTypes.ChangeDamageColor);

				Configuration.Get("TooltipDefense", ref Config.TooltipDefense);
				Configuration.Get("TooltipMelee", ref Config.TooltipMelee);
				Configuration.Get("TooltipRanged", ref Config.TooltipRanged);
				Configuration.Get("TooltipMagic", ref Config.TooltipMagic);
				Configuration.Get("TooltipThrown", ref Config.TooltipThrown);
				Configuration.Get("TooltipSummon", ref Config.TooltipSummon);
				Configuration.Get("TooltipSentry", ref Config.TooltipSentry);
				Configuration.Get("TooltipRadiant", ref Config.TooltipRadiant);
				Configuration.Get("TooltipSymphonic", ref Config.TooltipSymphonic);
				Configuration.Get("TooltipTrue", ref Config.TooltipTrue);
				Configuration.Get("TooltipAlchemic", ref Config.TooltipAlchemic);

				Configuration.Get("DamageMelee", ref Config.DamageMelee);
				Configuration.Get("DamageRanged", ref Config.DamageRanged);
				Configuration.Get("DamageMagic", ref Config.DamageMagic);
				Configuration.Get("DamageThrown", ref Config.DamageThrown);
				Configuration.Get("DamageSummon", ref Config.DamageSummon);
				Configuration.Get("DamageSentry", ref Config.DamageSentry);
				Configuration.Get("DamageRadiant", ref Config.DamageRadiant);
				Configuration.Get("DamageSymphonic", ref Config.DamageSymphonic);
				Configuration.Get("DamageTrue", ref Config.DamageTrue);
				Configuration.Get("DamageAlchemic", ref Config.DamageAlchemic);

				Configuration.Get("CritDamageMelee", ref Config.CritDamageMelee);
				Configuration.Get("CritDamageRanged", ref Config.CritDamageRanged);
				Configuration.Get("CritDamageMagic", ref Config.CritDamageMagic);
				Configuration.Get("CritDamageThrown", ref Config.CritDamageThrown);
				Configuration.Get("CritDamageSummon", ref Config.CritDamageSummon);
				Configuration.Get("CritDamageSentry", ref Config.CritDamageSentry);
				Configuration.Get("CritDamageRadiant", ref Config.CritDamageRadiant);
				Configuration.Get("CritDamageSymphonic", ref Config.CritDamageSymphonic);
				Configuration.Get("CritDamageTrue", ref Config.CritDamageTrue);
				Configuration.Get("CritDamageAlchemic", ref Config.CritDamageAlchemic);

				if (Config.DebugMode == 1) ColoredDamageTypes.debug = true;
				if (Config.DebugMode == 2) {
					ColoredDamageTypes.debug = true;
					ColoredDamageTypes.debugtooltip = true;
				}
				else ColoredDamageTypes.debug = false;
				if (Config.TooltipDefense != null) Colors.TooltipDefense = Colors.StringToColor(Config.TooltipDefense);
				if (Config.TooltipMelee != null) Colors.TooltipMelee = Colors.StringToColor(Config.TooltipMelee);
				if (Config.TooltipRanged != null) Colors.TooltipRanged = Colors.StringToColor(Config.TooltipRanged);
				if (Config.TooltipMagic != null) Colors.TooltipMagic = Colors.StringToColor(Config.TooltipMagic);
				if (Config.TooltipThrown != null) Colors.TooltipThrown = Colors.StringToColor(Config.TooltipThrown);
				if (Config.TooltipSummon != null) Colors.TooltipSummon = Colors.StringToColor(Config.TooltipSummon);
				if (Config.TooltipSentry != null) Colors.TooltipSentry = Colors.StringToColor(Config.TooltipSentry);
				if (Config.TooltipRadiant != null) Colors.TooltipRadiant = Colors.StringToColor(Config.TooltipRadiant);
				if (Config.TooltipSymphonic != null) Colors.TooltipSymphonic = Colors.StringToColor(Config.TooltipSymphonic);
				if (Config.TooltipTrue != null) Colors.TooltipTrue = Colors.StringToColor(Config.TooltipTrue);
				if (Config.TooltipAlchemic != null) Colors.TooltipAlchemic = Colors.StringToColor(Config.TooltipAlchemic);

				if (Config.DamageMelee != null) Colors.DamageMelee = Colors.StringToColor(Config.DamageMelee);
				if (Config.DamageRanged != null) Colors.DamageRanged = Colors.StringToColor(Config.DamageRanged);
				if (Config.DamageMagic != null) Colors.DamageMagic = Colors.StringToColor(Config.DamageMagic);
				if (Config.DamageThrown != null) Colors.DamageThrown = Colors.StringToColor(Config.DamageThrown);
				if (Config.DamageSummon != null) Colors.DamageSummon = Colors.StringToColor(Config.DamageSummon);
				if (Config.DamageSentry != null) Colors.DamageSentry = Colors.StringToColor(Config.DamageSentry);
				if (Config.DamageRadiant != null) Colors.DamageRadiant = Colors.StringToColor(Config.DamageRadiant);
				if (Config.DamageSymphonic != null) Colors.DamageSymphonic = Colors.StringToColor(Config.DamageSymphonic);
				if (Config.DamageTrue != null) Colors.DamageTrue = Colors.StringToColor(Config.DamageTrue);
				if (Config.DamageAlchemic != null) Colors.DamageAlchemic = Colors.StringToColor(Config.DamageAlchemic);

				if (Config.CritDamageMelee != null) Colors.CritDamageMelee = Colors.StringToColor(Config.CritDamageMelee);
				if (Config.CritDamageRanged != null) Colors.CritDamageRanged = Colors.StringToColor(Config.CritDamageRanged);
				if (Config.CritDamageMagic != null) Colors.CritDamageMagic = Colors.StringToColor(Config.CritDamageMagic);
				if (Config.CritDamageThrown != null) Colors.CritDamageThrown = Colors.StringToColor(Config.CritDamageThrown);
				if (Config.CritDamageSummon != null) Colors.CritDamageSummon = Colors.StringToColor(Config.CritDamageSummon);
				if (Config.CritDamageSentry != null) Colors.CritDamageSentry = Colors.StringToColor(Config.CritDamageSentry);
				if (Config.CritDamageRadiant != null) Colors.CritDamageRadiant = Colors.StringToColor(Config.CritDamageRadiant);
				if (Config.CritDamageSymphonic != null) Colors.CritDamageSymphonic = Colors.StringToColor(Config.CritDamageSymphonic);
				if (Config.CritDamageTrue != null) Colors.CritDamageTrue = Colors.StringToColor(Config.CritDamageTrue);
				if (Config.CritDamageAlchemic != null) Colors.CritDamageAlchemic = Colors.StringToColor(Config.CritDamageAlchemic);
				return true;
			}
			return false;
		}

		static void SaveConfig()
		{
			Configuration.Clear();
			Configuration.Put("Version", Version);
			Configuration.Put("ChangeTooltipColor", ColoredDamageTypes.ChangeTooltipColor);
			Configuration.Put("ChangeDamageColor", ColoredDamageTypes.ChangeDamageColor);

			Configuration.Put("TooltipDefense", Colors.ToRGB(Colors.TooltipDefense));
			Configuration.Put("TooltipMelee", Colors.ToRGB(Colors.TooltipMelee));
			Configuration.Put("TooltipRanged", Colors.ToRGB(Colors.TooltipRanged));
			Configuration.Put("TooltipMagic", Colors.ToRGB(Colors.TooltipMagic));
			Configuration.Put("TooltipThrown", Colors.ToRGB(Colors.TooltipThrown));
			Configuration.Put("TooltipSummon", Colors.ToRGB(Colors.TooltipSummon));
			Configuration.Put("TooltipSentry", Colors.ToRGB(Colors.TooltipSentry));
			Configuration.Put("TooltipRadiant", Colors.ToRGB(Colors.TooltipRadiant));
			Configuration.Put("TooltipSymphonic", Colors.ToRGB(Colors.TooltipSymphonic));
			Configuration.Put("TooltipTrue", Colors.ToRGB(Colors.TooltipTrue));
			Configuration.Put("TooltipAlchemic", Colors.ToRGB(Colors.TooltipAlchemic));

			Configuration.Put("DamageMelee", Colors.ToRGB(Colors.DamageMelee));
			Configuration.Put("DamageRanged", Colors.ToRGB(Colors.DamageRanged));
			Configuration.Put("DamageMagic", Colors.ToRGB(Colors.DamageMagic));
			Configuration.Put("DamageThrown", Colors.ToRGB(Colors.DamageThrown));
			Configuration.Put("DamageSummon", Colors.ToRGB(Colors.DamageSummon));
			Configuration.Put("DamageSentry", Colors.ToRGB(Colors.DamageSentry));
			Configuration.Put("DamageRadiant", Colors.ToRGB(Colors.DamageRadiant));
			Configuration.Put("DamageSymphonic", Colors.ToRGB(Colors.DamageSymphonic));
			Configuration.Put("DamageTrue", Colors.ToRGB(Colors.DamageTrue));
			Configuration.Put("DamageAlchemic", Colors.ToRGB(Colors.DamageAlchemic));

			Configuration.Put("CritDamageMelee", Colors.ToRGB(Colors.CritDamageMelee));
			Configuration.Put("CritDamageRanged", Colors.ToRGB(Colors.CritDamageRanged));
			Configuration.Put("CritDamageMagic", Colors.ToRGB(Colors.CritDamageMagic));
			Configuration.Put("CritDamageThrown", Colors.ToRGB(Colors.CritDamageThrown));
			Configuration.Put("CritDamageSummon", Colors.ToRGB(Colors.CritDamageSummon));
			Configuration.Put("CritDamageSentry", Colors.ToRGB(Colors.CritDamageSentry));
			Configuration.Put("CritDamageRadiant", Colors.ToRGB(Colors.CritDamageRadiant));
			Configuration.Put("CritDamageSymphonic", Colors.ToRGB(Colors.CritDamageSymphonic));
			Configuration.Put("CritDamageTrue", Colors.ToRGB(Colors.CritDamageTrue));
			Configuration.Put("CritDamageAlchemic", Colors.ToRGB(Colors.CritDamageAlchemic));
			Configuration.Save();
		}

	}
}
