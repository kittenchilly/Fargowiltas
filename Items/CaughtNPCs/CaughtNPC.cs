﻿using System.Text.RegularExpressions;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace Fargowiltas.Items.CaughtNPCs
{
    public abstract class CaughtNPC : ModItem
    {
        public virtual int Type => NPCID.None;

        public override string Texture => $"Terraria/NPC_{Type}";

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault($"The {Regex.Replace(Name, "([A-Z])", " $1").Trim()}");
        }

        public override void SetDefaults()
        {
            item.width = 20;
            item.height = 20;
            item.maxStack = 10;
            item.rare = 1;
            item.useStyle = 1;
            item.useAnimation = 15;
            item.useTime = 10;
            item.consumable = true;
            item.noMelee = true;
            item.noUseGraphic = true;
            item.UseSound = SoundID.Item44;
            if (Type != NPCID.None)
            {
                item.makeNPC = (short)Type;
                Main.RegisterItemAnimation(item.type, new DrawAnimationVertical(6, Main.npcFrameCount[Type]));
            }
        }
    }
}