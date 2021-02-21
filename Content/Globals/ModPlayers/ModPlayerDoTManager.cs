using System.Collections.Generic;
using Terraria.ModLoader;
using TomatoLib.Common.DataStructures;

namespace TomatoLib.Content.Globals.ModPlayers
{
    public class ModPlayerDoTManager : ModPlayer
    {
        public List<DoTUnit> DoTUnits = new List<DoTUnit>();

        public override void UpdateLifeRegen()
        {
            DoTUnit.RemoveDeadUnits(ref DoTUnits);

            foreach (DoTUnit unit in DoTUnits)
                unit.Update(player);
        }
    }
}