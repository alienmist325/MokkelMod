using System;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

using MokkelMod.Content.Unreleased.Worlds;
using MokkelMod;

namespace MokkelMod.Content.Sprites.NPCs.General
{
    public class Ticks : ModCommand
    {
        public override CommandType Type
        {
            get { return CommandType.Chat; }
        }

        public override string Command
        {
            get { return "t"; }
        }

        public override void Action(CommandCaller caller, string input, string[] args)
        {
            foreach (NPC n in Main.npc)
            {
                if (n.FullName == "Brood Mother")
                {
                    //ErrorLogger.Log("a " + n.whoAmI.ToString());
                    n.ai[3] = int.Parse(args[0]);

                }
            }
        }
    }
    public class Commands : ModCommand
    {

        string[] s = new string[5] {
            "tgTm",
            "ph",
            "lock",
            "reset",
            "unlock"
        };
        bool matchExists = false;
        public override CommandType Type
        {
            get { return CommandType.Chat; }
        }

        public override string Command
        {
            get { return "a"; }
        }

        public override void Action(CommandCaller caller, string input, string[] args)
        {
            CommandSelection(args[0]);
        }

        public void CommandSelection(string t)
        {
            matchExists = true;
            while (matchExists)
            {
                matchExists = false;
                foreach (string str in s)
                {
                    if (str.Length <= t.Length)
                    {
                        if (t.Substring(0, str.Length) == str)
                        {

                            matchExists = true;
                            //insert ph exception
                            if (str == s[1])
                            {
                                Actions(t.Substring(0, 3));
                                t = t.Substring(str.Length + 1);
                            }
                            else
                            {
                                Actions(t.Substring(0, str.Length));
                                t = t.Substring(str.Length);
                            }

                        }
                    }
                }
                if (t.Length == 0)
                {
                    break;
                }
                t = t.Substring(1);
            }

        }

        public void Actions(string str)
        {
            ErrorLogger.Log(str);
            if (str == s[0])
            {
                Main.dayTime = Main.dayTime ? false : true;
                Main.time = 10000;
            }
            if (str.Substring(0, s[1].Length) == s[1])
            {
                foreach (NPC n in Main.npc)
                {
                    if (n.FullName == "Brood Mother")
                    {
                        //ErrorLogger.Log("a " + n.whoAmI.ToString());
                        n.ai[0] = int.Parse(str.Substring(2));

                    }
                }
            }
            if (str == s[2])
            {
                Main.LocalPlayer.GetModPlayer<Content.Unreleased.Players.PlayerX>(mod).locked = true;
            }
            if (str == s[3])
            {
                Main.LocalPlayer.GetModPlayer<Content.Unreleased.Players.PlayerX>(mod).locked = false;
                foreach (Projectile p in Main.projectile)
                {
                    if (p.Name == "TestPos")
                    {
                        //ErrorLogger.Log(p.whoAmI.ToString());
                        p.ai[0] = -1;
                    }
                }
            }
            if (str == s[4])
            {
                Main.LocalPlayer.GetModPlayer<Content.Unreleased.Players.PlayerX>(mod).locked = false;
            }
        }

    }
}
