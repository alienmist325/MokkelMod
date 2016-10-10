using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace MokkelMod.Content.Sprites.Items.Materials
{
	public class RadiantOre : ModItem
	{
		public override void SetDefaults()
		{
			item.name = "Radiant Ore";
			item.width = 16;
			item.height = 16;
			item.maxStack = 999;
			AddTooltip("Pulses with arcane power");
			item.useTurn = true;
			item.autoReuse = true;
			item.useAnimation = 15;
			item.useTime = 10;
			item.useStyle = 1;
			item.consumable = true;
			item.createTile = mod.TileType("RadiantOre");
		}
	}
}