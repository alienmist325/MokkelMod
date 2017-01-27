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

            }
        }
	}
}