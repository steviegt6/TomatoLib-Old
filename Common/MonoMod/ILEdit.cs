using Terraria.ModLoader;

namespace TomatoLib.Common.MonoMod
{
    /// <summary>
    ///     Autoloadable IL edit and Detouring class.
    /// </summary>
    public abstract class ILEdit
    {
        /// <summary>
        ///     The <see cref="Mod" /> this <see cref="ILEdit" /> corresponds to.
        /// </summary>
        public Mod Mod { get; internal set; }

        public string Name { get; internal set; }

        public virtual bool Autoload(ref string name) => true;

        public abstract void Load();

        public abstract void Unload();
    }
}