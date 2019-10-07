using System.Collections.Generic;

namespace ToSClaimTrackingTool.Models.JsonData
{
    public class RoleSlotInfo
    {
        public string Name { get; set; }
        public string ShortName { get; set; }
        public List<string> PossibleRoleGroups { get; set; }
    }
}
