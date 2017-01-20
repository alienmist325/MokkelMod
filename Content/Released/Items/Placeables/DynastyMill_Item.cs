using System;

using Microsoft.Xna.Framework;

using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace MokkelMod.Content.Sprites.Items.Placeables
{
    public class DynastyMill_Item : ModItem
	{
		public override void SetDefaults()
		{
			item.name = "Dynasty Mill";
			item.toolTip = "Can be placed.";
			item.width = 26;
            item.height = 26;
            item.value = 50000;
            item.rare = 1;

			item.maxStack = 99;

            item.useStyle = 1;
            item.useTime = 10;
            item.useAnimation = 15;

            item.useTurn = true;
            item.autoReuse = true;
            item.consumable = true;

			item.createTile = mod.TileType("DynastyMill_Tile");
		}
	}
}