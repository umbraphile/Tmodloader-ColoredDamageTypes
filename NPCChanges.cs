using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ModLoader;
using System.Reflection;
using Terraria.ID;

namespace _ColoredDamageTypes
{
	class NPCChanges : GlobalNPC
	{
		//public override void UpdateLifeRegen(NPC npc, ref int damage)
		//{

		//}

		public Color CheckDamageColor(DamageTypes.Types dmgtype, bool crit) {
			Color newcolor;
			switch ( dmgtype ) {
				case DamageTypes.Types.Melee:
					newcolor = crit ? ConfigUI.Instance.DamageInstance.CritDamageMelee : ConfigUI.Instance.DamageInstance.DamageMelee;
					break;
				case DamageTypes.Types.Ranged:
					newcolor = crit ? ConfigUI.Instance.DamageInstance.CritDamageRanged : ConfigUI.Instance.DamageInstance.DamageRanged;
					break;
				case DamageTypes.Types.Magic:
					newcolor = crit ? ConfigUI.Instance.DamageInstance.CritDamageMagic : ConfigUI.Instance.DamageInstance.DamageMagic;
					break;
				case DamageTypes.Types.Thrown:
					newcolor = crit ? ConfigUI.Instance.DamageInstance.CritDamageThrowing : ConfigUI.Instance.DamageInstance.DamageThrowing;
					break;
				case DamageTypes.Types.Summon:
					newcolor = crit ? ConfigUI.Instance.DamageInstance.CritDamageSummon : ConfigUI.Instance.DamageInstance.DamageSummon;
					break;
				case DamageTypes.Types.Sentry:
					newcolor = crit ? ConfigUI.Instance.DamageInstance.CritDamageSentry : ConfigUI.Instance.DamageInstance.DamageSentry;
					break;
				case DamageTypes.Types.Radiant:
					newcolor = crit ? ConfigUI.Instance.DamageInstance.CritDamageRadiant : ConfigUI.Instance.DamageInstance.DamageRadiant;
					break;
				case DamageTypes.Types.Symphonic:
					newcolor = crit ? ConfigUI.Instance.DamageInstance.CritDamageSymphonic : ConfigUI.Instance.DamageInstance.DamageSymphonic;
					break;
				case DamageTypes.Types.True:
					newcolor = crit ? ConfigUI.Instance.DamageInstance.CritDamageTrue : ConfigUI.Instance.DamageInstance.DamageTrue;
					break;
				case DamageTypes.Types.Alchemic:
					newcolor = crit ? ConfigUI.Instance.DamageInstance.CritDamageAlchemic : ConfigUI.Instance.DamageInstance.DamageAlchemic;
					break;
				default:
					newcolor = new Color(0, 0, 0, 0); 
					break;
			}
			return newcolor;
		}
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

				if(ConfigUI.Instance.DebugMode) ColoredDamageTypes.Log("HitByItem: "+damage+item.Name + "/" + item.type + ": " + item.shoot+" "+ dmgtype.ToString());

				newcolor = CheckDamageColor(dmgtype, crit);

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

				if (ConfigUI.Instance.DebugMode) ColoredDamageTypes.Log("HitByProjectile: " + damage+" "+projectile.Name+"/"+projectile.type+": "+dmgtype.ToString());

				newcolor = CheckDamageColor(dmgtype, crit);

				//CombatText.NewText(new Rectangle((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height), newcolor, damage, crit, false);

				ColoredDamageTypes.instance.SendColorPacket(newcolor.R, newcolor.G, newcolor.B, newcolor.A, damage, crit);
				Main.combatText[recent].color = newcolor;
			}
		}
	}
}
