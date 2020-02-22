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

namespace _ColoredDamageTypes
{
	class ProjectileChanges : GlobalProjectile
	{
		public override bool PreAI(Projectile projectile)
		{
			ColoredDamageTypes.ProjectileWeaponSpawns[projectile.identity] = Main.player[projectile.owner].inventory[Main.player[projectile.owner].selectedItem];
			return base.PreAI(projectile);
		}
	}
}
