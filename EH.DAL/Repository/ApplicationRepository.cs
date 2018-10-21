using EH.DAL.Context;
using EH.DAL.Interface;

namespace EH.DAL.Repository
{
    public class ApplicationRepository : BaseRepository, IApplicationRepository
    {
        private ApplicationDbContext _dbContext;

        ApplicationDbContext IApplicationRepository._dbContext  // read-only instance property
        {
            get
            {
                return _dbContext;
            }
        }

        public ApplicationRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }
    }
}
