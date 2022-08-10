using Microsoft.Xna.Framework;

namespace JustEnoughScythes.Content.NPCs.Souls.Light
{
    public class Light : SoulMob
    {
        public override void SetStaticDefaults()
        {
            base.SetStaticDefaults();
            DisplayName.SetDefault($"Light soul");
        }
        public override void SetDefaults()
        {
            base.SetDefaults();
            SoulType = SoulType.Light;
            MainColor = new Color(216, 216, 216);
        }
    }
}
