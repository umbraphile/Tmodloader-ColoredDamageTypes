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
	[Label("Base Config")]
	class ConfigUI : ModConfig
	{
		public override ConfigScope Mode => ConfigScope.ClientSide;
		public static ConfigUI Instance;

		[Label("Change Tooltip Color")]
		[Tooltip("Allows the mod to change the color of some tooltip text when hovering over items.")]
		[DefaultValue(true)]
		public bool ChangeTooltipColor { get; set; }

		[Label("Change Damage Color")]
		[Tooltip("Allows the mod to change the color of damage numbers when hitting enemies.")]
		[DefaultValue(true)]
		public bool ChangeDamageColor { get; set; }

		[Label("Tooltip Colors")]
		public Tooltips TooltipsInstance = new Tooltips();

		[SeparatePage]
		public class Tooltips
		{
			[Header("Tooltips")]

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

			[Header("[c/29dfff:Thorium]")]
			[Label("Tooltip - Radiant (Thorium)")]
			[Tooltip("Color of the damage tooltip for Radiant weapons from Thorium mod")]
			[ColorNoAlpha]
			[DefaultValue(typeof(Color), "225, 225, 80, 255")]
			public Color TooltipRadiant = new Color(225, 225, 80, 255);

			[Label("Tooltip - Symphonic (Thorium)")]
			[Tooltip("Color of the damage tooltip for Symphonic weapons from Thorium mod")]
			[ColorNoAlpha]
			[DefaultValue(typeof(Color), "140, 220, 210, 255")]
			public Color TooltipSymphonic = new Color(140, 220, 210, 255);

			[Label("Tooltip - True (Thorium)")]
			[Tooltip("Color of the damage tooltip for True weapons from Thorium mod")]
			[ColorNoAlpha]
			[DefaultValue(typeof(Color), "170, 170, 170, 255")]
			public Color TooltipTrue = new Color(170, 170, 170, 255);

			[Header("[c/9f2284:Tremor]")]
			[Label("Tooltip - Alchemic (Tremor)")]
			[Tooltip("Color of the damage tooltip for Alchemic weapons from Tremor mod")]
			[ColorNoAlpha]
			[DefaultValue(typeof(Color), "190, 90, 190, 255")]
			public Color TooltipAlchemic = new Color(190, 90, 190, 255);

		}

		[Label("Damage Colors")]
		public Damage DamageInstance = new Damage();

		[SeparatePage]
		public class Damage
		{
			[Header("Damage")]

			[Label("Melee")]
			[Tooltip("Color of the damage numbers for Melee weapons")]
			[ColorNoAlpha]
			[DefaultValue(typeof(Color), "170, 0, 0, 255")]
			public Color DamageMelee = new Color(170, 0, 0, 255);

			[Label("Melee Crit")]
			[Tooltip("Color of the crit damage numbers for Melee weapons")]
			[ColorNoAlpha]
			[DefaultValue(typeof(Color), "255, 10, 50, 255")]
			public Color CritDamageMelee = new Color(255, 10, 50, 255);

			[Label("Ranged")]
			[Tooltip("Color of the damage numbers for Ranged weapons")]
			[ColorNoAlpha]
			[DefaultValue(typeof(Color), "150, 225, 155, 255")]
			public Color DamageRanged = new Color(150, 225, 155, 255);

			[Label("Ranged Crit")]
			[Tooltip("Color of the crit damage numbers for Ranged weapons")]
			[ColorNoAlpha]
			[DefaultValue(typeof(Color), "30, 205, 90, 255")]
			public Color CritDamageRanged = new Color(30, 205, 90, 255);

			[Label("Magic")]
			[Tooltip("Color of the damage numbers for Magic weapons")]
			[ColorNoAlpha]
			[DefaultValue(typeof(Color), "120, 190, 255, 255")]
			public Color DamageMagic = new Color(120, 190, 255, 255);

			[Label("Magic Crit")]
			[Tooltip("Color of the crit damage numbers for Magic weapons")]
			[ColorNoAlpha]
			[DefaultValue(typeof(Color), "55, 130, 255, 255")]
			public Color CritDamageMagic = new Color(55, 130, 255, 255);

			[Label("Throwing")]
			[Tooltip("Color of the damage numbers for Throwing weapons")]
			[ColorNoAlpha]
			[DefaultValue(typeof(Color), "160, 110, 60, 255")]
			public Color DamageThrowing = new Color(160, 110, 60, 255);

			[Label("Throwing Crit")]
			[Tooltip("Color of the crit damage numbers for Throwing weapons")]
			[ColorNoAlpha]
			[DefaultValue(typeof(Color), "220, 135, 0, 255")]
			public Color CritDamageThrowing = new Color(220, 135, 0, 255);

			[Label("Summon")]
			[Tooltip("Color of the damage numbers for Summon weapons")]
			[ColorNoAlpha]
			[DefaultValue(typeof(Color), "255, 115, 195, 255")]
			public Color DamageSummon = new Color(255, 115, 195, 255);

			[Label("Summon Crit")]
			[Tooltip("Color of the crit damage numbers for Summon weapons (requires mod to actually allow summons to crit)")]
			[ColorNoAlpha]
			[DefaultValue(typeof(Color), "250, 80, 250, 255")]
			public Color CritDamageSummon = new Color(250, 80, 250, 255);

			[Label("Sentry")]
			[Tooltip("Color of the damage numbers for Sentry weapons")]
			[ColorNoAlpha]
			[DefaultValue(typeof(Color), "150, 115, 255, 255")]
			public Color DamageSentry = new Color(150, 115, 255, 255);

			[Label("Sentry Crit")]
			[Tooltip("Color of the crit damage numbers for Sentry weapons (requires mod to actually allow sentries to crit)")]
			[ColorNoAlpha]
			[DefaultValue(typeof(Color), "120, 70, 255, 255")]
			public Color CritDamageSentry = new Color(120, 70, 255, 255);

			[Header("[c/29dfff:Thorium]")]
			[Label("Radiant (Thorium)")]
			[Tooltip("Color of the damage numbers for Radiant weapons from Thorium mod")]
			[ColorNoAlpha]
			[DefaultValue(typeof(Color), "225, 225, 80, 255")]
			public Color DamageRadiant = new Color(225, 225, 80, 255);

			[Label("Radiant Crit (Thorium)")]
			[Tooltip("Color of the crit damage numbers for Radiant weapons from Thorium mod")]
			[ColorNoAlpha]
			[DefaultValue(typeof(Color), "255, 190, 0, 255")]
			public Color CritDamageRadiant = new Color(255, 190, 0, 255);

			[Label("Symphonic (Thorium)")]
			[Tooltip("Color of the damage numbers for Symphonic weapons from Thorium mod")]
			[ColorNoAlpha]
			[DefaultValue(typeof(Color), "0, 200, 140, 255")]
			public Color DamageSymphonic = new Color(0, 200, 140, 255);

			[Label("Symphonic Crit (Thorium)")]
			[Tooltip("Color of the crit damage numbers for Symphonic weapons from Thorium mod")]
			[ColorNoAlpha]
			[DefaultValue(typeof(Color), "45, 255, 205, 255")]
			public Color CritDamageSymphonic = new Color(45, 255, 205, 255);

			[Label("True (Thorium)")]
			[Tooltip("Color of the damage numbers for True weapons from Thorium mod")]
			[ColorNoAlpha]
			[DefaultValue(typeof(Color), "180, 180, 180, 255")]
			public Color DamageTrue = new Color(180, 180, 180, 255);

			[Label("True Crit (Thorium)")]
			[Tooltip("Color of the crit damage numbers for True weapons from Thorium mod")]
			[ColorNoAlpha]
			[DefaultValue(typeof(Color), "255, 255, 255, 255")]
			public Color CritDamageTrue = new Color(255, 255, 255, 255);

			[Header("[c/9f2284:Tremor]")]
			[Label("Alchemic (Tremor)")]
			[Tooltip("Color of the damage numbers for Alchemic weapons from Tremor mod")]
			[ColorNoAlpha]
			[DefaultValue(typeof(Color), "190, 90, 190, 255")]
			public Color DamageAlchemic = new Color(190, 90, 190, 255);

			[Label("Alchemic Crit(Tremor)")]
			[Tooltip("Color of the crit damage numbers for Alchemic weapons from Tremor mod")]
			[ColorNoAlpha]
			[DefaultValue(typeof(Color), "180, 30, 190, 255")]
			public Color CritDamageAlchemic = new Color(180, 30, 190, 255);

		}


		[Label("Debug Mode")]
		[Tooltip("Don't turn on.")]
		[DefaultValue(false)]
		public bool DebugMode { get; set; }

		[Label("Debug Mode Tooltips")]
		[Tooltip("Don't turn on.")]
		[DefaultValue(false)]
		public bool DebugModeTooltips { get; set; }
	}

}
