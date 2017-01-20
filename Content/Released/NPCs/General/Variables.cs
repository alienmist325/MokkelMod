using System;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

public class Helper
{
	//FindNPI
	public byte NPI;//nearest player index
	public float curDist = 0;
	public float minDist = 0;
	public Vector2 curVect;
	public Vector2 minVect;//vector between npi and npc
	
	public Vector2 rv = Vector2.Zero;
	
	public int qnt;
	
	public Vector2 pMth;
	public Vector2 pEgg;
	
	//Draw sprite
	public float rot;
	public Vector2 screenPos;
	public Texture2D brdMthr;
	public Rectangle drawnRegion;
	public SpriteEffects se; // left = none
	public int frameNum = 0;
	
	public float r(int deg)
	{
		//degrees to radians
		return (float)MathHelper.ToRadians(deg);
	}
	
	public bool inq(float n,int l,int h)
	{
		//test inequality h is highest, l is lowest
		//specifically if an angle in radians is between l and h
		return (r(l) < n && n < r(h));
	}
	
	public float norm(float r)
	{
		//turns deg of rad from -180 - 180 to 0 - 360
		return r + 3.14f; 
	}
	
}