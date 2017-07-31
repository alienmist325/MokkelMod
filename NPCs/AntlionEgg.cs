using System;
using Terraria;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria.ID;

namespace MokkelMod.NPCs
{
    public class AntlionEgg : ModNPC
    {
        int frameNum = 1;
        bool toRight = true;
        int timer = 0;
        Helper h = new Helper();
        Vector2 tilePos = Vector2.Zero;
        Vector2 nv;

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Antlion Egg");
        }

        public override void SetDefaults()
        {
            npc.width = 36;
            npc.height = 42;
            npc.lifeMax = 200;
            npc.noGravity = npc.ai[0] == 1;
            npc.damage = 0;
            npc.defense = 20;
            npc.noTileCollide = npc.ai[0] == 1;
            npc.HitSound = SoundID.NPCHit2;
            npc.DeathSound = SoundID.NPCDeath5;
            npc.timeLeft = NPC.activeTime * 30;
            npc.value = 100f;
            npc.knockBackResist = 0f;
            Main.npcFrameCount[npc.type] = 3;
        }

        public override void FindFrame(int frameHeight)
        {
            npc.frame = new Rectangle(0, frameHeight * (frameNum - 1), 36, frameHeight);
        }

        public override void AI()
        {
            ErrorLogger.Log(Main.npc[(int)npc.ai[1]].ai[2].ToString());
            if (npc.ai[0] == 1)
            {
                MoveTo(Main.npc[(int)npc.ai[1]].position + (new Vector2(Main.npc[(int)npc.ai[1]].ai[2]*58, 134)), 2);
                npc.noGravity = true;
                npc.noTileCollide = true;
            }
            tilePos = h.gtp(npc.Center);
            timer++;
            if (timer % 200 == 0)
            {
                for (int i = 0; i < 10; i++)
                {
                    Dust.NewDust(npc.position, npc.width, npc.height, 32);
                }
                frameNum++;
            }
            if (timer == 600)
            {
                for (int i = 0; i < 50; i++)
                {
                    Dust.NewDust(npc.position, npc.width, npc.height, 32);
                }
                NPC.NewNPC((int)npc.Center.X, (int)npc.Center.Y, NPCID.FlyingAntlion);
                npc.life = 0;
            }
            npc.rotation += (3.14f / 90) * (toRight ? 1 : -1);
            if (npc.rotation > 3.14f / 64)
            {
                toRight = false;
            }
            if (npc.rotation < -3.14f / 64)
            {
                toRight = true;
            }
        }

        public bool MoveTo(Vector2 target, float speed) //bool tells you when movement is finished
        {
            h.testPos(target);
            nv = target - npc.Center;
            if (nv.Length() < Math.Sqrt(2 * Math.Pow(h.vel, 2)) + 0.1f)
            {
                //npc.velocity = Vector2.Zero;
                nv /= 2;

            }
            else
            {
                nv.Normalize();
                nv *= speed;
            }
            //ErrorLogger.Log(nv.ToString());
            npc.velocity = nv;
            if (nv.Length() < 0.01f)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}