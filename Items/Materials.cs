using System;
using Terraria.ModLoader;

namespace MokkelMod.Items
{
	public class IlluminescentEssence : ModItem
	{
		public override void SetDefaults()
		{
			item.name = "Illuminescent Essence";
			item.width = 32;
			item.height = 32;
			item.maxStack = 999;
			item.value = 1000;
			item.rare = 3;
		}
	}

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
