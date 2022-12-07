using Newtonsoft.Json;
using ShopnoirClothing.Helpers;
using ShopnoirClothing.Models;

namespace ShopnoirClothing.DB
{
    public class OffersDAO
    {
        private string cs;
        private SQLHelper Helper;
        public OffersDAO(string Connection) { 
            cs = Connection; 
            Helper = new SQLHelper(cs);
        }  

        public List<Item> GetAllOffers() 
        {
            var json = Helper.RunProcedureWithReturn("SN_GETALLOFFERS");
            List<Item> list = JsonConvert.DeserializeObject<List<Item>>(json);
            return list;
        }
    
    }


}
