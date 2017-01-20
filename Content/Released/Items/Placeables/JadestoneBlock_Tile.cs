using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace MokkelMod.Content.Sprites.Items.Placeables
{
	public class JadestoneBlock_Item : ModItem
	{
		public override void SetDefaults()
		{
			item.name = "Jadestone Block";
			item.toolTip = "You spot a faint glow comming from the stone...";
			item.width = 16;
			item.height = 16;
            item.maxStack = 999;
            item.value = 50000;
            item.rare = 1;

            item.useStyle = 1;
            item.useTime = 10;
            item.useAnimation = 15;

            item.useTurn = true;
            item.autoReuse = true;
			item.consumable = true;

			item.createTile = mod.TileType("JadestoneBlock_Tile");
		}
	}
}