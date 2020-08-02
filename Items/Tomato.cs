﻿using Terraria.ID;
using Terraria.ModLoader;
using TomatoLib.Projectiles;

namespace TomatoLib.Items
{
    internal class Tomato : ModItem
    {
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("Booo!");
        }

        public override void SetDefaults()
        {
            item.width = 24;
            item.height = 26;
            item.damage = 5;
            item.value = 0;
            item.useTime = item.useAnimation = 10;
            item.rare = ItemRarityID.Red;
            item.maxStack= 99;
            item.useStyle = 1;
            item.noUseGraphic = true;
            item.UseSound = SoundID.Item1;
            item.consumable = true;
            item.shoot = ModContent.ProjectileType<ThrownTomato>();
            item.shootSpeed = 8f;
        }
    }
}