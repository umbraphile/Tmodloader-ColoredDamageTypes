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
				DamageClass dmgtype = DamageTypes.GetType(item);

				if(Config.Instance.DebugMode) ColoredDamageTypes.Log("HitByItem: "+damage+item.Name + "/" + item.type + ": " + item.shoot+" "+ dmgtype.ToString());

				newcolor = DamageTypes.CheckDamageColor(dmgtype, crit, item.sentry);

				String dmgtypeString = dmgtype.ToString();
				CombatText recentct = Main.combatText[recent];
				recentct.color = newcolor;
				if(Config.Instance.ShowDamageNumbers == false)
				{
					recentct.active = false;
					return;
				}
				string npcIDString = npc.FullName + " " + npc.whoAmI;

				if (!ColoredDamageTypes.condense_totals.ContainsKey(npcIDString)) ColoredDamageTypes.condense_totals.Add(npcIDString, new Dictionary<string, int[]>());
				if (!ColoredDamageTypes.condense_totals[npcIDString].ContainsKey(dmgtypeString)) ColoredDamageTypes.condense_totals[npcIDString].Add(dmgtypeString, new int[] { 0, 0 });

				ColoredDamageTypes.condense_totals[npcIDString][dmgtypeString][0] += damage;
				if (Config.Instance.CondenseDamageHits > 0)
				{
					if (ColoredDamageTypes.condense_totals[npcIDString][dmgtypeString][1] < Config.Instance.CondenseDamageHits && npc.active)
					{
						ColoredDamageTypes.condense_totals[npcIDString][dmgtypeString][1]++;
						recentct.active = false;
					}
					else
					{
						recentct.text = ColoredDamageTypes.condense_totals[npcIDString][dmgtypeString][0].ToString();
						ColoredDamageTypes.condense_totals[npcIDString][dmgtypeString][0] = 0;
						ColoredDamageTypes.condense_totals[npcIDString][dmgtypeString][1] = 0;

						if (!npc.active && !Config.Instance.ShowCondenseDamageOnKill)
						{
							recentct.active = false;
							ColoredDamageTypes.condense_totals[npcIDString].Clear();
							ColoredDamageTypes.condense_totals.Remove(npcIDString);
						}
					}
				}
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
				DamageClass dmgtype = DamageTypes.GetType(projectile);

				if ( Config.Instance.DebugMode) ColoredDamageTypes.Log("HitByProjectile: " + damage+" "+projectile.Name+"/"+projectile.type+": "+dmgtype.ToString());

				newcolor = DamageTypes.CheckDamageColor(dmgtype, crit, projectile.sentry);


				String dmgtypeString = dmgtype.ToString();
				CombatText recentct = Main.combatText[recent];
				recentct.color = newcolor;
				if (Config.Instance.ShowDamageNumbers == false)
				{
					recentct.active = false;
					return;
				}
				string npcIDString = npc.FullName + " " + npc.whoAmI;

				if (!ColoredDamageTypes.condense_totals.ContainsKey(npcIDString)) ColoredDamageTypes.condense_totals.Add(npcIDString, new Dictionary<string, int[]>());
                if (!ColoredDamageTypes.condense_totals[npcIDString].ContainsKey(dmgtypeString)) ColoredDamageTypes.condense_totals[npcIDString].Add(dmgtypeString, new int[] { 0, 0 });

				ColoredDamageTypes.condense_totals[npcIDString][dmgtypeString][0] += damage;
				if (Config.Instance.CondenseDamageHits > 0)
				{
					if (ColoredDamageTypes.condense_totals[npcIDString][dmgtypeString][1] < Config.Instance.CondenseDamageHits && npc.active)
					{
						ColoredDamageTypes.condense_totals[npcIDString][dmgtypeString][1]++;
						recentct.active = false;
					}
					else
					{
						recentct.text = ColoredDamageTypes.condense_totals[npcIDString][dmgtypeString][0].ToString();
						ColoredDamageTypes.condense_totals[npcIDString][dmgtypeString][0] = 0;
						ColoredDamageTypes.condense_totals[npcIDString][dmgtypeString][1] = 0;

						if (!npc.active && !Config.Instance.ShowCondenseDamageOnKill)
						{
							recentct.active = false;
							ColoredDamageTypes.condense_totals[npcIDString].Clear();
							ColoredDamageTypes.condense_totals.Remove(npcIDString);
						}
					}
				}
			}
		}

		public override void ModifyHitByItem(NPC npc, Player player, Item item, ref int damage, ref float knockback, ref bool crit) {
			//TODO: Make numbers correspond to netcode damage type
			DamageClass dmgtype = DamageTypes.GetType(item);
			int outint = 0;
			if (dmgtype == DamageClass.Generic) outint = 0;
			else if (dmgtype == DamageClass.Melee) outint = 1;
			else if (dmgtype == DamageClass.Ranged) outint = 2;
			else if (dmgtype == DamageClass.Magic) outint = 3;
			else if (dmgtype == DamageClass.Summon) outint = 4;
			else if (dmgtype == ModContent.GetInstance<SentryClass>()) outint = 5;
			else if (dmgtype == DamageClass.Throwing) outint = 6;
			else
            {
				int indexfound = DamageTypes.DamageClasses.FindIndex(dt => dt == dmgtype);
				if (indexfound != -1) outint = 7 + indexfound + 1;
            }
			Netcode.recentcolor_out = outint;
			Netcode.recentdmg_out = damage;
			Netcode.recentkb_out = knockback;
			Netcode.recentcrit_out = (byte)(crit?1:0);
			
		}

		public override void ModifyHitByProjectile(NPC npc, Projectile projectile, ref int damage, ref float knockback, ref bool crit, ref int hitDirection)
		{
			//TODO: Make numbers correspond to netcode damage type
			DamageClass dmgtype = DamageTypes.GetType(projectile);
			int outint = 0;
			if (dmgtype == DamageClass.Generic) outint = 0;
			else if (dmgtype == DamageClass.Melee) outint = 1;
			else if (dmgtype == DamageClass.Ranged) outint = 2;
			else if (dmgtype == DamageClass.Magic) outint = 3;
			else if (dmgtype == DamageClass.Summon) outint = 4;
			else if (dmgtype == ModContent.GetInstance<SentryClass>()) outint = 5;
			else if (dmgtype == DamageClass.Throwing) outint = 6;
			else
			{
				int indexfound = DamageTypes.DamageClasses.FindIndex(dt => dt == dmgtype);
				if (indexfound != -1) outint = 7 + indexfound + 1;
			}
			Netcode.recentcolor_out = outint;
			Netcode.recentdmg_out = damage;
			Netcode.recentkb_out = knockback;
			Netcode.recentcrit_out = (byte)(crit?1:0);
		}
	}
}
