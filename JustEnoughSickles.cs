using Terraria.ModLoader;

namespace JustEnoughSickles
{
	public class JustEnoughSickles : Mod
	{
        public static JustEnoughSickles Instance;
        public override void Load()
        {
            Instance = this;
        }
    }
    // Those parts of code not mine
    // Thanks JavidPack for code
    // https://github.com/JavidPack
    public enum CheatSheetMessageType : byte
    {
        SpawnNPC,
        QuickClear,
        VacuumItems,
        ButcherNPCs,
        TeleportPlayer,
        SetSpawnRate,
        SpawnRateSet,
        FilterNPC,
        RequestToggleNPCSpawn,
        RequestFilterNPC,
        InformFilterNPC,
    }
}