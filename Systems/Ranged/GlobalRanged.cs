using JustEnoughScythes.Content.Items.RangedModificators;
using JustEnoughScythes.Systems.Items;
using Terraria;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;

namespace JustEnoughScythes.Systems.Ranged
{
    public class GlobalRanged : CustomGlobalItem
    {
        public ModificatorBase[] Modificators { get; protected set; } = null;
        public override void SetDefaults(Item item)
        {
            if (item.DamageType.Type == DamageClass.Ranged.Type) 
            {
                Modificators ??= new ModificatorBase[4];
                foreach(ModificatorBase m in Modificators)
                {
                    item.shootSpeed *= (int)m.ShootSpeed;
                    item.knockBack *= (int)m.Accuracy;
                    item.damage *= (int)m.CritMultiplier;
                    item.damage *= (int)m.Damage;
                }

            }
        }
        public override void SaveData(Item item, TagCompound tag) => tag.Add("Modificators", Modificators);

        public override void LoadData(Item item, TagCompound tag) => Modificators = tag.Get<ModificatorBase[]>("Modificators");
    }
}
