namespace ToSClaimTrackingTool.Models.ServerMessages
{
    public class PlayerDeadMessage : ServerMessage
    {
        private const int PlayerNumberIndex = 0;
        private const int PlayerRoleIndex = 1;

        public Player Player { get; set; }
        public Role Role { get; set; }

        public PlayerDeadMessage(byte[] bytes) : base(bytes)
        {
            Player = GetPlayer(PlayerNumberIndex);
            Role = GetRole(PlayerRoleIndex);
        }

        public override void Process()
        {
            if (Player == null || Role == null) return;
            Player.Claim(Role);
            Player.ToggleDead();
        }

        public override string ToString() => $"{Player?.Number} The {Role?.Name ?? ""} has died...";
    }
}
