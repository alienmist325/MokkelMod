using System.IO;
using System;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.World.Generation;
using Microsoft.Xna.Framework;
using Terraria.GameContent.Generation;

namespace MokkelMod.Content.Unreleased.Worlds
{
	public class World : ModWorld
	{
		public bool cometEvent = false; 
		int radius;
		int angle;
		int spawnX;
		int spawnY;
		public override void ModifyWorldGenTasks(List<GenPass> tasks, ref float totalWeight)
		{
			///a
			int ShiniesIndex = tasks.FindIndex(genpass => genpass.Name.Equals("Final Cleanup"));
			if (ShiniesIndex == -1)
			{
				return;
			}
			tasks.Insert(ShiniesIndex +  1, new PassLegacy("JadeTemple", delegate(GenerationProgress progress)
			{
                progress.Message = "Sealing away spirits; Generating island";
				
				//island gen
				int XTILE = WorldGen.genRand.Next(300, Main.maxTilesX - 1000);
            int yAxis = Main.maxTilesY / 10;
			for (int xAxis = XTILE; xAxis < XTILE + 150; xAxis++)
			{
				int Slope2 = Math.Abs(Main.rand.Next(67,83) - Math.Abs((xAxis - XTILE) - Main.rand.Next(67,83))) / 3;
				string SlopeText = Slope2.ToString();
				//Main.NewText(SlopeText, Color.Orange.R, Color.Orange.G, Color.Orange.B);
				for (int I = 0; I < Slope2; I++)
				{
					WorldMethods.TileRunner(xAxis, yAxis + I, (double)19, 1, 2, true, 0f, 0f, true, true);
				}
				WorldMethods.TileRunner(xAxis, yAxis, (double)19, 1, 2, true, 0f, 0f, true, true);
				if (Main.rand.Next(30) == 0)
				{
					WorldMethods.TileRunner(xAxis, yAxis - 5, (double)19, 1, 2, true, 0f, 0f, true, true);
				}
			}
			
			//temple gen
			progress.Message = "Sealing away spirits; Creating base";
			int center = XTILE + 75;
			int centerY = yAxis - 16;
			WorldMethods.TempleBasee(center, centerY, 20, 13, (ushort)30, 1, false, (ushort)2);
			
			//rooftop
			
			progress.Message = "Sealing away spirits; Building roof";
			int baseY = yAxis - 30;
			WorldMethods.TempleRoof((int)center, (int)baseY, 55, 55, 190, 312);
			
			
				
				}));
		}
		public override void PostUpdate()
		{
			//Main.NewText(Main.mouseY.ToString());
			//Main.NewText("X: " + Main.player[Main.myPlayer].position.X);
			//Main.NewText("Y: " + Main.player[Main.myPlayer].position.Y);
			Player p = Main.player[Main.myPlayer];
			Vector2 pos = p.position;
			
			//if ( == -1)
			//{
			//	Main.NewText(Main.tile[(int)pos.X/16,(int)pos.Y/16].collisionType.ToString());
			//}
			
			if (!Main.dayTime && NPC.downedPlantBoss && /**Main.rand.Next(100) % 99 == 0 &&**/ !cometEvent)
			{
				cometEvent = true;
				Main.NewText("Comets are falling from outerspace!!", Color.SkyBlue.R, Color.SkyBlue.G, Color.SkyBlue.B);
			}				
			
			if (cometEvent && Main.dayTime)
			{
				cometEvent = false;
				Main.NewText("Comets have stopped falling from outerspace.", Color.SkyBlue.R, Color.SkyBlue.G, Color.SkyBlue.B);
			}
			
			if (cometEvent)
			{
				if (Main.rand.Next(1000) % 999 == 0)
				{
					radius = Main.rand.Next(1000); //hyp
					angle = Main.rand.Next(360);
					spawnX = (int)(p.position.X + (Math.Sin(angle)*radius));
					angle = Main.rand.Next(360);
					spawnY = (int)(p.position.Y + (Math.Cos(angle)*radius));
					NPC.NewNPC(spawnX, spawnY, mod.NPCType("CometHead"), 0, 0f, 0f, 0f, (float)Main.myPlayer, Main.myPlayer);
				}
			}
			
		}
	}
}
