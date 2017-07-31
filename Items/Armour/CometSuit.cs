using System;
using System.Collections.Generic;

using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace MokkelMod.Items.Armors
{
	[AutoloadEquip(EquipType.Body)]
    public class CometSuit : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Comet Suit");
			Tooltip.SetDefault("Increases maximum mana by 80\n25% increased melee speed");
		}
		
		public override void SetDefaults()
		{
			item.width = 28;
			item.height = 22;
			item.defense = 18; // ??
		}

		public override void UpdateEquip(Player Player)
        {
			Player.statManaMax2 += 80;
			Player.meleeSpeed = 1.25f;
		}
	}
}