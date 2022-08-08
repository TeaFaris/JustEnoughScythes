using JustEnoughSickles.Content.NPCs.Souls.Frost;
using JustEnoughSickles.Content.NPCs.Souls.Inferno;
using JustEnoughSickles.Content.NPCs.Souls.Light;
using JustEnoughSickles.Content.NPCs.Souls.Shadow;
using Terraria.ModLoader;

namespace JustEnoughSickles.Utils.IDs
{
    public class JESNPCID
    {
        public class Souls
        {
            public static readonly int Inferno = ModContent.NPCType<Inferno>();
            public static readonly int Frost = ModContent.NPCType<Frost>();
            public static readonly int Shadow = ModContent.NPCType<Shadow>();
            public static readonly int Light = ModContent.NPCType<Light>();
        }
    }
}
