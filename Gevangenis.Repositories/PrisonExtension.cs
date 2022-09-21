using Gevangenis.Models.Entity;

namespace Gevangenis.Repositories
{
    public static class PrisonExtension
    {
        public async static Task<IEnumerable<Prison>> GetBelgianCompanies(this IRepository<Prison> prisons)
        {
            return await Task.Run(() =>
            {
                List<Prison> companiesList = new()
                {
                    new Prison() {Name = "ShawShank Redemption", Id = Guid.Parse("de8d4869-dc7f-4b27-90ca-8ce8605b3b2e"), Capacity = 200}
                };
                return companiesList;
            });
        }
    }
}
