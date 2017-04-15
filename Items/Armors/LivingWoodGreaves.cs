using System;
using System.Collections.Generic;

using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace MokkelMod.Items.Armors
{
    public class LivingWoodGreaves : ModItem
	{
		public override bool Autoload(ref string name, ref string texture, IList<EquipType> equips)
		{
			equips.Add(EquipType.Legs);
			return true;
		}

		public override void SetDefaults()
		{
            item.name = "Livingwood Greaves";
			item.width = 18;
            item.height = 18;
            item.toolTip = "?";

			item.defense = 10; // ??
		}

		public override void UpdateEquip(Player Player)
        {
            // Add item stat changes
		}
	}
}