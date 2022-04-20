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
							DamageTypes.Types dmgtype = DamageTypes.GetType(item);
							//Main.NewText("its damage");
							switch (dmgtype) {
								case DamageTypes.Types.Melee:
									newcolor = TooltipsConfig.Instance.VanillaTT.TooltipMelee;
									break;
								case DamageTypes.Types.Ranged:
									newcolor = TooltipsConfig.Instance.VanillaTT.TooltipRanged;
									break;
								case DamageTypes.Types.Magic:
									newcolor = TooltipsConfig.Instance.VanillaTT.TooltipMagic;
									break;
								case DamageTypes.Types.Thrown:
									newcolor = TooltipsConfig.Instance.VanillaTT.TooltipThrowing;
									break;
								case DamageTypes.Types.Summon:
									newcolor = TooltipsConfig.Instance.VanillaTT.TooltipSummon;
									break;
								case DamageTypes.Types.Sentry:
									newcolor = TooltipsConfig.Instance.VanillaTT.TooltipSentry;
									break;
								/*case DamageTypes.Types.Radiant:
									newcolor = TooltipsConfig.Instance.ThoriumTT.TooltipRadiant;
									break;
								case DamageTypes.Types.Symphonic:
									newcolor = TooltipsConfig.Instance.ThoriumTT.TooltipSymphonic;
									break;
								case DamageTypes.Types.True:
									newcolor = TooltipsConfig.Instance.ThoriumTT.TooltipTrue;
									break;
								case DamageTypes.Types.Druidic:
									newcolor = TooltipsConfig.Instance.RedemptionTT.TooltipDruidic;
									break;
								case DamageTypes.Types.Mystic:
									newcolor = TooltipsConfig.Instance.EnigmaTT.TooltipMystic;
									break;
								case DamageTypes.Types.Ki:
									newcolor = TooltipsConfig.Instance.DbzModTT.TooltipKi;
									break;
								case DamageTypes.Types.Rogue:
									newcolor = TooltipsConfig.Instance.CalamityTT.TooltipRogue;
									break;
								case DamageTypes.Types.Fishing:
									newcolor = TooltipsConfig.Instance.BattleRodsTT.TooltipFishing;
									break;
								case DamageTypes.Types.Click:
									newcolor = TooltipsConfig.Instance.ClickerModTT.TooltipClicker;
									break;*/
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
