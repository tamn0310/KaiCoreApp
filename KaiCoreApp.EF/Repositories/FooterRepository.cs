using KaiCoreApp.Data.Entities;
using KaiCoreApp.Data.IRepositories;

namespace KaiCoreApp.EF.Repositories
{
    public class FooterRepository : Repository<Footer, string>, IFooterRepository
    {
        public FooterRepository(AppDbContext context) : base(context)
        {
        }
    }
}