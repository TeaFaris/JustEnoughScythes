using Terraria;
using Terraria.ModLoader;

namespace JustEnoughSickles.Content.Items.Offerings
{
    public abstract class Offering : ModItem
    {
        public uint SoulsToAdd { get; set; } = 5;
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Some Offering");
            Tooltip.SetDefault("The... offering?");
        }
        public override bool CanUseItem(Player player) => false;
    }
}
