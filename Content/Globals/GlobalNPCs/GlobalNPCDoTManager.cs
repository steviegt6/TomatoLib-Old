using System.Collections.Generic;
using Terraria;
using Terraria.ModLoader;
using TomatoLib.Common.DataStructures;

namespace TomatoLib.Content.Globals.GlobalNPCs
{
    public class GlobalNPCDoTManager : GlobalNPC
    {
        public List<DoTUnit> DoTUnits = new List<DoTUnit>();

        public override bool InstancePerEntity => true;

        public override void UpdateLifeRegen(NPC npc, ref int damage)
        {
            DoTUnit.RemoveDeadUnits(ref DoTUnits);

            foreach (DoTUnit unit in DoTUnits)
                unit.Update(ref damage, npc);
        }
    }
}