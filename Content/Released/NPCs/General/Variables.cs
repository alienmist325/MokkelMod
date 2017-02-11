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
    public int phase = 1;
    public int[] timer = new int[4];

    //phase 1
    public bool LHS = true;//whether it is on the left hand side or not
    public int hoverPos = 25;
    public int rand = 100;
    public int interval = 1;

    public void rec(string a, ref float r)
    {
        Main.NewText(a +
            " Deg: " + ((int)d(rot)).ToString() +
            /**" Rad: " + rot.ToString() +**/
            " MinVect: " + (minVect).ToString() +
            " R:" + d(r).ToString() +
            " Q: " + qnt.ToString() +
            " Mouth: " + pMth.ToString() +
            " Egg: " + pEgg.ToString() +
            " distAway: " + hoverPos.ToString() +
            " box: " + rand.ToString()
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

    public float away(Vector2 a,Vector2 b)
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
	
	public bool inq(float n,int l,int h)
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
        timer[0]++;
        switch(timer[0])
        {
            case 5:
                frameNum = 1;
                break;
            case 10:
                frameNum = 0;
                timer[0] = 0;
                break;
        }
        timer[1] += phase == 1 ? 1 : 0;
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
}
