using System.Collections.Generic;

namespace ToSClaimTrackingTool.Models.JsonData
{
    public class RosterInfo
    {
        public string Name { get; set; }
        public List<RoleSlotInfo> RoleSlotInfos { get; set; }
    }
}
