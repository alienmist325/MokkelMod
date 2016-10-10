using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

using Terraria;
using Terraria.ModLoader;

namespace MokkelMod.Content.Sprites.Projectiles.Item
{	
	public class MagmaFork : ModProjectile 
	{
		public override void SetDefaults()
		{
			projectile.name = "Magma Fork"; //Name of the projectile, only shows this if you get killed by it
			projectile.width = 20; //Set the hitbox width
			projectile.height = 20; //Set the hitbox height
			projectile.penetrate = -1; //Tells the game how many enemies it can hit before being destroyed
			projectile.friendly = true; //Tells the game whether it is friendly to Players/friendly npcs or not
			projectile.hostile = false; //Tells the game whether it is hostile to Players or not
			projectile.ownerHitCheck = true;
			projectile.tileCollide = false; //Tells the game whether or not it can collide with a tile
			projectile.ignoreWater = true; //Tells the game whether or not projectile will be affected by water
			projectile.melee = true; //Tells the game whether it is a melee projectile or not
			projectile.aiStyle = 19; //How the projectile works, 0 makes the projectile just go straight towards your cursor
			projectile.scale = 1.2f;
            projectile.hide = true;
		}
		public override bool PreAI()
		{
			float protractSpeed = 1.5F;
			float retractSpeed = 1.4F;

			Vector2 heldPos = Main.player[projectile.owner].RotatedRelativePoint(Main.player[projectile.owner].MountedCenter, true);
			projectile.direction = Main.player[projectile.owner].direction;
			Main.player[projectile.owner].heldProj = projectile.whoAmI;
			Main.player[projectile.owner].itemTime = Main.player[projectile.owner].itemAnimation;
			projectile.position.X = heldPos.X - (float)(projectile.width / 2);
			projectile.position.Y = heldPos.Y - (float)(projectile.height / 2);
			if (!Main.player[projectile.owner].frozen)
			{
				if (projectile.ai[0] == 0f)
				{
					projectile.ai[0] = 3f;
					projectile.netUpdate = true;
				}
				if (Main.player[projectile.owner].itemAnimation < Main.player[projectile.owner].itemAnimationMax / 3)
				{
					projectile.ai[0] -= retractSpeed;
				}
				else
				{
					projectile.ai[0] += protractSpeed;
				}
			}
			projectile.position += projectile.velocity * projectile.ai[0];
			if (Main.player[projectile.owner].itemAnimation == 0)
			{
				projectile.Kill();
			}
			projectile.rotation = (float)Math.Atan2((double)projectile.velocity.Y, (double)projectile.velocity.X) + 2.355f;
			if (projectile.spriteDirection == -1)
			{
				projectile.rotation -= 1.57f;
			}
			return false;
		}
		//How the projectile works
		public override void AI()
        {
            Player owner = Main.player[projectile.owner]; //Makes a Player variable of owner set as the Player using the projectile
        }
	}
}
