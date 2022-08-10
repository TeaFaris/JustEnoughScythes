using JustEnoughScythes.Content.Items.Offerings;
using JustEnoughScythes.Content.NPCs.Souls;
using JustEnoughScythes.Content.Utils;
using JustEnoughScythes.Systems.NPCs;
using JustEnoughScythes.Systems.Reaper;
using JustEnoughScythes.Utils.IDs;
using System;
using System.Collections.Generic;
using System.Linq;
using Terraria;
using Terraria.DataStructures;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;

namespace JustEnoughScythes.Systems
{
    public class JESPlayer : ModPlayer, IContainsSouls
    {
        protected uint _MaxSouls { get; set; } = 5;
        public static JESPlayer PlayerJES => Main.LocalPlayer.GetModPlayer<JESPlayer>();
        public bool IsBlocking { get; set; } = false;
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
                int SoulType = (int)ReflectionExtentions.GetIDCategory<JESNPCID.Souls>().FirstOrDefault(x => x.Name == Soul.ToString()).GetValue(null);
                for(int i = 0; i < SoulsContainer[Soul]; i++)
                    HandledNPC.HandledSpawnNPC(SoulType, (int)Player.position.X, (int)Player.position.Y);
            }
            SoulsContainer.Reset();
        }
        public override void ModifyDrawInfo(ref PlayerDrawSet drawInfo)
        {
            if (IsBlocking)
                Main.instance.MouseText("Blocking!!!");
        }
        public override void SaveData(TagCompound tag)
        {
            if(UsedOfferings != null)
                tag.Add("UsedOfferings", UsedOfferings.Select(ItemIO.Save).ToList());
        }
        public override void LoadData(TagCompound tag) => UsedOfferings = tag.GetList<TagCompound>("UsedOfferings").Select(ItemIO.Load).ToList();
    }
}
