using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace MokkelMod.Tiles
{
    public class MagmaOre : ModTile
    {
        public override void SetDefaults()
        {
            Main.tileSolid[Type] = true; // Is a solid tile, so the Player can not walk 'over' it.
            Main.tileMergeDirt[Type] = true; // Merges with dirt?
            Main.tileBlockLight[Type] = true; // Blocks light.
            drop = mod.ItemType("MagmaOre"); // Drops this item
			Main.tileSpelunker[Type] = true; // Spelunker stuff
			Main.tileLighted[Type] = true; // You need to set this to let the game know that this tile gives off light.

            this.minPick = 100; // Will require a pickaxe with at least 100 pickaxe power.
            this.mineResist = 10; // When a pickaxe with the minPick value is picking, this is the amount of times
                                               // that pick will have to hit this block untill it's killed. For higher lvls of pickaxe power,
                                               // this goes faster (of course).
        }
		public override void ModifyLight(int i, int j, ref float r, ref float g, ref float b)
		{
		r = 0.8f;
		g = 0.6f;
		b = 0.5f;
		}
    }
}