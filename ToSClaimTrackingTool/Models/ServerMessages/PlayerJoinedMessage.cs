using ToSClaimTrackingTool.Utils;

namespace ToSClaimTrackingTool.Models.ServerMessages
{
    public class PlayerJoinedMessage : ServerMessage
    {
        private const int PlayerNumberIndex = 0;
        private const int PlayerNameIndex = 1;

        public Player Player { get; set; }

        public PlayerJoinedMessage(byte[] bytes) : base(bytes)
        {
            Player = new Player(GetTextAt(PlayerNameIndex), Bytes[PlayerNumberIndex]);
        }

        public override string ToString() => $"Player joined: {Player.Name} ({Player.Number})";
    }
}
