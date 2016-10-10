using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MokkelMod.Content.Sprites.Items
{
	public class ItemTweaks : GlobalItem
	{
		public override void SetDefaults(Item item)
		{
			switch(item.type)
			{
				case ItemID.Shuriken:
					item.ammo = ProjectileID.Shuriken;
					break;
			}
		}
		
		/*public override void PostDrawInWorld(Item item, SpriteBatch spriteBatch, Color lightColor, Color alphaColor, float rotation, float scale)
		{
			Vector2 dist;
			for(int i = 0; i < 200; i++)
			{
				dist = Main.npc[i].position - Main.player[Main.myPlayer].position;
				if(Main.npc[i].active && Main.npc[i].type == mod.NPCType("BroodMother") && dist.X + dist.Y <= (new Vector2(Main.screenWidth,Main.screenHeight)).Length())
				{
					
					Texture2D fore = mod.GetTexture("Sandstorm");
					spriteBatch.Draw(fore,Main.npc[i].position - Main.screenPosition,null,Color.White,0f,Vector2.Zero,1f,SpriteEffects.None,0.1f);
				}
			}
		}*/
	}
}
