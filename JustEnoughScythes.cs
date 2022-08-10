using Terraria.ModLoader;

namespace JustEnoughScythes
{
	public class JustEnoughScythes : Mod
	{
        public static JustEnoughScythes Instance { get; set; }
        public override void Load()
        {
            Instance = this;
        }
    }
    // Those parts of code not mine
    // Thanks JavidPack for code
    // https://github.com/JavidPack
    public enum PacketMessageType : byte
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