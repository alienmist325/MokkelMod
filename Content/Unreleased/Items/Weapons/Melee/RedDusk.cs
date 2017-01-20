using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace MokkelMod.Content.Sprites.Items.Weapons.Melee
{
	public class RedDusk : ModItem
	{
	
		public int[] toTile(int[] pos)
		{
			return new int[2] {(int)(pos[0]/16),(int)(pos[1]/16)};
		}
		
		public override void MeleeEffects(Player player, Rectangle hitbox)
		{
			int dust = Dust.NewDust(new Vector2(hitbox.X, hitbox.Y), hitbox.Width, hitbox.Height, 5);

			int[] pos = {hitbox.X,hitbox.Y};
			int[] tile = toTile(pos);
			int[] size = {hitbox.Width,hitbox.Height};
			int[] tileSize = toTile(size);
			Main.NewText(tile[0].ToString() + "" + tile[1].ToString());
			Main.tile[tile[0],tile[1]].active(true);
			
			for(int i = 0; i < tileSize[0]*tileSize[1]; i++)
			{
				pos = new int[] {hitbox.X,hitbox.Y};
				tile = toTile(pos);
				size = new int[] {hitbox.Width,hitbox.Height};
				tileSize = toTile(size);
			
			
				Main.tile[tile[0],tile[1]].active(!(Main.tile[tile[0],tile[1]].type == 1));
				if(tile[1] > toTile(pos)[1] + tileSize[1])
				{
					tile[1] -= tileSize[1];
					tile[0]++;
				}
				else
				{
					tile[1]++;
				}
			}
		}
		public override void SetDefaults()
		{
			item.name = "Red Dusk";
			item.damage = 47;
			item.melee = true;
			item.width = 56;
			item.height = 56;
			item.useTime = 31;
			item.useAnimation = 31;
			item.useStyle = 1;
			item.knockBack = 5;
			item.value = 10800;
			item.rare = 3;
			item.scale = 1.2f;
            item.UseSound = SoundID.Item1;
			item.autoReuse = false;
		}
		
		
		public override void AddRecipes()
		{
			var recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.BladeofGrass);
			recipe.AddIngredient(ItemID.FieryGreatsword);
			recipe.AddIngredient(ItemID.Muramasa);
			recipe.AddIngredient(ItemID.BloodButcherer);
			recipe.AddTile(TileID.DemonAltar);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}