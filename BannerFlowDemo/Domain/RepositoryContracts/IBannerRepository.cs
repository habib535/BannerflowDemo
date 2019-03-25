using BannerFlowDemo.Domain.Entities;

namespace BannerFlowDemo.Domain.RepositoryContracts
{
    public interface IBannerRepository : IBaseRepository<Banner>
    {
        Banner FindById(int id);
    }
}
