using Terraria;

namespace TomatoLib.Common.Delegates
{
    public delegate void NPCDoTDelegate(ref int timeRemaining, ref int timePerTick, NPC npc, ref int regenDamage);
}