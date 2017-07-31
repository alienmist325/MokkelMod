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
    public class LockedDynastyChest_Tile : ModTile
    {
        public override void SetDefaults()
        {
            Main.tileSpelunker[Type] = true;
            Main.tileContainer[Type] = true;
            Main.tileShine2[Type] = true;
            Main.tileShine[Type] = 1200;
            Main.tileFrameImportant[Type] = true;
            Main.tileNoAttach[Type] = true;
            Main.tileValue[Type] = 500;

            TileObjectData.newTile.CopyFrom(TileObjectData.Style2x2);
            TileObjectData.newTile.Origin = new Point16(0, 1);
            TileObjectData.newTile.CoordinateHeights = new int[] { 16, 18 };
            TileObjectData.newTile.AnchorInvalidTiles = new int[] { 127 };
            TileObjectData.newTile.LavaDeath = false;
            TileObjectData.newTile.AnchorBottom = new AnchorData(AnchorType.SolidTile | AnchorType.SolidWithTop, TileObjectData.newTile.Width, 0);
            TileObjectData.addTile(Type);
            ModTranslation name = CreateMapEntryName();
            name.SetDefault("Locked Dynasty Chest");
            AddMapEntry(new Color(75, 35, 0), name);
            disableSmartCursor = true;
        }

        public override void MouseOver(int i, int j)
        {
            Player player = Main.LocalPlayer;

            player.showItemIcon2 = mod.ItemType("DynastyKey");
			player.showItemIconText = "";
			player.noThrow = 2;
			player.showItemIcon = true;
        }

        public override void RightClick(int x, int y)
        {
            Tile tile = Main.tile[x, y];
            Player player = Main.LocalPlayer;
            // Loop through the players' inventory to find a key.
            for (int i = 0; i < player.inventory.Length; ++i)
            {
                // If a key has been found.
                if (player.inventory[i].type == mod.ItemType("DynastyKey") && player.inventory[i].stack > 0)
                {
                    Main.NewText("Opened chest");
                    // Decrease the key stacks and reset the item if it was the last in the stack.
                    player.inventory[i].stack--;
                    if (player.inventory[i].stack <= 0)
                    {
                        player.inventory[i] = new Item();
                    }

                    int left = x;
                    int top = y;
                    if (tile.frameX % 36 != 0)
                        left--;
                    if (tile.frameY != 0)
                        top--;

                    for (int chestX = left; chestX <= (left + 1); ++chestX)
                    {
                        for (int chestY = top; chestY <= (top + 1); ++chestY)
                        {
                            Main.tile[chestX, chestY].type = TileID.Containers;
                            Main.tile[chestX, chestY].frameX = (short)(1008 + (18 * (chestX - left)));
                            Main.tile[chestX, chestY].frameY = (short)(18 * (chestY - top));
                        }
                    }
                    Main.PlaySound(22, x * 16, y * 16, 1, 1f, 0f);

                    break;
                }
            }
        }

        // Tile cannot be destroyed if it has not been opened yet.
        public override bool CanKillTile(int i, int j, ref bool blockDamaged)
        {
            blockDamaged = true;
            return false;
        }
    }
}
