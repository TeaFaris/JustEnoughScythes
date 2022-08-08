using Microsoft.Xna.Framework;

namespace JustEnoughSickles.Content.NPCs.Souls.Shadow
{
    public class Shadow : SoulMob
    {
        public override void SetStaticDefaults()
        {
            base.SetStaticDefaults();
            DisplayName.SetDefault($"Shadow soul");
        }
        public override void SetDefaults()
        {
            base.SetDefaults();
            SoulType = SoulType.Shadow;
            MainColor = new Color(73, 73, 73);
        }
    }
}