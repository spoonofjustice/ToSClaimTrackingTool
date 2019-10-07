using ToSClaimTrackingTool.Extensions;
using ToSClaimTrackingTool.Utils;

namespace ToSClaimTrackingTool.Models.ServerMessages
{
    public class VoteVerdictMessage : ServerMessage
    {
        private const int PlayerNumberIndex = 0;
        private const int VoteVerdictIndex = 1;

        public GameTime Time { get; set; }
        public Player Player { get; set; }
        public VoteVerdict Verdict { get; set; }

        public VoteVerdictMessage(byte[] bytes) : base(bytes)
        {
            Time = SalemUtil.GetGameTime();
            Player = GetPlayer(PlayerNumberIndex);
            Verdict = Bytes.Length > VoteVerdictIndex ? Bytes[VoteVerdictIndex].GetVoteVerdict() : VoteVerdict.Unknown;
        }

        public override string ToString() => $"";
    }
}
