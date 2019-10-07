namespace ToSClaimTrackingTool.Models
{
    public class GameTime
    {
        public bool IsDay { get; set; }
        public int DayPassed { get; set; }
        public string Text => $"{(IsDay ? "Day" : "Night")} {DayPassed + 1}";

        public GameTime GetNext()
        {
            return new GameTime
            {
                IsDay = !this.IsDay,
                DayPassed = this.DayPassed + (this.IsDay ? 0 : 1)
            };
        }
    }
}
