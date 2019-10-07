namespace ToSClaimTrackingTool.Models.ServerMessages
{
    public class PlayerOnStandMessage : ServerMessage
    {
        private const int PlayerFromNumberIndex = 0;
        public Player Player { get; set; }

        public PlayerOnStandMessage(byte[] bytes) : base(bytes)
        {
            Player = GetPlayer(PlayerFromNumberIndex);
        }

        public override string ToString() => $"{Player?.Name} was put on stand...";
    }
}
