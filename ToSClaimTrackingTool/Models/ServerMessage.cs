

using System;
using System.Linq;
using System.Text;
using ToSClaimTrackingTool.Extensions;
using ToSClaimTrackingTool.Utils;

namespace ToSClaimTrackingTool.Models.ServerMessages
{
    public class ServerMessage
    {
        public ServerMessageType Type { get; set; }
        public byte MessageNumber { get; set; }
        public byte[] Bytes { get; set; }
        public string RawText { get; set; }

        public ServerMessage(byte[] bytes)
        {
            MessageNumber = bytes.FirstOrDefault();
            Bytes = bytes.RemoveAt(0);
            Type = MessageNumber.GetMessageType();
            RawText = Encoding.Default.GetString(Bytes);
        }

        public virtual void Process() { }
        public override string ToString() => $"({MessageNumber}) {Encoding.Default.GetString(Bytes)}";
        public string GetBytesReport() => Bytes.Any() ? Bytes.Select(b => $"{b.ToString("X")}({Encoding.Default.GetString(new byte[1] { b })})").Aggregate((a, b) => $"{a} - {b}") : "";
        protected Player GetPlayer(int playerNumberIndex) => Bytes.Length > playerNumberIndex ? SalemUtil.GetPlayer(Bytes[playerNumberIndex]) : null;
        protected Role GetRole(int playerRoleIndex) => Bytes.Length > playerRoleIndex ? SalemUtil.GetRole(Bytes[playerRoleIndex]) : null;
        protected string GetTextAt(int startingIndex) => RawText.Length > startingIndex ? RawText.Substring(startingIndex, RawText.Length - startingIndex) : "";
    }
}
