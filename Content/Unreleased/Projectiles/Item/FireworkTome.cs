using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ModLoader;

namespace MokkelMod.Content.Sprites.Projectiles.Item
{	
	public class FireworkTome : ModProjectile 
	{
		public override void SetDefaults()
		{
			projectile.name = "Firework"; //Name of the projectile, only shows this if you get killed by it
			projectile.width = 16; //Set the hitbox width
			projectile.height = 16; //Set the hitbox height
			projectile.timeLeft = 1200; //The amount of time the projectile is alive for
			projectile.penetrate = 7; //Tells the game how many enemies it can hit before being destroyed
			projectile.friendly = true; //Tells the game whether it is friendly to Players/friendly npcs or not
			projectile.hostile = false; //Tells the game whether it is hostile to Players or not
			projectile.tileCollide = true; //Tells the game whether or not it can collide with a tile
			projectile.ignoreWater = true; //Tells the game whether or not projectile will be affected by water
			projectile.magic = true; //Tells the game whether it is a melee projectile or not
			projectile.aiStyle = 0; //How the projectile works, 0 makes the projectile just go straight towards your cursor
		}
		
		//How the projectile works
		public override void AI()
        {
            Player owner = Main.player[projectile.owner]; //Makes a Player variable of owner set as the Player using the projectile
            projectile.alpha = 255; //Semi Transparent
			int dust = Dust.NewDust(projectile.position, projectile.width, projectile.height, 219, projectile.velocity.X * 0.2f, projectile.velocity.Y * 0.2f, 100, default(Color), 1.9f);
			Main.dust[dust].noGravity = false;
        }
	}
}
