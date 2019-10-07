using System;
using System.Collections.Generic;
using System.Linq;
using ToSClaimTrackingTool.Models;
using ToSClaimTrackingTool.Models.JsonData;
using ToSClaimTrackingTool.Models.ServerMessages;

namespace ToSClaimTrackingTool.Utils
{
    class SalemUtil
    {
        private static readonly SalemReader _salemReader = new SalemReader();
        private static readonly SalemInfo _info = new SalemInfo();

        public static void ResetToStartOfLastGame() => _salemReader.ResetToStartOfLastGame();

        //[Memory] Server messages
        public static List<ServerMessage> GetNewMessages() => _salemReader.GetNewMessages().ToList();
        public static void StartReadingMessage() => _salemReader.StartReadingMessage();
        public static void StopReadingMessage() => _salemReader.StopReadingMessage();

        //[Memory] Player
        public static List<Player> GetPlayers() => _salemReader.Players;
        public static Player GetPlayer(int number) => _salemReader.Players.FirstOrDefault(p => p.Number == number);
        public static List<Player> CreateDummyPlayers() => _salemReader.CreateDummyPlayers().ToList();

        //[Memory] GameTime
        public static GameTime GetGameTime() => _salemReader.GetGameTime();
        public static void MoveTimeForward() => _salemReader.MoveTimeForward();

        //[Memory] Votes



        //[tosdata.txt] Rosters
        public static Roster GetRoster(string rosterName) => _info.RostersByName.ContainsKey(rosterName) ? _info.RostersByName[rosterName] : null;
        public static List<Roster> GetRosters() => _info.RostersByName.Values.ToList();

        //[tosdata.txt] Roles
        public static Role GetRole(string roleName) => _info.RolesByName.ContainsKey(roleName) ? _info.RolesByName[roleName] : null;
        public static Role GetRole(int roleId) => _info.RolesById.ContainsKey(roleId) ? _info.RolesById[roleId] : null;
        public static List<Role> GetRoles() => _info.RolesByName.Values.ToList();

        //[tosdata.txt] Rolegroups
        public static RoleGroup GetRoleGroup(string roleGroupName) => _info.RoleGroupsByName.ContainsKey(roleGroupName) ? _info.RoleGroupsByName[roleGroupName] : null;
        public static List<RoleGroup> GetRoleGroups() => _info.RoleGroupsByName.Values.ToList();

    }
}
