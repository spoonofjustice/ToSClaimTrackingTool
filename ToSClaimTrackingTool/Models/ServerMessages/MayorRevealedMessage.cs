using ToSClaimTrackingTool.Utils;

namespace ToSClaimTrackingTool.Models.ServerMessages
{
    public class MayorRevealedMessage : ServerMessage
    {
        private const int PlayerNumberIndex = 0;
        public Player Player { get; set; }

        public MayorRevealedMessage(byte[] bytes) : base(bytes)
        {
            Player = GetPlayer(PlayerNumberIndex);
        }

        public override void Process() => Player?.Claim(SalemUtil.GetRole("Mayor"), true);
        public override string ToString() => $"{Player?.Number}: {Player?.Name} has revealed themselves as Mayor!";
    }
}
