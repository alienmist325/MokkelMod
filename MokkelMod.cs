using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;



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
		

	
		public override void AddRecipes()
		{
			
		}
	}
}