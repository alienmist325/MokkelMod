using System;

using Microsoft.Xna.Framework;

using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace MokkelMod.Tiles
{
    public class JadestoneBlock_Tile : ModTile
    {
        public override void SetDefaults()
        {
            Main.tileSolid[Type] = true;
            Main.tileMergeDirt[Type] = true;
            Main.tileBlockLight[Type] = true;
            Main.tileLighted[Type] = true;

            drop = mod.ItemType("Jadestone Block");
            AddMapEntry(new Color(0, 75, 30));
        }

        public override void ModifyLight(int i, int j, ref float r, ref float g, ref float b)
        {
            float randomLightIntensity = Main.rand.Next(28, 42) * 0.005F;
            randomLightIntensity += (270 - (int)Main.mouseTextColor) / 1000f;
            Lighting.AddLight(i, j, 0.1F, 0.7F + randomLightIntensity, 0.2F + randomLightIntensity / 2);
        }
    }
}
