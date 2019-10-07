using System.Windows.Forms;
using ToSClaimTrackingTool.Menus;
using ToSClaimTrackingTool.Models;

namespace ToSClaimTrackingTool.UserControls
{
    public partial class PlayerLabel : UserControl
    {
        private readonly Player _player;

        public PlayerLabel(Player player, int labelCount)
        {
            InitializeComponent();
            _player = player;
            lblPlayerNumber.Text = player.Number.ToString();
            lblPlayerName.Text = player.Name;
            this.Top = labelCount * (this.Height + 1);
            CreateContextMenu();
        }

        private void CreateContextMenu()
        {
            var contextMenu = new PlayerContextMenu(_player);
            lblPlayerNumber.ContextMenuStrip = contextMenu;
            lblPlayerName.ContextMenuStrip = contextMenu;
            lblRole.ContextMenuStrip = contextMenu;
            this.ContextMenuStrip = contextMenu;
        }

        public void DoUpdate()
        {
            lblPlayerNumber.Visible = !_player.IsDead;
            lblPlayerName.Visible = !_player.IsDead;
            lblRole.Visible = !_player.IsDead;

            lblRole.Text = _player.Role?.Name ?? "";
            lblRole.BackColor = _player.GetColor();
        }
    }
}
