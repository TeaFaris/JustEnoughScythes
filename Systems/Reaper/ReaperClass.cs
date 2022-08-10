using Terraria.ModLoader;

namespace JustEnoughScythes.Systems.Reaper
{
    public class ReaperClass : DamageClass
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
