using KaiCoreApp.Data.Entities;
using KaiCoreApp.Data.IRepositories;

namespace KaiCoreApp.EF.Repositories
{
    public class SlideRepository : Repository<Slide, int>, ISlideRepository
    {
        public SlideRepository(AppDbContext context) : base(context)
        {
        }
    }
}