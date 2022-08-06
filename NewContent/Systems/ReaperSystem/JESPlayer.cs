using JustEnoughSickles.NewContent.Items.Offerings;
using JustEnoughSickles.NewContent.NPCs;
using JustEnoughSickles.NewContent.NPCs.Souls;
using JustEnoughSickles.NewContent.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using Terraria;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;

namespace JustEnoughSickles.NewContent.Systems.ReaperSystem
{
    public class JESPlayer : ModPlayer, IContainsSouls
    {
        protected uint _MaxSouls { get; set; } = 5;
        public List<Item> UsedOfferings { get; set; }
        public uint MaxSouls
        {
            get
            {
                UsedOfferings ??= new List<Item>();
                _MaxSouls += (uint)UsedOfferings.Select(x => ((Offering)x.ModItem).SoulsToAdd).Cast<int>().Sum();
                return _MaxSouls;
            }
            set => _MaxSouls = value;
        }
        public float SoulPickupRange { get; set; } = 5;
        public SoulContainer SoulsContainer { get; protected set; }
        public JESPlayer() => SoulsContainer = new SoulContainer(this);
        public override void UpdateDead()
        {
            foreach (SoulType Soul in Enum.GetValues(typeof(SoulType)))
            {
                int SoulType = (int)tModLoaderExtentions.GetReadonlyFields<JESIDs.NPCIDs.Souls>().FirstOrDefault(x => x.Name == Soul.ToString()).GetValue(null);
                for(int i = 0; i < SoulsContainer[Soul]; i++)
                    HandledNPC.HandledSpawnNPC(SoulType, (int)Player.position.X, (int)Player.position.Y);
            }
            SoulsContainer.Reset();
        }
        public override void SaveData(TagCompound tag)
        {
            if(UsedOfferings != null)
                tag.Add("UsedOfferings", UsedOfferings.Select(ItemIO.Save).ToList());
        }
        public override void LoadData(TagCompound tag) => UsedOfferings = tag.GetList<TagCompound>("UsedOfferings").Select(ItemIO.Load).ToList();
    }
}
