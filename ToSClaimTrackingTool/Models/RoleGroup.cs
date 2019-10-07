using System.Collections.Generic;
using ToSClaimTrackingTool.Models.JsonData;

namespace ToSClaimTrackingTool.Models
{
    public class RoleGroup
    {
        public string Name { get; set; }
        public Team Team { get; set; }
        public List<Role> PossibleRoles { get; set; }

        public RoleGroup(RoleGroupInfo roleGroupInfo, Team team)
        {
            Name = roleGroupInfo.Name;
            PossibleRoles = new List<Role>();
            Team = team;
        }
    }
}
