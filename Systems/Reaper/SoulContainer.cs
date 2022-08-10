using JustEnoughScythes.Content.NPCs.Souls;
using System;
using Terraria.Audio;
using Terraria.ID;

namespace JustEnoughScythes.Systems.Reaper
{
    public class SoulContainer
    {
        public event SoulContainerHandler OnSoulsCountChanged = delegate { };
        public uint this[SoulType Index]
        {
            get => Souls[(int)Index];
            set
            {
                OnSoulsCountChanged(this, new SoulContainerEventArgs()
                {
                    SoulType = Index,
                    SoulsCount = value
                });
            }
        }
        public SoulContainer(IContainsSouls Owner)
        {
            this.Owner = Owner;
            OnSoulsCountChanged += SoulsCountChanged;
        }
        public virtual void Reset() => Array.Clear(Souls);
        protected uint[] Souls { get; set; } = new uint[Enum.GetValues(typeof(SoulType)).Length];
        protected IContainsSouls Owner { get; set; }
        private void SoulsCountChanged(object Sender, SoulContainerEventArgs EventArgs)
        {
            if (Souls[(int)EventArgs.SoulType] >= Owner.MaxSouls)
            {
                SoundEngine.PlaySound(SoundID.MaxMana);
                return;
            }
            if (EventArgs.SoulsCount <= 0)
            {
                SoundEngine.PlaySound(SoundID.Drip);
                Souls[(int)EventArgs.SoulType] = 0;
                return;
            }
            SoundEngine.PlaySound(SoundID.Zombie53);
            Souls[(uint)EventArgs.SoulType] = EventArgs.SoulsCount;
        }

        public delegate void SoulContainerHandler(object Sender, SoulContainerEventArgs EventArgs);
        public class SoulContainerEventArgs : EventArgs
        {
            public uint SoulsCount { get; set; }
            public SoulType SoulType { get; set; }
        }
    }
    public interface IContainsSouls
    {
        public SoulContainer SoulsContainer { get; }
        public uint MaxSouls { get; }
        public float SoulPickupRange { get; }
    }
}
