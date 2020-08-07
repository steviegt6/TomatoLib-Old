using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using Terraria.ModLoader;

namespace TomatoLib.Core.Utils.API
{
    public abstract class ModRarity
    {
        private static int nextRarity = 12;

        internal static readonly IList<ModRarity> rarities = new List<ModRarity>();

        internal static int ReverseRarityID()
        {
            if (ModNet.AllowVanillaClients)
            {
                throw new Exception("Adding rarities breaks vanilla client compatibility");
            }

            if (nextRarity < 12)
            {
                throw new Exception("ItemRarity ID limit has been broken");
            }

            int reserveID = nextRarity;
            nextRarity++;
            return reserveID;
        }


        /// <summary>
        /// Returns the ModRarity associated with the specified type.
        /// If not a ModRarity, returns null.
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public static ModRarity GetRarity(int type)
        {
            return type >= 12 && type < RarityCount ? rarities[type - 12] : null;
        }

        public static int RarityCount => nextRarity;

        internal static void Unload()
        {
            rarities.Clear();
            nextRarity = 12;
        }

        public Mod mod { get; internal set; }

        public string Name { get; internal set; }

        public int Type { get; internal set; }

        public virtual bool Autoload(ref string name) => mod.Properties.Autoload;

        /// <summary>
        /// Your ModRarity's color.
        /// Returns White by default.
        /// </summary>
        /// <returns></returns>
        public virtual Color RarityColor() => Color.White;
    }
}