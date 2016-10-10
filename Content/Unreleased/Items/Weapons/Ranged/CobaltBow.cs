using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace MokkelMod.Content.Sprites.Items.Weapons.Ranged
{
	public class CobaltBow : ModItem
	{
		public override void SetDefaults()
		{
			item.name = "Cobalt Bow";
			item.damage = 20;
			item.ranged = true;
			item.width = 24;
			item.height = 36;
			item.useTime = 15;
			item.useAnimation = 15;
			item.useStyle = 5;
			item.noMelee = true; //so the item's animation doesn't do damage
			item.knockBack = 1;
			item.value = 60000;
			item.rare = 4;
			item.useSound = 5;
			item.autoReuse = true;
			item.shoot = 1; //idk why but all the guns in the vanilla source have this
			item.shootSpeed = 20f;
			item.useAmmo = 1;
			//item.timeLeft = 20;
		}
	}
}