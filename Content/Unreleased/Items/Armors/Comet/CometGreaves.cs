using System;
using System.Collections.Generic;

using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace MokkelMod.Content.Sprites.Items.Armors.Comet
{
    public class CometGreaves : ModItem
	{
		public override bool Autoload(ref string name, ref string texture, IList<EquipType> equips)
		{
			equips.Add(EquipType.Legs);
			return true;
		}

		public override void SetDefaults()
		{
            item.name = "Comet Greaves";
			item.width = 28;
            item.height = 14;
            item.toolTip = "10% increased magic and melee critical strike chance";
			item.defense = 11;
		}

		public override void UpdateEquip(Player Player)
        {
            Player.meleeCrit += 10;
			Player.magicCrit += 10;
		}
	}
}