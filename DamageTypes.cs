using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ModLoader;
using Terraria.UI;
using System.Reflection;
using Microsoft.Xna.Framework;

namespace _ColoredDamageTypes
{
	class DamageTypes
	{
		public static Dictionary<string, Types> ProjectileOverrideList = new Dictionary<string, Types>() {
			{"Solar Eruption", Types.Melee },
			{"Ballista", Types.Sentry },
			{"Pygmy", Types.Summon },
			{"Consolaria.Projectiles.EasterEgg", Types.Ranged },
			{"ThoriumMod.Projectiles.LifeLight", Types.Melee },
			{"ThoriumMod.Projectiles.Minions.CreepingVineStaffPro", Types.Sentry },
			{"ThoriumMod.Projectiles.Minions.MoltenProtectorStaffPro", Types.Sentry },
			{"ThoriumMod.Projectiles.TorpedoPro2", Types.Ranged },
			{"ThoriumMod.Projectiles.MeteorPlasmaDamage", Types.Summon },
			{"ThoriumMod.Projectiles.GeyserSplash", Types.Magic },
			{"ThoriumMod.Projectiles.ReactionNitrogen", Types.Thrown },
			{"ThoriumMod.Projectiles.BlackDaggerPro",Types.Thrown },
			{"CrystiliumMod.Projectiles.SapphireSpike", Types.Summon },
			{"SacredTools.Projectiles.SpearOfJusticeProj", Types.Thrown },
			{"SacredTools.Projectiles.CrossProj", Types.Thrown },
			{"SacredTools.Projectiles.Minions.Frostfield", Types.Sentry },
			{"Fargowiltas.Projectiles.Minions.EaterBody", Types.Summon },
			{"Fargowiltas.Projectiles.Minions.EaterTail", Types.Summon },
			{"ThoriumMod.Projectiles.LanternFlame", Types.True },
			{"ThoriumMod.Projectiles.HexPro", Types.True },
			{"ThoriumMod.Projectiles.BowofLightPro2", Types.True },
			{"ThoriumMod.Projectiles.BowofLightPro3", Types.True },
			{"ThoriumMod.Projectiles.FrostGlandPro", Types.True },
			{"ThoriumMod.Projectiles.MJPro", Types.True },
			{"ThoriumMod.Projectiles.MJShock", Types.True },
			{"ThoriumMod.Projectiles.ThorBoom", Types.True },
			{"Tremor.Ice.Items.FrostLiquidFlaskPro", Types.Alchemic },
			{"Tremor.Projectiles.WallOfShadowsBoom", Types.Alchemic },
			{"Tremor.Projectiles.PlaguePro", Types.Alchemic },
			{"Tremor.Projectiles.Dukado", Types.Alchemic },
			{"Tremor.Projectiles.WallOfShadowsFlask_Proj", Types.Alchemic },
			{"SpiritMod.Projectiles.SadBeam", Types.Summon }
		};

		public static Dictionary<string, Types> ItemOverrideList = new Dictionary<string, Types>() {
			{"SacredTools.Items.Weapons.Decree.FrostGlobeStaff", Types.Sentry },
			{"SacredTools.Items.Weapons.Pumpkin.MoodSummon", Types.Sentry },
			{"SacredTools.Items.Weapons.Featherstorm", Types.Thrown },
			{"SacredTools.Items.Weapons.SpearOfJustice", Types.Thrown },
			{"SacredTools.Items.Weapons.TrueDecapitator", Types.Thrown },
			{"SacredTools.Items.Weapons.Trispear", Types.Thrown },
			{"ThoriumMod.Items.EnergyStorm.BoulderProbe", Types.Sentry },
			{"ThoriumMod.Items.SummonItems.CreepingVineStaff", Types.Sentry },
			{"ThoriumMod.Items.Donate.SilversBlade", Types.Sentry},
			{"ThoriumMod.Items.EndofDays.Mjölnir", Types.True },
			{"ThoriumMod.Items.Misc.Lantern", Types.True },
			{"ThoriumMod.Items.NPCItems.HexWand", Types.True },
			{"ThoriumMod.Items.Donate.BowofLight", Types.True },
			{"ThoriumMod.Items.Blizzard.FrostBurntTongue", Types.True},
			{"Tremor.Ice.Items.FrostLiquidFlask", Types.Alchemic },
			{"Tremor.Items.LesserHealingFlack", Types.Alchemic },
			{"Tremor.Items.BigHealingFlack", Types.Alchemic },
			{"SpiritMod.Items.Weapon.Summon.GloomgusStaff", Types.Summon },
			{"SpiritMod.Items.Weapon.Summon.BlueEyeStaff", Types.Sentry },
			{"FargowiltasSouls.Items.Weapons.BossDrops.HiveStaff", Types.Sentry }
		};


		public enum Types { Unknown, Melee, Ranged, Magic, Thrown, Summon, Sentry, Radiant, Symphonic, True, Alchemic }
		public static Types GetType(Item item)
		{
			//ThoriumMod Check

			if (ItemOverrideList.ContainsKey(item.Name)) {
				return ItemOverrideList[item.Name];
			}

			ModItem mitem = item.modItem;

			if (mitem != null) {
				Type mitemtype = mitem.GetType();
				if (ItemOverrideList.ContainsKey(mitemtype.ToString())) {
					return ItemOverrideList[mitemtype.ToString()];
				}
				if (Config.Instance.DebugMode && Config.Instance.DebugModeTooltips) ColoredDamageTypes.Log("Item: "+mitemtype.ToString());
			}

			if (ColoredDamageTypes.ThoriumMod != null && mitem != null && mitem.mod == ColoredDamageTypes.ThoriumMod) {
				Type mitemType = mitem.GetType();
				/*
				 * ColoredDamageTypes.Log("---------------------------------------");
				foreach ( FieldInfo f in mitemType.GetFields() ) {
					ColoredDamageTypes.Log(f.Name + ": " + f.FieldType+": "+f.Attributes+": "+f.GetValue(mitem));
				}
				*/
				var fieldRadiant = mitemType.GetField("radiant");
				var fieldSymphonic = mitemType.GetField("Empowerments");
				var fieldThrowing = mitemType.GetField("throwing");
				if (fieldRadiant != null && (bool)fieldRadiant.GetValue(mitem) == true) return Types.Radiant;
				else if (fieldSymphonic != null) return Types.Symphonic;
				else if (fieldThrowing != null && (bool)fieldThrowing.GetValue(mitem) == true) return Types.Thrown;
			}
			/*
			if (ColoredDamageTypes.TremorMod != null && mitem != null && mitem.mod == ColoredDamageTypes.TremorMod) {
				Type mitemType = mitem.GetType();
				string mitemTypestr = mitemType.ToString();
				bool isAlchemic = mitemTypestr.Contains("Alchemist.") || mitemTypestr.Contains("Alchemic.") || mitemTypestr.Contains("NovaPillar.");
				if (mitemType != null && isAlchemic == true) return Types.Alchemic;
			}
			*/

			if (item.melee && !item.magic && !item.thrown) return Types.Melee;
			else if (item.ranged && !item.magic && !item.thrown) return Types.Ranged;
			else if (item.magic) return Types.Magic;
			else if (item.thrown) return Types.Thrown;
			else if (item.sentry) return Types.Sentry;
			else if (item.summon) return Types.Summon;

			return Types.Unknown;
		}

		public static Types GetType(Projectile projectile)
		{
			if (ProjectileOverrideList.ContainsKey(projectile.Name)) {
				return ProjectileOverrideList[projectile.Name];
			}

			ModProjectile mproj = projectile.modProjectile;
			if (mproj != null) {
				Type mprojtype = mproj.GetType();

				if (ProjectileOverrideList.ContainsKey(mprojtype.ToString())) {
					return ProjectileOverrideList[mprojtype.ToString()];
				}
				if (Config.Instance.DebugMode) ColoredDamageTypes.Log("Projectile: "+mprojtype.ToString());
			}

			//ThoriumMod Check
			if (ColoredDamageTypes.ThoriumMod != null && mproj != null && mproj.mod == ColoredDamageTypes.ThoriumMod) {
				Type mprojtype = mproj.GetType();
				string typestr = mprojtype.ToString();
				if (typestr.Contains("ThoriumMod.Projectiles.Scythe") || typestr.Contains("ThoriumMod.Projectiles.Healer")) return Types.Radiant;
				else if (typestr.Contains("ThoriumMod.Projectiles.Bard")) return Types.Symphonic;
				else if (typestr.Contains("ThoriumMod.Items.ThrownItems")) return Types.Thrown;
			}
			/*
			if (ColoredDamageTypes.TremorMod != null && mproj != null && mproj.mod == ColoredDamageTypes.TremorMod) {
				Type mprojType = mproj.GetType();
				string mitemTypestr = mprojType.ToString();
				bool isAlchemic = mitemTypestr.Contains("Alchemist.") || mitemTypestr.Contains("Alchemic.") || mitemTypestr.Contains("NovaPillar.");
				if (mprojType != null && isAlchemic == true) return Types.Alchemic;
			}
			*/

			Item item = null;
			Item selecteditem = Main.player[projectile.owner].inventory[Main.player[projectile.owner].selectedItem];
			ProjectileTypeCheck(projectile, selecteditem, ref item);

			if(item == null) {
				foreach (Item i in Main.player[projectile.owner].inventory) {
					if (i.shoot == projectile.type) {
						item = i;
						break;
					}
				}
			}
			if (item != null) { // Found item in inventory
				return GetType(item);
			}
			else { // Didn't find item. Use projectile type
				int fromsummon = 0;

				for (int i = 0; i < 1000; i++) {
					Projectile CheckProjectile = Main.projectile[i];
					if (CheckProjectile.active && (CheckProjectile.sentry) && CheckProjectile.type + 1 == projectile.type) {
						fromsummon = 2; // Is a sentry
						break;
					}
					else if (CheckProjectile.active && (CheckProjectile.minion) && CheckProjectile.type + 1 == projectile.type) {
						fromsummon = 1; // Is a minion
						break;
					}
				}

				if (projectile.melee && !projectile.magic && !projectile.thrown) return Types.Melee;
				else if (projectile.ranged && !projectile.magic && !projectile.thrown) return Types.Ranged;
				else if (projectile.magic) return Types.Magic;
				else if (projectile.thrown) return Types.Thrown;
				else if (fromsummon == 2 || projectile.sentry) return Types.Sentry;
				else if (fromsummon == 1 || projectile.minion) return Types.Summon;

				return Types.Unknown;
			}
		}

		public static void ProjectileTypeCheck(Projectile projectile, Item item, ref Item returnitem)
		{
			Dictionary<int, int[]> ProjectileTypeOverride = new Dictionary<int, int[]>() {
					{469, new int[]{181,566 } }
				};

			string[] ProjectileTypeNameOverride = new string[] {"CrystiliumMod.Projectiles.DiamondBomb","CrystiliumMod.Projectiles.Shatter1",
				"CrystiliumMod.Projectiles.Shatter2","CrystiliumMod.Projectiles.Shatter3","SacredTools.Projectiles.FrostExplosion","SacredTools.Projectiles.CerniumMist",
			"SacredTools.Projectiles.DarkExplosion","SacredTools.Projectiles.FlameExplosion","SacredTools.Projectiles.JusticeSpark", "SpiritMod.Projectiles.Fire"};

			if (item.shoot == projectile.type || (ProjectileTypeOverride.ContainsKey(item.shoot) && ProjectileTypeOverride[item.shoot].Contains(projectile.type))) {
				returnitem = item;
			}
			else {
				ModProjectile mproj = projectile.modProjectile;
				if (mproj != null) {
					Type mprojtype = mproj.GetType();
					//Main.NewText(mprojtype.ToString());
					if (ProjectileTypeNameOverride.Contains(mprojtype.ToString())){
						returnitem = ColoredDamageTypes.ProjectileWeaponSpawns[projectile.identity];
					}

				}
			}
		}


		public static Color CheckDamageColor(Types dmgtype, bool crit) {
			Color newcolor;
			switch ( dmgtype ) {
				case Types.Melee:
					newcolor = crit ? DamageConfig.Instance.BaseDmg.MeleeDmg.MeleeDamageCrit : DamageConfig.Instance.BaseDmg.MeleeDmg.MeleeDamage;
					break;
				case Types.Ranged:
					newcolor = crit ? DamageConfig.Instance.BaseDmg.RangedDmg.RangedDamageCrit : DamageConfig.Instance.BaseDmg.RangedDmg.RangedDamage;
					break;
				case Types.Magic:
					newcolor = crit ? DamageConfig.Instance.BaseDmg.MagicDmg.MagicDamageCrit : DamageConfig.Instance.BaseDmg.MagicDmg.MagicDamage;
					break;
				case Types.Thrown:
					newcolor = crit ? DamageConfig.Instance.BaseDmg.ThrowingDmg.ThrowingDamageCrit : DamageConfig.Instance.BaseDmg.ThrowingDmg.ThrowingDamage;
					break;
				case Types.Summon:
					newcolor = crit ? DamageConfig.Instance.BaseDmg.SummonDmg.SummonDamageCrit : DamageConfig.Instance.BaseDmg.SummonDmg.SummonDamage;
					break;
				case Types.Sentry:
					newcolor = crit ? DamageConfig.Instance.BaseDmg.SentryDmg.SentryDamageCrit : DamageConfig.Instance.BaseDmg.SentryDmg.SentryDamage;
					break;
				case Types.Radiant:
					newcolor = crit ? DamageConfig.Instance.ThoriumDmg.RadiantDmg.RadiantDamageCrit : DamageConfig.Instance.ThoriumDmg.RadiantDmg.RadiantDamage;
					break;
				case Types.Symphonic:
					newcolor = crit ? DamageConfig.Instance.ThoriumDmg.SymphonicDmg.SymphonicDamageCrit : DamageConfig.Instance.ThoriumDmg.SymphonicDmg.SymphonicDamage;
					break;
				case Types.True:
					newcolor = crit ? DamageConfig.Instance.ThoriumDmg.TrueDmg.TrueDamageCrit : DamageConfig.Instance.ThoriumDmg.TrueDmg.TrueDamage;
					break;
				/*
				case Types.Alchemic:
					newcolor = crit ? DamageConfig.Instance.TremorDmg.AlchemicDmg.AlchemicDamageCrit : DamageConfig.Instance.TremorDmg.AlchemicDmg.AlchemicDamage;
					break;
				*/
				case Types.Unknown:
					newcolor = crit ? CombatText.DamagedHostileCrit : CombatText.DamagedHostile;
					break;
				default:
					newcolor = crit ? CombatText.DamagedHostileCrit : CombatText.DamagedHostile;
					break;
			}
			return newcolor;
		}
	}
}
