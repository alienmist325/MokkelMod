using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

using Terraria;
using Terraria.ModLoader;

namespace MokkelMod.Projectiles
{	
	public class Infernorion : ModProjectile 
	{
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Infernorion");
        }

        public override void SetDefaults()
		{
			projectile.width = 60; //Set the hitbox width
			projectile.height = 56; //Set the hitbox height
			projectile.timeLeft = 600; //The amount of time the projectile is alive for
			projectile.penetrate = 10; //Tells the game how many enemies it can hit before being destroyed
			projectile.friendly = true; //Tells the game whether it is friendly to Players/friendly npcs or not
			projectile.hostile = false; //Tells the game whether it is hostile to Players or not
			projectile.tileCollide = true; //Tells the game whether or not it can collide with a tile
			projectile.ignoreWater = true; //Tells the game whether or not projectile will be affected by water
			projectile.melee = true; //Tells the game whether it is a melee projectile or not
			projectile.aiStyle = 3; //How the projectile works, 0 makes the projectile just go straight towards your cursor
			projectile.scale = 1f;
		}
		
		//How the projectile works
		public override void AI()
        {
            Player owner = Main.player[projectile.owner]; //Makes a Player variable of owner set as the Player using the projectile
            projectile.rotation += (float)projectile.direction * 0.6f; //Spins in a good speed
			int dust = Dust.NewDust(projectile.position, projectile.width, projectile.height, 6, projectile.velocity.X * 0.2f, projectile.velocity.Y * 0.2f, 100, default(Color), 1.9f);
			Main.dust[dust].noGravity = true;
        }
		
		public override void OnHitNPC(NPC n, int damage, float knockback, bool crit)
        {
            Player owner = Main.player[projectile.owner];
            n.AddBuff(24, 300);
            n.AddBuff(69, 600);
			Main.player[projectile.owner].AddBuff(116, 300);

        }
	}
}