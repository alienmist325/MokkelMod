using System;
using System.Collections.Generic;

using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace MokkelMod.Items.Armour
{
	[AutoloadEquip(EquipType.Legs)]
    public class CometGreaves : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Comet Greaves");
			Tooltip.SetDefault("10% increased magic and melee critical strike chance");
		}
		
		public override void SetDefaults()
		{
			item.width = 28;
            item.height = 14;
			item.defense = 11;
		}

		public override void UpdateEquip(Player Player)
        {
            Player.meleeCrit += 10;
			Player.magicCrit += 10;
		}
	}
}