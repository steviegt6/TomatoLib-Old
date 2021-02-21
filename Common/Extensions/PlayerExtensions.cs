using Terraria;
using TomatoLib.Common.DataStructures;
using TomatoLib.Content.Globals.ModPlayers;

namespace TomatoLib.Common.Extensions
{
    public static class PlayerExtensions
    {
        public static void AddDoTUnit(this Player player, DoTUnit unit) =>
            player.GetModPlayer<ModPlayerDoTManager>().DoTUnits.Add(unit);
    }
}