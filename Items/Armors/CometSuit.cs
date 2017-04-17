using System;
using System.Collections.Generic;

using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace MokkelMod.Items.Armors
{
    public class CometSuit : ModItem
	{
		public override bool Autoload(ref string name, ref string texture, IList<EquipType> equips)
		{
			equips.Add(EquipType.Body);
			
			return true;
		}

		public override void SetDefaults()
		{
            item.name = "Comet Suit";
			item.width = 28;
			item.height = 22;
			item.toolTip = "Increases maximum mana by 80";
			item.toolTip2 = "25% increased melee speed";
			item.defense = 18; // ??
		}

		public override void UpdateEquip(Player Player)
        {
			Player.statManaMax2 += 80;
			Player.meleeSpeed = 1.25f;
		}
	}
}