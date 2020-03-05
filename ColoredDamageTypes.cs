using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.UI;
using System.Collections.Generic;
using log4net;
using System.IO;
using Terraria.Localization;

namespace _ColoredDamageTypes
{
	class ColoredDamageTypes : Mod
	{
        public static Mod ThoriumMod;
		//public static Mod TremorMod;
		public static bool ChangeTooltipColor = true;
		public static bool ChangeDamageColor = true;
		public static ColoredDamageTypes instance;
		public static string GithubUserName { get { return "PvtFudgepants"; } }
		public static string GithubProjectName { get { return "tModLoader---Colored-Damage-Types"; } }

		public static Item[] ProjectileWeaponSpawns = new Item[1001];

		public static DamageTypes.Types recentcolor_in;
		public static DamageTypes.Types recentcolor_out;
		public static int recentdmg_in;
		public static int recentdmg_out;
		public static float recentkb_in;
		public static float recentkb_out;
		public static byte recentcrit_in;
		public static byte recentcrit_out;

		public ColoredDamageTypes()
		{
            Properties = new ModProperties() {
                Autoload = true
            };
			instance = this;
		}

		public override void PostSetupContent()
		{
			ThoriumMod = ModLoader.GetMod("ThoriumMod");
			//TremorMod = ModLoader.GetMod("Tremor");
		}

		public static void Log(object message, params object[] formatData)
		{
			instance.Logger.InfoFormat("[ColoredDamageTypes] " + string.Format(message.ToString(), formatData), "ColoredDamageTypes");
		}

		public override bool HijackGetData(ref byte messageType, ref BinaryReader reader, int playerNumber) {
			if(messageType == 28 ) {
				if(Main.netMode == NetmodeID.MultiplayerClient ) {
					NPC npc = Main.npc[(int)reader.ReadInt16()]; //npc being hit
					int damage = ModNet.AllowVanillaClients ? reader.ReadInt16() : reader.ReadInt32(); //damage
					float knockback = reader.ReadSingle(); // knockback
					int hitdir = (reader.ReadByte() - 1); // hit direction
					byte critbyte = reader.ReadByte();
					bool crit = critbyte == 1;

					//Main.NewText("Knockback: " + num86 + ", Direction: " + num87 + ", Crit: " + bb+" ?: "+crit);
					if(damage > 0 && damage == recentdmg_in && knockback == recentkb_in && critbyte == recentcrit_in) {
						npc.StrikeNPC(damage, knockback, hitdir, crit, false, true);
						int recent = -1;
						for ( int i = 99; i >= 0; i-- ) {
							CombatText ctToCheck = Main.combatText[i];
							if ( ctToCheck.lifeTime == 60 || ctToCheck.lifeTime == 120 ) {
								if ( ctToCheck.alpha == 1f ) {
									if ( (ctToCheck.color == CombatText.OthersDamagedHostile || ctToCheck.color == CombatText.OthersDamagedHostileCrit) ) {
										recent = i;
										break;
									}
								}
							}
						}
						if ( recent > -1 ) {
							Main.combatText[recent].color = DamageTypes.CheckDamageColor(recentcolor_in, crit) * 0.4f;
						}
						return true;
					}

				}
				return false;
			}
			return false;
		}
		public override bool HijackSendData(int whoAmI, int msgType, int remoteClient, int ignoreClient, NetworkText text, int number, float number2, float number3, float number4, int number5, int number6, int number7) {
			if(msgType == 28 && Main.netMode == NetmodeID.MultiplayerClient) {
				ModPacket packet = instance.GetPacket();
				packet.Write((byte)recentcolor_out);
				packet.Write(recentdmg_out);
				packet.Write(recentkb_out);
				packet.Write(recentcrit_out);
				packet.Send();
				return false;
			}
			return false;
		}

		public override void HandlePacket(BinaryReader reader, int whoAmI) {
			//Main.NewText("Got packet");
			if ( Main.netMode == NetmodeID.Server ) {
				ModPacket packet = instance.GetPacket();
				packet.Write(reader.ReadByte());
				packet.Write(reader.ReadInt32());
				packet.Write(reader.ReadSingle());
				packet.Write(reader.ReadByte());
				packet.Send(-1, whoAmI);
				packet.Close();
			}
			if (Main.netMode == NetmodeID.MultiplayerClient ) {
				recentcolor_in = (DamageTypes.Types)reader.ReadByte();
				recentdmg_in = reader.ReadInt32();
				recentkb_in = reader.ReadSingle();
				recentcrit_in = reader.ReadByte();
			}
		}
	}
}
