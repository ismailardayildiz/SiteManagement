using SiteManagement.Entity.Entities;

namespace SiteManagement.Data.Seeds
{


    public static class SiteSeed
    {
        public static readonly Guid Site1Id = Guid.Parse("F0BC1C34-DBD4-4BD7-9668-D8C6C66ED480");
        public static readonly Guid Site2Id = Guid.Parse("EF55ED67-B6AE-4746-8B94-6E48A0F61A49");

        public static readonly IEnumerable<Site> Data = new List<Site>
        {
            new Site
            {
                Id        = Site1Id,
                Name      = "Yeşilvadi Sitesi",
                Address   = "Atatürk Cad. No:12",
                City      = "İstanbul",
                ManagerId = UserSeed.ManagerId,
                CreatedBy = "seed",
                CreatedDate = new DateTime(2024, 1, 1),
                IsDeleted = false
            },
            new Site
            {
                Id        = Site2Id,
                Name      = "Mavi Köşk Sitesi",
                Address   = "Cumhuriyet Bulvarı No:45",
                City      = "Ankara",
                ManagerId = UserSeed.ManagerId,
                CreatedBy = "seed",
                CreatedDate = new DateTime(2024, 1, 1),
                IsDeleted = false
            }
        };
    }

}
