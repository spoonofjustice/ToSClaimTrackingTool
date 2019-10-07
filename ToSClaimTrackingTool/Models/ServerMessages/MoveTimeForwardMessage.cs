namespace ToSClaimTrackingTool.Models.ServerMessages
{
    public class MoveTimeForwardMessage : ServerMessage
    {
        public MoveTimeForwardMessage(byte[] bytes) : base(bytes) { }
        public override string ToString() => $"The {(Type == ServerMessageType.StartOfDay ? "day" : "night")} has started...";
    }
}
