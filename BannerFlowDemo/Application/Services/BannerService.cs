using BannerFlowDemo.Domain.Entities;
using BannerFlowDemo.Domain.RepositoryContracts;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BannerFlowDemo.Application.Services
{
    public class BannerService : IBannerService
    {
        private readonly IBannerRepository _bannerRepository;

        public BannerService(IBannerRepository bannerRepository)
        {
            _bannerRepository = bannerRepository;
            //initialize db with default data
            PopulateTestData();
        }
        public async Task<IEnumerable<Banner>> GetAll()
        {
            return await _bannerRepository.GetAll();
        }

        public Banner GetById(int id)
        {
            return _bannerRepository.FindById(id);
        }

        public async Task AddBanner(Banner banner)
        {
            await _bannerRepository.Add(banner);
        }

        public async Task UpdateBanner(int id, Banner banner)
        {
            var existingBanner = _bannerRepository.FindById(id);
            existingBanner.Html = banner.Html;
            await _bannerRepository.Update(existingBanner);
        }

        public async Task RemoveBanner(int id)
        {
            var existingBanner = _bannerRepository.FindById(id);
            await _bannerRepository.Delete(existingBanner);
        }

        #region seed test data
        private void PopulateTestData()
        {
            // populate only if no table is empty
            if (!_bannerRepository.Any().Result)
            {
                var taskList = new List<Task>();
                for (int i = 1; i <= 10; i++)
                {
                    taskList.Add(_bannerRepository.Add(
                        new Banner
                        {
                            Id = i,
                            Html = GenerateHTMLForBanners(i)
                        }));
                }

                Task.WaitAll(taskList.ToArray());
            }
        }

        private string GenerateHTMLForBanners(int id)
        {
            return $@"<div style='width: 300px;
                        height: 200px;
                        border: 1px solid black;
                        padding: 10px;
                        margin: 10px;'>
                    <p>Buy 1 get 1 Free</p>
                    <br/>
                    <p>Get 50% discount on non seasonal items</p>
                    <br/>
                    <p>Banner # {id}</p>
                    </div>";
        }

        #endregion
    }
}
