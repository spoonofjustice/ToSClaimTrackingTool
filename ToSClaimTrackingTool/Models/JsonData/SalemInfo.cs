using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

namespace ToSClaimTrackingTool.Models.JsonData
{
    public class SalemInfo
    {
        private const string _filePath = "../../../ToSData/tosdata.json";

        public Dictionary<string, Role> RolesByName { get; set; }
        public Dictionary<int, Role> RolesById { get; set; }

        public Dictionary<string, RoleGroup> RoleGroupsByName { get; set; }

        public Dictionary<string, Roster> RostersByName { get; set; }

        public SalemInfo()
        {
            RolesByName = new Dictionary<string, Role>();
            RolesById = new Dictionary<int, Role>();
            RoleGroupsByName = new Dictionary<string, RoleGroup>();
            RostersByName = new Dictionary<string, Roster>();

            if (File.Exists(_filePath))
            {
                var data = JsonConvert.DeserializeObject<SalemJsonData>(File.ReadAllText(_filePath));
                data.TeamInfos.ForEach(Load);
                data.RosterInfos.ForEach(Load);
            }
        }

        private void Load(TeamInfo teamInfo)
        {
            foreach (var groupInfo in teamInfo.RoleGroupInfos)
            {
                var roleGroup = new RoleGroup(groupInfo, teamInfo.Team);

                foreach (var roleInfo in groupInfo.RoleInfos)
                {
                    var role = new Role(roleInfo, roleGroup);

                    roleGroup.PossibleRoles.Add(role);
                    RolesByName.Add(role.Name, role);
                    RolesById.Add(role.Id, role);
                }

                RoleGroupsByName.Add(roleGroup.Name, roleGroup);
            }
        }

        private void Load(RosterInfo rosterInfo)
        {
            var roster = new Roster(rosterInfo);
            RostersByName.Add(rosterInfo.Name, roster);
        }
    }

    class SalemJsonData
    {
        public List<TeamInfo> TeamInfos { get; set; }
        public List<RosterInfo> RosterInfos { get; set; }
    }
}
