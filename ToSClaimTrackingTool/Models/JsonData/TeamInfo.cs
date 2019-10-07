using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace ToSClaimTrackingTool.Models.JsonData
{
    public class TeamInfo
    {
        [JsonConverter(typeof(StringEnumConverter))]
        public Team Team { get; set; }
        public string ColorName { get; set; }
        public List<RoleGroupInfo> RoleGroupInfos { get; set; }
    }
}
