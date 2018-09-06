using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    public class MenuDAO
    {
        public List<Menu> GetAll()
        {
            using (RCPEntities db = new RCPEntities())
            {
                return db.Menus.ToList();
            }
        }
    }
}
