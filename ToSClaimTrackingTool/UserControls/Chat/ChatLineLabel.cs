using System.Drawing;
using System.Windows.Forms;
using ToSClaimTrackingTool.Menus;
using ToSClaimTrackingTool.Models.ServerMessages;

namespace ToSClaimTrackingTool.UserControls.Chat
{
    public partial class ChatLineLabel : UserControl
    {
        private ChatMessage _message;
        private PlayerContextMenu _contextMenu = new PlayerContextMenu();

        public ChatLineLabel(MouseEventHandler wheelEventHandler)
        {
            InitializeComponent();
            txtChat.MouseWheel += wheelEventHandler;
            txtChat.ContextMenuStrip = _contextMenu;
        }

        public void SetMessage(ChatMessage message)
        {
            _message = message;
            _contextMenu.SetPlayer(message.Player);
            DoUpdate();
        }

        public void DoUpdate()
        {
            lblPlayerNumber.Text = _message?.Player?.Number.ToString() ?? string.Empty;
            lblRole.Text = _message.Player?.Role?.ShortName ?? string.Empty;
            lblPlayerName.Text = _message.Player?.Name;
            txtChat.Text = _message.CleanText;

            var color = _message?.Player?.GetColor() ?? Color.White;
            lblPlayerNumber.BackColor = color;
            lblRole.BackColor = color;
        }
    }
}
