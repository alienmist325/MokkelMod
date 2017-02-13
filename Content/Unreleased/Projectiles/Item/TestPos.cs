using System;
using Terraria;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Terraria.ID;

namespace MokkelMod.Content.Sprites.Projectiles.Item
{
	public class TestPos : ModProjectile
	{
		
		public override void SetDefaults()
		{
			projectile.name = "TestPos";
			projectile.width = 16;
			projectile.height = 16;
			projectile.timeLeft = 2;
			projectile.penetrate = -1;
			projectile.ignoreWater = true;
			projectile.friendly = true;
			projectile.scale = 1f;
			projectile.light = 1f;
			projectile.tileCollide = false;
			
		}
	}
}