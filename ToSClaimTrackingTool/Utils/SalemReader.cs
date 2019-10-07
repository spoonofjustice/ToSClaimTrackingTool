using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using ToSClaimTrackingTool.Extensions;
using ToSClaimTrackingTool.Models;
using ToSClaimTrackingTool.Models.ServerMessages;

namespace ToSClaimTrackingTool.Utils
{
    public class SalemReader
    {
        public List<Player> Players { get; set; }
        public Trial Trial { get; set; }

        private readonly int _msBetweenReads = 200;
        private readonly ToSMemory _memory = new ToSMemory();
        private readonly List<ServerMessage> _oldMessages = new List<ServerMessage>();
        private readonly List<ServerMessage> _newMessages = new List<ServerMessage>();
        private GameTime _gameTime = new GameTime { IsDay = true };
        private bool _bgTaskActive = false;
        private bool _restarting = false;

        public SalemReader()
        {
            Players = new List<Player>();
            Trial = new Trial();
        }

        public void ResetToStartOfLastGame() => _restarting = true;

        //GameTime
        public GameTime GetGameTime() => _gameTime;
        public void MoveTimeForward() => _gameTime = _gameTime.GetNext();
        public void ResetGameTime() => _gameTime = new GameTime { IsDay = true };

        public IEnumerable<Player> CreateDummyPlayers()
        {
            Players.Clear();
            for (int i = 1; i <= 15; i++)
            {
                Players.Add(new Player($"Player{i}", i));
            }
            return Players;
        }

        //ServerMessages
        public IEnumerable<ServerMessage> GetNewMessages()
        {
            var temp = new List<ServerMessage>();

            lock (_newMessages)
            {
                temp.AddRange(_newMessages);
                _newMessages.Clear();
            }

            _oldMessages.AddRange(temp);
            return temp;
        }
        public void StartReadingMessage() => new Thread(BackgroundMessageReader) { IsBackground = true }.Start();
        public void StopReadingMessage() => _bgTaskActive = false;

        private void BackgroundMessageReader()
        {
            _bgTaskActive = true;

            while (_bgTaskActive)
            {
                if (_restarting)
                {
                    _memory.ResetToStartOfLastGame();
                    _restarting = false;
                    continue;
                }

                byte[] bytes = _memory.GetNextBytes();
                if (bytes.Any())
                {
                    var splittedBytes = Split(bytes);
                    lock(_newMessages)
                    {
                        _newMessages.AddRange(splittedBytes);
                    }
                }

                Thread.Sleep(_msBetweenReads);
            }
        }

        private IEnumerable<ServerMessage> Split(byte[] bytes)
        {
            List<byte[]> bytesList = new List<byte[]>();
            List<byte> currentList = new List<byte>();

            foreach (byte b in bytes)
            {
                if (b == 0 && currentList.Count > 0)
                {
                    bytesList.Add(currentList.ToArray());
                    currentList = new List<byte>();
                    continue;
                }

                currentList.Add(b);
            }

            return bytesList.Select(b => CreateMessage(b));
        }

        public ServerMessage CreateMessage(byte[] bytes)
        {
            var messageType = (bytes?.FirstOrDefault() ?? 0).GetMessageType();

            switch (messageType)
            {
                case ServerMessageType.PlayerJoined:
                    var playerJoinedMessage = new PlayerJoinedMessage(bytes);
                    Players.Add(playerJoinedMessage.Player);
                    return playerJoinedMessage;

                case ServerMessageType.StartOfGame:
                    Players.Clear();
                    ResetGameTime();
                    return new StartOfGameMessage(bytes);

                case ServerMessageType.StartOfDay:
                case ServerMessageType.StartOfNight:
                    Trial.Clear();
                    MoveTimeForward();
                    return new MoveTimeForwardMessage(bytes);

                case ServerMessageType.PlayerVote:
                    var playerVoteMessage = new PlayerVoteMessage(bytes);
                    Trial.AddVote(playerVoteMessage);
                    return playerVoteMessage;

                case ServerMessageType.PlayerOnStand:
                    var playerOnStandMessage = new PlayerOnStandMessage(bytes);
                    Trial.SetPlayerOnStand(playerOnStandMessage);
                    return playerOnStandMessage;

                case ServerMessageType.VoteVerdict:
                    var voteVerdictMessage = new VoteVerdictMessage(bytes);
                    Trial.AddVerdict(voteVerdictMessage);
                    return voteVerdictMessage;

                case ServerMessageType.PlayerIsGuilty:
                case ServerMessageType.PlayerIsInnocent:
                    Trial.Complete();
                    return new ServerMessage(bytes);

                case ServerMessageType.Chat: return new ChatMessage(bytes);
                case ServerMessageType.PlayerDead: return new PlayerDeadMessage(bytes);
                case ServerMessageType.LocalPlayerReport: return new LocalPlayerReportMessage(bytes);
                case ServerMessageType.MafiaPlayersReport: return new MafiaPlayersReportMessage(bytes);
                case ServerMessageType.MayorRevealed: return new MayorRevealedMessage(bytes);
                case ServerMessageType.PlayerRevived: return new PlayerRevivedMessage(bytes);

                default: return new ServerMessage(bytes);
            }
        }
    }
}
