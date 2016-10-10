using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace MokkelMod.Content.Sprites.Items.Materials
{
	public class Comet : ModItem
	{
		public override void SetDefaults()
		{
			item.name = "Comet";
			item.width = 28;
			item.height = 28;
			item.maxStack = 999;
			item.value = 1000;
			item.rare = 6;
		}
	}
}