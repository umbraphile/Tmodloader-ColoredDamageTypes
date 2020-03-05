using Microsoft.Xna.Framework;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using Terraria;
using Terraria.Localization;
using Terraria.ModLoader.Config;
using Terraria.ModLoader;


namespace _ColoredDamageTypes
{
	[Label("Config")]
	class Config : ModConfig {
		public override ConfigScope Mode => ConfigScope.ClientSide;
		public static Config Instance = new Config();

		[Header("Toggles")]

		[Label("Change Tooltip Color")]
		[Tooltip("Allows the mod to change the color of some tooltip text when hovering over items.")]
		[DefaultValue(true)]
		public bool ChangeTooltipColor { get; set; }

		[Label("Change Damage Color")]
		[Tooltip("Allows the mod to change the color of damage numbers when hitting enemies.")]
		[DefaultValue(true)]
		public bool ChangeDamageColor { get; set; }

		[Label("Debug Mode")]
		[Tooltip("Don't turn on.")]
		[DefaultValue(false)]
		public bool DebugMode { get; set; }

		[Label("Debug Mode Tooltips")]
		[Tooltip("Don't turn on.")]
		[DefaultValue(false)]
		public bool DebugModeTooltips { get; set; }

	}
	[Label("Tooltips Config")]
	class TooltipsConfig : ModConfig {
		public override ConfigScope Mode => ConfigScope.ClientSide;
		public static TooltipsConfig Instance = new TooltipsConfig();

		[Header("Tooltip Colors")]
		[Label("Base Game")]
		public Base BaseTT = new Base();
		public class Base {
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

		[Label("[c/29dfff:Thorium]")]
		public Thorium ThoriumTT = new Thorium();
		public class Thorium {
			[Label("Radiant (Thorium)")]
			[Tooltip("Color of the damage tooltip for Radiant weapons from Thorium mod")]
			[ColorNoAlpha]
			[DefaultValue(typeof(Color), "225, 225, 80, 255")]
			public Color TooltipRadiant = new Color(225, 225, 80, 255);

			[Label("Symphonic (Thorium)")]
			[Tooltip("Color of the damage tooltip for Symphonic weapons from Thorium mod")]
			[ColorNoAlpha]
			[DefaultValue(typeof(Color), "140, 220, 210, 255")]
			public Color TooltipSymphonic = new Color(140, 220, 210, 255);

			[Label("True (Thorium)")]
			[Tooltip("Color of the damage tooltip for True weapons from Thorium mod")]
			[ColorNoAlpha]
			[DefaultValue(typeof(Color), "170, 170, 170, 255")]
			public Color TooltipTrue = new Color(170, 170, 170, 255);
		}

		/*
		[Label("[c/9f2284:Tremor]")]
		public Tremor TremorTT = new Tremor();
		public class Tremor {
			[Label("Tooltip - Alchemic (Tremor)")]
			[Tooltip("Color of the damage tooltip for Alchemic weapons from Tremor mod")]
			[ColorNoAlpha]
			[DefaultValue(typeof(Color), "190, 90, 190, 255")]
			public Color TooltipAlchemic = new Color(190, 90, 190, 255);
		}
		*/
	}
	class DamageConfig : ModConfig	{
		public override ConfigScope Mode => ConfigScope.ClientSide;
		public static DamageConfig Instance = new DamageConfig();
		[Header("Damage Colors")]
		[Label("Base Game")]
		public Base BaseDmg = new Base();
		public class Base
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
		[Label("[c/29dfff:Thorium]")]
		public Thorium ThoriumDmg = new Thorium();
		public class Thorium
		{
			[Label("Radiant")]
			public Radiant RadiantDmg = new Radiant();
			public class Radiant
			{
				[Label("Normal")]
				[Tooltip("Color of the damage numbers for Radiant weapons from Thorium mod")]
				[ColorNoAlpha]
				[DefaultValue(typeof(Color), "225, 225, 80, 255")]
				public Color RadiantDamage = new Color(225, 225, 80, 255);

				[Label("Crit")]
				[Tooltip("Color of the crit damage numbers for Radiant weapons from Thorium mod")]
				[ColorNoAlpha]
				[DefaultValue(typeof(Color), "255, 190, 0, 255")]
				public Color RadiantDamageCrit = new Color(255, 190, 0, 255);
			}

			[Label("Symphonic")]
			public Symphonic SymphonicDmg = new Symphonic();
			public class Symphonic
			{
				[Label("Normal")]
				[Tooltip("Color of the damage numbers for Symphonic weapons from Thorium mod")]
				[ColorNoAlpha]
				[DefaultValue(typeof(Color), "0, 200, 140, 255")]
				public Color SymphonicDamage = new Color(0, 200, 140, 255);

				[Label("Crit")]
				[Tooltip("Color of the crit damage numbers for Symphonic weapons from Thorium mod")]
				[ColorNoAlpha]
				[DefaultValue(typeof(Color), "45, 255, 205, 255")]
				public Color SymphonicDamageCrit = new Color(45, 255, 205, 255);
			}

			[Label("True")]
			public True TrueDmg = new True();
			public class True
			{
				[Label("Normal")]
				[Tooltip("Color of the damage numbers for True weapons from Thorium mod")]
				[ColorNoAlpha]
				[DefaultValue(typeof(Color), "180, 180, 180, 255")]
				public Color TrueDamage = new Color(180, 180, 180, 255);

				[Label("Crit")]
				[Tooltip("Color of the crit damage numbers for True weapons from Thorium mod")]
				[ColorNoAlpha]
				[DefaultValue(typeof(Color), "255, 255, 255, 255")]
				public Color TrueDamageCrit = new Color(255, 255, 255, 255);
			}
		}
		/*
		[Label("[c/9f2284:Tremor]")]
		public Tremor TremorDmg = new Tremor();
		public class Tremor
		{
			[Label("Alchemic")]
			public Alchemic AlchemicDmg = new Alchemic();
			public class Alchemic
			{
				[Label("Normal")]
				[Tooltip("Color of the damage numbers for Alchemic weapons from Tremor mod")]
				[ColorNoAlpha]
				[DefaultValue(typeof(Color), "190, 90, 190, 255")]
				public Color AlchemicDamage = new Color(190, 90, 190, 255);

				[Label("Crit")]
				[Tooltip("Color of the crit damage numbers for Alchemic weapons from Tremor mod")]
				[ColorNoAlpha]
				[DefaultValue(typeof(Color), "180, 30, 190, 255")]
				public Color AlchemicDamageCrit = new Color(180, 30, 190, 255);
			}
		}
		*/

	}

}
