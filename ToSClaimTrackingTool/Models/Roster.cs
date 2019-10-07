using System;
using System.Collections.Generic;
using System.Linq;
using ToSClaimTrackingTool.Extensions;
using ToSClaimTrackingTool.Models.JsonData;

namespace ToSClaimTrackingTool.Models
{
    public class Roster
    {
        public List<RoleSlot> RoleSlots { get; }
        public List<Player> Players { get; set; }

        public Roster(RosterInfo rosterInfo)
        {
            RoleSlots = rosterInfo.RoleSlotInfos.Select(rsi => CreateRoleSlot(rsi)).ToList();
            RoleSlots.Add(CreateTempRTSlot());
            RoleSlots.Add(CreateTempRTSlot());
            RoleSlots.Add(CreateTempRTSlot());
            RoleSlots.Add(CreateTempRTSlot());
            RoleSlots.Add(CreateTempRTSlot());
        }

        public void DoUpdate()
        {
            Players.ResetOverclaim();
            RoleSlots.ResetPlayers();

            var claimedPlayers = Players.Where(p => p.Role != null);
            claimedPlayers.Where(p => p.IsConfirmed).ToList().ForEach(Place);
            claimedPlayers.Where(p => !p.IsConfirmed).ToList().ForEach(Place);
        }

        public string GetLastWill()
        {
            return RoleSlots
                .Where(rs => rs.Team == Team.Town && !(rs.IsTemporary && rs.Player == null))
                .Select(rs => rs.LastWillLine)
                .Aggregate((i, j) => i + "\r\n" + j)
                + Environment.NewLine 
                + Players.GetLastWill();
        }

        private void Place(Player player)
        {
            var firstFreeSlot = GetFirstFreeSlot(player.Role);

            if (firstFreeSlot != null)
            {
                firstFreeSlot.Player = player;
                return;
            }

            var overclaimedPlayers = GetOverclaimPlayers(player.Role);
            if (overclaimedPlayers.Count == 0)
            {
                player.IsImpossibleClaim = true;
            }
            else
            {
                overclaimedPlayers.Add(player);

                foreach (string overclaimedGroup in overclaimedPlayers.Select(p => p.Role.Group.Name).Distinct())
                {
                    foreach (var p in GetUnconfirmedPlayers(overclaimedGroup))
                    {
                        p.IsOverclaimed = true;
                    }
                }
            }

            if (player.Role.Group.Team == Team.Town)
            {
                RoleSlots.First(rs => rs.IsTemporary && rs.Player == null).Player = player;
            }
        }

        private RoleSlot GetFirstFreeSlot(Role role) =>
            RoleSlots.FirstOrDefault(rs => !rs.IsTemporary && rs.Player == null && rs.CanHold(role.Group.Name));

        private List<Player> GetOverclaimPlayers(Role role) =>
            RoleSlots.Where(rs => rs.Player != null && !rs.Player.IsConfirmed && rs.CanHold(role.Group.Name)).Select(rs => rs.Player).ToList();

        private List<Player> GetUnconfirmedPlayers(string groupName) =>
            Players.Where(p => p.IsClaimed && !p.IsConfirmed && p.Role.Group.Name.Equals(groupName, StringComparison.InvariantCultureIgnoreCase)).ToList();

        private RoleSlot CreateRoleSlot(RoleSlotInfo roleSlotInfo)
        {
            string name = !string.IsNullOrWhiteSpace(roleSlotInfo.Name) ? roleSlotInfo.Name : roleSlotInfo.PossibleRoleGroups[0];
            string shortName = !string.IsNullOrWhiteSpace(roleSlotInfo.ShortName) ? roleSlotInfo.ShortName : name;

            return new RoleSlot
            {
                Name = name,
                ShortName = shortName,
                PossibleRoleGroups = roleSlotInfo.PossibleRoleGroups
            };
        }

        private RoleSlot CreateTempRTSlot()
        {
            return new RoleSlot
            {
                Name = "Random Town",
                ShortName = "RT",
                PossibleRoleGroups = new List<string> { "Town Investigative", "Town Protective", "Town Killing", "Town Support" },
                IsTemporary = true
            };
        }
    }
}
