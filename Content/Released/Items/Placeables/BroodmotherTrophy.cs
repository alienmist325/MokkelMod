using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace MokkelMod.Content.Sprites.Items.Placeables
{
	public class BroodmotherTrophy : ModItem
	{
		public override void SetDefaults()
		{
			item.name = "Broodmother Trophy";
			item.toolTip = "Can be placed.";
			item.width = 30;
			item.height = 30;
			item.maxStack = 99;
			item.useTurn = true;
			item.autoReuse = true;
			item.useAnimation = 15;
			item.useTime = 10;
			item.useStyle = 1;
			item.consumable = true;
			item.value = 50000;
			item.rare = 1;
			item.createTile = mod.TileType("BossTrophy");
			item.placeStyle = 0;
		}
	}
}