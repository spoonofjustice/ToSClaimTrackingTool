using System;
using System.Collections.Generic;
using System.Linq;
using ToSClaimTrackingTool.Models;
using ToSClaimTrackingTool.Models.ServerMessages;

namespace ToSClaimTrackingTool.Extensions
{
    public static class ListExtensions
    {
        public static string GetLastWill(this List<Player> players) => GetUnclaimedLastWill(players) + GetEvilLastWill(players);
        public static void AddUpdateAction(this List<Player> players, Action updateAction) => players.ForEach(p => p.AddUpdateAction(updateAction));
        public static void ResetOverclaim(this List<Player> players) => players.ForEach(p => p.ResetOverclaim());
        public static void ResetPlayers(this List<RoleSlot> roleSlots) => roleSlots.ForEach(rs => rs.Player = null);

        public static byte[] RemoveAt(this byte[] bytes, int index)
        {
            var list = bytes.ToList();
            list.RemoveAt(index);
            return list.ToArray();
        }

        public static ServerMessageType GetMessageType(this byte number)
        {
            ServerMessageType messageType;
            return Enum.TryParse(number.ToString(), out messageType) ? messageType : ServerMessageType.Unknown;
        }
        public static VoteVerdict GetVoteVerdict(this byte number)
        {
            VoteVerdict messageType;
            return Enum.TryParse(number.ToString(), out messageType) ? messageType : VoteVerdict.Unknown;
        }

        private static string GetUnclaimedLastWill(IEnumerable<Player> players)
        {
            var unclaimedPlayers = players.Where(p => !p.IsDead && !p.IsClaimed);
            if (!unclaimedPlayers.Any()) return "";

            return $"{Environment.NewLine}No claim: {GetNumbers(unclaimedPlayers)}";
        }
        private static string GetEvilLastWill(IEnumerable<Player> players)
        {
            var evilPlayers = players.Where(p => !p.IsDead && p.IsClaimed && p.Role.Group.Team != Team.Town);
            if (!evilPlayers.Any()) return "";
            return $"{Environment.NewLine}Evil: {GetNumbers(evilPlayers)}";
        }
        private static string GetNumbers(IEnumerable<Player> players)
        {
            return players.Select(p => p.Number.ToString()).Aggregate((i, j) => i + ", " + j);
        }
    }
}
