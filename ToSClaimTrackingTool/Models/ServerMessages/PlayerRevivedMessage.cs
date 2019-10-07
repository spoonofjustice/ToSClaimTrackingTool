namespace ToSClaimTrackingTool.Models.ServerMessages
{
    public class PlayerRevivedMessage : ServerMessage
    {
        private const int PlayerNumberIndex = 0;
        public Player Player { get; set; }

        public PlayerRevivedMessage(byte[] bytes) : base(bytes)
        {
            Player = GetPlayer(PlayerNumberIndex);
        }

        public override void Process() => Player?.ToggleDead();
        public override string ToString() => $"{Player?.Name} The {Player?.Role?.Name} has been revived!";
    }
}
