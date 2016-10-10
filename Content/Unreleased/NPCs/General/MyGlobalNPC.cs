using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using System.Linq;

namespace MokkelMod.Content.Sprites.NPCs.General
{
    // Having a class derive from GlobalNPC ( : GlobalNPC) creates a class that will allow us to manipulate the data of ALL NPCs.
    // Vanilla ones and modded ones alike. This means you need only 1 of these classes in your whole mod (some people make the 
    // mistake of creating more, which will cause massive frame drops, so refrain from doing so).
    public class MyGlobalNPC : GlobalNPC
    {
        // This function is called before any vanilla drop stuff is called, so we can make use of this to check if hardmode is initialized.
        public override bool PreNPCLoot(NPC npc)
        {
            // We check if the type of the given NPC matches the type of the Wall of Flesh.
            // If it is the wall of flesh, we can then check if hardmode has not been initialized yet ( ! means not, so !something checks if something is false).
            // If this isn't the case and this NPC is the WoF, we can safely assume that we're entering hardmode and therefore spawn the ore.
            if(npc.type == NPCID.WallofFlesh && !Main.hardMode)
            {
                SpawnOre();
            }
           
            return true;
        }
	
	        public override void NPCLoot(NPC npc)
        {
            if(npc.type == NPCID.Mimic)
            {
				if(Main.rand.Next(0, 10) == 0)
				{
					Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("MagicCards"));	
				}   
			}
			
			else if(new[] {3,430,132,186,187,432,433,188,434,189,435,200,436,223,161,431,254,52,53,536,319,320,321,332}.Contains(npc.type))
            {
				Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("ZombieFlesh"));	   
			}
			
			else if(npc.type == NPCID.Harpy)
            {
				if(Main.rand.Next(0, 20) == 0)
				{
					Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("RazorFeathers"));	
				}   
			}
			
			else if(npc.type == NPCID.GraniteGolem)
            {
				if(Main.rand.Next(0, 20) == 0)
				{
					Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("GraniteSlasher"));	
				} 				
			}
			
			else if(npc.type == NPCID.Probe)
            {
				if(Main.rand.Next(0, 40) == 0)
				{
					Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("TheDestroyersEye"));	
				}   
			}
			
			else if(npc.type == NPCID.Spazmatism)
            {
				if(Main.rand.Next(0, 20) == 0)
				{
					Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("Spazmatism"));	
				}   
			}
			
			else if(npc.type == NPCID.Retinazer)
            {
				if(Main.rand.Next(0, 20) == 0)
				{
					Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("Retinazer"));	
				}   
			}
			
			else if(npc.type == NPCID.Plantera)
            {
				Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("PlanteraSpore"), 450); 
			}
			
			else if(new[] {137,138,120}.Contains(npc.type))
            {
				if(Main.rand.Next(0, 3) == 0)
				{
					if(NPC.downedMechBossAny)
					{
						Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("IlluminescentEssence"));
					}
				} 
			}
		}
		
		public override void SetupShop(int type, Chest shop, ref int nextSlot)
		{
			switch(type)
			{
				case NPCID.GoblinTinkerer:
					if(Main.hardMode)
					{
						shop.item[nextSlot].SetDefaults(mod.ItemType("GiantSpikyBall"));
						nextSlot++;
					}
					break;
				case NPCID.PartyGirl:
					if(Main.hardMode)
					{
						shop.item[nextSlot].SetDefaults(mod.ItemType("FireworkTome"));
						nextSlot++;
					}
					break;
			}
		}
       
        private void SpawnOre()
        {                   
            // Here we declare the boundaries of the ore spawning.
            // Along the X axis, we do not allow ore spawning on the most outer sides of the map (ocean biome).
            // Along the Y axis, we want to spawn under the worlds' surface, but above the hell layer.
            int minX = 200;
            int maxX = Main.maxTilesX - 200;
            int minY = (int)Main.worldSurface;
            int maxY = Main.maxTilesY - 200;

            // The minimum and maximum spread of the ore chunks (determines the size of your ore chunks).
            int minSpread = 2;
            int maxSpread = 6;

            // The minimum and maximum frequency (determines the shape of your ore chunks).
            int minFreq = 6;
            int maxFreq = 8;
       
            int s = WorldGen.genRand.Next(minSpread, maxSpread + 1);
            int f = WorldGen.genRand.Next(minFreq, maxFreq + 1);

            for (int k = 0; k < (int)((double)(Main.maxTilesX * Main.maxTilesY) * 6E-05); k++)
            {
                int x = WorldGen.genRand.Next(minX, maxX);
                int y = WorldGen.genRand.Next(minY, maxY);
                WorldGen.OreRunner(x, y, s, f, (ushort)mod.TileType("RadiantOre"));
            }
        }
    }
}