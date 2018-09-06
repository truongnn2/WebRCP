using DAO;
using System.Collections.Generic;

namespace BLL
{
    public class MenuSubBLL
    {
        public List<MenuSub> GetAll(int? idCat)
        {
            MenuSubDAO context = new MenuSubDAO();
            List<MenuSub> lstMenuSub = new List<MenuSub>();
            try
            {
                lstMenuSub = context.GetAll(idCat);
            }
            catch
            {
                return null;
            }
            return lstMenuSub;
        }
    }
}