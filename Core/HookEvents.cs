using MonoMod.RuntimeDetour.HookGen;
using System;
using System.Reflection;

namespace TomatoLib.Core
{
    public class HookEvents
    {
        public delegate void Orig_UIModItem_Initialize(object instance);
        public delegate void Hook_UIModItem_Initialize(Orig_UIModItem_Initialize orig, object instance);

        public static event Hook_UIModItem_Initialize OverrideInitialize
        {
            add
            {
                HookEndpointManager.Add(TomatoLib.Terraria.GetType("Terraria.ModLoader.UI.UIModItem").GetMethod("OnInitialize", BindingFlags.Public | BindingFlags.Instance), value);
            }
            remove
            {
                HookEndpointManager.Remove(TomatoLib.Terraria.GetType("Terraria.ModLoader.UI.UIModItem").GetMethod("OnInitialize", BindingFlags.Public | BindingFlags.Instance), value);
            }
        }
    }
}
