using Terraria.ID;

namespace Fargowiltas.Items.Weapons.Thrown
{
    public class DayBreakThrown : BaseThrownItem
    {
        public override int Type => ItemID.DayBreak;

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Daybreak Thrown");
            Tooltip.SetDefault("'Rend your foes asunder with a spear of light!'");
        }
    }
}