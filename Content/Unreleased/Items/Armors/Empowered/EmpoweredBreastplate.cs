using System;
using System.Collections.Generic;

using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace MokkelMod.Content.Sprites.Items.Armors.Empowered
{
    public class EmpoweredBreastplate : ModItem
	{
		public override bool Autoload(ref string name, ref string texture, IList<EquipType> equips)
		{
			equips.Add(EquipType.Body);
			return true;
		}

		public override void SetDefaults()
		{
            item.name = "Empowered Breastplate";
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