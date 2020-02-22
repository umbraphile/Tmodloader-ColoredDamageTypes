using Microsoft.Xna.Framework;
using System.Collections.Generic;
using System.ComponentModel;
using Terraria;
using Terraria.Localization;
using Terraria.ModLoader.Config;


namespace _ColoredDamageTypes
{
	[Label("Config")]
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


		[DefaultValue(typeof(Color), "87, 181, 92, 255")]
		[Label("Color")]
		[Tooltip("Color")]
		public Color Color1 { get; set; }

		[Label("Debug Mode")]
		[Tooltip("Debug Mode.")]
		[DefaultValue(false)]
		public bool DebugMode { get; set; }
	}

}
