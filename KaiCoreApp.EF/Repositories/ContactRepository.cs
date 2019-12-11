using KaiCoreApp.Data.Entities;
using KaiCoreApp.Data.IRepositories;

namespace KaiCoreApp.EF.Repositories
{
    public class ContactRepository : Repository<Contact, string>, IContactRepository
    {
        public ContactRepository(AppDbContext context) : base(context)
        {
        }
    }
}