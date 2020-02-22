using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ModLoader;

namespace _ColoredDamageTypes
{
	public class ItemChanges : GlobalItem
	{

		public override void ModifyTooltips(Item item, List<TooltipLine> tooltips)
		{
			UpdateToolTips(item, tooltips);
		}

		public async void UpdateToolTips(Item item, List<TooltipLine> tooltips) {
			await Task.Delay(0);
			if (ConfigUI.Instance.ChangeTooltipColor) {
				foreach (TooltipLine tooltip in tooltips) {
					//Main.NewText(tooltip.Name+": "+tooltip.text);
					Color newcolor = Color.White;
					switch (tooltip.Name) {
						case "Defense":
							newcolor = Colors.TooltipDefense;
							tooltip.overrideColor = newcolor;
							break;
						case "Damage":
							DamageTypes.Types dmgtype = DamageTypes.GetType(item);

							switch (dmgtype) {
								case DamageTypes.Types.Melee:
									newcolor = Colors.TooltipMelee;
									break;
								case DamageTypes.Types.Ranged:
									newcolor = Colors.TooltipRanged;
									break;
								case DamageTypes.Types.Magic:
									newcolor = Colors.TooltipMagic;
									break;
								case DamageTypes.Types.Thrown:
									newcolor = Colors.TooltipThrown;
									break;
								case DamageTypes.Types.Summon:
									newcolor = Colors.TooltipSummon;
									break;
								case DamageTypes.Types.Sentry:
									newcolor = Colors.TooltipSentry;
									break;
								case DamageTypes.Types.Radiant:
									newcolor = Colors.TooltipRadiant;
									break;
								case DamageTypes.Types.Symphonic:
									newcolor = Colors.TooltipSymphonic;
									break;
								case DamageTypes.Types.True:
									newcolor = Colors.TooltipTrue;
									break;
								case DamageTypes.Types.Alchemic:
									newcolor = Colors.TooltipAlchemic;
									break;
								default:
									break;
							}
							if (newcolor != Color.White) tooltip.overrideColor = newcolor;
							break;
					}
				}
			}
		}
	}

}
