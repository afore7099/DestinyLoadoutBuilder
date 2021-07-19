namespace DestinyLoadoutBuilder.Data.Mappers
{
    using DestinyLoadoutBuilder.Data.Models;
    public static class Destiny2PlayerMapper
    {
        public static Destiny2Player MapDestiny2Player(Root data)
        {
            Destiny2Player player = new Destiny2Player()
            {
                CrossSaveOverride = data.Response[0].CrossSaveOverride,
                DisplayName = data.Response[0].DisplayName,
                IconPath = data.Response[0].IconPath,
                IsPublic = data.Response[0].IsPublic,
                MembershipId = data.Response[0].MembershipId,
                MembershipType = data.Response[0].MembershipType
            };
            return player;
        }
    }
}
