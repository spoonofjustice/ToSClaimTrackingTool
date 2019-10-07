using System;

namespace ToSClaimTrackingTool.Utils
{
    class RandomNumbers
    {
        private static readonly Random _obj = new Random();

        public static int Next(int s, int e)
        {
            return _obj.Next(s, e);
        }
    }
}
