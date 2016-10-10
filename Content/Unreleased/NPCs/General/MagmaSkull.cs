using Terraria;
using System;
using Terraria.ModLoader;
using Terraria.ID;
using Microsoft.Xna.Framework;

namespace MokkelMod.Content.Sprites.NPCs.General
{
	public class MagmaSkull : ModNPC
	{
		public override void SetDefaults()
		{
			npc.name = "Magma Skull";
			npc.width = 28;
			npc.height = 28;
			npc.value = 20;
			npc.noGravity = true;
			npc.lifeMax = 600;
			npc.damage = 120;
			npc.defense = 30;
			npc.knockBackResist= 0f;
			npc.noTileCollide = true;
			npc.soundHit = 2;
			npc.soundKilled = 5;
			npc.aiStyle = 10;
		}
		
		public override void HitEffect(int hitDirection, double damage)
		{
			if (npc.life <= 0)
			{
				Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/MagmaSkull1"), 1f);
				Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/MagmaSkull2"), 1f);
			}
		}
	}
}