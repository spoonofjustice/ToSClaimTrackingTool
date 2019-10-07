using System.Collections.Generic;
using System.Windows.Forms;
using ToSClaimTrackingTool.Models;

namespace ToSClaimTrackingTool.UserControls
{
    public partial class RosterBox : UserControl
    {
        private readonly List<RoleSlotLabel> _roleSlotLabels = new List<RoleSlotLabel>();

        public RosterBox()
        {
            InitializeComponent();
        }

        public void DoUpdate() => _roleSlotLabels.ForEach(rll => rll.DoUpdate());

        public void LoadRoster(Roster roster)
        {
            pTown.Controls.Clear();
            pRandomTown.Controls.Clear();
            pEvil.Controls.Clear();
            _roleSlotLabels.Clear();

            roster.RoleSlots.ForEach(Add);
            DoUpdate();
        }

        private void Add(RoleSlot roleSlot)
        {
            var panel = GetPanel(roleSlot);
            var roleSlotLabel = new RoleSlotLabel(roleSlot)
            {
                Top = panel.Controls.Count * 26
            };

            panel.Controls.Add(roleSlotLabel);
            _roleSlotLabels.Add(roleSlotLabel);
        }

        private Panel GetPanel(RoleSlot roleSlot)
        {
            return roleSlot.Team == Team.Town ? roleSlot.ShortName == "RT" ? pRandomTown : pTown : pEvil;
        }
    }
}
