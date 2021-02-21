using System.Collections.Generic;
using System.Linq;
using Terraria;
using TomatoLib.Common.Delegates;

namespace TomatoLib.Common.DataStructures
{
    /// <summary>
    /// Struct containing important info for handling DoT stuff.
    /// </summary>
    public struct DoTUnit
    {
        /// <summary>
        /// The amount of time remaining before the unit expires.
        /// </summary>
        public int timeRemaining;

        /// <summary>
        /// The amount of time removed from <see cref="timeRemaining"/> every tick.
        /// </summary>
        public int timePerTick;

        /// <summary>
        /// Invoked if the unit is attached to an NPC.
        /// </summary>
        public NPCDoTDelegate npcAction;

        /// <summary>
        /// Invoked if the unit is attached to a Player.
        /// </summary>
        public PlayerDoTDelegate playerAction;

        public DoTUnit(int timeRemaining, int timePerTick, NPCDoTDelegate npcAction)
        {
            this.timeRemaining = timeRemaining;
            this.timePerTick = timePerTick;
            this.npcAction = npcAction;
            playerAction = null;
        }

        public DoTUnit(int timeRemaining, int timePerTick, PlayerDoTDelegate playerAction)
        {
            this.timeRemaining = timeRemaining;
            this.timePerTick = timePerTick;
            this.playerAction = playerAction;
            npcAction = null;
        }

        public DoTUnit(int timeRemaining, int timePerTick, NPCDoTDelegate npcAction, PlayerDoTDelegate playerAction)
        {
            this.timeRemaining = timeRemaining;
            this.timePerTick = timePerTick;
            this.npcAction = npcAction;
            this.playerAction = playerAction;
        }

        public void Update(ref int regenDamage, NPC npc)
        {
            timeRemaining -= timePerTick;
            npcAction?.Invoke(ref timeRemaining, ref timePerTick, npc, ref regenDamage);
        }

        public void Update(Player player)
        {
            timeRemaining -= timePerTick;
            playerAction?.Invoke(ref timeRemaining, ref timePerTick, player);
        }

        internal static void RemoveDeadUnits(ref List<DoTUnit> dotUnits)
        {
            foreach (DoTUnit unit in dotUnits.Where(unit => unit.timeRemaining <= 0))
                dotUnits.Remove(unit);
        }
    }
}