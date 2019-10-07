namespace ToSClaimTrackingTool.Models.ServerMessages
{
    public class StartOfGameMessage : ServerMessage
    {
        public StartOfGameMessage(byte[] bytes) : base(bytes) { }
        public override string ToString() => $"The game has started...";
    }
}
