using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace MokkelMod.Content.Sprites.Items.Weapons.Melee
{
	public class Infernorion : ModItem
	{
		public override void SetDefaults()
		{
			item.name = "Infernorion";
			item.damage = 140;
			item.melee = true;
			item.width = 60;
			item.height = 56;
			item.toolTip = "The hammer wielded by the master of the core";
			item.useTime = 40;
			item.useAnimation = 40;
			item.useStyle = 1;
			item.knockBack = 9;
			item.value = 200;
			item.crit = 4;
			item.rare = 8;
			item.noMelee = true;
			item.noUseGraphic = true;
			item.shoot = mod.ProjectileType("Infernorion");
			item.shootSpeed = 10f;
			item.useSound = 1;
			item.autoReuse = true;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(null, "MagmaIngot", 30);
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
		
		public virtual bool CanUseItem(Item item, Player player)
		{
			for(int i = 0; i < 1000; ++i)
			{
				if(Main.projectile[i].type == mod.ProjectileType("Infernorion"))
				{
					return false;
				}
			}
			return true;
		}
	}
}