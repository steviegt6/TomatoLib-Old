using Terraria;
using TomatoLib.Common.DataStructures;
using TomatoLib.Content.Globals.GlobalNPCs;

namespace TomatoLib.Common.Extensions
{
    public static class NPCExtensions
    {
        public static void AddDoTUnit(this NPC npc, DoTUnit unit) =>
            npc.GetGlobalNPC<GlobalNPCDoTManager>().DoTUnits.Add(unit);
    }
}