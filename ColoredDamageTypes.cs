using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.UI;
using System.Collections.Generic;
using log4net;

namespace _ColoredDamageTypes
{
	class ColoredDamageTypes : Mod
	{
        public static Mod ThoriumMod;
		public static Mod TremorMod;
		public static bool ChangeTooltipColor = true;
		public static bool ChangeDamageColor = true;
		public static Mod instance;
		public static bool debug = false;
		public static bool debugtooltip = false;
		public static string GithubUserName { get { return "PvtFudgepants"; } }
		public static string GithubProjectName { get { return "tModLoader---Colored-Damage-Types"; } }
		public static string ConfigFileRelativePath
		{
			get { return "Mod Configs/ColoredDamageTypes.json"; }
		}
		public static void ReloadConfigFromFile()
		{
			Config.Load(); // Define implementation to reload your mod's config data from file
		}

		public static Item[] ProjectileWeaponSpawns = new Item[1001];

		public ColoredDamageTypes()
		{
            Properties = new ModProperties() {
                Autoload = true
            };
			instance = this;
		}
		
		public override void Load()
		{
			Config.Load();
		}

		public override void PostSetupContent()
		{
			ThoriumMod = ModLoader.GetMod("ThoriumMod");
			TremorMod = ModLoader.GetMod("Tremor");
		}

		public static void Log(object message, params object[] formatData)
		{
			instance.Logger.InfoFormat("[ColoredDamageTypes] " + string.Format(message.ToString(), formatData), "ColoredDamageTypes");
		}
		
	}
}
