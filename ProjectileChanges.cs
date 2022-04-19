using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ModLoader;
using System.Reflection;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace ColoredDamageTypes
{
	class ProjectileChanges : GlobalProjectile
	{
		//public DamageTypes.Types OwnerType;
		//public override bool InstancePerEntity => true;
		public override bool PreAI(Projectile projectile)
		{
			Item helditem = Main.player[projectile.owner].inventory[Main.player[projectile.owner].selectedItem];
			ColoredDamageTypes.ProjectileWeaponSpawns[projectile.identity] = helditem;

			//if (projectile.modProjectile!=null && Config.Instance.DebugMode && Config.Instance.DebugModeTooltips ) ColoredDamageTypes.Log("Item: " + projectile.modProjectile.GetType().ToString() + " ---- " + projectile.Name);

			return base.PreAI(projectile);

		}
	}
}
