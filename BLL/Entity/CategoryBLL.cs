using DAO;
using System;
using System.Collections.Generic;

namespace BLL.Entity
{
    public class CategoryBLL
    {
        public List<Category> GetAll()
        {
            CategoryDAO context = new CategoryDAO();
            List<Category> lstCategory = new List<Category>();
            try
            {
                lstCategory = context.GetAll();
                return lstCategory;
            }
            catch (Exception ex)
            {
                return null;
            }
        }


    }
}
