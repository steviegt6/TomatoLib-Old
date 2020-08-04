using MonoMod.RuntimeDetour.HookGen;
using System.Reflection;

namespace TomatoLib.Content
{
    public class HookEvents
    {
        public delegate void Orig_UIModItem_Initialize(object self);

        public delegate void Hook_UIModItem_Initialize(Orig_UIModItem_Initialize orig, object self);

        public static event Hook_UIModItem_Initialize UIModItem_OverrideInitialize
        {
            add => HookEndpointManager.Add(TomatoLib.TerrariaAssembly.GetType("Terraria.ModLoader.UI.UIModItem").GetMethod("OnInitialize", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Public | BindingFlags.Static), value);

            remove => HookEndpointManager.Remove(TomatoLib.TerrariaAssembly.GetType("Terraria.ModLoader.UI.UIModItem").GetMethod("OnInitialize", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Public | BindingFlags.Static), value);
        }
    }
}