using Terraria;
using Terraria.ModLoader;
using Terraria.GameContent.Creative;
using System.Collections.Generic;

namespace JustEnoughScythes.Content.Items.RangedModificators
{
    public abstract class ModificatorBase : ModItem
    {
        protected Item? Owner { get; set; }
        public float Damage { get; protected set; } = 0;
        public float Accuracy { get; protected set; } = 0;
        public float CritMultiplier { get; protected set; } = 0;
        public float ShootSpeed { get; protected set; } = 0;

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Null modificator");
        }
        public override void ModifyTooltips(List<TooltipLine> tooltips)
        {
            void newLine(string Name, float Value)
            {
                TooltipLine Line = new TooltipLine(Mod, Name, $"{Name}: {Value}");
                Line.IsModifier = Value != 0;
                Line.IsModifierBad = Value < 0;
                tooltips.Add(Line);
            }
            string[] names = { "Damage", "Accuracy", "Crit multiplier", "Shoot speed" };
            float[] values = { Damage, Accuracy, CritMultiplier, ShootSpeed };
            for (int i = 0; i!=4; i++) { newLine(names[i], values[i]); }
        }
        public override void SetDefaults()
        {
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
            Item.value = Item.sellPrice(0, 15, 0, 0);
            Item.maxStack = 1;
            Item.width = 26;
            Item.height = 26;
        }
    }
}
