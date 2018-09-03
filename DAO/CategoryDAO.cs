using System;
using System.Collections.Generic;
using System.Linq;

namespace DAO
{
    public class CategoryDAO
    {
        public List<Category> GetAll()
        {
            using(var db = new RCPEntities())
            {
                return db.Categories.ToList();
            }
        }
    }
}
