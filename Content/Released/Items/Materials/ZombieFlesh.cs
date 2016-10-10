using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace MokkelMod.Content.Sprites.Items.Materials
{
	public class ZombieFlesh : ModItem
	{
		public override void SetDefaults()
		{
			item.name = "Zombie Flesh";
			item.width = 24;
			item.height = 24;
			item.maxStack = 999;
		}
	}
}