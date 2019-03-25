using BannerFlowDemo.Domain.Entities;
using BannerFlowDemo.Domain.RepositoryContracts;
using System.Linq;

namespace BannerFlowDemo.Infrastructure.Repositories
{
    public class BannerRepository : BaseRepository<Banner>, IBannerRepository
    {
        public BannerRepository(AppDbContext appDbContext) : base(appDbContext)
        {
        }

        public Banner FindById(int id)
        {
            return _appDbContext.Banners.FirstOrDefault(x => x.Id == id);
        }
    }
}
