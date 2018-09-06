using DAO;
using System.Collections.Generic;

namespace BLL
{
    public class MenuBLL
    {
        public List<Menu> GetAll()
        {
            MenuDAO context = new MenuDAO();
            List<Menu> lstMenu = new List<Menu>();
            try
            {
                lstMenu = context.GetAll();
            }
            catch
            {
                return null;
            }
            return lstMenu;
        }
    }
}