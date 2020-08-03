namespace TomatoLib.Content.UI
{
    internal class UIModItem_Hook
    {
        //TODO: Recreate all of this method using reflection.
        //TODO: Add prefix count, etc.
        internal void HookEvents_UIModItem_OverrideInitialize(HookEvents.Orig_UIModItem_Initialize orig, object self)
        {
            orig(self);
        }
    }
}
