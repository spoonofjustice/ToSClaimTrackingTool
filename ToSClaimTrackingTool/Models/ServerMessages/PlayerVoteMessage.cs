namespace ToSClaimTrackingTool.Models.ServerMessages
{
    public class PlayerVoteMessage : ServerMessage
    {
        private const int PlayerFromNumberIndex = 0;
        private const int PlayerToNumberIndex = 1;
        private const int VoteCountIndex = 2;

        public Player PlayerFrom { get; set; }
        public Player PlayerTo { get; set; }
        public int VoteCount { get; set; }
        public int Order { get; set; }

        public PlayerVoteMessage(byte[] bytes) : base(bytes)
        {
            PlayerFrom = GetPlayer(PlayerFromNumberIndex);
            PlayerTo = GetPlayer(PlayerToNumberIndex);
            VoteCount = Bytes[VoteCountIndex];
        }

        public override string ToString() => $"{PlayerFrom?.Name} voted against {PlayerTo?.Name}...";
    }
}
