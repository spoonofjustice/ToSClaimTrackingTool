using ToSClaimTrackingTool.Utils;

namespace ToSClaimTrackingTool.Models.ServerMessages
{
    public class ChatMessage : ServerMessage
    {
        private const int PlayerNumberIndex = 0;
        private const int TextStartIndex = 1;
        
        public GameTime Time { get; set; }
        public Player Player { get; set; }
        public string CleanText { get; set; }

        public ChatMessage(byte[] bytes) : base(bytes)
        {
            Time = SalemUtil.GetGameTime();
            Player = GetPlayer(PlayerNumberIndex);
            CleanText = GetTextAt(TextStartIndex);
        }
    }
}
