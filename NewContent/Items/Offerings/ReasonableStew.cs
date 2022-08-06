using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JustEnoughSickles.NewContent.Items.Offerings
{
    public class ReasonableStew : Offering
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Reasonable Stew");
            Tooltip.SetDefault("Smarter than the developers of this mod.");
        }
    }
}
