using System;
using Terraria.ModLoader;

namespace MokkelMod.Items
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
