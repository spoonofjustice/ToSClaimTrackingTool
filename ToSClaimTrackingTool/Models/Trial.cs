using System.Collections.Generic;
using System.Linq;
using ToSClaimTrackingTool.Models.ServerMessages;

namespace ToSClaimTrackingTool.Models
{
    public class Trial
    {
        private readonly List<PlayerVoteMessage> _votes = new List<PlayerVoteMessage>();
        private readonly List<VoteVerdictMessage> _verdicts = new List<VoteVerdictMessage>();
        private Player _playerOnStand;

        public void AddVote(PlayerVoteMessage message) => _votes.Add(message);
        public void AddVerdict(VoteVerdictMessage message) => _verdicts.Add(message);
        public void SetPlayerOnStand(PlayerOnStandMessage message)
        {
            _playerOnStand = message.Player;

            var votesForStand = _votes.Where(v => v.PlayerTo == _playerOnStand).ToList();
            for (int i = 0; i < votesForStand.Count; i++)
            {
                votesForStand[i].Order = i + 1;
            }
        } 

        public void Complete()
        {
            _verdicts.ForEach(SaveResult);
            Clear();
        }

        private void SaveResult(VoteVerdictMessage verdict)
        {
            var player = verdict.Player;
            var playerVotes = _votes.Where(vote => vote.PlayerFrom == player).ToList();
            player.VoteHistory.Add(new VoteHistoryItem(playerVotes, verdict, _playerOnStand));
        }

        public void Clear()
        {
            _votes.Clear();
            _verdicts.Clear();
            _playerOnStand = null;
        }
    }

    public enum VoteVerdict
    {
        Unknown = 0,
        Guilty = 1,
        Innocent = 2,
        Abstain = 3
    }
}
