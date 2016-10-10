using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace MokkelMod.Content.Sprites.Items.Weapons.Melee
{
	public class TrueRedDusk : ModItem
	{
		public override void SetDefaults()
		{
			item.name = "True Red Dusk";
			item.damage = 93;
			item.melee = true;
			item.width = 72;
			item.height = 74;
			item.useTime = 28;
			item.useAnimation = 28;
			item.useStyle = 1;
			item.knockBack = 5;
			item.value = 100000;
			item.crit = 4;
			item.rare = 8;
			item.shoot = mod.ProjectileType("TrueRedDusk");
			item.shootSpeed = 8f;
			item.useSound = 1;
			item.autoReuse = false;
		}
		
		public override void MeleeEffects(Player player, Rectangle hitbox)
		{
			int dust = Dust.NewDust(new Vector2(hitbox.X, hitbox.Y), hitbox.Width, hitbox.Height, 5);
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.BrokenHeroSword);
			recipe.AddIngredient(null, "RedDusk");
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}