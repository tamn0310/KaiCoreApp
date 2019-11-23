using KaiCoreApp.Data.Entities;
using KaiCoreApp.Data.IRepositories;

namespace KaiCoreApp.EF.Repositories
{
    public class SystemConfigRepository : Repository<SystemConfig, string>, ISystemConfigRepository
    {
        public SystemConfigRepository(AppDbContext context) : base(context)
        {
        }
    }
}