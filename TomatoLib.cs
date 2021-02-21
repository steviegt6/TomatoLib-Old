using System.Reflection;
using MonoMod.RuntimeDetour.HookGen;
using Terraria.ModLoader;
using TomatoLib.Common.MonoMod;

namespace TomatoLib
{
    public class TomatoLib : Mod
    {
        public override void Load()
        {
            ILManager.Initialize();

            OnModLoad += (orig, self) =>
                         {
                             ILManager.LoadILEdits(self);
                             orig(self);
                         };

            OnModUnload += (orig, self) =>
                           {
                               ILManager.UnloadILEdits(self);
                               orig(self);
                           };
        }

        public override void Unload()
        {
            ILManager.Uninitialize();
        }

        #region Manual HookGen

        private static readonly MethodInfo ModLoadInfo =
            typeof(Mod).GetMethod("Load", BindingFlags.Instance | BindingFlags.Public);

        private static readonly MethodInfo ModUnloadInfo =
            typeof(Mod).GetMethod("Unload", BindingFlags.Instance | BindingFlags.Public);

        private delegate void OrigModLoad(Mod self);

        private delegate void OrigModUnload(Mod self);

        private delegate void HookModLoad(OrigModLoad orig, Mod self);

        private delegate void HookModUnload(OrigModUnload orig, Mod self);

        private event HookModLoad OnModLoad
        {
            add => HookEndpointManager.Add(ModLoadInfo, value);

            remove => HookEndpointManager.Remove(ModLoadInfo, value);
        }

        private event HookModUnload OnModUnload
        {
            add => HookEndpointManager.Add(ModUnloadInfo, value);

            remove => HookEndpointManager.Remove(ModUnloadInfo, value);
        }

        #endregion
    }
}