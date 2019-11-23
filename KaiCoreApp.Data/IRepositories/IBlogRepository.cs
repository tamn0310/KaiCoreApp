using KaiCoreApp.Data.Entities;
using KaiCoreApp.Infrastructure.Interfaces;

namespace KaiCoreApp.Data.IRepositories
{
    public interface IBlogRepository : IRepository<Blog, int>
    {
    }
}