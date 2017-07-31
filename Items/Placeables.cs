using System;
using Terraria.ModLoader;

namespace MokkelMod.Items
{
	public class BroodmotherTrophy : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Broodmother Trophy");
			Tooltip.SetDefault("Can be placed.");
		}
		
		public override void SetDefaults()
		{
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
		
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Dynasty Mill");
			Tooltip.SetDefault("Can be placed.");
		}
		
		public override void SetDefaults()
		{
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
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Jadestone Block");
			Tooltip.SetDefault("You spot a faint glow comming from the stone...");
		}
		
		public override void SetDefaults()
		{
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
