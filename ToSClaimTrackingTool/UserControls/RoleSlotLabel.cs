using System.Drawing;
using System.Windows.Forms;
using ToSClaimTrackingTool.Models;

namespace ToSClaimTrackingTool.UserControls
{
    public partial class RoleSlotLabel : UserControl
    {
        private readonly RoleSlot _roleSlot;

        public RoleSlotLabel(RoleSlot roleSlot)
        {
            InitializeComponent();
            lblRoleSlot.Text = roleSlot.Name;
            _roleSlot = roleSlot;
        }

        public void DoUpdate()
        {
            Visible = !_roleSlot.IsTemporary || _roleSlot.Player != null;
            if (!Visible) return;

            lblStatus.Text = _roleSlot?.Player?.Name ?? string.Empty;
            lblRoleShortName.Text = _roleSlot?.Player?.Role?.ShortName ?? string.Empty;
            lblStatus.BackColor = GetColor();
        }

        private Color GetColor()
        {
            var player = _roleSlot?.Player;
            if (player == null || player.IsConfirmed) return Color.White;
            if (player.IsImpossibleClaim) return Color.Tomato;
            if (player.IsOverclaimed) return Color.DarkOrange;
            return Color.Yellow;
        }
    }
}
