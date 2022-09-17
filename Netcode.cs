using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ModLoader;
using Terraria.Localization;
using System.IO;
using Terraria.ID;
using Microsoft.Xna.Framework;

namespace ColoredDamageTypes
{
    internal class Netcode : ModSystem
	{

		public static int recentcolor_in;
		public static int recentcolor_out;
		public static int recentdmg_in;
		public static int recentdmg_out;
		public static float recentkb_in;
		public static float recentkb_out;
		public static byte recentcrit_in;
		public static byte recentcrit_out;

		public override bool HijackGetData(ref byte messageType, ref BinaryReader reader, int playerNumber)
		{
			if (messageType == 28)
			{
				if (Main.netMode == NetmodeID.MultiplayerClient)
				{
					NPC npc = Main.npc[(int)reader.ReadInt16()]; //npc being hit
					int damage = ModNet.AllowVanillaClients ? reader.ReadInt16() : reader.ReadInt32(); //damage
					float knockback = reader.ReadSingle(); // knockback
					int hitdir = (reader.ReadByte() - 1); // hit direction
					byte critbyte = reader.ReadByte();
					bool crit = critbyte == 1;
					//fileStream.Seek(filestream.Position - 5, SeekOrigin.Begin);

					if (Config.Instance.DebugModeMultiplayer)
					{
						ColoredDamageTypes.Log("IN Dmg: " + recentdmg_in + ", KB: " + recentkb_in + ", Crit: " + (recentcrit_in == 1));
						ColoredDamageTypes.Log("Dmg: " + damage + ", KB: " + knockback + ", Crit: " + crit);
					}
					//Main.NewText("Knockback: " + num86 + ", Direction: " + num87 + ", Crit: " + bb+" ?: "+crit);
					if (damage > 0 && damage == recentdmg_in && knockback == recentkb_in && critbyte == recentcrit_in)
					{
						if (Config.Instance.DebugModeMultiplayer)
						{
							ColoredDamageTypes.Log("Passed");
						}
						npc.StrikeNPC(damage, knockback, hitdir, crit, false, true);
						int recent = -1;
						for (int i = 99; i >= 0; i--)
						{
							CombatText ctToCheck = Main.combatText[i];
							if (ctToCheck.alpha == 1f)
							{
								//Default times are 60 and 120 (crit)
								if ((ctToCheck.color == CombatText.OthersDamagedHostile && ctToCheck.lifeTime == 60) || (ctToCheck.color == CombatText.OthersDamagedHostileCrit && ctToCheck.lifeTime == 120))
								{
									recent = i;
									break;
								}
							}

							/*if ( ctToCheck.lifeTime == 60 || ctToCheck.lifeTime == 120 ) {
								// Time might be slightly lower though...
								if ( ctToCheck.alpha == 1f ) {
									if ( (ctToCheck.color == CombatText.OthersDamagedHostile || ctToCheck.color == CombatText.OthersDamagedHostileCrit) ) {
										recent = i;
										break;
									}
								}
							}
							*/
						}
						if (recent > -1)
						{

							DamageClass intype = DamageClass.Generic;
							bool sentrycheck = false;
							if (recentcolor_in == 0) intype = DamageClass.Generic;
							else if (recentcolor_in == 1) intype = DamageClass.Melee;
							else if (recentcolor_in == 2) intype = DamageClass.Ranged;
							else if (recentcolor_in == 3) intype = DamageClass.Magic;
							else if (recentcolor_in == 4) intype = DamageClass.Summon;
							else if (recentcolor_in == 5)
							{
								intype = ModContent.GetInstance<SentryClass>();
								sentrycheck = true;
							}
							else if (recentcolor_in == 6) intype = DamageClass.Throwing;
							else
							{
								intype = DamageTypes.DamageClasses[recentcolor_in - 8];
							}

							Color newcolor = DamageTypes.CheckDamageColor(intype, crit, sentrycheck) * 0.4f;
							CombatText recentct = Main.combatText[recent];

							recentct.color = newcolor;
							if (Config.Instance.ShowMultiplayerDamageNumbers == false)
							{
								recentct.active = false;
								return true;
							}
							String dmgtypeString = intype.ToString();


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
						return true;
					}

				}
				return false;
			}
			return false;
		}
		public override bool HijackSendData(int whoAmI, int msgType, int remoteClient, int ignoreClient, NetworkText text, int number, float number2, float number3, float number4, int number5, int number6, int number7)
		{
			if (msgType == 28 && Main.netMode == NetmodeID.MultiplayerClient)
			{
				ModPacket packet = ColoredDamageTypes.instance.GetPacket();
				packet.Write((byte)recentcolor_out);
				packet.Write(recentdmg_out);
				packet.Write(recentkb_out);
				packet.Write(recentcrit_out);
				packet.Send();
				recentcolor_out = 0;
				recentdmg_out = 0;
				recentkb_out = 0;
				recentcrit_out = 0;
				return false;
			}
			return false;
		}
	}
}