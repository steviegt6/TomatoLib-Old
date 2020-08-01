using Microsoft.Xna.Framework.Graphics;
using System;
using System.Linq;
using Terraria;
using Terraria.GameContent.UI.Elements;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.UI;

namespace TomatoLib.Core
{
    internal class UIModItemPlus
    {
		//TODO: Get off your lazy butt and get this finished, Stevie. - Stevie
		internal static void UIModItem_OverrideInitialize(HookEvents.Orig_UIModItem_Initialize orig, object instance)
		{
			orig(instance);
		}
	}
}
