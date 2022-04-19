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

namespace ColoredDamageTypes
{
	class NPCChanges : GlobalNPC
	{
		//public override void UpdateLifeRegen(NPC npc, ref int damage)
		//{

		//}

		public override void OnHitByItem(NPC npc, Player player, Item item, int damage, float knockback, bool crit)
		{
			if (!Config.Instance.ChangeDamageColor) return;

			int recent = -1;
			for (int i = 99; i >= 0; i--) {
				CombatText ctToCheck = Main.combatText[i];
				if (ctToCheck.lifeTime == 60 || ctToCheck.lifeTime == 120 || (ctToCheck.dot && ctToCheck.lifeTime == 40)) {
					if(ctToCheck.alpha == 1f) {
						if ( (ctToCheck.color == CombatText.DamagedHostile || ctToCheck.color == CombatText.DamagedHostileCrit) ) {
							recent = i;
							break;
						}
					}
				}
			}
			if (recent == -1) return;
			else {
				Color newcolor;
				DamageTypes.Types dmgtype = DamageTypes.GetType(item);

				if(Config.Instance.DebugMode) ColoredDamageTypes.Log("HitByItem: "+damage+item.Name + "/" + item.type + ": " + item.shoot+" "+ dmgtype.ToString());

				newcolor = DamageTypes.CheckDamageColor(dmgtype, crit);

				Main.combatText[recent].color = newcolor;
				Main.combatText[recent].active = Config.Instance.ShowDamageNumbers;
			}
		}

		public override void OnHitByProjectile(NPC npc, Projectile projectile, int damage, float knockback, bool crit)
		{

			if (!Config.Instance.ChangeDamageColor) return;

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

				if ( Config.Instance.DebugMode) ColoredDamageTypes.Log("HitByProjectile: " + damage+" "+projectile.Name+"/"+projectile.type+": "+dmgtype.ToString());

				newcolor = DamageTypes.CheckDamageColor(dmgtype, crit);

				//Main.combatText[recent].active = false;
				//Main.combatText[recent].lifeTime = 0;
				//CombatText.NewText(new Rectangle((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height), newcolor, damage, crit, false);
				//NetMessage.SendData
				//ColoredDamageTypes.instance.SendColorPacket(newcolor.R, newcolor.G, newcolor.B, newcolor.A, damage, crit);
				Main.combatText[recent].color = newcolor;
				Main.combatText[recent].active = Config.Instance.ShowDamageNumbers;
			}
		}

		public override void ModifyHitByItem(NPC npc, Player player, Item item, ref int damage, ref float knockback, ref bool crit) {
			Netcode.recentcolor_out = DamageTypes.GetType(item);
			Netcode.recentdmg_out = damage;
			Netcode.recentkb_out = knockback;
			Netcode.recentcrit_out = (byte)(crit?1:0);
			
		}

		public override void ModifyHitByProjectile(NPC npc, Projectile projectile, ref int damage, ref float knockback, ref bool crit, ref int hitDirection) {
			Netcode.recentcolor_out = DamageTypes.GetType(projectile);
			Netcode.recentdmg_out = damage;
			Netcode.recentkb_out = knockback;
			Netcode.recentcrit_out = (byte)(crit?1:0);
		}
	}
}
