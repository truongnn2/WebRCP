using DAO;
using System.Collections.Generic;

namespace BLL
{
    public class ProductBLL
    {
        public List<Product> GetAll()
        {
            ProductDAO context = new ProductDAO();
            List<Product> lstProduct = new List<Product>();
            try
            {
                lstProduct = context.GetAll();
            }
            catch
            {
                return null;
            }
            return lstProduct;
        }
    }
}