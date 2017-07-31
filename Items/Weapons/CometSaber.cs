using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace MokkelMod.Items.Weapons
{
	public class CometSaber : ModItem
	{
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Comet Saber");
            Tooltip.SetDefault("'Kylo Ren would be proud'");
        }

        public override void SetDefaults()
		{
			item.damage = 73;
			item.melee = true;
			item.width = 54;
			item.height = 52;
			item.useTime = 4;
			item.useAnimation = 32;
			item.useStyle = 1;
			item.knockBack = 6;
			item.value = 100000;
			item.rare = 6;
			item.scale = 1.3f;
            item.UseSound = SoundID.Item7;
			item.autoReuse = true;
		}

		public override void AddRecipes()
		{
			var recipe = new ModRecipe(mod);
			recipe.AddIngredient(null, "CometBar", 20);
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}