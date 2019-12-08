using KaiCoreApp.Data.Entities;
using KaiCoreApp.Data.IRepositories;

namespace KaiCoreApp.EF.Repositories
{
    public class FeedbackRepository : Repository<Feedback, int>, IFeedBackRepository
    {
        public FeedbackRepository(AppDbContext context) : base(context)
        {
        }
    }
}