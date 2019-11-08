using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Fargowiltas.Items.Summons.Deviantt
{
    public class HeartChocolate : DevianttSummon
    {
        public override int summonType => NPCID.Nymph;

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Heart Chocolate");
            Tooltip.SetDefault("Summons Nymph\nOnly usable at night or underground");
        }

        public override bool CanUseItem(Player player)
        {
            return !Main.dayTime || player.ZoneRockLayerHeight || player.ZoneUnderworldHeight;
        }
    }
}