using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    public class MenuSubDAO
    {
        public List<MenuSub> GetAll(int? idCat)
        {
            using (RCPEntities db = new RCPEntities())
            {
                return db.MenuSubs.Where(x => x.IDMenu == idCat && x.Status == 0).ToList();
            }
        }
    }
}
