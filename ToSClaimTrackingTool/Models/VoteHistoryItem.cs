using System.Collections.Generic;
using System.Linq;
using ToSClaimTrackingTool.Models.ServerMessages;

namespace ToSClaimTrackingTool.Models
{
    public class VoteHistoryItem
    {
        public List<PlayerVoteMessage> Votes { get; set; }
        public GameTime Time;
        public VoteVerdict Verdict;
        public Player Target;
        public int Order;

        public VoteHistoryItem(List<PlayerVoteMessage> votes, VoteVerdictMessage verdictMessage, Player target, int order = 0)
        {
            Votes = votes;
            Time = verdictMessage.Time;
            Verdict = verdictMessage.Verdict;
            Target = target;
            Order = order;
        }

        public override string ToString()
        {
            var vote = Votes.FirstOrDefault(v => v.PlayerTo == Target);
            string voteOrder = vote != null ? $"{GetNumberWithSuffix(vote.Order)} voter" : "non-voter";
            string isConfirmedFlag = !(Target?.IsConfirmed ?? false) ? "?" : "";
            return $"{voteOrder}: {Verdict} on {Target?.Name} ({Target?.Role?.Name}) {isConfirmedFlag}";
        }

        private string GetNumberWithSuffix(int number)
        {
            switch(number.ToString().Last())
            {
                case '1': return $"{number}st";
                case '2': return $"{number}nd";
                case '3': return $"{number}rd";
                default: return $"{number}th";
            }
        }
    }
}
