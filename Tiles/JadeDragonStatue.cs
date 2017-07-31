using System;

using Microsoft.Xna.Framework;

using Terraria;
using Terraria.ID;
using Terraria.Enums;
using Terraria.ModLoader;
using Terraria.ObjectData;
using Terraria.DataStructures;

namespace MokkelMod.Tiles
{
    public class TEMP_JadeDragonTile_ITEM : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("TEMP JADEDRAGONTILE");
        }
        public override void SetDefaults()
        {
            item.width = item.height = 16;

            item.useStyle = 1;
            item.useAnimation = item.useTime = 10;
            item.autoReuse = true;

            item.createTile = mod.TileType("JadeDragonStatue");
        }
    }

    public class JadeDragonStatue : ModTile
    {
        public override void SetDefaults()
        {
            Main.tileFrameImportant[Type] = true;
            Main.tileNoAttach[Type] = true;
            Main.tileBlockLight[Type] = false;
            Main.tileLighted[Type] = true;

            TileObjectData.newTile.Width = 10;
            TileObjectData.newTile.Height = 9;
            TileObjectData.newTile.Origin = new Point16(0, 8);
            TileObjectData.newTile.AnchorBottom = new AnchorData(AnchorType.SolidTile, TileObjectData.newTile.Width, 0);
            TileObjectData.newTile.UsesCustomCanPlace = true;
            TileObjectData.newTile.LavaDeath = false;
            TileObjectData.newTile.CoordinateHeights = new int[] { 16, 16, 16, 16, 16, 16, 16, 16, 16 };
            TileObjectData.newTile.CoordinateWidth = 16;
            TileObjectData.newTile.CoordinatePadding = 2;
            TileObjectData.addTile(Type);

            this.minPick = 1;
            this.mineResist = 1;
        }

        public override void RightClick(int i, int j)
        {
            Main.NewText("Spawn Jade Dragon?", 0, 200, 80);
        }
    }
}