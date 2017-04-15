using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

using Terraria;
using Terraria.ModLoader;

namespace MokkelMod.Projectiles
{	
	public class GraniteSlasher : ModProjectile 
	{
		public override void SetDefaults()
		{
			projectile.name = "Granite Shard"; //Name of the projectile, only shows this if you get killed by it
			projectile.width = 22; //Set the hitbox width
			projectile.height = 22; //Set the hitbox height
			projectile.timeLeft = 180; //The amount of time the projectile is alive for
			projectile.penetrate = -1; //Tells the game how many enemies it can hit before being destroyed
			projectile.friendly = true; //Tells the game whether it is friendly to Players/friendly npcs or not
			projectile.hostile = false; //Tells the game whether it is hostile to Players or not
			projectile.tileCollide = true; //Tells the game whether or not it can collide with a tile
			projectile.ignoreWater = true; //Tells the game whether or not projectile will be affected by water
			projectile.melee = true; //Tells the game whether it is a melee projectile or not
			projectile.aiStyle = 1; //How the projectile works, 0 makes the projectile just go straight towards your cursor
		}
		
		//How the projectile works
		public override void AI()
        {
            Player owner = Main.player[projectile.owner]; //Makes a Player variable of owner set as the Player using the projectile

        }
	}
}
