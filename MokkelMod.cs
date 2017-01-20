using System;

using Microsoft.Xna.Framework;

using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

using MokkelMod.Content.Unreleased.Worlds;

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
				AutoloadSounds = true
			};
		}

        public override void ChatInput(string text, ref bool broadcast)
        {
            if (text.StartsWith("/"))
            {
                broadcast = false;

                text = text.Substring(1);
                if (text.ToLower() == "teleporttodynasty")
                {
                    Player player = Main.LocalPlayer;
                    player.Teleport(new Vector2(
                        this.GetModWorld<MokkelWorld>().dynastyBiome.dynastyX,
                        this.GetModWorld<MokkelWorld>().dynastyBiome.dynastyY));                    
                }
            }
        }
	}
}