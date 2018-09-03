using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    public class ProductDAO
    {
        public List<Product> GetAll()
        {
            using (RCPEntities db = new RCPEntities())
            {
                return db.Products.ToList();
            }
        }
    }
}
