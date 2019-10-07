namespace ToSClaimTrackingTool.Models.ServerMessages
{
    public enum ServerMessageType
    {
        Unknown = 0,
        MoveTimeForward = 2,
        Chat = 6,
        JoinedRankedQueue = 71,
        LeftRankedQueue = 72,
        PlayerJoined = 91,
        LocalPlayerReport = 92,
        StartOfNight = 93,
        StartOfDay = 94,
        PlayerDead = 95,
        VoteStarted = 97,
        PlayerOnStand = 98,
        PlayerIsGuilty = 100,
        PlayerIsInnocent = 101,
        PlayerVote = 103,
        ChangedPlayerVote = 105,
        PlayerRevived = 107,
        PlayerNameChosen = 109,
        MafiaPlayersReport = 110,
        HasVoted = 117,
        ChangedVote = 118,
        CanceledVote = 119,
        VoteVerdict = 120,
        MayorRevealed = 123,
        LastWill = 130,
        PlayerLeft = 142,
        Whisper = 159,
        StartOfGame = 165,
        FullMoon = 169
    }
}
