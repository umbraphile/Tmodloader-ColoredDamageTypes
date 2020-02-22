using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ModLoader;
using System.Reflection;

namespace _ColoredDamageTypes
{
	class NPCChanges : GlobalNPC
	{
		//public override void UpdateLifeRegen(NPC npc, ref int damage)
		//{

		//}
		public override void OnHitByItem(NPC npc, Player player, Item item, int damage, float knockback, bool crit)
		{
			if (!ConfigUI.Instance.ChangeDamageColor) return;

			int recent = -1;
			for (int i = 99; i >= 0; i--) {
				CombatText ctToCheck = Main.combatText[i];
				if (ctToCheck.lifeTime == 60 || ctToCheck.lifeTime == 120 || (ctToCheck.dot && ctToCheck.lifeTime == 40)) {
					if(ctToCheck.alpha == 1f){
						recent = i;
						break;
					}
				}
			}
			if (recent == -1) return;
			else {
				Color newcolor;
				DamageTypes.Types dmgtype = DamageTypes.GetType(item);

				if(ColoredDamageTypes.debug) ColoredDamageTypes.Log("HitByItem: "+damage+item.Name + "/" + item.type + ": " + item.shoot+" "+ dmgtype.ToString());

				switch (dmgtype) {
					case DamageTypes.Types.Melee:
						newcolor = crit ? Colors.CritDamageMelee : Colors.DamageMelee;
						break;
					case DamageTypes.Types.Ranged:
						newcolor = crit ? Colors.CritDamageRanged : Colors.DamageRanged;
						break;
					case DamageTypes.Types.Magic:
						newcolor = crit ? Colors.CritDamageMagic : Colors.DamageMagic;
						break;
					case DamageTypes.Types.Thrown:
						newcolor = crit ? Colors.CritDamageThrown : Colors.DamageThrown;
						break;
					case DamageTypes.Types.Summon:
						newcolor = crit ? Colors.CritDamageSummon : Colors.DamageSummon;
						break;
					case DamageTypes.Types.Sentry:
						newcolor = crit ? Colors.CritDamageSentry : Colors.DamageSentry;
						break;
					case DamageTypes.Types.Radiant:
						newcolor = crit ? Colors.CritDamageRadiant : Colors.DamageRadiant;
						break;
					case DamageTypes.Types.Symphonic:
						newcolor = crit ? Colors.CritDamageSymphonic : Colors.DamageSymphonic;
						break;
					case DamageTypes.Types.True:
						newcolor = crit ? Colors.CritDamageTrue : Colors.DamageTrue;
						break;
					case DamageTypes.Types.Alchemic:
						newcolor = crit ? Colors.CritDamageAlchemic : Colors.DamageAlchemic;
						break;
					default:
						return;
				}

				Main.combatText[recent].color = newcolor;
			}
		}

		public override void OnHitByProjectile(NPC npc, Projectile projectile, int damage, float knockback, bool crit)
		{

			if (!ConfigUI.Instance.ChangeDamageColor) return;

			int recent = -1;
			for (int i = 99; i >= 0; i--) {
				CombatText ctToCheck = Main.combatText[i];
				if (ctToCheck.lifeTime == 60 || ctToCheck.lifeTime == 120) {
					if(ctToCheck.alpha == 1f) {
						if((ctToCheck.color == CombatText.DamagedHostile || ctToCheck.color == CombatText.DamagedHostileCrit)) {
							recent = i;
							break;
						}
					}
				}
			}
			if (recent == -1) return;
			else {
				Color newcolor;
				DamageTypes.Types dmgtype = DamageTypes.GetType(projectile);

				if (ColoredDamageTypes.debug) ColoredDamageTypes.Log("HitByProjectile: " + damage+" "+projectile.Name+"/"+projectile.type+": "+dmgtype.ToString());

				switch (dmgtype) {
					case DamageTypes.Types.Melee:
						newcolor = crit ? Colors.CritDamageMelee : Colors.DamageMelee;
						break;
					case DamageTypes.Types.Ranged:
						newcolor = crit ? Colors.CritDamageRanged : Colors.DamageRanged;
						break;
					case DamageTypes.Types.Magic:
						newcolor = crit ? Colors.CritDamageMagic : Colors.DamageMagic;
						break;
					case DamageTypes.Types.Thrown:
						newcolor = crit ? Colors.CritDamageThrown : Colors.DamageThrown;
						break;
					case DamageTypes.Types.Summon:
						newcolor = crit ? Colors.CritDamageSummon : Colors.DamageSummon;
						break;
					case DamageTypes.Types.Sentry:
						newcolor = crit ? Colors.CritDamageSentry : Colors.DamageSentry;
						break;
					case DamageTypes.Types.Radiant:
						newcolor = crit ? Colors.CritDamageRadiant : Colors.DamageRadiant;
						break;
					case DamageTypes.Types.Symphonic:
						newcolor = crit ? Colors.CritDamageSymphonic : Colors.DamageSymphonic;
						break;
					case DamageTypes.Types.True:
						newcolor = crit ? Colors.CritDamageTrue : Colors.DamageTrue;
						break;
					case DamageTypes.Types.Alchemic:
						newcolor = crit ? Colors.CritDamageAlchemic : Colors.DamageAlchemic;
						break;
					default:
						return;
				}

				Main.combatText[recent].color = newcolor;
			}
		}
	}
}
