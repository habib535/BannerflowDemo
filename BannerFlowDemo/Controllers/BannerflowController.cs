using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using BannerFlowDemo.Application.Services;
using BannerFlowDemo.Domain.Entities;
using System.Net;

namespace BannerFlowDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BannerflowController : ControllerBase
    {
        private readonly IBannerService _bannerService;
        public BannerflowController(IBannerService bannerService)
        {
            _bannerService = bannerService;
        }

        // GET api/Bannerflow
        [HttpGet]
        public IEnumerable<Banner> Get()
        {
            return _bannerService.GetAll().Result;
        }

        // GET api/Bannerflow/5
        [HttpGet("{id}")]
        public Banner Get(int id)
        {
            return _bannerService.GetById(id);
        }

        [HttpGet("{id}/Render")]
        public ContentResult Render(int id)
        {
            var html = _bannerService.GetById(id).Html;
            return new ContentResult()
            {
                ContentType = "text/html",
                StatusCode = (int)HttpStatusCode.OK,
                Content = html
            };
        }

        // POST api/Bannerflow
        [HttpPost]
        public void Post(Banner banner)
        {
            _bannerService.AddBanner(banner).Wait();
        }

        // PUT api/Bannerflow/5
        [HttpPut("{id}")]
        public void Put(int id, Banner banner)
        {
            _bannerService.UpdateBanner(id, banner).Wait();
        }

        // DELETE api/Bannerflow/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _bannerService.RemoveBanner(id).Wait();
        }
    }
}
