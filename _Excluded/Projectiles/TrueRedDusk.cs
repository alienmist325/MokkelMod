using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

using Terraria;
using Terraria.ModLoader;

namespace MokkelMod.Projectiles
{	
	public class TrueRedDusk : ModProjectile 
	{
		public override void SetDefaults()
		{
			projectile.name = "True Red Dusk"; //Name of the projectile, only shows this if you get killed by it
			projectile.width = 30; //Set the hitbox width
			projectile.height = 30; //Set the hitbox height
			projectile.timeLeft = 300; //The amount of time the projectile is alive for
			projectile.penetrate = 1; //Tells the game how many enemies it can hit before being destroyed
			projectile.friendly = true; //Tells the game whether it is friendly to Players/friendly npcs or not
			projectile.hostile = false; //Tells the game whether it is hostile to Players or not
			projectile.tileCollide = true; //Tells the game whether or not it can collide with a tile
			projectile.ignoreWater = true; //Tells the game whether or not projectile will be affected by water
			projectile.melee = true; //Tells the game whether it is a melee projectile or not
			projectile.aiStyle = 0; //How the projectile works, 0 makes the projectile just go straight towards your cursor
			projectile.scale = 1f;
			projectile.light = 0.7f;
		}
		
		public bool atCreation = true;

		
		//How the projectile works
		public override void AI()
        {
			if(atCreation)
			{
				Main.PlaySound(2, -1, -1, 8);
			}
			atCreation = false;
            Player owner = Main.player[projectile.owner]; //Makes a Player variable of owner set as the Player using the projectile
            projectile.alpha = 50; //Semi Transparent
            projectile.rotation += (float)projectile.direction * 0.4f; //Spins in a good speed
			Lighting.AddLight(projectile.width, projectile.height, 1f, 0.9f, 0.6f);
        }
		
		public override void Kill(int timeLeft)
		{
			int dust = Dust.NewDust(projectile.position, projectile.width, projectile.height, 228, projectile.velocity.X * 2f, projectile.velocity.Y * 2f, 100, default(Color), 1.9f);
		}
	}
}
