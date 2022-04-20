using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Terraria;
using Terraria.ModLoader;

namespace ColoredDamageTypes
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
							newcolor = TooltipsConfig.Instance.VanillaTT.TooltipDefense;
							break;
						case "Damage":
							DamageClass dmgtype = DamageTypes.GetType(item);
							//Main.NewText("its damage");
							if(dmgtype == DamageClass.Melee)
                            {
								newcolor = TooltipsConfig.Instance.VanillaTT.TooltipMelee;
							}
							else if (dmgtype == DamageClass.Ranged)
							{
								newcolor = TooltipsConfig.Instance.VanillaTT.TooltipRanged;
							}
							else if (dmgtype == DamageClass.Magic)
							{
								newcolor = TooltipsConfig.Instance.VanillaTT.TooltipMagic;
							}
							else if (dmgtype == DamageClass.Throwing)
							{
								newcolor = TooltipsConfig.Instance.VanillaTT.TooltipThrowing;
							}
							else if (dmgtype == DamageClass.Summon)
							{	
								if(item.sentry) newcolor = TooltipsConfig.Instance.VanillaTT.TooltipSentry;
								else newcolor = TooltipsConfig.Instance.VanillaTT.TooltipSummon;
							}
                            else if (dmgtype != DamageClass.Generic)
                            {
								newcolor = zCrossModConfig.CrossModDamageConfig_Orig[dmgtype.ToString()].TooltipColor;
                            }

							break;
					}
					if ( newcolor != Color.White ) tooltip.overrideColor = newcolor;
				}
			}
		}
	}

}
