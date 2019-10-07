using System.Collections.Generic;

namespace ToSClaimTrackingTool.Models.JsonData
{
    public class RoleGroupInfo
    {
        public string Name { get; set; }
        public string ColorName { get; set; }
        public List<RoleInfo> RoleInfos { get; set; }
    }
}
