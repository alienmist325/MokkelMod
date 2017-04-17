using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace MokkelMod.Items.Weapons
{
	public class Thunderbolt : ModItem
	{
		public override void SetDefaults()
		{
			item.name = "Thunderbolt";
			item.damage = 30;
			item.ranged = true;
			item.width = 36;
			item.height = 56;
			item.toolTip = "Shoots arrows at lightning speed!";
			item.useTime = 15;
			item.useAnimation = 15;
			item.useStyle = 5;
			item.noMelee = true; //so the item's animation doesn't do damage
			item.knockBack = 1;
			item.value = 5000;
			item.rare = 3;
            item.UseSound = SoundID.Item5;
			item.autoReuse = false;
			item.shoot = 1; //idk why but all the guns in the vanilla source have this
			item.shootSpeed = 20f;
			item.useAmmo = 1;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.SunplateBlock, 20);
			recipe.AddIngredient(ItemID.FallenStar, 3);
			recipe.AddIngredient(ItemID.MeteoriteBar, 5);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}