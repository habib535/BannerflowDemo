using BannerFlowDemo.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BannerFlowDemo.Application.Services
{
    public interface IBannerService
    {
        Task<IEnumerable<Banner>> GetAll();

        Banner GetById(int id);

        Task AddBanner(Banner banner);

        Task UpdateBanner(int id, Banner banner);

        Task RemoveBanner(int id);
    }
}
