namespace ToSClaimTrackingTool.Models.ServerMessages
{
    public class MafiaPlayersReportMessage : ServerMessage
    {
        public Player[] MafiaPlayers { get; set; }
        public Role[] MafiaRoles { get; set; }

        public MafiaPlayersReportMessage(byte[] bytes) : base(bytes)
        {
            int mafiaPlayersCount = bytes.Length / 2;
            MafiaPlayers = new Player[mafiaPlayersCount];
            MafiaRoles = new Role[mafiaPlayersCount];

            for (int i = 0; i < mafiaPlayersCount; i++)
            {
                MafiaPlayers[i] = GetPlayer(i * 2);
                MafiaRoles[i] = GetRole(i * 2 + 1);
            }
        }

        public override void Process()
        {
            for (int i = 0; i < MafiaPlayers.Length; i++)
            {
                if (MafiaPlayers[i] == null || MafiaRoles[i] == null) continue;
                MafiaPlayers[i].Claim(MafiaRoles[i]);
            }
        }

        public override string ToString() => $"This is mafia roles report...";
    }
}
