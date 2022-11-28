using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShopnoirClothing.DB;

namespace ShopnoirClothing.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemController : ControllerBase
    {
        private IConfiguration _configuration;
        private OffersDAO OffersDAO;
        public ItemController(IConfiguration configuration) 
        { 
            _configuration= configuration;
            OffersDAO = new OffersDAO(_configuration.GetConnectionString("DefaultConnection"));

            test();
        }

        public void test()
        {
            var x = OffersDAO.GetAllOffers();
            var y = x;
        }



    }

}
