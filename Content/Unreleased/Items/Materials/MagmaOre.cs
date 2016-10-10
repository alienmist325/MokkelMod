using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace MokkelMod.Content.Sprites.Items.Materials
{
	public class MagmaOre : ModItem
	{
		public override void SetDefaults()
		{
			item.name = "Magma Ore";
			item.width = 16;
			item.height = 16;
			item.maxStack = 999;
			AddTooltip("Burns with a hellish fire");
			item.useTurn = true;
			item.autoReuse = true;
			item.useAnimation = 15;
			item.useTime = 10;
			item.useStyle = 1;
			item.consumable = true;
			item.createTile = mod.TileType("MagmaOre");
		}
	}
}