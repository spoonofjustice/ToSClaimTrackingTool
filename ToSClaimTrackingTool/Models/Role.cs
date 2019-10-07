using System.Drawing;
using ToSClaimTrackingTool.Models.JsonData;

namespace ToSClaimTrackingTool.Models
{
    public class Role
    {
        private Color DefaultColor => Group?.Team == Team.Town ? Color.PaleGreen : Group?.Team == Team.Mafia ? Color.Tomato : Color.White;
        public string Name { get; set; }
        public string ShortName { get; set; }
        public RoleGroup Group { get; set; }
        public Color Color { get; set; }
        public bool IsUnique { get; set; }
        public int Id { get; set; }

        public Role(RoleInfo roleInfo, RoleGroup group)
        {
            this.Id = roleInfo.Id;
            this.Name = roleInfo.Name;
            this.ShortName = roleInfo.ShortName;
            this.IsUnique = roleInfo.IsUnique;
            this.Group = group;

            this.Color = !string.IsNullOrWhiteSpace(roleInfo.ColorName) ? Color.FromName(roleInfo.ColorName) : DefaultColor;
        }
    }
}
