using KaiCoreApp.Data.Entities;
using KaiCoreApp.Infrastructure.Interfaces;

namespace KaiCoreApp.Data.IRepositories
{
    public interface IPermissionRepository : IRepository<Permission, int>
    {
    }
}