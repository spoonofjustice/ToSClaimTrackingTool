using System.Collections.Generic;
using System.Windows.Forms;
using ToSClaimTrackingTool.Models;

namespace ToSClaimTrackingTool.UserControls
{
    public partial class PlayersBox : UserControl
    {
        private List<PlayerLabel> _playerLabels = new List<PlayerLabel>();

        public PlayersBox()
        {
            InitializeComponent();
        }

        public void DoUpdate() => _playerLabels.ForEach(pl => pl.DoUpdate());

        public void LoadPlayers(List<Player> players)
        {
            Controls.Clear();
            players.ForEach(Add);
        } 

        private void Add(Player player)
        {
            var playerLabel = new PlayerLabel(player, Controls.Count);
            Controls.Add(playerLabel);
            _playerLabels.Add(playerLabel);
        }
    }
}
