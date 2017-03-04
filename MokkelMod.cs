using System;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

using MokkelMod.Content.Unreleased.Worlds;
using MokkelMod;

namespace MokkelMod
{
	public class MokkelMod : Mod
	{
        public int no;
		public MokkelMod()
		{
			Properties = new ModProperties()
			{
				Autoload = true,
				AutoloadGores = true,
				AutoloadSounds = true,
				AutoloadBackgrounds = true
			};
		}

        public override void ChatInput(string text, ref bool broadcast)
        {
            if (text.StartsWith("/"))
            {
                ErrorLogger.Log(text);
                broadcast = false;
                Player player = Main.LocalPlayer;
                text = text.Substring(1);
                if (text.ToLower() == "teleporttodynasty")
                {
                   
                    player.Teleport(new Vector2(
                        this.GetModWorld<MokkelWorld>().dynastyBiome.dynastyX,
                        this.GetModWorld<MokkelWorld>().dynastyBiome.dynastyY));                    
                }
                if (text.ToLower() == "togtime")
                {
                    Main.dayTime = Main.dayTime ? false : true;
                }
                
                if (text.StartsWith("ph"))
                {
                    try
                    {
                        this.GetNPC("BroodMother").npc.ai[0] = int.Parse(text.Substring(2));
                        ErrorLogger.Log(this.GetNPC("BroodMother").npc.whoAmI.ToString());
                        ErrorLogger.Log(int.Parse(text.Substring(2)).ToString());
                        foreach (NPC n in Main.npc)
                        {
                            if (n.name == "Brood Mother")
                            {
                                ErrorLogger.Log("a " + n.whoAmI.ToString());
                                n.ai[0] = int.Parse(text.Substring(2));
                                
                            }
                        }
                        
                    }
                    catch (Exception e){ }
                
       
                }
                    

            }
        }
	}
}