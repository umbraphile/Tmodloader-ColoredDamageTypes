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

namespace ColoredDamageTypes
{
	class DamageTypes {
		public static Dictionary<string, Types> ProjectileOverrideList = new Dictionary<string, Types>() {
			{"Solar Eruption", Types.Melee },
			{"Ballista", Types.Sentry },
			{"Pygmy", Types.Summon },
			{"Baby Spider", Types.Sentry },
			{"Molotov Fire", Types.Thrown },
			{"UFO Ray", Types.Summon },
			//{"Influx Waver", Types.Melee },
			{"SpiritMod.Projectiles.DonatorItems.FlambergeProjectile", Types.Melee },
			{"QwertysRandomContent.Items.BladeBossItems.Imperious", Types.Summon },
			{"AmuletOfManyMinions.Projectiles.Minions.SpiritGun.SpiritGunMinionBullet", Types.Summon },
			{"AmuletOfManyMinions.Projectiles.Minions.CharredChimera.CharredChimeraMinionHead", Types.Summon },
			{"AmuletOfManyMinions.Projectiles.Squires.AncientCobaltSquire.AncientCobaltBolt", Types.Summon },
			{"AmuletOfManyMinions.Projectiles.Squires.GuideSquire.GuideArrow", Types.Summon },
			{"AmuletOfManyMinions.Projectiles.Minions.EclipseHerald.EclipseSphere", Types.Summon },
			{"AmuletOfManyMinions.Projectiles.Squires.StardustSquire.StardustBeastProjectile", Types.Summon },
			{"SpiritMod.Projectiles.SpiritStar", Types.Summon },
			{"Laugicality.Projectiles.Melee.DawnStar", Types.Melee },
			{"CalamityMod.Items.Weapons", Types.Rogue },
			{"Split.Projectiles.Arrows.LightningArrow", Types.Ranged },
			{"Split.Projectiles.Arrows.FlareArrow", Types.Ranged },
			{"Split.Projectiles.Arrows.FlareArrowSpirit", Types.Ranged }, 
			{"Split.Projectiles.Melee.ElectricBlast", Types.Melee },
			{"Split.Projectiles.Magic.FullColorEmerald", Types.Magic },
			{"Split.Projectiles.Magic.FullColorBoom", Types.Magic },
			{"Split.Projectiles.Magic.FullColorSapphire", Types.Magic },
			{"Split.Projectiles.Magic.FullColorRuby", Types.Magic },
			{"Split.Projectiles.Magic.FullColorDiamond", Types.Magic },
			{"Split.Projectiles.Magic.FullColorTopaz", Types.Magic },
			{"Split.Projectiles.Magic.StepFlamesDiamond", Types.Magic },
			{"SpiritMod.Projectiles.Fire", Types.Sentry },
			{"SpiritMod.NPCs.Boss.Dusking.CrystalShadow", Types.Sentry },
			{"SpiritMod.Items.Weapon.Magic.ShadowSphere", Types.Sentry },
			{"SpiritMod.Projectiles.DonatorItems.Wrath", Types.Magic },
			{"SpiritMod.Projectiles.Magic.Blood3", Types.Magic },
			{"SpiritMod.Projectiles.Magic.CorruptPortal_Star", Types.Magic },
			{"SpiritMod.Projectiles.GraniteShard1", Types.Melee },
			{"SpiritMod.Projectiles.Magic.GraniteSpike1", Types.Melee },
			{"SpiritMod.Projectiles.Summon.Artifact.WitherShard3", Types.Summon },
			{"SpiritMod.Projectiles.Summon.Dragon.DragonTailOne", Types.Summon },
			{"SpiritMod.Projectiles.Summon.Dragon.DragonTailTwo", Types.Summon },
			{"SpiritMod.Projectiles.Summon.Dragon.DragonHeadOne", Types.Summon },
			{"SpiritMod.Projectiles.Summon.Dragon.DragonBodyOne", Types.Summon },
			{"SpiritMod.Projectiles.Summon.Dragon.DragonHeadTwo", Types.Summon },
			{"SpiritMod.Projectiles.Summon.Dragon.DragonBodyTwo", Types.Summon }, 
			{"SpiritMod.Projectiles.Blaze", Types.Magic },
			{"ThoriumMod.Projectiles.IcyGazePro", Types.True },
			{"ThoriumMod.Projectiles.Minions.AstroSetPro", Types.Summon },
			{"ThoriumMod.Projectiles.ObsidianStaffPro2", Types.Magic },
			{"ThoriumMod.Projectiles.Minions.GasterBlast", Types.Sentry },
			{"ThoriumMod.Projectiles.Minions.SapSpider", Types.Summon },
			{"ThoriumMod.Projectiles.Thrower.ThrowingGuideFollowup", Types.True },
			{"ThoriumMod.Projectiles.Minions.Spark", Types.Summon },
			{"ThoriumMod.Projectiles.Minions.SnowmanBombBoom", Types.Summon },
			{"ThoriumMod.Projectiles.Minions.StrongestLinkPro", Types.Sentry },
			{"ThoriumMod.Projectiles.Minions.MortarFriendly", Types.Sentry },
			{"ThoriumMod.Projectiles.Minions.ValeforPro3", Types.Sentry },
			{"ThoriumMod.Projectiles.Minions.UFOTurret3", Types.Sentry },
			{"ThoriumMod.Projectiles.FieryTotemPro", Types.Sentry },
			{"ThoriumMod.Projectiles.DummyDamage", Types.Unknown },
			{"ThoriumMod.Projectiles.LifeLight", Types.Melee },
			{"ThoriumMod.Projectiles.CorruptionSpark", Types.Melee },
			{"ThoriumMod.Projectiles.Minions.CreepingVineStaffPro", Types.Sentry },
			{"ThoriumMod.Projectiles.Minions.MoltenProtectorStaffPro", Types.Sentry },
			{"ThoriumMod.Projectiles.TorpedoPro2", Types.Ranged },
			{"ThoriumMod.Projectiles.MeteorPlasmaDamage", Types.Summon },
			{"ThoriumMod.Projectiles.GeyserSplash", Types.Magic },
			{"ThoriumMod.Projectiles.ReactionNitrogen", Types.Thrown },
			{"ThoriumMod.Projectiles.BlackDaggerPro",Types.Thrown },
			{"Consolaria.Projectiles.EasterEgg", Types.Ranged },
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
			//{"Tremor.Ice.Items.FrostLiquidFlaskPro", Types.Alchemic },
			//{"Tremor.Projectiles.WallOfShadowsBoom", Types.Alchemic },
			//{"Tremor.Projectiles.PlaguePro", Types.Alchemic },
			//{"Tremor.Projectiles.Dukado", Types.Alchemic },
			//{"Tremor.Projectiles.WallOfShadowsFlask_Proj", Types.Alchemic },
			{"SpiritMod.Projectiles.SadBeam", Types.Summon }
		};

		public static Dictionary<string, Types> ItemOverrideList = new Dictionary<string, Types>() {
			{"SpiritMod.Items.Weapon.Magic.ShadowSphere", Types.Sentry },
			{"ThoriumMod.Items.Tracker.IcyGaze", Types.True },
			{"SacredTools.Items.Weapons.Decree.FrostGlobeStaff", Types.Sentry },
			{"SacredTools.Items.Weapons.Pumpkin.MoodSummon", Types.Sentry },
			{"SacredTools.Items.Weapons.Featherstorm", Types.Thrown },
			{"SacredTools.Items.Weapons.SpearOfJustice", Types.Thrown },
			{"SacredTools.Items.Weapons.TrueDecapitator", Types.Thrown },
			{"SacredTools.Items.Weapons.Trispear", Types.Thrown },
			{"ThoriumMod.Items.SummonItems.WeedEater", Types.Sentry },
			{"ThoriumMod.Items.SummonItems.StrongestLink", Types.Sentry },
			{"ThoriumMod.Items.SummonItems.AntlionStaff", Types.Sentry },
			{"ThoriumMod.Items.SummonItems.MortarStaff", Types.Sentry },
			{"ThoriumMod.Items.Donate.HerdingStaff", Types.Sentry },
			{"ThoriumMod.Items.Depths.NanoClamCane", Types.Sentry },
			{"ThoriumMod.Items.Scouter.DistressCaller", Types.Sentry },
			{"ThoriumMod.Items.Tracker.HagTotemCaller", Types.Sentry },
			{"ThoriumMod.Items.EnergyStorm.BoulderProbe", Types.Sentry },
			{"ThoriumMod.Items.SummonItems.CreepingVineStaff", Types.Sentry },
			{"ThoriumMod.Items.Donate.SilversBlade", Types.Sentry},
			{"ThoriumMod.Items.EndofDays.Mjölnir", Types.True },
			{"ThoriumMod.Items.Misc.Lantern", Types.True },
			{"ThoriumMod.Items.NPCItems.HexWand", Types.True },
			{"ThoriumMod.Items.Donate.BowofLight", Types.True },
			{"ThoriumMod.Items.Blizzard.FrostBurntTongue", Types.True},
			//{"Tremor.Ice.Items.FrostLiquidFlask", Types.Alchemic },
			//{"Tremor.Items.LesserHealingFlack", Types.Alchemic },
			//{"Tremor.Items.BigHealingFlack", Types.Alchemic },
			{"SpiritMod.Items.Weapon.Summon.GloomgusStaff", Types.Summon },
			{"SpiritMod.Items.Weapon.Summon.BlueEyeStaff", Types.Sentry },
			{"FargowiltasSouls.Items.Weapons.BossDrops.HiveStaff", Types.Sentry }
		}; 
		
		public static string[] ProjectilesBypassItemType = new string[] {"Bullet", "Bee", "XBone"};

		public static List<DamageClass> DamageClasses = new List<DamageClass>();
		public enum Types { Unknown, Melee, Ranged, Magic, Thrown, Summon, Sentry, Radiant, Symphonic, True, Mystic, Druidic, Rogue, Ki, Fishing, Click }
		public static Types GetType(Item item) {
			//ThoriumMod Check

			if ( ItemOverrideList.ContainsKey(item.Name) ) {
				return ItemOverrideList[item.Name];
			}

			//item.DamageType
			//item.CountsAsClass(ModContent.GetInstance<NecroDamageClass>());
			ModItem mitem = item.ModItem;

			if ( mitem != null ) {
				Type mitemtype = mitem.GetType();
				if ( ItemOverrideList.ContainsKey(mitemtype.ToString()) ) {
					return ItemOverrideList[mitemtype.ToString()];
				}
				if ( Config.Instance.DebugMode && Config.Instance.DebugModeTooltips ) ColoredDamageTypes.Log("Item: " + mitemtype.ToString());
			}

			if (Config.Instance.DebugMode && Config.Instance.DebugModeFields ) {
				if(mitem == null ) {
					ColoredDamageTypes.Log("---------------------------------------");
					ColoredDamageTypes.Log(item.Name);
					Type itemType = item.GetType();
					foreach ( FieldInfo f in itemType.GetFields() ) {
						try {
							ColoredDamageTypes.Log(f.Name + ": " + f.FieldType + ": " + ": " + f.GetValue(mitem).ToString());
						}
						catch {

						}
					}
				}
				else {
					ColoredDamageTypes.Log("---------------------------------------");
					ColoredDamageTypes.Log(mitem.Name);
					Type mitemType = mitem.GetType();
					foreach ( FieldInfo f in mitemType.GetFields() ) {
						try {
							ColoredDamageTypes.Log(f.Name + ": " + f.FieldType + ": " + ": " + f.GetValue(mitem).ToString());
						}
						catch {

						}
					}
				}
			}

			if ( ColoredDamageTypes.ThoriumMod != null && mitem != null && mitem.Mod == ColoredDamageTypes.ThoriumMod ) {
				Type mitemType = mitem.GetType();
				var fieldRadiant = mitemType.GetField("radiant");
				var fieldSymphonic = mitemType.GetField("Empowerments");
				var fieldThrowing = mitemType.GetField("throwing");
				if ( fieldRadiant != null && (bool)fieldRadiant.GetValue(mitem) == true ) return Types.Radiant;
				else if ( fieldSymphonic != null ) return Types.Symphonic;
				else if ( fieldThrowing != null && (bool)fieldThrowing.GetValue(mitem) == true ) return Types.Thrown;
			}

			//EnigmaMod Check
			if ( ColoredDamageTypes.EnigmaMod != null && mitem != null && mitem.Mod == ColoredDamageTypes.EnigmaMod ) {
				Type mprojtype = mitem.GetType();
				string typestr = mprojtype.ToString();
				if ( typestr.Contains("Laugicality.Items.Weapons.Mystic") ) return Types.Mystic;
			}

			//RedemptionMod Check
			if ( ColoredDamageTypes.RedemptionMod != null && mitem != null && mitem.Mod == ColoredDamageTypes.RedemptionMod ) {
				Type mprojtype = mitem.GetType();
				string typestr = mprojtype.ToString();
				if ( typestr.Contains("Redemption.Items.DruidDamageClass") || typestr.Contains("Redemption.Projectiles.DruidProjectiles") ) return Types.Druidic;
			}

			//CalamityMod Check
			if ( ColoredDamageTypes.CalamityMod != null && mitem != null && mitem.Mod == ColoredDamageTypes.CalamityMod ) {
				Type mprojtype = mitem.GetType();
				string typestr = mprojtype.ToString();
				if ( typestr.Contains("CalamityMod.Items.Weapons.Rogue") || typestr.Contains("CalamityMod.Projectiles.Rogue") ) return Types.Rogue;
			}

			//DBZMod Check
			if ( ColoredDamageTypes.DbzMod != null && mitem != null && mitem.Mod == ColoredDamageTypes.DbzMod ) {
				Type mprojtype = mitem.GetType();
				string typestr = mprojtype.ToString();
				if ( typestr.Contains("DBZMOD.Projectiles") || (typestr.Contains("DBZMOD.Items.Weapons") && !typestr.Contains("Normal")) ) return Types.Ki;
			}

			//BattleRod Check
			if ( ColoredDamageTypes.BattleRodsMod != null && mitem != null && mitem.Mod == ColoredDamageTypes.BattleRodsMod ) {
				Type mprojtype = mitem.GetType();
				string typestr = mprojtype.ToString();
				if ( typestr.Contains("UnuBattleRods.Projectiles") || typestr.Contains("UnuBattleRods.Items.Rods") ) return Types.Fishing;
			}

			//Clicker Check
			if ( ColoredDamageTypes.ClickerMod != null && mitem != null && mitem.Mod == ColoredDamageTypes.ClickerMod ) {
				Type mprojtype = mitem.GetType();
				string typestr = mprojtype.ToString();
				if ( typestr.Contains("ClickerClass.Items.Weapons") || typestr.Contains("ClickerClass.Projectiles") ) return Types.Click;
			}

			/*//OrchidMod Check
			if ( ColoredDamageTypes.OrchidMod != null && mitem != null && mitem.mod == ColoredDamageTypes.OrchidMod ) {
				Type mprojtype = mitem.GetType();
				string typestr = mprojtype.ToString();
				if ( typestr.Contains("OrchidMod.Shaman.Weapons") || typestr.Contains("OrchidMod.Shaman.Projectiles") ) return Types.Shamanic;
			}
			*/


			/*
			if (ColoredDamageTypes.TremorMod != null && mitem != null && mitem.mod == ColoredDamageTypes.TremorMod) {
				Type mitemType = mitem.GetType();
				string mitemTypestr = mitemType.ToString();
				bool isAlchemic = mitemTypestr.Contains("Alchemist.") || mitemTypestr.Contains("Alchemic.") || mitemTypestr.Contains("NovaPillar.");
				if (mitemType != null && isAlchemic == true) return Types.Alchemic;
			}
			*/

			if ( item.CountsAsClass(DamageClass.Melee) && !item.CountsAsClass(DamageClass.Magic) && !item.CountsAsClass(DamageClass.Throwing)) return Types.Melee;
			else if ( item.CountsAsClass(DamageClass.Ranged) && !item.CountsAsClass(DamageClass.Magic) && !item.CountsAsClass(DamageClass.Throwing) ) return Types.Ranged;
			else if ( item.CountsAsClass(DamageClass.Magic) ) return Types.Magic;
			else if ( item.CountsAsClass(DamageClass.Throwing) ) return Types.Thrown;
			else if ( item.sentry ) return Types.Sentry;
			else if ( item.CountsAsClass(DamageClass.Summon) ) return Types.Summon;

			return Types.Unknown;
		}

		public static Types GetType(Projectile projectile) {
			if ( ProjectileOverrideList.ContainsKey(projectile.Name) ) {
				return ProjectileOverrideList[projectile.Name];
			}
			ModProjectile mproj = projectile.ModProjectile;
			if ( mproj != null ) {
				Type mprojtype = mproj.GetType();

				if ( ProjectileOverrideList.ContainsKey(mprojtype.ToString()) ) {
					return ProjectileOverrideList[mprojtype.ToString()];
				}
				if ( Config.Instance.DebugMode ) ColoredDamageTypes.Log("Projectile: " + mprojtype.ToString());
			}

			//ThoriumMod Check
			if ( ColoredDamageTypes.ThoriumMod != null && mproj != null && mproj.Mod == ColoredDamageTypes.ThoriumMod ) {
				Type mprojtype = mproj.GetType();
				string typestr = mprojtype.ToString();
				if ( typestr.Contains("ThoriumMod.Projectiles.Scythe") || typestr.Contains("ThoriumMod.Projectiles.Healer") ) return Types.Radiant;
				else if ( typestr.Contains("ThoriumMod.Projectiles.Bard") ) return Types.Symphonic;
				else if ( typestr.Contains("ThoriumMod.Items.ThrownItems") ) return Types.Thrown;
			}

			//EnigmaMod Check
			if ( ColoredDamageTypes.EnigmaMod != null && mproj != null && mproj.Mod == ColoredDamageTypes.EnigmaMod ) {
				Type mprojtype = mproj.GetType();
				string typestr = mprojtype.ToString();
				if ( typestr.Contains("Laugicality.Items.Weapons.Mystic") || typestr.Contains("Laugicality.Projectiles.Mystic") ) return Types.Mystic;
			}

			//RedemptionMod Check
			if ( ColoredDamageTypes.RedemptionMod != null && mproj != null && mproj.Mod == ColoredDamageTypes.RedemptionMod ) {
				Type mprojtype = mproj.GetType();
				string typestr = mprojtype.ToString();
				if ( typestr.Contains("Redemption.Items.DruidDamageClass") || typestr.Contains("Redemption.Projectiles.DruidProjectiles" ) ) return Types.Druidic;
			}

			//CalamityMod Check
			if ( ColoredDamageTypes.CalamityMod != null && mproj != null && mproj.Mod == ColoredDamageTypes.CalamityMod ) {
				Type mprojtype = mproj.GetType();
				string typestr = mprojtype.ToString();
				if ( typestr.Contains("CalamityMod.Items.Weapons.Rogue") || typestr.Contains("CalamityMod.Projectiles.Rogue") ) return Types.Rogue;
			}

			//DBZMod Check
			if ( ColoredDamageTypes.DbzMod != null && mproj != null && mproj.Mod == ColoredDamageTypes.DbzMod ) {
				Type mprojtype = mproj.GetType();
				string typestr = mprojtype.ToString();
				if ( typestr.Contains("DBZMOD.Projectiles") || (typestr.Contains("DBZMOD.Items.Weapons") && !typestr.Contains("Normal") ) ) return Types.Ki;
			}

			//BattleRod Check
			if ( ColoredDamageTypes.BattleRodsMod != null && mproj != null && mproj.Mod == ColoredDamageTypes.BattleRodsMod ) {
				Type mprojtype = mproj.GetType();
				string typestr = mprojtype.ToString();
				if ( typestr.Contains("UnuBattleRods.Projectiles") || typestr.Contains("UnuBattleRods.Items.Rods") ) return Types.Fishing;
			}

			//Clicker Check
			if ( ColoredDamageTypes.ClickerMod != null && mproj != null && mproj.Mod == ColoredDamageTypes.ClickerMod ) {
				Type mprojtype = mproj.GetType();
				string typestr = mprojtype.ToString();
				if ( typestr.Contains("ClickerClass.Items.Weapons") || typestr.Contains("ClickerClass.Projectiles") ) return Types.Click;
			}

			/*//OrchidMod Check
			if ( ColoredDamageTypes.OrchidMod != null && mproj != null && mproj.mod == ColoredDamageTypes.OrchidMod ) {
				Type mprojtype = mproj.GetType();
				string typestr = mprojtype.ToString();
				if ( typestr.Contains("OrchidMod.Shaman.Weapons") || typestr.Contains("OrchidMod.Shaman.Projectiles") ) return Types.Shamanic;
			}
			*/

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
			if (!ProjectilesBypassItemType.Contains(projectile.Name)) ProjectileTypeCheck(projectile, selecteditem, ref item);

			if ( item == null && !ProjectilesBypassItemType.Contains(projectile.Name)) {
				foreach ( Item i in Main.player[projectile.owner].inventory ) {
					if ( i.shoot == projectile.type ) {
						item = i;
						break;
					}
				}
			}
			if ( item != null ) { // Found item in inventory
				return GetType(item);
			}
			else { // Didn't find item. Use projectile type
				int fromsummon = 0;

				for ( int i = 0; i < 1000; i++ ) {
					Projectile CheckProjectile = Main.projectile[i];

					if ( CheckProjectile.active && (CheckProjectile.sentry) && CheckProjectile.type + 1 == projectile.type ) {
						fromsummon = 2; // Is a sentry
						break;
					}
					else if ( CheckProjectile.active && (CheckProjectile.minion) && CheckProjectile.type + 1 == projectile.type ) {
						fromsummon = 1; // Is a minion
						break;
					}
					/*
					if ( ProjectilesThatInheritItemType.ContainsKey(CheckProjectile.Name) ) {
						string MinionTypeToCheck = ProjectilesThatInheritItemType[CheckProjectile.Name];
						for ( int ii = 0; ii < 1000; ii++ ) {
							if ( !Main.projectile[ii].active || Main.projectile[ii].modProjectile == null ) continue;
							ModProjectile CheckProjectile2 = Main.projectile[ii].modProjectile;
							//Main.NewText(CheckProjectile.Name);
							if ( fromsummon > 0 ) break;
							if ( CheckProjectile2.GetType().ToString().Equals(MinionTypeToCheck) ) {
								ColoredDamageTypes.Log(CheckProjectile2.GetType().ToString() + " == " + MinionTypeToCheck + "?");
								ColoredDamageTypes.Log("Yes");

								if ( CheckProjectile2.projectile.sentry ) {
									fromsummon = 2; // Is a sentry
									break;
								}
								else if ( CheckProjectile2.projectile.minion ) {
									fromsummon = 1; // Is a minion
									break;
								}
							}
						}
					}
					*/
				}


				if ( fromsummon == 2 || projectile.sentry ) return Types.Sentry;
				else if ( fromsummon == 1 || projectile.minion ) return Types.Summon;
				else if ( projectile.CountsAsClass(DamageClass.Melee) && !projectile.CountsAsClass(DamageClass.Magic) && !projectile.CountsAsClass(DamageClass.Throwing) && !projectile.minion && !projectile.sentry ) return Types.Melee;
				else if ( projectile.CountsAsClass(DamageClass.Ranged) && !projectile.CountsAsClass(DamageClass.Magic) && !projectile.CountsAsClass(DamageClass.Throwing) && !projectile.minion && !projectile.sentry ) return Types.Ranged;
				else if ( projectile.CountsAsClass(DamageClass.Magic) && !projectile.minion && !projectile.sentry ) return Types.Magic;
				else if ( projectile.CountsAsClass(DamageClass.Throwing) && !projectile.minion && !projectile.sentry ) return Types.Thrown;

				return Types.Unknown;
			}
		}

		public static void ProjectileTypeCheck(Projectile projectile, Item item, ref Item returnitem) {
			Dictionary<int, int[]> ProjectileTypeOverride = new Dictionary<int, int[]>() {
					{469, new int[]{181,566 } }
				};

			string[] ProjectileTypeNameOverride = new string[] {"CrystiliumMod.Projectiles.DiamondBomb","CrystiliumMod.Projectiles.Shatter1",
				"CrystiliumMod.Projectiles.Shatter2","CrystiliumMod.Projectiles.Shatter3","SacredTools.Projectiles.FrostExplosion","SacredTools.Projectiles.CerniumMist",
			"SacredTools.Projectiles.DarkExplosion","SacredTools.Projectiles.FlameExplosion","SacredTools.Projectiles.JusticeSpark", "SpiritMod.Projectiles.Fire"};

			string[] ProjectileNameOverride = new string[] { "Skull" };


			if ( item.shoot == projectile.type || (ProjectileTypeOverride.ContainsKey(item.shoot) && ProjectileTypeOverride[item.shoot].Contains(projectile.type)) ) {
				returnitem = item;
			}
			else {
				if ( !projectile.npcProj ) {
					if ( ProjectileTypeNameOverride.Contains(projectile.GetType().ToString()) || ProjectileNameOverride.Contains(projectile.Name) ) {
						returnitem = ColoredDamageTypes.ProjectileWeaponSpawns[projectile.identity];
					}
				}
				/*
				else {
					Dictionary<string, Types> NPCProjectileOverride = new Dictionary<string, Types>() {
						{"Skull", Types.Magic },
					};
					if(NPCProjectileOverride.ContainsKey(projectile.Name) || NPCProjectileOverride.ContainsKey(projectile.GetType().ToString())){

					}
				}
				*/
			}
		}


		public static Color CheckDamageColor(Types dmgtype, bool crit) {
			Color newcolor;
			switch ( dmgtype ) {
				case Types.Melee:
					newcolor = crit ? DamageConfig.Instance.VanillaDmg.MeleeDmg.MeleeDamageCrit : DamageConfig.Instance.VanillaDmg.MeleeDmg.MeleeDamage;
					break;
				case Types.Ranged:
					newcolor = crit ? DamageConfig.Instance.VanillaDmg.RangedDmg.RangedDamageCrit : DamageConfig.Instance.VanillaDmg.RangedDmg.RangedDamage;
					break;
				case Types.Magic:
					newcolor = crit ? DamageConfig.Instance.VanillaDmg.MagicDmg.MagicDamageCrit : DamageConfig.Instance.VanillaDmg.MagicDmg.MagicDamage;
					break;
				case Types.Thrown:
					newcolor = crit ? DamageConfig.Instance.VanillaDmg.ThrowingDmg.ThrowingDamageCrit : DamageConfig.Instance.VanillaDmg.ThrowingDmg.ThrowingDamage;
					break;
				case Types.Summon:
					newcolor = crit ? DamageConfig.Instance.VanillaDmg.SummonDmg.SummonDamageCrit : DamageConfig.Instance.VanillaDmg.SummonDmg.SummonDamage;
					break;
				case Types.Sentry:
					newcolor = crit ? DamageConfig.Instance.VanillaDmg.SentryDmg.SentryDamageCrit : DamageConfig.Instance.VanillaDmg.SentryDmg.SentryDamage;
					break;
				/*case Types.Radiant:
					newcolor = crit ? DamageConfig.Instance.ThoriumDmg.RadiantDmg.RadiantDamageCrit : DamageConfig.Instance.ThoriumDmg.RadiantDmg.RadiantDamage;
					break;
				case Types.Symphonic:
					newcolor = crit ? DamageConfig.Instance.ThoriumDmg.SymphonicDmg.SymphonicDamageCrit : DamageConfig.Instance.ThoriumDmg.SymphonicDmg.SymphonicDamage;
					break;
				case Types.True:
					newcolor = crit ? DamageConfig.Instance.ThoriumDmg.TrueDmg.TrueDamageCrit : DamageConfig.Instance.ThoriumDmg.TrueDmg.TrueDamage;
					break;
				case Types.Mystic:
					newcolor = crit ? DamageConfig.Instance.EnigmaDmg.MysticDmg.MysticDamageCrit : DamageConfig.Instance.EnigmaDmg.MysticDmg.MysticDamage;
					break;
				case Types.Druidic:
					newcolor = crit ? DamageConfig.Instance.RedemptionDmg.DruidicDmg.DruidicDamageCrit : DamageConfig.Instance.RedemptionDmg.DruidicDmg.DruidicDamage;
					break;
				case Types.Ki:
					newcolor = crit ? DamageConfig.Instance.DbzModDmg.KiDmg.KiDamageCrit : DamageConfig.Instance.DbzModDmg.KiDmg.KiDamage;
					break;
				case Types.Rogue:
					newcolor = crit ? DamageConfig.Instance.CalamityModDmg.RogueDmg.RogueDamageCrit : DamageConfig.Instance.CalamityModDmg.RogueDmg.RogueDamage;
					break;
				case Types.Fishing:
					newcolor = crit ? DamageConfig.Instance.BattleRodModDmg.FishingDmg.FishingDamageCrit : DamageConfig.Instance.BattleRodModDmg.FishingDmg.FishingDamage;
					break;
				case Types.Click:
					newcolor = crit ? DamageConfig.Instance.ClickerModDmg.ClickDmg.ClickDamageCrit : DamageConfig.Instance.ClickerModDmg.ClickDmg.ClickDamage;
					break;*/

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
