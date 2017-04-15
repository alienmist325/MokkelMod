using Terraria;
using System;
using Terraria.ModLoader;
using Terraria.ID;
using Microsoft.Xna.Framework;

namespace MokkelMod.NPCs
{
	public class CometHead : ModNPC
	{
		int timer = 0;
		float dir;
		int hyp;
		float xsp;
		float ysp;
		int dmg = 10;
		int noProj;
		float lightInc = 0.1f;
		float light = 0.1f;
		
		public override void SetDefaults()
		{
			npc.name = "Comet Head";
			npc.width = 28;
			npc.height = 28;
			npc.value = 20;
			npc.noGravity = true;
			npc.lifeMax = 900;
			npc.damage = 40;
			npc.defense = 20;
			npc.knockBackResist = 0f;
			npc.noTileCollide = true;
			npc.HitSound = SoundID.NPCHit3;
			npc.DeathSound = SoundID.NPCDeath3;
			npc.aiStyle = 44;
		}
		
		public override void NPCLoot()
		{
			if (Main.rand.Next(2) == 0)
			{
				Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("CometBar"));
			}
		}
		
		public override bool CheckDead()
		{
			dir = (float)(Main.rand.Next(100) * 0.36); // max 360 degrees
			noProj = Main.rand.Next(3) + 1;
			while (noProj > 0)
			{
				hyp = Main.rand.Next(5) + 1;
				dir += 120;
				xsp = (float)(Math.Sin(dir) * hyp);
				ysp = (float)(Math.Cos(dir) * hyp);
				Projectile.NewProjectile(npc.position.X, npc.position.Y,xsp,ysp,mod.ProjectileType("CometHead"),dmg,1.0f,255,0f,0f);
				noProj--;
			}
			Main.PlaySound(4,npc.position,14);
			return true;
		}
		
		public override void AI()
		{
			int centerX = (int)(npc.position.X - (npc.width/2));
			int centerY = (int)(npc.position.Y - (npc.height/2));
			Vector2 center = new Vector2(centerX, centerY);
			
			// resonating light
			if (light < 0.1)
			{
				lightInc = 0.01f;
			}
			if (light > 1)
			{
				lightInc = -0.01f;
			}
			light += lightInc;
			Lighting.AddLight(center,light,light,light);
			timer++;
			if (timer == 1)
			{
				Main.PlaySound(2,npc.position,89);
			}
			
			Player p = Main.player[Main.myPlayer];
			Dust.NewDust(center, npc.width, npc.height, mod.DustType("Comet"));
			 // blue 1 0.4 0.4
			if (Math.Abs((npc.position.X + npc.position.Y) - (p.position.X + p.position.Y))<250)
			{
				npc.velocity.X += npc.direction * 0.01f;
			}
			if (npc.position.X < p.position.X)
			{
				npc.spriteDirection = 1;
				npc.rotation = (float)Math.Atan2((double)(p.position.Y - centerY),(double)(p.position.X - centerX)); // tan in radians
			}
			else
			{
				npc.spriteDirection = -1;
				npc.rotation = (float)Math.Atan2((double)(p.position.Y - centerY),(double)(p.position.X - centerX)) + 3.14f; //tan in radians + half a turn (pi)
			}
			
		}
	}
}