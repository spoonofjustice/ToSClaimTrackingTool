using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using ToSClaimTrackingTool.Models.ServerMessages;

namespace ToSClaimTrackingTool.Models
{
    public class Player
    {
        private readonly List<Action> _updateActions = new List<Action>();
        public Role Role { get; set; }
        public string Name { get; set; }
        public int Number { get; set; }
        public bool IsDead { get; set; }
        public bool IsClaimed { get; set; }
        public bool IsConfirmed { get; set; }
        public bool IsOverclaimed { get; set; }
        public bool IsImpossibleClaim { get; set; }
        public List<ChatMessage> ChatMessages { get; set; }
        public List<VoteHistoryItem> VoteHistory { get; set; }

        public Player(string name, int number)
        {
            Name = name;
            Number = number;
            ChatMessages = new List<ChatMessage>();
            VoteHistory = new List<VoteHistoryItem>();
        }

        public Player(string xml)
        {
            int numberIndex = xml.IndexOf("'>") + 2;

            string nameAndNumber = xml.Substring(numberIndex, xml.Length - numberIndex);
            nameAndNumber = nameAndNumber.Substring(0, nameAndNumber.IndexOf("<"));

            int spaceIndex = nameAndNumber.IndexOf(' ');

            Name = nameAndNumber.Substring(spaceIndex + 1, nameAndNumber.Length - spaceIndex - 1);
            Number = Convert.ToInt32(nameAndNumber.Substring(0, spaceIndex));
        }

        public void Claim(Role role, bool autoConfirm = false)
        {
            IsClaimed = true;
            Role = role;

            if (!IsConfirmed && (role.Group.Team != Team.Town || autoConfirm))
            {
                ToggleConfirm();
            }

            RunUpdates();
        }

        public void ToggleDead()
        {
            IsDead = !IsDead;
            IsConfirmed = true;
            RunUpdates();
        }

        public void ToggleConfirm()
        {
            if (Role == null) return;
            IsConfirmed = !IsConfirmed;
            RunUpdates();
        }

        public Color GetColor()
        {
            if (Role == null) return Color.White;
            if (IsImpossibleClaim) return Color.Tomato;
            if (IsOverclaimed) return Color.DarkOrange;
            if (!IsConfirmed) return Color.Yellow;

            return Role.Color;
        }

        public void ResetOverclaim()
        {
            IsOverclaimed = false;
            IsImpossibleClaim = false;
        }

        public string[] GetVoteHistory() => VoteHistory.Select(vh => vh.ToString()).ToArray();
        private void RunUpdates() => _updateActions.ForEach(update => update.Invoke());
        public void AddUpdateAction(Action updateAction) => _updateActions.Add(updateAction);
        public override string ToString() => Name;
    }
}
