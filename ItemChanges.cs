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
			if ( Config.Instance.ChangeTooltipColor) {
				foreach (TooltipLine tooltip in tooltips) {
					//Main.NewText(tooltip.Name+": "+tooltip.text);
					//ColoredDamageTypes.Log(tooltip.Name + ": " + tooltip.mod+": "+": "+tooltip.text);
					Color newcolor = Color.White;
					switch (tooltip.Name) {
						case "Defense":
							newcolor = TooltipsConfig.Instance.BaseTT.TooltipDefense;
							break;
						case "Damage":
							DamageTypes.Types dmgtype = DamageTypes.GetType(item);
							//Main.NewText("its damage");
							switch (dmgtype) {
								case DamageTypes.Types.Melee:
									newcolor = TooltipsConfig.Instance.BaseTT.TooltipMelee;
									break;
								case DamageTypes.Types.Ranged:
									newcolor = TooltipsConfig.Instance.BaseTT.TooltipRanged;
									break;
								case DamageTypes.Types.Magic:
									newcolor = TooltipsConfig.Instance.BaseTT.TooltipMagic;
									break;
								case DamageTypes.Types.Thrown:
									newcolor = TooltipsConfig.Instance.BaseTT.TooltipThrowing;
									break;
								case DamageTypes.Types.Summon:
									newcolor = TooltipsConfig.Instance.BaseTT.TooltipSummon;
									break;
								case DamageTypes.Types.Sentry:
									newcolor = TooltipsConfig.Instance.BaseTT.TooltipSentry;
									break;
								case DamageTypes.Types.Radiant:
									newcolor = TooltipsConfig.Instance.ThoriumTT.TooltipRadiant;
									break;
								case DamageTypes.Types.Symphonic:
									newcolor = TooltipsConfig.Instance.ThoriumTT.TooltipSymphonic;
									break;
								case DamageTypes.Types.True:
									newcolor = TooltipsConfig.Instance.ThoriumTT.TooltipTrue;
									break;
								/*
								case DamageTypes.Types.Alchemic:
									newcolor = TooltipsConfig.Instance.TremorTT.TooltipAlchemic;
									break;
								*/
								default:
									break;
							}
							break;
					}
					if ( newcolor != Color.White ) tooltip.overrideColor = newcolor;
				}
			}
		}
	}

}
