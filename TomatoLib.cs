using System.Reflection;
using Terraria.ModLoader;
using TomatoLib.Core;

namespace TomatoLib
{
	public class TomatoLib : Mod
	{
        internal static Assembly Terraria;
        public override void Load()
        {
            Terraria = Assembly.LoadFrom("C:\\Program Files (x86)\\Steam\\steamapps\\common\\tModLoader\\tModLoader.exe");

            HookEvents.OverrideInitialize += UIModItemPlus.UIModItem_OverrideInitialize;
        }

        public override void Unload()
        {
            Terraria = null;
        }
    }
}