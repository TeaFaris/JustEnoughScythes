using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace JustEnoughSickles.Systems.NPCs
{
    public abstract class HandledNPC : ModNPC
    {
        public Player Target { get; set; } = null;
        private static bool Filtered { get; set; } = false;

        // Those parts of code not mine
        // Thanks JavidPack for code
        // https://github.com/JavidPack
        public static NPC HandledSpawnNPC(int Type, int X, int Y)
        {
            NPC NPC = new NPC();
            NPC.SetDefaults(Type);
            int SyncID = NPC.netID;

            if(!Filtered)
            {
                if (Main.netMode == NetmodeID.MultiplayerClient)
                {
                    var message = JustEnoughSickles.Instance.GetPacket();
                    message.Write((byte)CheatSheetMessageType.RequestFilterNPC);
                    message.Write(SyncID);
                    message.Write(!Filtered);
                    message.Send();
                }
            }

            if (Main.netMode == NetmodeID.SinglePlayer)
            {
                int Index = NPC.NewNPC(NPC.GetSource_NaturalSpawn(), X, Y, Type);
                if (SyncID < 0)
                    Main.npc[Index].SetDefaults(SyncID);
                return Main.npc[Index];
            }
            else
            {
                ModPacket NetMessage = JustEnoughSickles.Instance.GetPacket();
                NetMessage.Write((byte)CheatSheetMessageType.SpawnNPC);
                NetMessage.Write(Type);
                NetMessage.Write(SyncID);
                NetMessage.Send();
            }
            return Main.npc[NPC.whoAmI];
        }
        public virtual void SetTarget(Player Target) => this.Target = Target;
    }
}
