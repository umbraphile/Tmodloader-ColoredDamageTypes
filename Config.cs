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
		public override ConfigScope Mode => ConfigScope.ClientSide;
		public static Config Instance = new Config();

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

		[Label("[c/7b4441:Calamity]")]
		public Calamity CalamityTT = new Calamity();
		public class Calamity
		{
			[Label("Rogue (Calamity)")]
			[Tooltip("Color of the damage tooltip for Rogue weapons from Calamity mod")]
			[ColorNoAlpha]
			[DefaultValue(typeof(Color), "170, 120, 120, 255")]
			public Color TooltipRogue = new Color(170, 120, 120, 255);
		}


		[Label("[c/94d65b:Redemption]")]
		public Redemption RedemptionTT = new Redemption();
		public class Redemption
		{
			[Label("Druidic (Redemption)")]
			[Tooltip("Color of the damage tooltip for Druidic weapons from Redemption mod")]
			[ColorNoAlpha]
			[DefaultValue(typeof(Color), "125, 155, 70, 255")]
			public Color TooltipDruidic = new Color(125, 155, 70, 255);
		}
		[Label("[c/555fc8:Enigma]")]
		public Enigma EnigmaTT = new Enigma();
		public class Enigma
		{
			[Label("Mystic (Enigma)")]
			[Tooltip("Color of the damage tooltip for Mystic weapons from Enigma mod")]
			[ColorNoAlpha]
			[DefaultValue(typeof(Color), "155, 140, 200, 255")]
			public Color TooltipMystic = new Color(155, 140, 200, 255);
		}

		[Label("[c/ca5939:DBZ Mod]")]
		public DbzMod DbzModTT = new DbzMod();
		public class DbzMod
		{
			[Label("Ki (DbzMod)")]
			[Tooltip("Color of the damage tooltip for Ki weapons from DbzMod mod")]
			[ColorNoAlpha]
			[DefaultValue(typeof(Color), "50, 205, 240, 255")]
			public Color TooltipKi = new Color(50, 205, 240, 255);
		}

		[Label("[c/0367ff:Battle Rods]")]
		public BattleRods BattleRodsTT= new BattleRods();
		public class BattleRods
		{
			[Label("Fishing (Battle Rods)")]
			[Tooltip("Color of the damage tooltip for Fishing weapons from Battle Rods mod")]
			[ColorNoAlpha]
			[DefaultValue(typeof(Color), "0, 130, 215, 255")]
			public Color TooltipFishing = new Color(0, 130, 215, 255);
		}

		[Label("[c/0367ff:Clicker Class]")]
		public Clicker ClickerModTT = new Clicker();
		public class Clicker
		{
			[Label("Click (Clicker Class)")]
			[Tooltip("Color of the damage tooltip for Clicker weapons from Clicker Class mod")]
			[ColorNoAlpha]
			[DefaultValue(typeof(Color), "210, 185, 145, 255")]
			public Color TooltipClicker = new Color(210, 185, 145, 255);
		}
		/*[Label("[c/0367ff:Orchid Mod]")]
		public Orchid OrchidModTT = new Orchid();
		public class Orchid
		{
			[Label("Shamanic (Orchid)")]
			[Tooltip("Color of the damage tooltip for Shamanic weapons from Orchid mod")]
			[ColorNoAlpha]
			[DefaultValue(typeof(Color), "0, 130, 215, 255")]
			public Color TooltipOrchid = new Color(0, 130, 215, 255);
		}*/


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
				[DefaultValue(typeof(Color), "255, 255, 255, 255")]
				public Color TrueDamage = new Color(255, 255, 255, 255);

				[Label("Crit")]
				[Tooltip("Color of the crit damage numbers for True weapons from Thorium mod")]
				[ColorNoAlpha]
				[DefaultValue(typeof(Color), "255, 255, 255, 255")]
				public Color TrueDamageCrit = new Color(255, 255, 255, 255);
			}
		}

		[Label("[c/7b4441:Calamity]")]
		public CalamityMod CalamityModDmg = new CalamityMod();
		public class CalamityMod
		{
			[Label("Rogue")]
			public Rogue RogueDmg = new Rogue();
			public class Rogue
			{
				[Label("Normal")]
				[Tooltip("Color of the damage numbers for Rogue weapons from Calamity mod")]
				[ColorNoAlpha]
				[DefaultValue(typeof(Color), "120, 100, 100, 255")]
				public Color RogueDamage = new Color(120, 100, 100, 255);

				[Label("Crit")]
				[Tooltip("Color of the crit damage numbers for Rogue weapons from Calamity mod")]
				[ColorNoAlpha]
				[DefaultValue(typeof(Color), "170, 140, 140, 255")]
				public Color RogueDamageCrit = new Color(170, 140, 140, 255);
			}
		}

		[Label("[c/94d65b:Redemption]")]
		public Redemption RedemptionDmg = new Redemption();
		public class Redemption
		{
			[Label("Druidic")]
			public Druidic DruidicDmg = new Druidic();
			public class Druidic
			{
				[Label("Normal")]
				[Tooltip("Color of the damage numbers for Druidic weapons from Redemption mod")]
				[ColorNoAlpha]
				[DefaultValue(typeof(Color), "125, 155, 70, 255")]
				public Color DruidicDamage = new Color(125, 155, 70, 255);

				[Label("Crit")]
				[Tooltip("Color of the crit damage numbers for Druidic weapons from Redemption mod")]
				[ColorNoAlpha]
				[DefaultValue(typeof(Color), "190, 200, 135, 255")]
				public Color DruidicDamageCrit = new Color(190, 200, 135, 255);
			}
		}

		[Label("[c/555fc8:Enigma]")]
		public Enigma EnigmaDmg = new Enigma();
		public class Enigma
		{
			[Label("Mystic")]
			public Mystic MysticDmg = new Mystic();
			public class Mystic
			{
				[Label("Normal")]
				[Tooltip("Color of the damage numbers for Mystic weapons from Enigma mod")]
				[ColorNoAlpha]
				[DefaultValue(typeof(Color), "85, 95, 200, 255")]
				public Color MysticDamage = new Color(85, 95, 200, 255);

				[Label("Crit")]
				[Tooltip("Color of the crit damage numbers for Mystic weapons from Enigma mod")]
				[ColorNoAlpha]
				[DefaultValue(typeof(Color), "105, 110, 170, 255")]
				public Color MysticDamageCrit = new Color(105, 110, 170, 255);
			}
		}

		[Label("[c/ca5939:DBZ]")]
		public DbzMod DbzModDmg = new DbzMod();
		public class DbzMod
		{
			[Label("Ki")]
			public Ki KiDmg = new Ki();
			public class Ki
			{
				[Label("Normal")]
				[Tooltip("Color of the damage numbers for Ki weapons from Dbz mod")]
				[ColorNoAlpha]
				[DefaultValue(typeof(Color), "50, 205, 240, 255")]
				public Color KiDamage = new Color(50, 205, 240, 255);

				[Label("Crit")]
				[Tooltip("Color of the crit damage numbers for Ki weapons from Dbz mod")]
				[ColorNoAlpha]
				[DefaultValue(typeof(Color), "205, 250, 255, 255")]
				public Color KiDamageCrit = new Color(205, 250, 255, 255);
			}
		}

		[Label("[c/0367ff:Battle Rods]")]
		public BattleRodMod BattleRodModDmg = new BattleRodMod();
		public class BattleRodMod
		{
			[Label("Fishing")]
			public Fishing FishingDmg = new Fishing();
			public class Fishing
			{
				[Label("Normal")]
				[Tooltip("Color of the damage numbers for Fishing weapons from Battle Rod mod")]
				[ColorNoAlpha]
				[DefaultValue(typeof(Color), "0, 75, 255, 255")]
				public Color FishingDamage = new Color(0, 75, 255, 255);

				[Label("Crit")]
				[Tooltip("Color of the crit damage numbers for Fishing weapons from Battle Rod mod")]
				[ColorNoAlpha]
				[DefaultValue(typeof(Color), "0, 130, 215, 255")]
				public Color FishingDamageCrit = new Color(0, 130, 215, 255);
			}
		}

		[Label("[c/d2b991:Clicker Class]")]
		public ClickerMod ClickerModDmg = new ClickerMod();
		public class ClickerMod
		{
			[Label("Click")]
			public Click ClickDmg = new Click();
			public class Click
			{
				[Label("Normal")]
				[Tooltip("Color of the damage numbers for Click weapons from Clicker Class mod")]
				[ColorNoAlpha]
				[DefaultValue(typeof(Color), "210, 185, 145, 255")]
				public Color ClickDamage = new Color(210, 185, 145, 255);

				[Label("Crit")]
				[Tooltip("Color of the crit damage numbers for Click weapons from Clicker Class mod")]
				[ColorNoAlpha]
				[DefaultValue(typeof(Color), "250, 230, 220, 255")]
				public Color ClickDamageCrit = new Color(250, 230, 220, 255);
			}
		}

		/*[Label("[c/0367ff:Orchid Mod]")]
		public OrchidMod OrchidModDmg = new OrchidMod();
		public class OrchidMod
		{
			[Label("Shamanic")]
			public Shamanic ShamanicDmg = new Shamanic();
			public class Shamanic
			{
				[Label("Normal")]
				[Tooltip("Color of the damage numbers for Shamanic weapons from Orchid mod")]
				[ColorNoAlpha]
				[DefaultValue(typeof(Color), "0, 75, 255, 255")]
				public Color FishingDamage = new Color(0, 75, 255, 255);

				[Label("Crit")]
				[Tooltip("Color of the crit damage numbers for Shamanic weapons from Orchid mod")]
				[ColorNoAlpha]
				[DefaultValue(typeof(Color), "0, 130, 215, 255")]
				public Color FishingDamageCrit = new Color(0, 130, 215, 255);
			}
		}
		*/

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
