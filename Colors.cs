using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace _ColoredDamageTypes
{
	class Colors
	{
		public static Color			TooltipDefense = new Color(140, 160, 140),
									TooltipMelee = new Color(235, 25, 25),
									TooltipRanged = new Color(0, 180, 60),
									TooltipMagic = new Color(15, 135, 255),
									TooltipThrown = new Color(255, 120, 25),
									TooltipSummon = new Color(255, 115, 195),
									TooltipSentry = new Color(150, 115, 255),
									TooltipRadiant = new Color(225, 225, 80),
									TooltipSymphonic = new Color(140,220,210),
									TooltipTrue = new Color(170, 170, 170),
									TooltipAlchemic = new Color(190, 90, 190),

									DamageMelee = new Color(170, 0, 0),
									DamageRanged = new Color(150, 225, 155),
									DamageMagic = new Color(120, 190, 255),
									DamageThrown = new Color(160, 110, 60),
									DamageSummon = new Color(255, 115, 195),
									DamageSentry = new Color(150, 115, 255),
									DamageRadiant = new Color(225, 225, 80),
									DamageSymphonic = new Color(0, 200, 140),
									DamageTrue = new Color(180, 180, 180),
									DamageAlchemic = new Color(190, 90, 190),


									CritDamageMelee = new Color(255, 10, 50),
									CritDamageRanged = new Color(30, 205, 90),
									CritDamageMagic = new Color(55, 130, 255),
									CritDamageThrown = new Color(220, 135, 0),
									CritDamageSummon = new Color(250, 80, 250),
									CritDamageSentry = new Color(120, 68, 255),
									CritDamageRadiant = new Color(255, 190, 0),
									CritDamageSymphonic = new Color(45, 255, 205),
									CritDamageTrue = new Color(255, 255, 255),
									CritDamageAlchemic = new Color(180, 30, 190);


		public static string ToRGB(Color c)
		{
			return c.R + ", " + c.G + ", " + c.B;
		}

		public static Color StringToColor(string s)
		{
			string regexrgb = @"^\d{1,3}, ?\d{1,3}, ?\d{1,3}";
			string regexhex = @"^(#[a-fA-F0-9]{6})|(#[a-fA-F0-9]{3})$";
			if (Regex.IsMatch(s,regexrgb)) {
				string[] splitString = s.Split(',');
				int r, g, b;
				if (Int32.TryParse(splitString[0], out r) && Int32.TryParse(splitString[1], out g) && Int32.TryParse(splitString[2], out b)) {
					return new Color(r, g, b);
				}
				else {
					ColoredDamageTypes.Log("Could not parse rgb color: " + s);
					return Color.Black;
				}
			}
			if (Regex.IsMatch(s, regexhex)) {
				int r, g, b;
				if (s.Length == 7) {
					r = Convert.ToInt32(s.Substring(1, 2), 16);
					g = Convert.ToInt32(s.Substring(3, 2), 16);
					b = Convert.ToInt32(s.Substring(5, 2), 16);
					return new Color(r, g, b);
				}
				else if (s.Length == 4) {
					r = Convert.ToInt32(s.Substring(1, 1) + s.Substring(1, 1), 16);
					g = Convert.ToInt32(s.Substring(2, 1) + s.Substring(2, 1), 16);
					b = Convert.ToInt32(s.Substring(3, 1) + s.Substring(3, 1), 16);
					return new Color(r, g, b);
				}

				else {
					ColoredDamageTypes.Log("Could not parse hex color: " + s);
					return Color.Black;
				}
			}
			else {
				ColoredDamageTypes.Log("Could not parse color type: " + s);
				return Color.Black;
			}
		}
	}
}