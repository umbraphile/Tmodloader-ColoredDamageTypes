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

namespace _ColoredDamageTypes
{
	class ColoredDamageTypes : Mod
	{
        public static Mod ThoriumMod;
		public static Mod TremorMod;
		public static bool ChangeTooltipColor = true;
		public static bool ChangeDamageColor = true;
		public static ColoredDamageTypes instance;
		public static string GithubUserName { get { return "PvtFudgepants"; } }
		public static string GithubProjectName { get { return "tModLoader---Colored-Damage-Types"; } }

		public static Item[] ProjectileWeaponSpawns = new Item[1001];

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
			TremorMod = ModLoader.GetMod("Tremor");
		}

		public static void Log(object message, params object[] formatData)
		{
			instance.Logger.InfoFormat("[ColoredDamageTypes] " + string.Format(message.ToString(), formatData), "ColoredDamageTypes");
		}

		//public override bool HijackGetData(ref byte messageType, ref BinaryReader reader, int playerNumber) {
		//}
		public void SendColorPacket(byte R, byte G, byte B, byte A, int damage, bool crit, int towho = -1, int exclude = -1) {
			return;
			/*if ( Main.netMode == NetmodeID.MultiplayerClient || Main.netMode == NetmodeID.Server) {
				ModPacket packet = instance.GetPacket();

				packet.Write(R);
				packet.Write(G);
				packet.Write(B);
				packet.Write(A);
				packet.Write(damage);
				packet.Write(crit);
				//packet.Write(recentid);
				packet.Send(towho, exclude);
			}
			*/
		}
	/*
		public override void HandlePacket(BinaryReader reader, int fromwho) {
			//String msgType = reader.ReadString();
			//switch ( msgType ) {
			//	case "ChangedColor":
			byte r = reader.ReadByte();
			byte g = reader.ReadByte();
			byte b = reader.ReadByte();
			byte a = reader.ReadByte();
			int dmg = reader.ReadInt32();
			bool crit = reader.ReadBoolean();
			//int recentid = reader.ReadInt32();

			if ( Main.netMode == NetmodeID.Server ) {
				SendColorPacket(r, g, b, a, dmg, crit);
				return;
			}

			Color newcolor = new Color(r, g, b, a);

			int recent = -1;
			for ( int i = 99; i >= 0; i-- ) {
				CombatText ctToCheck = Main.combatText[i];
				if ( (ctToCheck.color == CombatText.OthersDamagedHostile || ctToCheck.color == CombatText.OthersDamagedHostileCrit) && ( (ctToCheck.lifeTime >= 41 && ctToCheck.lifeTime <= 60) || (ctToCheck.lifeTime >= 90 && ctToCheck.lifeTime <= 120) ) ) {
					if ( ctToCheck.alpha == 1f) {
						//recent = i;
						Main.combatText[i].color = newcolor * 0.4f;
						//break;
					}
				}
			}

			//if ( recent >= 0 ) Main.combatText[recent].color = newcolor * 0.4f;
			//Main.combatText[recentid].color = newcolor;
		}
		
	*/
	}
}
