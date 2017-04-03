using System;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

public class Helper
{
    //FindNPI
    public byte NPI = 0;//nearest player index
    public float curDist = 0;
    public float minDist = 0;
    public Vector2 curVect;
    public Vector2 minVect;//vector between npi and npc

    //general
    public int qnt;
    public Vector2 pMth = Vector2.Zero;
    public Vector2 pEgg = Vector2.Zero;
    public float real = 0;

    public int[] dif = new int[2] { 1, 1 };

    //Draw sprite
    public float rot = 0f;
    public Vector2 screenPos;
    public Texture2D brdMthr;
    public Rectangle drawnRegion;
    public SpriteEffects se; // left = none
    public int frameNum = 0;

    //phases
    public int phase = 0;
    public int[] timer = new int[2]; //new int[max timers] misc
    public int[] pTimer = new int[3]; //new byte[max phases] phases
    public int[] pMax = new int[3] { 299, 10000, 51 };

    //phase 0
    public int RHS = 1;//whether it is on the right hand side or not
    public int rand = 100;
    public float vel = 5;
    public bool turbo = false;
    public Vector2 oldTarg = Vector2.Zero;

    public Vector2 upv = Vector2.Zero; //used player velocity
    public int maxi;

    //phase 1
    public Vector2 swpPnt;
    public Vector2 swpOrig;
    public Vector2 swpNPC;
    public bool swpStrt = true;
    public bool preSwoop = true;
    public bool passedPlayer = false;
    public Vector2 swpPlyr;
    public float velocity = 0.1f;

    //phase 2
    public bool preLay = true;

    public void rec(string a, ref float r, Vector2 pv, Vector2 nv)
    {
        Main.NewText(a +
            " Deg: " + ((int)d(rot)).ToString() +
            /**" Rad: " + rot.ToString() +**/
            " MinVect: " + (minVect).ToString() +
            " R:" + d(r).ToString() +
            " Q: " + qnt.ToString() +
            " Mouth: " + pMth.ToString() +
            " Egg: " + pEgg.ToString() +
            " playerVel: " + pv.X.ToString() +
            " broodVel: " + vel.ToString() +
            " box: " + rand.ToString() +
            " turbo: " + turbo.ToString() +
            " phase: " + phase.ToString() +
            " pTimer: " + pTimer[phase].ToString() +
            " swpOrig: " + swpOrig.ToString() +
            " swpStrt: " + swpStrt.ToString() +
            " se: " + se.ToString() +
            " pos: " + nv.ToString()
            );

    }

    public void FindNPI(NPC npc)
    {
        for (byte i = 0; i < 254; i++)
        {
            if (Main.player[i].active)
            {
                curVect = Main.player[i].Center - npc.Center;
                curDist = curVect.Length(); //distance between npc and player
                if (curDist < minDist || minDist == 0)
                {
                    NPI = i;

                    minDist = curDist;

                }
            }
            else
            {
                i = 254; //break from cycle because all proceeding positions will be null.
            }
        }
        minVect = curVect;
    }

    public float away(Vector2 a, Vector2 b)
    {
        Vector2 c;
        c = Vector2.Subtract(a, b);
        return c.Length();
    }

    public float r(float deg)
    {
        //degrees to radians
        return (float)MathHelper.ToRadians(deg);
    }

    public float d(float rad)
    {
        //radians to degrees
        return (float)MathHelper.ToDegrees(rad);
    }

    public bool inq(float n, int l, int h)
    {
        //test inequality h is highest, l is lowest
        //specifically if an angle in radians is between l and h
        return (r(l) < n && n < r(h));
    }

    public void RestrictRot()
    {
        //restrict rotation

        if (qnt == 1 && real > r(10))
        {
            real = r(10);
        }
        if (qnt == 4 && real < r(350))
        {
            real = r(350);
        }
        //right
        if (qnt == 2 && real < r(170))
        {
            real = r(170);
        }
        if (qnt == 3 && real > r(190))
        {
            real = r(190);
        }

    }

    public void Timer()
    {
        //0 controls wing flapping
        //1 controls
        //timer
        timer[0]++;
        switch (timer[0])
        {
            case 5:
                frameNum = 1;
                break;
            case 10:
                frameNum = 0;
                timer[0] = 0;
                break;
        }
        if (phase == 0)
        {
            timer[1] += timer[1] < maxi ? 1 : -1;
            timer[1] = timer[1] == maxi ? 0 : timer[1];
        }

        for (byte i = 0; i < 3; i++)
        {
            pTimer[i] += phase == i ? 1 : 0;
            pTimer[i] = pTimer[i] > pMax[i] ? 0 : pTimer[i];
        }

        //phase = timer[1] == 300 ? 2 : phase;

    }

    public bool canShoot(Vector2 vecFrom)
    {
        float r = vecFrom.ToRotation();
        r += 3.14f;
        float deg = d(r);
        return
            qnt == 1 && deg < 30 ||
            qnt == 2 && deg > 150 ||
            qnt == 3 && deg < 240 ||
            qnt == 4 && deg > 300;
    }

    public void Fluc(ref int f, int max, int min, int no)
    {
        dif[no] *= (f == max || f == min) ? -1 : 1;
        f += dif[no];
    }

    public Vector2 Turbo(Vector2 pv)
    {
        if (turbo)
        {
            //if it faster than half your speed, and it can't see you, speed up
            vel += Math.Abs(pv.X) > Math.Abs(vel / 2) ? 0.01f : 0f;
        }
        else
        {
            //if your targ speed is very high (>5) and the player has slowed down (<4), slow down
            vel -= Math.Abs(pv.X) < 4 && Math.Abs(vel) > 5 ? 0.1f : 0f;
        }
        maxi = (int)(Math.Abs(pv.X) * 10); //maxi decides how big timer[1] must be to update (i.e. set to 0)
        upv = timer[1] == 0 ? pv : upv; //every 2 ticks update playerVel
        return Math.Abs(pv.X) > 4 ? upv * 30 : Vector2.Zero; // no extra dist if player is slow
    }

    public void testPos(Vector2 pos)
    {
        Projectile.NewProjectile(pos, Vector2.Zero, 736, 0, 0f);
    }

    public float swoopFormula(float x)//pos is useless half the time..
    {

        return (float)(-0.003 * Math.Pow(x - swpPnt.X, 2) + swpPnt.Y); //-0.0015
    }

    public float accelerate()
    {
        int max = 15;
        int min = 3;
        if (passedPlayer)
        {
            velocity *= 0.95f;
            if (Math.Abs(velocity) < min)
            {
                velocity = min;
            }
        }
        else
        {
            velocity += 0.5f;//*= 1.05f;
            if (Math.Abs(velocity) > max)
            {
                velocity = max;
            }
        }

        return Math.Abs(velocity) * RHS * -1;
    }

    public Vector2 gtp(Vector2 xy)
    {
        //get tile position
        //is it x or y, bool X tells you
        xy /= 16;
        xy.X = (int)xy.X;
        xy.Y = (int)xy.Y;
        return xy;
    }
}
