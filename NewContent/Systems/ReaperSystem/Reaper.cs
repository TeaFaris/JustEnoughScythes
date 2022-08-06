using Terraria.ModLoader;

namespace JustEnoughSickles.NewContent.Systems.ReaperSystem
{
    public class Reaper : DamageClass
    {
        public override void SetStaticDefaults()
        {
            ClassName.SetDefault("reaper damage");
        }
        public override bool GetEffectInheritance(DamageClass damageClass)
        {
            if (damageClass == Melee)
                return true;
            return false;
        }
    }
}
