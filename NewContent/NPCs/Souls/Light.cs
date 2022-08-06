using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JustEnoughSickles.NewContent.NPCs.Souls
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
            MainColor = new Microsoft.Xna.Framework.Color(216, 216, 216);
        }
    }
}
