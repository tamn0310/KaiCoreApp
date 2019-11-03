using KaiCoreApp.Data.Entities;
using KaiCoreApp.Data.IRepositories;

namespace KaiCoreApp.EF.Repositories
{
    public class PermissionRepository : Repository<Permission, int>, IPermissionRepository
    {
        public PermissionRepository(AppDbContext context) : base(context)
        {
        }
    }
}