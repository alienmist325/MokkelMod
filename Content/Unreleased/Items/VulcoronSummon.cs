
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using System.Linq;
using System.Collections.Generic;
using System.Threading;

namespace MokkelMod.Content.Sprites.Items
{

	public class VulcoronSummon : ModItem
	{
        bool exists;
        int num;
		public override void SetDefaults()
		{
			item.name = "Summon the demise";
			item.width = 42;
			item.height = 36;
			item.maxStack = 20;
			item.rare = 9;
			item.useAnimation = 45;
			item.useTime = 45;
			item.useStyle = 4;
			item.UseSound = SoundID.Item44;
			//item.consumable = true;
		}

		public override bool UseItem(Player player)
		{
            /*if(Main.dayTime)
			{
				Main.dayTime = false;
			}
			else
			{
				Main.dayTime = true;
			}*/
            exists = false;
            foreach (NPC n in Main.npc)
            {
                if (n.name == "Brood Mother")

                {
                    exists = true;
                    num = n.whoAmI;
                }
            }
            if (!exists)
            {
                NPC.SpawnOnPlayer(player.whoAmI, mod.NPCType("BroodMother"));
                Main.PlaySound(15, (int)player.position.X, (int)player.position.Y, 0);
            }
            else
            {
                Main.npc[num].ai[1] = 1;
            }
			
			return true;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.DirtBlock,1);
			recipe.SetResult(this, 20);
			recipe.AddRecipe();
			// Now in here, you can just create recipes:
			recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.ManaCrystal);
			recipe.AddIngredient(ItemID.SilverBar, 5);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(ItemID.BandofStarpower);
			recipe.AddRecipe();
			recipe = new ModRecipe(mod);
			// Etc. etc.
			

			recipe.AddIngredient(ItemID.ManaCrystal);
			recipe.AddIngredient(ItemID.TungstenBar, 5);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(ItemID.BandofStarpower);
			recipe.AddRecipe();
			recipe = new ModRecipe(mod);
			
			recipe.AddIngredient(ItemID.SwiftnessPotion);
			recipe.AddIngredient(ItemID.TungstenBar, 5);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(ItemID.Aglet);
			recipe.AddRecipe();
			recipe = new ModRecipe(mod);
						
			recipe.AddIngredient(ItemID.SwiftnessPotion);
			recipe.AddIngredient(ItemID.SilverBar, 5);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(ItemID.Aglet);
			recipe.AddRecipe();
			recipe = new ModRecipe(mod);
			
			recipe.AddIngredient(null, "ZombieFlesh", 5);
			recipe.AddIngredient(ItemID.Cobweb, 1);
			recipe.AddTile(TileID.Loom);
			recipe.SetResult(ItemID.Leather);
			recipe.AddRecipe();
			recipe = new ModRecipe(mod);
			
			recipe.AddIngredient(ItemID.BladeofGrass);
			recipe.AddIngredient(ItemID.FieryGreatsword);
			recipe.AddIngredient(ItemID.Muramasa);
			recipe.AddIngredient(ItemID.LightsBane);
			recipe.AddTile(TileID.DemonAltar);
			recipe.SetResult(ItemID.NightsEdge);
			recipe.AddRecipe();
			recipe = new ModRecipe(mod);
			
			/*// Removing Recipes.
			List<Recipe> rec = Main.recipe.ToList();
			int numberRecipesRemoved = 0;
			// The Recipes to remove. 
			numberRecipesRemoved += rec.RemoveAll(x => x.createItem.type == ItemID.NightsEdge);
			Main.recipe = rec.ToArray();
			Array.Resize(ref Main.recipe, Recipe.maxRecipes);
			Recipe.numRecipes -= numberRecipesRemoved;*/
		}
	}
}