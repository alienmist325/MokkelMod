using System.IO;
using System.Collections.Generic;
using Terraria;
using System;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.World.Generation;
using Microsoft.Xna.Framework;
using Terraria.GameContent.Generation;

namespace MokkelMod
{
	public class WorldMethods
	{
		public static void TempleRoof(int X, int Y, int width, int height, int rotation1, ushort type)
		{
			int width2 = width / 3;
			for (int rotation2 = rotation1; rotation2 < 350; rotation2++)
			{
				int DistX = (int)(0 - (Math.Sin(rotation2)* (width / 4)));
				int DistY = (int)(0 - (Math.Cos(rotation2)* (height / 4)));
				if (DistY > 5)
				{
				   WorldMethods.TileRunner(X + DistX + width2, (Y - (height / 3)) + DistY, (double)4, 1, type, true, 0f, 0f, false, true);
			   WorldMethods.TileRunner(X + (DistX - width2), (Y - (height / 3)) + DistY, (double)4, 1, type, true, 0f, 0f, false, true);
				}
			}
			//fourth on each side
				WorldMethods.TempleBasee(X, (Y - height / 2) - 5, 2, (height / 3) + 8, type, 3, true, (ushort)2);
		}
		public static void TempleBasee(int X, int Y, int length, int height, ushort type2, float slope, bool replace, ushort replacetile)
		{
			float trueslope = 1 / slope;
			int Xstray = length / 2;
			for (int level = 0; level <= height; level++)
			{
				for (int I = X - (int)(length + (level * trueslope)); I < X + (int)(length + (level * trueslope)); I++)
				{
					if (Main.tile[(int)I, (int)(Y + level)].type != replacetile || replace)
					{
						Main.tile[(int)I, (int)(Y + level)].active(true);
						Main.tile[(int)I, (int)(Y + level)].type = type2;
					}
				}
			}
		}
		public static void TileRunner(int i, int j, double strength, int steps, int type, bool addTile = false, float speedX = 0f, float speedY = 0f, bool noYChange = false, bool overRide = true)
        {
            double num = strength;
            float num2 = (float)steps;
            Vector2 pos;
			pos.X = (float)i;
            pos.Y = (float)j;
            Vector2 randVect;
			randVect.X = (float)WorldGen.genRand.Next(-10, 11) * 0.1f;
            randVect.Y = (float)WorldGen.genRand.Next(-10, 11) * 0.1f;
            if (speedX != 0f || speedY != 0f)
            {
                randVect.X = speedX;
                randVect.Y = speedY;
			}

            while (num > 0.0 && num2 > 0f)
            {
                if (pos.Y < 0f && num2 > 0f && type == 59)
                {
                    num2 = 0f;
                }
                num = strength * (double)(num2 / (float)steps);
                num2 -= 1f;
                int num3 = (int)((double)pos.X - num * 0.5);
                int num4 = (int)((double)pos.X + num * 0.5);
                int num5 = (int)((double)pos.Y - num * 0.5);
                int num6 = (int)((double)pos.Y + num * 0.5);
                if (num3 < 1)
                {
                    num3 = 1;
                }
                if (num5 < 1)
                {
                    num5 = 1;
                }
                if (num6 > Main.maxTilesY - 1)
                {
                    num6 = Main.maxTilesY - 1;
                }
                for (int k = num3; k < num4; k++)
                {
                    for (int l = num5; l < num6; l++)
                    {
                        if ((double)(Math.Abs((float)k - pos.X) + Math.Abs((float)l - pos.Y)) < strength * 0.5 * (1.0 + (double)WorldGen.genRand.Next(-10, 11) * 0.015))
                        {
                        
                            if (type < 0)
                            {
                                if (type == -2 && Main.tile[k, l].active() && (l < WorldGen.waterLine || l > WorldGen.lavaLine))
                                {
                                    Main.tile[k, l].liquid = 255;
                                    if (l > WorldGen.lavaLine)
                                    {
                                        Main.tile[k, l].lava(true);
                                    }
                                }
                                Main.tile[k, l].active(false);
                            }
                            else
                            {
                                if (overRide || !Main.tile[k, l].active())
                                {
                                    Tile tile = Main.tile[k, l];
                                    bool flag3 = Main.tileStone[type] && tile.type != 1;
                                    if (!TileID.Sets.CanBeClearedDuringGeneration[(int)tile.type])
                                    {
                                        flag3 = true;
                                    }
                                    ushort type2 = tile.type;
                                    if (type2 <= 147)
                                    {
                                        if (type2 <= 45)
                                        {
                                            if (type2 != 1)
                                            {
                                                if (type2 == 45)
                                                {
                                                    goto IL_575;
                                                }
                                            }
                                            else if (type == 59 && (double)l < Main.worldSurface + (double)WorldGen.genRand.Next(-50, 50))
                                            {
                                                flag3 = true;
                                            }
                                        }
                                        else if (type2 != 53)
                                        {
                                            if (type2 == 147)
                                            {
                                                goto IL_575;
                                            }
                                        }
                                        else
                                        {
                                            if (type == 40)
                                            {
                                                flag3 = true;
                                            }
                                            if ((double)l < Main.worldSurface && type != 59)
                                            {
                                                flag3 = true;
                                            }
                                        }
                                    }
                                    else if (type2 <= 196)
                                    {
                                        switch (type2)
                                        {
                                        case 189:
                                        case 190:
                                            goto IL_575;
                                        default:
                                            if (type2 == 196)
                                            {
                                                goto IL_575;
                                            }
                                            break;
                                        }
                                    }
                                    else
                                    {
                                        switch (type2)
                                        {
                                        case 367:
                                        case 368:
                                            if (type == 59)
                                            {
                                                flag3 = true;
                                            }
                                            break;
                                        default:
                                            switch (type2)
                                            {
                                            case 396:
                                            case 397:
                                                flag3 = !TileID.Sets.Ore[type];
                                                break;
                                            }
                                            break;
                                        }
                                    }
                                    IL_5B7:
                                    if (!flag3)
                                    {
                                        tile.type = (ushort)type;
                                        goto IL_5C5;
                                    }
                                    goto IL_5C5;
                                    IL_575:
                                    flag3 = true;
                                    goto IL_5B7;
                                }
                                IL_5C5:
                                if (addTile)
                                {
                                    Main.tile[k, l].active(true);
                                    Main.tile[k, l].liquid = 0;
                                    Main.tile[k, l].lava(false);
                                }
                                if (type == 59 && l > WorldGen.waterLine && Main.tile[k, l].liquid > 0)
                                {
                                    Main.tile[k, l].lava(false);
                                    Main.tile[k, l].liquid = 0;
                                }
                            }
                        }
                    }
                }
                pos += randVect;
                if (num > 50.0)
                {
                    pos += randVect;
                    num2 -= 1f;
                    randVect.Y += (float)WorldGen.genRand.Next(-10, 11) * 0.05f;
                    randVect.X += (float)WorldGen.genRand.Next(-10, 11) * 0.05f;
                    if (num > 100.0)
                    {
                        pos += randVect;
                        num2 -= 1f;
                        randVect.Y += (float)WorldGen.genRand.Next(-10, 11) * 0.05f;
                        randVect.X += (float)WorldGen.genRand.Next(-10, 11) * 0.05f;
                        if (num > 150.0)
                        {
                            pos += randVect;
                            num2 -= 1f;
                            randVect.Y += (float)WorldGen.genRand.Next(-10, 11) * 0.05f;
                            randVect.X += (float)WorldGen.genRand.Next(-10, 11) * 0.05f;
                            if (num > 200.0)
                            {
                                pos += randVect;
                                num2 -= 1f;
                                randVect.Y += (float)WorldGen.genRand.Next(-10, 11) * 0.05f;
                                randVect.X += (float)WorldGen.genRand.Next(-10, 11) * 0.05f;
                                if (num > 250.0)
                                {
                                    pos += randVect;
                                    num2 -= 1f;
                                    randVect.Y += (float)WorldGen.genRand.Next(-10, 11) * 0.05f;
                                    randVect.X += (float)WorldGen.genRand.Next(-10, 11) * 0.05f;
                                    if (num > 300.0)
                                    {
                                        pos += randVect;
                                        num2 -= 1f;
                                        randVect.Y += (float)WorldGen.genRand.Next(-10, 11) * 0.05f;
                                        randVect.X += (float)WorldGen.genRand.Next(-10, 11) * 0.05f;
                                        if (num > 400.0)
                                        {
                                            pos += randVect;
                                            num2 -= 1f;
                                            randVect.Y += (float)WorldGen.genRand.Next(-10, 11) * 0.05f;
                                            randVect.X += (float)WorldGen.genRand.Next(-10, 11) * 0.05f;
                                            if (num > 500.0)
                                            {
                                                pos += randVect;
                                                num2 -= 1f;
                                                randVect.Y += (float)WorldGen.genRand.Next(-10, 11) * 0.05f;
                                                randVect.X += (float)WorldGen.genRand.Next(-10, 11) * 0.05f;
                                                if (num > 600.0)
                                                {
                                                    pos += randVect;
                                                    num2 -= 1f;
                                                    randVect.Y += (float)WorldGen.genRand.Next(-10, 11) * 0.05f;
                                                    randVect.X += (float)WorldGen.genRand.Next(-10, 11) * 0.05f;
                                                    if (num > 700.0)
                                                    {
                                                        pos += randVect;
                                                        num2 -= 1f;
                                                        randVect.Y += (float)WorldGen.genRand.Next(-10, 11) * 0.05f;
                                                        randVect.X += (float)WorldGen.genRand.Next(-10, 11) * 0.05f;
                                                        if (num > 800.0)
                                                        {
                                                            pos += randVect;
                                                            num2 -= 1f;
                                                            randVect.Y += (float)WorldGen.genRand.Next(-10, 11) * 0.05f;
                                                            randVect.X += (float)WorldGen.genRand.Next(-10, 11) * 0.05f;
                                                            if (num > 900.0)
                                                            {
                                                                pos += randVect;
                                                                num2 -= 1f;
                                                                randVect.Y += (float)WorldGen.genRand.Next(-10, 11) * 0.05f;
                                                                randVect.X += (float)WorldGen.genRand.Next(-10, 11) * 0.05f;
                                                            }
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
                randVect.X += (float)WorldGen.genRand.Next(-10, 11) * 0.05f;
                if (randVect.X > 1f)
                {
                    randVect.X = 1f;
                }
                if (randVect.X < -1f)
                {
                    randVect.X = -1f;
                }
                if (!noYChange)
                {
                    randVect.Y += (float)WorldGen.genRand.Next(-10, 11) * 0.05f;
                    if (randVect.Y > 1f)
                    {
                        randVect.Y = 1f;
                    }
                    if (randVect.Y < -1f)
                    {
                        randVect.Y = -1f;
                    }
                }
                else if (type != 59 && num < 3.0)
                {
                    if (randVect.Y > 1f)
                    {
                        randVect.Y = 1f;
                    }
                    if (randVect.Y < -1f)
                    {
                        randVect.Y = -1f;
                    }
                }
                if (type == 59 && !noYChange)
                {
                    if ((double)randVect.Y > 0.5)
                    {
                        randVect.Y = 0.5f;
                    }
                    if ((double)randVect.Y < -0.5)
                    {
                        randVect.Y = -0.5f;
                    }
                    if ((double)pos.Y < Main.rockLayer + 100.0)
                    {
                        randVect.Y = 1f;
                    }
                    if (pos.Y > (float)(Main.maxTilesY - 300))
                    {
                        randVect.Y = -1f;
                    }
                }
            }
        }
	}

    public class DynastyBiome
    {
        Mod mod;

        internal int dynastyBiomeRadius = 120;

        internal int dynastyX, dynastyY;

        public DynastyBiome(Mod mod)
        {
            this.mod = mod;
        }

        internal void Generate()
        {
            bool canGenerate = false;
            while (!canGenerate)
            {
                canGenerate = true;

                // By using this set of random coordinates, the biome can not generate near the jungle, nor the dungeon, nor the sea, nor hell.
                int dynastyBiomeX = WorldGen.genRand.Next((int)(Main.maxTilesX * 0.3), (int)(Main.maxTilesX * 0.7));
                int dynastyBiomeY = WorldGen.genRand.Next((int)Main.rockLayer, Main.maxTilesY - 350);

                for (int x = dynastyBiomeX - dynastyBiomeRadius; x < dynastyBiomeX + dynastyBiomeRadius; x += 3)
                {
                    for (int y = dynastyBiomeY - dynastyBiomeRadius; y < dynastyBiomeY + dynastyBiomeRadius; y += 3)
                    {
                        // By doing these checks, we make sure the biome does not collapse with the snow biome or the underground desert.
                        if (Main.tile[x, y].type == TileID.SnowBlock || 
                            Main.tile[x, y].type == TileID.IceBlock ||
                            Main.tile[x, y].type == TileID.BreakableIce ||
                            Main.tile[x, y].type == TileID.JungleGrass ||
                            WorldGen.UndergroundDesertLocation.Contains(new Point(x, y)))
                        {
                            canGenerate = false;
                            break;
                        }
                    }
                }

                // If we can generate.
                if (canGenerate)
                {
                    // Set the mid-coordinates of the Dynasty Biome.
                    this.dynastyX = dynastyBiomeX; this.dynastyY = dynastyBiomeY;

                    // Generate the main patch (grows dirt, grass and jadestone).
                    this.GenerateDynastyPatch(dynastyBiomeX, dynastyBiomeY);

                    // Generate the Dynasty Village Structures.
                    this.GenerateStructures(this.dynastyX, this.dynastyY);		
                }
            }	
        }

        internal void GenerateDynastyPatch(int x, int y)
        {
                int randX = Main.rand.Next(x - (this.dynastyBiomeRadius / 15), x + (this.dynastyBiomeRadius / 15) + 1);
                int randY = Main.rand.Next(y - (this.dynastyBiomeRadius / 15), y + (this.dynastyBiomeRadius / 15) + 1);

                this.RoundHole(randX, randY, (int)(Main.rand.NextFloat() * 80), (int)(Main.rand.NextFloat() * 20), 20, true, true);
        }

        internal void RoundHole(int X, int Y, int Xmult, int Ymult, int strength, bool initialdig, bool grassy = false)
        {
            if (initialdig)
                WorldGen.digTunnel(X, Y, 0, 0, strength, strength, false);

            for (int rotation2 = 0; rotation2 < 350; rotation2++)
            {
                int DistX = (int)(0 - (Math.Sin(rotation2) * Xmult));
                int DistY = (int)(0 - (Math.Cos(rotation2) * Ymult));

                WorldGen.digTunnel(X + DistX, Y + DistY, 0, 0, strength, strength, false);
            }
            for (int rotation3 = 0; rotation3 < 350; rotation3++)
            {
                int Dist2X = (int)(0 - (Math.Sin(rotation3) * Xmult));
                int Dist2Y = (int)(0 - (Math.Cos(rotation3) * Ymult));
                if (grassy && Math.Cos(rotation3) < -0.1f)
                {
                    WorldMethods.TileRunner(X + (Dist2X * 2), Y + (Dist2Y * 3) + Ymult, (strength / 2), 1, 2, true, 0f, 0f, true, true); //placeholder

                }


            }
        }

        // A LOT OF THE FOLLOWING METHOD CODE NEEDS TO BE REWORKED.
        // BUILDINGS ARE SPAWNING QUIRKY.
        internal void GenerateStructures(int x, int y)
        {
            int numberToGenerate = WorldGen.genRand.Next(6, 9);
            for (int k = 0; k < numberToGenerate; ++k)
            {
                    DynastyStructure dynastyStructure = new DynastyStructure(mod, Main.rand.Next(1, 3));

                    int worldHeight = Main.maxTilesY;
                    int worldWidth = Main.maxTilesX;
                    bool alreadydone = false;
                    int a = x + Main.rand.Next(-60, 60);
                   // int b = y + Main.rand.Next(0, 40);
                    for (int b = y; b < y + 120 || alreadydone == true; b++)
                    {
                        if (Main.tile[a, b].active())
                        {
                            bool placementOK = true;

                            for (int i = 0; i <= 40; i++)
                            {
                                for (int j = 0; j <= 40; j++)
                                {
                                    int c = x + i;
                                    int d = y + j;
                                    while (c > worldWidth)
                                        c--;
                                    while (d > worldHeight)
                                        d--;
                                    int type = (int)Main.tile[c, d].type;
                                    if (Main.tile[c, d].active())
                                    {
                                        if (type == TileID.BlueDungeonBrick || type == TileID.GreenDungeonBrick || type == TileID.PinkDungeonBrick || type == TileID.Cloud || type == TileID.RainCloud || type == TileID.DynastyWood)
                                        {
                                            placementOK = false;
                                            break;
                                        }
                                    }
                                }
                                if (!placementOK)
                                    break;
                            }

                            for (int i = 0; i >= -40; i--)
                            {
                                if (!placementOK)
                                    break;

                                for (int j = 0; j >= -40; j--)
                                {
                                    int c = x + i;
                                    int d = y + j;
                                    while (a < 0)
                                        a++;
                                    while (b < 0)
                                        b++;
                                    int type = (int)Main.tile[c, d].type;
                                    if (Main.tile[c, d].active())
                                    {
                                        if (type == TileID.BlueDungeonBrick || type == TileID.GreenDungeonBrick || type == TileID.PinkDungeonBrick || type == TileID.Cloud || type == TileID.RainCloud || type == TileID.DynastyWood)
                                        {
                                            placementOK = false;
                                            break;
                                        }
                                    }
                                }
                            }

                            if (placementOK)
                            {
                                dynastyStructure.Generate(a, b);
                                break;
                                alreadydone = true;
                            }
                        }
                    }
            }
        }
    }

    internal class DynastyStructure
    {
        // << Tile Types: >>
        // None = 0
        // Dynasty Wood = 1
        // Red Dynasty Shingles = 2
        // Blue Dynasty Shingles = 3
        // Wooden Platform = 4
        // Wooden Beam = 5
        // Dynasty Door = 6

        // Dynasty Lantern = 7
        // Large Dynasty Lantern = 8
        // Dynasty Candle = 9
        // Large Dynasty Candle = 10
        // Chinese Lantern = 11

        // Red Banner = 12
        // Blue Banner = 13

        // Dynasty Chair Facing Right = 14
        // Dynasty Chair Facing Left = 15
        // Dynasty Table = 16
        // Dynasty Workbench = 17
        // Dynasty Cup = 18
        // Dynasty Bowl = 19
        // Dynasty Mill = 20
        // Dynasty Chest = 21

        // << Tile Styles: >>
        // HalfBrick = 1
        // SlopeDownRight = 2
        // SlopeDownLeft = 3
        // SlopeUpRight = 4
        // SlopeUpLeft = 5

        #region Dynasty House 01

        private readonly int dynastyHouse_01Width = 19, dynastyHouse_01Height = 16;

        private readonly int[,] dynastyHouse_01Tiles = new int[,]
        {
            { 0, 0, 0, 0, 0, 0, 0, 0, 0, 2, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
            { 0, 0, 0, 0, 2, 0, 0, 2, 2, 2, 2, 2, 0, 0, 2, 0, 0, 0, 0 },
            { 0, 0, 0, 0, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 0, 0, 0, 0 },
            { 0, 0, 0, 0, 0, 0, 2, 2, 2, 2, 2, 2, 2, 0, 0, 0, 0, 0, 0 },
            { 0, 2, 0, 2, 2, 2, 2, 1, 1, 1, 1, 1, 2, 2, 2, 2, 0, 2, 0 },
            { 0, 2, 2, 2, 2, 2, 1, 1, 0, 0, 0, 1, 1, 2, 2, 2, 2, 2, 0 },
            { 0, 0, 0, 0, 2, 2, 1, 0, 0, 0, 0, 0, 1, 2, 2, 0, 0, 0, 0 },
            { 2, 0, 2, 2, 2, 2, 1, 21, 0, 0, 21, 0, 1, 2, 2, 2, 2, 0, 2 },
            { 2, 2, 2, 1, 1, 1, 1, 1, 4, 4, 4, 1, 1, 1, 1, 1, 2, 2, 2 },
            { 0, 7, 0, 12, 1, 0, 0, 13, 0, 0, 0, 13, 0, 0, 1, 12, 0, 7, 0 },
            { 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0 },
            { 0, 0, 0, 0, 6, 0, 0, 0, 0, 0, 0, 0, 0, 0, 6, 0, 0, 0, 0 },
            { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
            { 0, 0, 0, 0, 0, 0, 0, 14, 0, 16, 0, 15, 0, 0, 0, 0, 0, 0, 0 },
            { -1, -1, -1, -1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, -1, -1, -1, -1 },
            { -1, -1, -1, -1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, -1, -1, -1, -1 }
        };

        private readonly int[,] dynastyHouse_01Styles = new int[,]
        {
            { 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
            { 0, 0, 0, 0, 4, 0, 0, 0, 0, 0, 0, 0, 0, 0, 2, 0, 0, 0, 0 },
            { 0, 0, 0, 0, 5, 0, 0, 0, 0, 0, 0, 0, 0, 0, 3, 0, 0, 0, 0 },
            { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
            { 0, 4, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 2, 0 },
            { 0, 5, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 3, 0 },
            { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
            { 4, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 2 },
            { 5, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 3 },
            { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
            { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
            { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
            { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
            { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
            { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
            { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 }
        };

        #endregion

        #region Dynasty Structure 02

        private readonly int dynastyHouse_02Width = 25, dynastyHouse_02Height = 22;
        
        private readonly int[,] dynastyHouse_02Tiles = new int[,]
        {
            { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 2, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
            { 0, 0, 0, 0, 0, 0, 0, 0, 2, 2, 2, 2, 2, 2, 2, 2, 2, 0, 0, 0, 0, 0, 0, 0, 0 },
            { 0, 0, 0, 0, 0, 2, 0, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 0, 2, 0, 0, 0, 0, 0 },
            { 0, 0, 0, 0, 0, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 0, 0, 0, 0, 0 },
            { 0, 0, 0, 0, 0, 0, 7, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 7, 0, 0, 0, 0, 0, 0 },
            { 0, 0, 0, 0, 0, 0, 0, 7, 1, 0, 0, 0, 8, 0, 0, 0, 1, 7, 0, 0, 0, 0, 0, 0, 0 },
            { 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0 },
            { 0, 0, 0, 2, 2, 2, 2, 2, 1, 0, 0, 0, 0, 0, 0, 0, 1, 2, 2, 2, 2, 2, 0, 0, 0 },
            { 2, 0, 2, 2, 2, 2, 2, 2, 1, 0, 0, 0, 0, 0, 0, 0, 1, 2, 2, 2, 2, 2, 2, 0, 2 },
            { 2, 2, 2, 2, 2, 2, 2, 2, 1, 21, 0, 0, 0, 0, 21, 0, 1, 2, 2, 2, 2, 2, 2, 2, 2 },
            { 0, 7, 1, 1, 1, 1, 1, 1, 1, 1, 1, 4, 4, 4, 1, 1, 1, 1, 1, 1, 1, 1, 1, 7, 0 },
            { 0, 0, 7, 1, 0, 0, 0, 0, 8, 0, 5, 0, 0, 0, 5, 0, 8, 0, 0, 0, 0, 1, 7, 0, 0 },
            { 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 5, 0, 0, 0, 5, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0 },
            { 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 5, 0, 0, 0, 5, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0 },
            { 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 5, 0, 0, 0, 5, 0, 0, 0, 18, 9, 0, 1, 0, 0, 0 },
            { 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 5, 0, 0, 0, 5, 0, 0, 0, 4, 4, 0, 1, 0, 0, 0 },
            { 0, 0, 0, 6, 0, 0, 0, 0, 0, 0, 5, 0, 0, 0, 5, 0, 0, 0, 0, 0, 0, 6, 0, 0, 0 },
            { 0, 0, 0, 0, 0, 0, 10, 0, 0, 0, 5, 0, 0, 0, 5, 0, 0, 0, 19, 0, 0, 0, 0, 0, 0 },
            { 0, 0, 0, 0, 0, 17, 0, 15, 0, 0, 5, 20, 0, 0, 5, 14, 0, 16, 0, 15, 0, 0, 0, 0, 0 },
            { 0, 0, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 0, 0 },
            { 0, 1, 5, 1, 5, 1, 5, 1, 5, 1, 5, 1, 5, 1, 5, 1, 5, 1, 5, 1, 5, 1, 5, 1, 0 },
            { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 },
        };
        private readonly int[,] dynastyHouse_02Styles = new int[,]
        {
            { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
            { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
            { 0, 0, 0, 0, 0, 4, 0, 2, 0, 0, 0, 0, 0, 0, 0, 0, 0, 4, 0, 2, 0, 0, 0, 0, 0 },
            { 0, 0, 0, 0, 0, 5, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 3, 0, 0, 0, 0, 0 },
            { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
            { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 8, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
            { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
            { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
            { 4, 0, 2, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 4, 0, 2 },
            { 5, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 3 },
            { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
            { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
            { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
            { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
            { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
            { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
            { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
            { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
            { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
            { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
            { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
            { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
        };

        #endregion

        Mod mod;
        int type = 0;

        public int width
        {
            get
            {
                switch (type)
                {
                    case 1: return dynastyHouse_01Width;

                    default: return dynastyHouse_01Width; // Default returns House_01 Width.
                }
            }
        }
        public int height
        {
            get
            {
                switch (type)
                {
                    case 1: return dynastyHouse_01Height;

                    default: return dynastyHouse_01Height; // Default returns House_01 Height.
                }
            }
        }

        public int[,] dynastyStructureTiles
        {
            get
            {
                switch (type)
                {
                    case 1: return dynastyHouse_01Tiles;
                    case 2: return dynastyHouse_02Tiles;

                    default: return dynastyHouse_01Tiles; // Default will return House_01 tiles.
                }
            }
        }
        public int[,] dynastyStructureStyles
        {
            get
            {
                switch (type)
                {
                    case 1: return dynastyHouse_01Styles;
                    case 2: return dynastyHouse_02Styles;

                    default: return dynastyHouse_01Styles; // Default will return House01 styles.
                }
            }
        }

        public DynastyStructure(Mod mod, int type = 0)
        {
            this.mod = mod;
            this.type = type;
        }

        public void Generate(int x, int y)
        {
            bool chestSpawned = false;

            // Cleanup generation site first.
            for (int i = 0; i < dynastyStructureTiles.GetLength(0); i++)
            {
                for (int j = 0; j < dynastyStructureTiles.GetLength(1); j++)
                {
                    int k = (x + j) - dynastyStructureTiles.GetLength(1);
                    int l = (y + i) - dynastyStructureTiles.GetLength(0); 
                    if (WorldGen.InWorld(k, l, 40))
                    {
                        Tile tile = Framing.GetTileSafely(k, l);
                        if (dynastyStructureTiles[i, j] >= 0)
                        {
                            tile.ResetToType(0);
                        }

                        // If the spot should be empty: empty it, before actual generation begins.
                        if (dynastyStructureTiles[i, j] == 0)
                            tile.active(false);
                        tile.liquid = 0;
                        tile.lava(false);
                    }
                }
            }

            // Start generating actual house.
            for (int i = 0; i < dynastyStructureTiles.GetLength(0); i++)
            {
                for (int j = 0; j < dynastyStructureTiles.GetLength(1); j++)
                {
                    int k = (x + j) - dynastyStructureTiles.GetLength(1);
                    int l = (y + i) - dynastyStructureTiles.GetLength(0);
                    if (WorldGen.InWorld(k, l, 40))
                    {
                        Tile tile = Framing.GetTileSafely(k, l);
                        // Place tiles.
                        switch (dynastyStructureTiles[i, j])
                        {
                            case 1: // Dynasty Wood
                                tile.active(true);
                                tile.type = TileID.DynastyWood;
                                break;
                            case 2: // Red Dynasty Shingles
                                tile.active(true);
                                tile.type = TileID.RedDynastyShingles;
                                break;
                            case 3: // Blue Dynasty Shingles
                                tile.active(true);
                                tile.type = TileID.BlueDynastyShingles;
                                break;
                            case 4: // Wooden Platform
                                tile.active(true);
                                tile.type = TileID.Platforms;
                                WorldGen.SquareTileFrame(k, l, true);
                                break;
                            case 5: // Wooden Beam
                                tile.active(true);
                                tile.type = TileID.WoodenBeam;
                                break;
                            case 6: // Dynasty Door
                                this.Place(k, l, TileID.ClosedDoor, 28, 1);
                                break;

                            case 7: // Dynasty Lantern
                                this.Place(k, l, TileID.HangingLanterns, 26, 1);
                                break;
                            case 8: // Large Dynasty Lantern
                                this.Place(k, l, TileID.Chandeliers, 22, 1);                                
                                break;
                            case 9: // Dynasty Candle
                                this.Place(k, l, TileID.Candles, 18, 1);
                                break;
                            case 10: // Large Dynasty Candle
                                this.Place(k, l, TileID.Candelabras, 18, 1);
                                break;
                            case 11: // Chinese Lantern
                                this.Place(k, l, TileID.ChineseLanterns, 0, 1);
                                break;

                            case 12: // Red Banner
                                this.Place(k, l, TileID.Banners, 0, 1);
                                break;
                            case 13: // Blue Banner
                                this.Place(k, l, TileID.Banners, 2, 1);
                                break;

                            case 14: // Dynasty Chair Facing Right
                                this.Place(k, l, TileID.Chairs, 27, 1);
                                break;
                            case 15: // Dynasty Chair Facing Left
                                this.Place(k, l, TileID.Chairs, 27, -1);
                                break;
                            case 16: // Dynasty Table
                                this.Place(k, l, TileID.Tables, 25, 1);
                                break;
                            case 17: // Dynasty Workbench
                                this.Place(k, l, TileID.WorkBenches, 18, 1);
                                break;
                            case 18: // Dynasty Cup
                                this.Place(k, l, TileID.Bottles, 5, 1);
                                break;
                            case 19: // Dynasty Plate
                                this.Place(k, l, TileID.Bowls, 2, 1);
                                break;
                            case 20: // Dynasty Mill
                                this.Place(k, l, mod.TileType("DynastyMill_Tile"), 0, 1);
                                break;
                            case 21: // Dynasty Chest
                                Main.tile[k, l].active(false);

                                // Modify this to add items and give a chance *not* to spawn.
                                if (!chestSpawned && WorldGen.genRand.Next(3) == 0)
                                {
                                    this.Place(k, l, mod.TileType("LockedDynastyChest_Tile"), 0, 1);
                                    int chest = Chest.CreateChest(k, l - 1, -1);
                                    // Fill chest.

                                    chestSpawned = true;
                                }
                                break;
                        }

                        // Apply tile styles.
                        switch (dynastyStructureStyles[i, j])
                        {
                            case 1:
                                tile.halfBrick(true);
                                break;
                            case 2:
                                tile.slope(Tile.Type_SlopeDownRight);
                                break;
                            case 3:
                                tile.slope(Tile.Type_SlopeDownLeft);
                                break;
                            case 4:
                                tile.slope(1);
                                break;
                            case 5:
                                tile.slope(Tile.Type_SlopeUpLeft);
                                break;
                        }
                    }
                }
            }
        }

        internal void Place(int x, int y, int type, int style, int dir)
        {
            Main.tile[x,y].active(false);
            TileObject tileObject;
            if (TileObject.CanPlace(x, y, type, style, dir, out tileObject))
                TileObject.Place(tileObject);
        }
    }
}