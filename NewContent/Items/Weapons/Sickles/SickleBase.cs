﻿using JustEnoughSickles.NewContent.NPCs;
using JustEnoughSickles.NewContent.Systems.ReaperSystem;
using JustEnoughSickles.NewContent.Utils;
using System;
using System.Reflection;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Utilities;

namespace JustEnoughSickles.NewContent.Items.Weapons.Sickles
{
    public abstract class SickleBase : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Le Sickle");
            Tooltip.SetDefault("This is a new content sickle.");
        }
        public override void SetDefaults()
        {
            Item.useStyle = ItemUseStyleID.Swing;
			Item.autoReuse = false;
			Item.DamageType = ModContent.GetInstance<Reaper>();
			Item.UseSound = SoundID.Item71;

            Item.crit = 8;
            Item.width = 40;
            Item.height = 40;
            Item.useTime = 30;
            Item.useAnimation = 30;
            Item.knockBack = 7;
            Item.ArmorPenetration = (int)(Item.damage / 2f);
        }
        public override void OnHitNPC (Player player, NPC target, int damage, float knockBack, bool crit)
        {
            if (target.aiStyle == NPCAIStyleID.Passive ||
                target.aiStyle == NPCAIStyleID.Firefly ||
                target.aiStyle == NPCAIStyleID.Butterfly ||
                target.aiStyle == NPCAIStyleID.Dragonfly ||
                target.aiStyle == NPCAIStyleID.Slime ||
                target.aiStyle == NPCAIStyleID.CritterWorm ||
                target.aiStyle == NPCAIStyleID.Bird ||
                target.aiStyle == NPCAIStyleID.Balloon ||
                target.aiStyle == NPCAIStyleID.Snail ||
                target.aiStyle == NPCAIStyleID.TeslaTurret ||
                target.aiStyle == NPCAIStyleID.Ladybug ||
                target.aiStyle == NPCAIStyleID.WaterStrider ||
                target.aiStyle == NPCAIStyleID.Piranha ||
                target.aiStyle == NPCAIStyleID.Spell ||
                target.aiStyle == 0)
                return;
            if ( (target.life > 0 && !target.boss) || (target.boss && !crit) || (!crit && new Random().Next(0, 3) > 0) )
                return;
            
            WeightedRandom<int> Rand = new WeightedRandom<int>();
            foreach (var Soul in tModLoaderExtentions.GetReadonlyFields<JESIDs.NPCIDs.Souls>())
                Rand.Add((int)Soul.GetValue(null));

            ((HandledNPC)HandledNPC.HandledSpawnNPC(Rand.Get(), (int)target.position.X, (int)target.position.Y).ModNPC).SetTarget(player);
        }
    }
}
