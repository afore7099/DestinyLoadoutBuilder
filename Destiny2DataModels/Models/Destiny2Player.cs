using System;
using System.Collections.Generic;
using System.Text;

namespace Destiny2DataModels.Models
{
    public class Destiny2Player
    {
        public string IconPath { get; set; }
        public int CrossSaveOverride { get; set; }
        public bool IsPublic { get; set; }
        public int MembershipType { get; set; }
        public long MembershipId { get; set; }
        public string DisplayName { get; set; }

    }
}
