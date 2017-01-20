using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace MokkelMod.Content.Sprites.Items.Weapons.Magic
{
	public class Sandstorm : ModItem
	{
		public override void SetDefaults()
		{
			item.name = "Sandstorm"; 
			item.damage = 24;
			item.magic = true;
			item.width = 28;
			item.height = 32;
			item.maxStack = 1;
			item.toolTip = "Sends out a raging tornado.";
			item.useTime = 40;
			item.useAnimation = 40;
			item.knockBack = 1f;
            item.UseSound = SoundID.Item1;
			item.noMelee = true;
			item.useStyle = 5;
			item.value = 1;
			item.rare = 3;
			item.crit = 7;
			item.mana = 5;
			item.shoot = mod.ProjectileType("Sandstorm");
			item.shootSpeed = 7f;
			item.autoReuse = false;
		}
	}
}
