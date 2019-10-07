using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using ToSClaimTrackingTool.Extensions;
using ToSClaimTrackingTool.Models.ServerMessages;
using ToSClaimTrackingTool.UserControls;
using ToSClaimTrackingTool.UserControls.Chat;
using ToSClaimTrackingTool.Utils;

namespace ToSClaimTrackingTool.Models
{
    public class Game
    {
        private readonly Dictionary<ServerMessageType, Action<ServerMessage>> _uiActionPerMessageType = new Dictionary<ServerMessageType, Action<ServerMessage>>();
        private readonly string _defaultRosterName = "Ranked";
        private readonly int _timerInterval = 1000;
        private Roster _roster;
        
        private ChatBox _chatBox;
        private PlayersBox _playersBox;
        private RosterBox _rosterBox;
        private ListBox _listBox;

        public Game(ChatBox chatBox, PlayersBox playersBox, RosterBox rosterBox, ListBox listBox)
        {
            _chatBox = chatBox;
            _playersBox = playersBox;
            _rosterBox = rosterBox;
            _listBox = listBox;

            _uiActionPerMessageType.Add(ServerMessageType.Chat, _chatBox.Add);
            _uiActionPerMessageType.Add(ServerMessageType.LocalPlayerReport, LoadGameIntoUI);

            SalemUtil.StartReadingMessage();
            var timer = new Timer { Interval = _timerInterval };
            timer.Tick += new EventHandler(TimerTick);
            timer.Start();
        }

        public void LoadGameIntoUI(ServerMessage message) => LoadGameIntoUI(SalemUtil.GetPlayers().OrderBy(p => p.Number).ToList(), _defaultRosterName);
        public void LoadGameIntoUI(List<Player> players, string rosterName)
        {
            if (players == null)
            {
                players = SalemUtil.CreateDummyPlayers();
            }

            _chatBox.Clear();
            _listBox.Items.Clear();

            _roster = SalemUtil.GetRoster(rosterName);
            _roster.Players = players;

            _playersBox.LoadPlayers(players);
            _rosterBox.LoadRoster(_roster);

            players.AddUpdateAction(_roster.DoUpdate);
            players.AddUpdateAction(_playersBox.DoUpdate);
            players.AddUpdateAction(_rosterBox.DoUpdate);
            players.AddUpdateAction(_chatBox.DoUpdate);
        }

        private void TimerTick(object sender, EventArgs e) => SalemUtil.GetNewMessages().ForEach(HandleServerMessage);
        public void HandleServerMessage(ServerMessage message)
        {
            if (_uiActionPerMessageType.ContainsKey(message.Type))
            {
                _uiActionPerMessageType[message.Type].Invoke(message);
            }

            message.Process();
            _listBox.Items.Add(message);
        }

        public string GetLastWill() => _roster.GetLastWill();
    }
}
