using System;
using System.Linq;
using System.Windows.Forms;
using ToSClaimTrackingTool.Models;
using ToSClaimTrackingTool.Models.ServerMessages;
using ToSClaimTrackingTool.Utils;

namespace ToSClaimTrackingTool.Forms
{
    public partial class MainForm : Form
    {
        private readonly Game _game;

        public MainForm()
        {
            InitializeComponent();
            _game = new Game(chatBox1, playersBox, rosterBox, listBox1);
        }

        private void NewGameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SalemUtil.ResetToStartOfLastGame();
        }

        private void LastWillToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(_game.GetLastWill());
        }

        private void ListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex < 0) return;
            txtBytes.Text = ((ServerMessage)listBox1.SelectedItem).GetBytesReport();
        }

        private void TestGameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _game.LoadGameIntoUI(null, "Ranked");
            CreateDummyMessages(10);
            SalemUtil.MoveTimeForward();
            CreateDummyMessages(5);
            SalemUtil.MoveTimeForward();
            CreateDummyMessages(30);
            SalemUtil.MoveTimeForward();
            SalemUtil.MoveTimeForward();
            CreateDummyMessages(30);
        }

        private void CreateDummyMessages(int count)
        {
            for (int i = 1; i <= count; i++)
            {
                var dummyMessage = GetDummyMessage();
                chatBox1.Add(dummyMessage);
                listBox1.Items.Add(dummyMessage);
            }
        }

        private ServerMessage GetDummyMessage()
        {
            string dummyChat = $"{Convert.ToChar(6)}{Convert.ToChar(RandomNumbers.Next(1, 16))}This is a chat line test!";
            return new ChatMessage(dummyChat.Select(c => Convert.ToByte(c)).ToArray());
        }

        private void ClearToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var players = SalemUtil.GetPlayers();
        }
    }
}
