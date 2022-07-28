using Microsoft.Xna.Framework;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using Terraria;
using Terraria.ModLoader.Config;
using Terraria.ModLoader;


namespace ColoredDamageTypes
{


	[Label("Config")]
	class Config : ModConfig {
		public static zCrossModConfig crossModInstance;
		public override ConfigScope Mode => ConfigScope.ClientSide;
		public static Config Instance;

        /*public override void OnLoaded()
        {
			Instance = this;
		}*/

        [Header("Toggles")]

		[Label("Show damage numbers")]
		[Tooltip("Show/Hide all damage numbers")]
		[DefaultValue(true)]
		public bool ShowDamageNumbers { get; set; }

		[Label("Show other players damage numbers in multiplayer")]
		[Tooltip("Show/Hide other players damage numbers in multiplayer")]
		[DefaultValue(true)]
		public bool ShowMultiplayerDamageNumbers { get; set; }

		[Label("Change Tooltip Color")]
		[Tooltip("Allows the mod to change the color of some tooltip text when hovering over items.")]
		[DefaultValue(true)]
		public bool ChangeTooltipColor { get; set; }

		[Label("Change Damage Color")]
		[Tooltip("Allows the mod to change the color of damage numbers when hitting enemies.")]
		[DefaultValue(true)]
		public bool ChangeDamageColor { get; set; }

		[Header("Debug Settings (Please Ignore)")]
		[Label("Debug Mode")]
		[Tooltip("Don't turn on.")]
		[DefaultValue(false)]
		public bool DebugMode { get; set; }

		[Label("Debug Mode Tooltips")]
		[Tooltip("Don't turn on.")]
		[DefaultValue(false)]
		public bool DebugModeTooltips { get; set; }

		[Label("Debug Mode Fields")]
		[Tooltip("Don't turn on.")]
		[DefaultValue(false)]
		public bool DebugModeFields { get; set; }

		[Label("Debug Mode (Multiplayer)")]
		[Tooltip("Don't turn on.")]
		[DefaultValue(false)]
		public bool DebugModeMultiplayer { get; set; }

		
	}
	[Label("Tooltips Config")]
	class TooltipsConfig : ModConfig {
		public override ConfigScope Mode => ConfigScope.ClientSide;
		public static TooltipsConfig Instance = new TooltipsConfig();

		[Header("Tooltip Colors")]
		[Label("Vanilla")]
		public Vanilla VanillaTT = new Vanilla();
		public class Vanilla {

			[Label("Defense")]
			[Tooltip("Color of the defense tooltip on armor")]
			[ColorNoAlpha]
			[DefaultValue(typeof(Color), "140, 160, 140, 255")]
			public Color TooltipDefense = new Color(140, 160, 140, 255);

			[Label("Melee")]
			[Tooltip("Color of the damage tooltip for Melee weapons")]
			[ColorNoAlpha]
			[DefaultValue(typeof(Color), "235, 25, 25, 255")]
			public Color TooltipMelee = new Color(235, 25, 25, 255);

			[Label("Ranged")]
			[Tooltip("Color of the damage tooltip for Ranged weapons")]
			[ColorNoAlpha]
			[DefaultValue(typeof(Color), "0, 180, 60, 255")]
			public Color TooltipRanged = new Color(0, 180, 60, 255);

			[Label("Magic")]
			[Tooltip("Color of the damage tooltip for Magic weapons")]
			[ColorNoAlpha]
			[DefaultValue(typeof(Color), "15, 135, 255, 255")]
			public Color TooltipMagic = new Color(15, 135, 255, 255);

			[Label("Throwing")]
			[Tooltip("Color of the damage tooltip for Throwing weapons")]
			[ColorNoAlpha]
			[DefaultValue(typeof(Color), "255, 120, 25, 255")]
			public Color TooltipThrowing = new Color(255, 120, 25, 255);

			[Label("Summon")]
			[Tooltip("Color of the damage tooltip for Summon weapons")]
			[ColorNoAlpha]
			[DefaultValue(typeof(Color), "255, 115, 195, 255")]
			public Color TooltipSummon = new Color(255, 115, 195, 255);

			[Label("Sentry")]
			[Tooltip("Color of the damage tooltip for Sentry weapons")]
			[ColorNoAlpha]
			[DefaultValue(typeof(Color), "150, 115, 255, 255")]
			public Color TooltipSentry = new Color(150, 115, 255, 255);

		}
	}
	[Label("Damage Config")]
	class DamageConfig : ModConfig {
		public override ConfigScope Mode => ConfigScope.ClientSide;
		public static DamageConfig Instance = new DamageConfig();

		[Header("Damage Colors")]
		[Label("Vanilla")]
		public Vanilla VanillaDmg = new Vanilla();
		public class Vanilla
		{
			[Label("Melee")]
			public Melee MeleeDmg = new Melee();
			public class Melee
			{
				[Label("Normal")]
				[Tooltip("Color of the damage numbers for Melee weapons")]
				[ColorNoAlpha]
				[DefaultValue(typeof(Color), "170, 0, 0, 255")]
				public Color MeleeDamage = new Color(170, 0, 0, 255);

				[Label("Crit")]
				[Tooltip("Color of the crit damage numbers for Melee weapons")]
				[ColorNoAlpha]
				[DefaultValue(typeof(Color), "255, 10, 50, 255")]
				public Color MeleeDamageCrit = new Color(255, 10, 50, 255);
			}
			[Label("Ranged")]
			public Ranged RangedDmg = new Ranged();
			public class Ranged
			{
				[Label("Normal")]
				[Tooltip("Color of the damage numbers for Ranged weapons")]
				[ColorNoAlpha]
				[DefaultValue(typeof(Color), "150, 225, 155, 255")]
				public Color RangedDamage = new Color(150, 225, 155, 255);

				[Label("Crit")]
				[Tooltip("Color of the crit damage numbers for Ranged weapons")]
				[ColorNoAlpha]
				[DefaultValue(typeof(Color), "30, 205, 90, 255")]
				public Color RangedDamageCrit = new Color(30, 205, 90, 255);
			}

			[Label("Magic")]
			public Magic MagicDmg = new Magic();
			public class Magic
			{
				[Label("Normal")]
				[Tooltip("Color of the damage numbers for Magic weapons")]
				[ColorNoAlpha]
				[DefaultValue(typeof(Color), "120, 190, 255, 255")]
				public Color MagicDamage = new Color(120, 190, 255, 255);

				[Label("Crit")]
				[Tooltip("Color of the crit damage numbers for Magic weapons")]
				[ColorNoAlpha]
				[DefaultValue(typeof(Color), "55, 130, 255, 255")]
				public Color MagicDamageCrit = new Color(55, 130, 255, 255);
			}

			[Label("Throwing")]
			public Throwing ThrowingDmg = new Throwing();
			public class Throwing
			{
				[Label("Normal")]
				[Tooltip("Color of the damage numbers for Throwing weapons")]
				[ColorNoAlpha]
				[DefaultValue(typeof(Color), "160, 110, 60, 255")]
				public Color ThrowingDamage = new Color(160, 110, 60, 255);

				[Label("Crit")]
				[Tooltip("Color of the crit damage numbers for Throwing weapons")]
				[ColorNoAlpha]
				[DefaultValue(typeof(Color), "220, 135, 0, 255")]
				public Color ThrowingDamageCrit = new Color(220, 135, 0, 255);
			}

			[Label("Summon")]
			public Summon SummonDmg = new Summon();
			public class Summon
			{
				[Label("Normal")]
				[Tooltip("Color of the damage numbers for Summon weapons")]
				[ColorNoAlpha]
				[DefaultValue(typeof(Color), "255, 115, 195, 255")]
				public Color SummonDamage = new Color(255, 115, 195, 255);

				[Label("Crit")]
				[Tooltip("Color of the crit damage numbers for Summon weapons (requires mod to actually allow summons to crit)")]
				[ColorNoAlpha]
				[DefaultValue(typeof(Color), "250, 80, 250, 255")]
				public Color SummonDamageCrit = new Color(250, 80, 250, 255);
			}

			[Label("Sentry")]
			public Sentry SentryDmg = new Sentry();
			public class Sentry
			{
				[Label("Normal")]
				[Tooltip("Color of the damage numbers for Sentry weapons")]
				[ColorNoAlpha]
				[DefaultValue(typeof(Color), "150, 115, 255, 255")]
				public Color SentryDamage = new Color(150, 115, 255, 255);

				[Label("Crit")]
				[Tooltip("Color of the crit damage numbers for Sentry weapons (requires mod to actually allow sentries to crit)")]
				[ColorNoAlpha]
				[DefaultValue(typeof(Color), "120, 70, 255, 255")]
				public Color SentryDamageCrit = new Color(120, 70, 255, 255);
			}
		}
	}
	[Label("Mod Compatbility Config")]
	class zCrossModConfig : ModConfig
	{
		public override ConfigScope Mode => ConfigScope.ClientSide;
		public static zCrossModConfig Instance;

		[Header("Mod Compatibility\nIf you change a setting here, you will need to \"Restore Defaults\" if any new damage types are added after.")]
		[Label("Colors and damage types that were added by other mods:")]
		[DefaultDictionaryKeyValue("Mod Name")]


		public Dictionary<string, zCrossModConfig.DamageType> CrossModDamageConfig = new Dictionary<string, zCrossModConfig.DamageType>();
		public static Dictionary<string, zCrossModConfig.DamageType> CrossModDamageConfig_Orig = new Dictionary<string, zCrossModConfig.DamageType>();

		public override string ToString()
		{
			return "Damage Types";
		}
		public class DamageType
		{
			[Label("Damage Type (For reference only)")]
			[Tooltip("For reference only. Changing this will do nothing.")]
			//public string type;
			public string dtname;
			public DamageType(string s, Color defaulttt, Color defaultdmg, Color defaultcrit)
			{
				TooltipColor = defaulttt;
				DamageColor = defaultdmg;
				CritDamageColor = defaultcrit;
				if(s != null && s.Contains('/'))
                {
					string[] ssplit = s.Split('/');
					dtname = ssplit[ssplit.Length-1];
				}
				else if (s != null && s.Contains('.'))
				{
					string[] ssplit = s.Split('.');
					dtname = ssplit[ssplit.Length - 1];
				}
			}

			[Tooltip("Tooltip color")]
			[ColorNoAlpha]
			[DefaultValue(typeof(Color), "155, 140, 200, 255")]
			public Color TooltipColor = new Color(155, 140, 200, 255);

			[Tooltip("Damage color")]
			[ColorNoAlpha]
			[DefaultValue(typeof(Color), "155, 140, 200, 255")]
			public Color DamageColor = new Color(155, 140, 200, 255);

			[Tooltip("Crit Damage color")]
			[ColorNoAlpha]
			[DefaultValue(typeof(Color), "155, 140, 200, 255")]
			public Color CritDamageColor = new Color(155, 140, 200, 255);


        }

        public override void OnChanged()
		{
			//this.CrossModDamageConfig = new Dictionary<string, zCrossModConfig.DamageType>(zCrossModConfig.CrossModDamageConfig_Orig);
			base.OnChanged();
        }

        public override void OnLoaded()
        {
			ColoredDamageTypes.Log("Loaded config");
			Config.crossModInstance = this;
            base.OnLoaded();
        }
        public zCrossModConfig()
		{
			//DoMenuModeState()
			CrossModDamageConfig = new Dictionary<string, DamageType>(CrossModDamageConfig_Orig);
			/*string modname = "ExampleMod";
            DamageClass dc = DamageClass.Summon;
            if (ModLoader.TryGetMod(modname, out ColoredDamageTypes.ExampleMod))
            {
                Color ex1critcolor = new Color(155, 140, 0, 255);
                Color ex1dmgcolor = new Color(155, 0, 200, 255);
                Color ex1tooltipcolor = new Color(0, 140, 200, 255);
                string dcname = dc.ToString();


                string dcname2 = DamageClass.Magic.ToString();

                List<zCrossModConfig.DamageType> typeslist;
                if (!CrossModDamageConfig.ContainsKey(dcname))
                {
                    CrossModDamageConfig[dcname] = new DamageType(dcname, ex1tooltipcolor, ex1dmgcolor, ex1critcolor);
                }
                if (!CrossModDamageConfig.ContainsKey(dcname2))
                {
                    CrossModDamageConfig[dcname2] = new DamageType(dcname2, ex1tooltipcolor, ex1dmgcolor, ex1critcolor);
                }
                //typeslist.Add(new zCrossModConfig.DamageType(ex1type,ex1tooltipcolor,ex1dmgcolor,ex1critcolor));
                //CrossModConfigs.Add("ExampleMod", new CrossModConfig(list));
            }*/
		}
	}

}
