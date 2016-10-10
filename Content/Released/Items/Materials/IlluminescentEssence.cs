using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace MokkelMod.Content.Sprites.Items.Materials
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
}