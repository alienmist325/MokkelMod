using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace MokkelMod.Items.Weapons
{
	public class TerraCleaver : ModItem
	{
		public override void SetDefaults()
		{
			item.name = "Terra Cleaver";
			item.damage = 105;
			item.melee = true;
			item.width = 60;
			item.height = 62;
			item.useTime = 30;
			item.useAnimation = 20;
			item.useStyle = 1;
			item.knockBack = 7;
			item.value = 200;
			item.crit = 4;
			item.rare = 8;
			item.shoot = 132;
			item.shootSpeed = 10f;
			item.UseSound = SoundID.Item1;
			item.autoReuse = true;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(null, "TrueRedDusk");
			recipe.AddIngredient(ItemID.TrueExcalibur);
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}