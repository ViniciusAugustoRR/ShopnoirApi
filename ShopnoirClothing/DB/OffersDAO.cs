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
            var list = Helper.RunProcedureWithReturn("SN_GETALLOFFERS");
            return list;
        }
    
    }


}
