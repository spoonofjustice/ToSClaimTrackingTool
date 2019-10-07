namespace ToSClaimTrackingTool.Models.ServerMessages
{
    public class LocalPlayerReportMessage : ServerMessage
    {
        private const int PlayerRoleIndex = 0;
        private const int PlayerNumberIndex = 1;

        public Player Player { get; set; }
        public Role Role { get; set; }

        public LocalPlayerReportMessage(byte[] bytes) : base(bytes)
        {
            Player = GetPlayer(PlayerNumberIndex);
            Role = GetRole(PlayerRoleIndex);
        }

        public override void Process()
        {
            if (Role == null) return;
            Player.Claim(Role, true);
        }

        public override string ToString() => $"You are number {Player?.Number}: {Player?.Name} The {Role?.Name}";
    }
}
