using System.Collections.Generic;
using ToSClaimTrackingTool.UserControls;
using ToSClaimTrackingTool.Utils;

namespace ToSClaimTrackingTool.Models
{
    public class RoleSlot
    {
        public string Name { get; set; }
        public string ShortName { get; set; }
        public List<string> PossibleRoleGroups { get; set; }
        public Player Player { get; set; }
        public bool IsTemporary { get; set; }
        private Team _team;
        public Team Team
        {
            get
            {
                if (_team == Team.Unknown)
                    _team = SalemUtil.GetRoleGroup(PossibleRoleGroups[0]).Team;

                return _team;
            }
        }

        public bool CanHold(string roleGroupName)
        {
            return PossibleRoleGroups.Contains(roleGroupName);
        }

        public string LastWillLine => $"{ShortName}: {Player?.Name ?? ""} {PlayerClaim} {PlayerConfirmedMarker}{PlayerOverclaimedMarker}{PlayerImpossibleClaimMarker}";
        private string PlayerClaim => !IsJailorSlot && !string.IsNullOrWhiteSpace(Player?.Role?.Name) ? $"({Player.Role.Name})" : "";
        private string PlayerConfirmedMarker => !Player?.IsConfirmed ?? false ? "?" : "";
        private string PlayerOverclaimedMarker => Player?.IsOverclaimed ?? false ? "?" : "";
        private string PlayerImpossibleClaimMarker => Player?.IsImpossibleClaim ?? false ? "<-- no room" : "";
        private bool IsJailorSlot => PossibleRoleGroups[0] == "Jailor";
    }

    public enum Team
    {
        Unknown,
        Town,
        Mafia,
        Neutral
    }
}
