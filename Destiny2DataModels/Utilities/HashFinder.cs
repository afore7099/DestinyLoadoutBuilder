using System;
using System.Collections.Generic;
using System.Text;

namespace DestinyLoadoutBuilder.Data.Utilities
{
    public static class HashFinder
    {
        public static string GetPropertyFromHash(long hash)
        {
            switch (hash)
            {
                case 671679327: return "Hunter";
                case 3655393761: return "Titan";
                case 2271682572: return "Warlock";
                default: throw new InvalidOperationException("The hash was invalid.");
            }
        }
    }
}
