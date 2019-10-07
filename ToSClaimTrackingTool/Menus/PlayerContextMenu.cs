using System;
using System.Linq;
using System.Windows.Forms;
using ToSClaimTrackingTool.Models;
using ToSClaimTrackingTool.Utils;

namespace ToSClaimTrackingTool.Menus
{
    public class PlayerContextMenu : ContextMenuStrip
    {
        private Player _player;

        public PlayerContextMenu()
        {
            this.Items.Add(CreateSelectRoleMenuItem());
            this.Items.Add(CreateConfirmMenuItem());
            this.Items.Add(CreateDeadMenuItem());
            this.Items.Add(CreateVotingHistoryMenuItem());
        }
        public PlayerContextMenu(Player player) : this() => SetPlayer(player);
        public void SetPlayer(Player player) => _player = player;

        private ToolStripMenuItem CreateVotingHistoryMenuItem()
        {
            var menuItem = new ToolStripMenuItem { Text = "Get voting history" };
            menuItem.Click += new EventHandler(GetVotingHistory);
            return menuItem;
        }

        private ToolStripMenuItem CreateSelectRoleMenuItem()
        {
            var menuItem = new ToolStripMenuItem { Text = "Select role" };
            SalemUtil.GetRoleGroups().ForEach(rg => menuItem.DropDownItems.Add(CreateRoleGroupMenuItem(rg)));
            return menuItem;
        }

        private ToolStripMenuItem CreateRoleGroupMenuItem(RoleGroup roleGroup)
        {
            var menuItem = new ToolStripMenuItem { Text = roleGroup.Name };

            if (roleGroup.PossibleRoles.Count > 1)
            {
                roleGroup.PossibleRoles.ForEach(pr => menuItem.DropDownItems.Add(CreateRoleMenuItem(pr)));
            }
            else
            {
                menuItem.Click += new EventHandler(Claim);
            }

            return menuItem;
        }

        private ToolStripMenuItem CreateRoleMenuItem(Role role)
        {
            var menuItem = new ToolStripMenuItem { Text = role.Name };
            menuItem.Click += new EventHandler(Claim);
            return menuItem;
        }

        private ToolStripMenuItem CreateConfirmMenuItem()
        {
            var menuItem = new ToolStripMenuItem { Text = "Confirm" };
            menuItem.Click += new EventHandler(Confirm);
            return menuItem;
        }

        private ToolStripMenuItem CreateDeadMenuItem()
        {
            var menuItem = new ToolStripMenuItem { Text = "Dead" };
            menuItem.Click += new EventHandler(Dead);
            return menuItem;
        }

        private void GetVotingHistory(object sender, EventArgs e)
        {
            var voteHistory = _player.GetVoteHistory();
            if (!voteHistory.Any()) return;

            MessageBox.Show(voteHistory.Aggregate((a, b) => $"{a}{Environment.NewLine}{b}"));
        }
        private void Claim(object sender, EventArgs e) => _player.Claim(SalemUtil.GetRole(((ToolStripMenuItem)sender).Text));
        private void Dead(object sender, EventArgs e) => _player.ToggleDead();
        private void Confirm(object sender, EventArgs e) => _player.ToggleConfirm();
    }
}
