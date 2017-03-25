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
        string[] s = new string[5] {
            "tgTm",
            "ph",
            "lock",
            "reset",
            "unlock"
        };
        bool matchExists = false;

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

        public void Action(string str)
        {
            ErrorLogger.Log(str);
            if (str == s[0])
            {
                Main.dayTime = Main.dayTime ? false : true;
                Main.time = 10000;
            }
            if(str.Substring(0,s[1].Length) == s[1])
            {
                try
                {
                    this.GetNPC("BroodMother").npc.ai[0] = int.Parse(str.Substring(2));
                    foreach (NPC n in Main.npc)
                    {
                        if (n.name == "Brood Mother")
                        {
                            //ErrorLogger.Log("a " + n.whoAmI.ToString());
                            n.ai[0] = int.Parse(str.Substring(2));

                        }
                    }
                }
                catch (Exception e)
                {

                }
            }
            if (str == s[2])
            {
                Main.LocalPlayer.GetModPlayer<Content.Unreleased.Players.PlayerX>(this).locked = true;
            }
            if (str == s[3])
            {
                Main.LocalPlayer.GetModPlayer<Content.Unreleased.Players.PlayerX>(this).locked = false;
                foreach (Projectile p in Main.projectile)
                {
                    if (p.name == "TestPos")
                    {
                        ErrorLogger.Log(p.whoAmI.ToString());
                        p.ai[0] = -1;
                    }
                }
            }
            if (str == s[4])
            {
                Main.LocalPlayer.GetModPlayer<Content.Unreleased.Players.PlayerX>(this).locked = false;
            }
        }

        public void Commands(string t)
        {
            t = t.Substring(1);
            matchExists = true;
            while (matchExists)
            {
                t = t.Substring(1);
                matchExists = false;
                foreach (string str in s)
                {
                    if (str.Length <= t.Length)
                    {
                        if (t.Substring(0,str.Length) == str)
                        {
                            
                            matchExists = true;
                            //insert ph exception
                            if (str == s[1])
                            {
                                Action(t.Substring(0, 3));
                                t = t.Substring(str.Length + 1);
                            }
                            else
                            {
                                Action(t.Substring(0,str.Length));
                                t = t.Substring(str.Length);
                            }
                            
                        }
                    }
                }
                if (t.Length == 0)
                {
                    break;
                }
            }
            
        }

        public override void ChatInput(string text, ref bool broadcast)
        {
            if (text.StartsWith("//"))
            {
                Commands(text);
            }
            if (text.StartsWith("/"))
            {
                ErrorLogger.Log(text);
                broadcast = false;
                Player player = Main.LocalPlayer;
                text = text.Substring(1);
                
                
                if (text.ToLower() == "teleporttodynasty")
                {
                    text.Substring("teleporttodynasty".Length);
                    player.Teleport(new Vector2(
                        this.GetModWorld<MokkelWorld>().dynastyBiome.dynastyX,
                        this.GetModWorld<MokkelWorld>().dynastyBiome.dynastyY));                    
                }
            }
        }
	}
}