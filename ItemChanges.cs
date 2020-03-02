using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
		public void UpdateToolTips(Item item, List<TooltipLine> tooltips) {
			if (ConfigUI.Instance.ChangeTooltipColor) {
				foreach (TooltipLine tooltip in tooltips) {
					//Main.NewText(tooltip.Name+": "+tooltip.text);
					Color newcolor = Color.White;
					switch (tooltip.Name) {
						case "Defense":
							newcolor = ConfigUI.Instance.TooltipsInstance.TooltipDefense;
							tooltip.overrideColor = newcolor;
							break;
						case "Damage":
							DamageTypes.Types dmgtype = DamageTypes.GetType(item);

							switch (dmgtype) {
								case DamageTypes.Types.Melee:
									newcolor = ConfigUI.Instance.TooltipsInstance.TooltipMelee;
									break;
								case DamageTypes.Types.Ranged:
									newcolor = ConfigUI.Instance.TooltipsInstance.TooltipRanged;
									break;
								case DamageTypes.Types.Magic:
									newcolor = ConfigUI.Instance.TooltipsInstance.TooltipMagic;
									break;
								case DamageTypes.Types.Thrown:
									newcolor = ConfigUI.Instance.TooltipsInstance.TooltipThrowing;
									break;
								case DamageTypes.Types.Summon:
									newcolor = ConfigUI.Instance.TooltipsInstance.TooltipSummon;
									break;
								case DamageTypes.Types.Sentry:
									newcolor = ConfigUI.Instance.TooltipsInstance.TooltipSentry;
									break;
								case DamageTypes.Types.Radiant:
									newcolor = ConfigUI.Instance.TooltipsInstance.TooltipRadiant;
									break;
								case DamageTypes.Types.Symphonic:
									newcolor = ConfigUI.Instance.TooltipsInstance.TooltipSymphonic;
									break;
								case DamageTypes.Types.True:
									newcolor = ConfigUI.Instance.TooltipsInstance.TooltipTrue;
									break;
								case DamageTypes.Types.Alchemic:
									newcolor = ConfigUI.Instance.TooltipsInstance.TooltipAlchemic;
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
