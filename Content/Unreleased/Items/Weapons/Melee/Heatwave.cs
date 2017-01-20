using System;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace MokkelMod.Content.Sprites.Items.Weapons.Melee
{
	public class Heatwave : ModItem
	{
		public override void SetDefaults()
		{
			item.name = "Heatwave";
			item.useStyle = 5;
			item.width = 30;
			item.height = 26;
			item.toolTip = "It burns!";
			item.noUseGraphic = true;
            item.UseSound = SoundID.Item1;
			item.melee = true;
			item.channel = true;
			item.noMelee = true;
			item.shoot = mod.ProjectileType("Heatwave");
			item.useAnimation = 25;
			item.useTime = 25;
			item.shootSpeed = 20f;
			item.knockBack = 2.5f;
			item.damage = 25;
		}
		
		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.HellstoneBar,12);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this,1);
			recipe.AddRecipe();
		}
		
	}
}