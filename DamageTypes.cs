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
		public static Dictionary<string, DamageClass> ProjectileOverrideList = new Dictionary<string, DamageClass>() {
			{"Solar Eruption", DamageClass.Melee },
			{"Ballista", ModContent.GetInstance<SentryClass>() },
			{"Pygmy", DamageClass.Summon },
			{"Baby Spider", ModContent.GetInstance<SentryClass>() },
			{"Molotov Fire", DamageClass.Throwing },
			{"UFO Ray", DamageClass.Summon }
			//{"Influx Waver", Types.Melee },
/*			{"SpiritMod.Projectiles.DonatorItems.FlambergeProjectile", Types.Melee },
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
			{"SpiritMod.Projectiles.SadBeam", Types.Summon }*/
		};

		public static Dictionary<string, DamageClass> ItemOverrideList = new Dictionary<string, DamageClass>() {
			/*{"SpiritMod.Items.Weapon.Magic.ShadowSphere", Types.Sentry },
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
			{"FargowiltasSouls.Items.Weapons.BossDrops.HiveStaff", Types.Sentry }*/
		};
		
		public static string[] ProjectilesBypassItemType = new string[] {"Bullet", "Bee", "XBone"};

		public static List<DamageClass> DamageClasses = new List<DamageClass>();
		/*public enum Types { Unknown, Melee, Ranged, Magic, Thrown, Summon, Sentry, Radiant, Symphonic, True, Mystic, Druidic, Rogue, Ki, Fishing, Click }*/
		public static DamageClass GetType(Item item) {
            //ThoriumMod Check

            if (ItemOverrideList.ContainsKey(item.Name))
            {
                return ItemOverrideList[item.Name];
            }

            ModItem mitem = item.ModItem;

            if (mitem != null)
            {
                Type mitemtype = mitem.GetType();
                if (ItemOverrideList.ContainsKey(mitemtype.ToString()))
                {
                    return ItemOverrideList[mitemtype.ToString()];
                }
                if (Config.Instance.DebugMode && Config.Instance.DebugModeTooltips) ColoredDamageTypes.Log("Item: " + mitemtype.ToString());
            }

            if (Config.Instance.DebugMode && Config.Instance.DebugModeFields)
            {
                if (mitem == null)
                {
                    ColoredDamageTypes.Log("---------------------------------------");
                    ColoredDamageTypes.Log(item.Name);
                    Type itemType = item.GetType();
                    foreach (FieldInfo f in itemType.GetFields())
                    {
                        try
                        {
                            ColoredDamageTypes.Log(f.Name + ": " + f.FieldType + ": " + ": " + f.GetValue(mitem).ToString());
                        }
                        catch
                        {

                        }
                    }
                }
                else
                {
                    ColoredDamageTypes.Log("---------------------------------------");
                    ColoredDamageTypes.Log(mitem.Name);
                    Type mitemType = mitem.GetType();
                    foreach (FieldInfo f in mitemType.GetFields())
                    {
                        try
                        {
                            ColoredDamageTypes.Log(f.Name + ": " + f.FieldType + ": " + ": " + f.GetValue(mitem).ToString());
                        }
                        catch
                        {

                        }
                    }
                }
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

            if ( item.CountsAsClass(DamageClass.Melee) && !item.CountsAsClass(DamageClass.Magic) && !item.CountsAsClass(DamageClass.Throwing)) return DamageClass.Melee;
			else if ( item.CountsAsClass(DamageClass.Ranged) && !item.CountsAsClass(DamageClass.Magic) && !item.CountsAsClass(DamageClass.Throwing) ) return DamageClass.Ranged;
			else if ( item.CountsAsClass(DamageClass.Magic) ) return DamageClass.Magic;
			else if ( item.CountsAsClass(DamageClass.Throwing) ) return DamageClass.Throwing;
			else if ( item.CountsAsClass(DamageClass.Summon) ) return DamageClass.Summon;
            else
            {
				foreach (DamageClass dc in DamageTypes.DamageClasses)
				{
					if (item.CountsAsClass(dc))
					{
						return dc;
					}
				}
			}

			return DamageClass.Generic;
		}

		public static DamageClass GetType(Projectile projectile) {
            if (ProjectileOverrideList.ContainsKey(projectile.Name))
            {
                return ProjectileOverrideList[projectile.Name];
            }
            ModProjectile mproj = projectile.ModProjectile;
            if (mproj != null)
            {
                Type mprojtype = mproj.GetType();

                if (ProjectileOverrideList.ContainsKey(mprojtype.ToString()))
                {
                    return ProjectileOverrideList[mprojtype.ToString()];
                }
                if (Config.Instance.DebugMode) ColoredDamageTypes.Log("Projectile: " + mprojtype.ToString());
            }

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


				if ( fromsummon == 2 || projectile.sentry ) return ModContent.GetInstance<SentryClass>();
				if ( fromsummon == 1 || projectile.minion ) return DamageClass.Summon;
				else if ( projectile.CountsAsClass(DamageClass.Melee) && !projectile.CountsAsClass(DamageClass.Magic) && !projectile.CountsAsClass(DamageClass.Throwing) && !projectile.minion && !projectile.sentry ) return DamageClass.Melee;
				else if ( projectile.CountsAsClass(DamageClass.Ranged) && !projectile.CountsAsClass(DamageClass.Magic) && !projectile.CountsAsClass(DamageClass.Throwing) && !projectile.minion && !projectile.sentry ) return DamageClass.Ranged;
				else if ( projectile.CountsAsClass(DamageClass.Magic) && !projectile.minion && !projectile.sentry ) return DamageClass.Magic;
				else if ( projectile.CountsAsClass(DamageClass.Throwing) && !projectile.minion && !projectile.sentry ) return DamageClass.Throwing;

				return DamageClass.Generic;
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


		public static Color CheckDamageColor(DamageClass dmgtype, bool crit, bool sentrycheck) {
			Color newcolor;
			if(dmgtype == DamageClass.Melee)
            {
				newcolor = crit ? DamageConfig.Instance.VanillaDmg.MeleeDmg.MeleeDamageCrit : DamageConfig.Instance.VanillaDmg.MeleeDmg.MeleeDamage;
			}
			else if (dmgtype == DamageClass.Ranged)
			{
				newcolor = crit ? DamageConfig.Instance.VanillaDmg.RangedDmg.RangedDamageCrit : DamageConfig.Instance.VanillaDmg.RangedDmg.RangedDamage;
			}
			else if (dmgtype == DamageClass.Magic)
			{
				newcolor = crit ? DamageConfig.Instance.VanillaDmg.MagicDmg.MagicDamageCrit : DamageConfig.Instance.VanillaDmg.MagicDmg.MagicDamage;
			}
			else if (dmgtype == DamageClass.Throwing)
			{
				newcolor = crit ? DamageConfig.Instance.VanillaDmg.ThrowingDmg.ThrowingDamageCrit : DamageConfig.Instance.VanillaDmg.ThrowingDmg.ThrowingDamage;
			}
			else if (dmgtype == ModContent.GetInstance<SentryClass>())
			{
				newcolor = crit ? DamageConfig.Instance.VanillaDmg.SentryDmg.SentryDamageCrit : DamageConfig.Instance.VanillaDmg.SentryDmg.SentryDamage;
			}
			else if (dmgtype == DamageClass.Summon)
			{
				if (sentrycheck) newcolor = crit ? DamageConfig.Instance.VanillaDmg.SentryDmg.SentryDamageCrit : DamageConfig.Instance.VanillaDmg.SentryDmg.SentryDamage;
				else newcolor = crit ? DamageConfig.Instance.VanillaDmg.SummonDmg.SummonDamageCrit : DamageConfig.Instance.VanillaDmg.SummonDmg.SummonDamage;
			}
			else if (dmgtype == DamageClass.Generic)
			{
				newcolor = crit ? CombatText.DamagedHostileCrit : CombatText.DamagedHostile;
			}
			else
            {
				newcolor = crit ? zCrossModConfig.CrossModDamageConfig_Orig[dmgtype.ToString()].CritDamageColor : zCrossModConfig.CrossModDamageConfig_Orig[dmgtype.ToString()].DamageColor;
			}
			return newcolor;
		}
	}
}
