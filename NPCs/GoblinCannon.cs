using System;
using System.IO;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace MokkelMod.NPCs
{
    public class GoblinCannon : ModNPC
    {
        private NPC parent { get { return Main.npc[(int)npc.ai[0]]; } set { npc.ai[0] = value.whoAmI; } }
		private int counter = 0;

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Cannon");
        }

        public override void SetDefaults()
        {
            npc.aiStyle = -1;
            npc.lifeMax = 1000;
            npc.damage = 23;
            npc.knockBackResist = 0f;
            npc.width = 34;
            npc.height = 54;
            npc.value = Item.buyPrice(0, 0, 0, 0);
            npc.npcSlots = 0f;
            npc.boss = false;
            npc.lavaImmune = true;
            npc.noGravity = true;
            npc.noTileCollide = true;
            npc.HitSound = SoundID.NPCHit1;
            npc.DeathSound = SoundID.NPCDeath1;
            npc.buffImmune[24] = true;
            npc.alpha = 255;
            npc.netAlways = true;
        }

        public override void AI()
        {
			npc.TargetClosest(true);
			counter++;
			if (counter % 90 == 0) 
			{
				Vector2 aim = Main.player[npc.target].Center - npc.Center;
				aim.Normalize();
				Projectile.NewProjectile(npc.Center.X, npc.Center.Y, aim.X * 10f, aim.Y * 10f, 240, 25, 1, Main.myPlayer, 0, 0);
			}
            Vector2 goPosition = parent.Center + new Vector2(24, 27);;
			if (parent.spriteDirection == 1) 
			{
				goPosition = parent.Center + new Vector2(-24, 27);;
			}
			else
			{
				goPosition = parent.Center + new Vector2(24, 27);;
			}
            npc.Center = goPosition;
              

            if (!parent.active)
                npc.life = 0;
        }

        public override bool CheckDead()
        {
            if (npc.life <= 0)
            {
                parent.ai[3] = 0;
            }
            return true;
        }
    }
    
}
