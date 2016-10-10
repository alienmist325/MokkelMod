using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace MokkelMod.Content.Sprites.Items.Materials
{
	public class CometBar : ModItem
	{
		public override void SetDefaults()
		{
			item.name = "Comet Bar";
			item.width = 30;
			item.height = 24;
			item.maxStack = 999;
			item.value = 4000;
			item.rare = 6;
		}
	}
}