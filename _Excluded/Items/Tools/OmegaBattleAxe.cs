using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace MokkelMod.Items.Tools
{
	public class OmegaBattleAxe : ModItem
	{
		public override void SetDefaults()
		{
			item.name = "Omega Battleaxe";
			item.damage = 57;
			item.melee = true;
			item.width = 58;
			item.height = 58;
			item.useTime = 40;
			item.useAnimation = 40;
			item.useStyle = 1;
			item.knockBack = 9;
			item.value = 60000;
			item.rare = 4;
            item.scale = 1.6f;
            item.UseSound = SoundID.Item1;
			item.autoReuse = true;
		}
	}
}