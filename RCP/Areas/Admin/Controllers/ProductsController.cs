using BLL;
using BLL.Entity;
using DAO;
using PagedList;
using System.Collections.Generic;
using System.Data.Entity;
using System.Net;
using System.Web.Mvc;

namespace RCP.Areas.Admin.Controllers
{
    public class ProductsController : Controller
    {
        private RCPEntities db = new RCPEntities();
        private ProductBLL productContext = new ProductBLL();
        private const int PageSize = 20;

        #region GetAll List Product
        public ActionResult Index()
        {
            return View(productContext.GetAll().ToPagedList(1, PageSize));
        }
        #endregion

        #region Page list
        public PartialViewResult GetPaging(int? page)
        {
            int pageNumber = (page ?? 1);
            return PartialView("_PartialViewProducts", productContext.GetAll().ToPagedList(pageNumber, PageSize));
        }
        #endregion

        #region Product Detail
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }
        #endregion

        #region Create- View
        public ActionResult Create()
        {
            CategoryBLL contextCategory = new CategoryBLL();
            List<Category> lstCategory = contextCategory.GetAll();
            List<Category> lstCategorNo1 = new List<Category>();


            foreach (var item in lstCategory)
            {
                if(item.Father == null && item.GrandFather == null && item.GreatGrandFather == null)
                {
                    lstCategorNo1.Add(item);
                }
            }
            ViewBag.Category = lstCategorNo1;
            return View();
        }
        #endregion

        // POST: Admin/Products/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Category,CategoryDetail,CategoryDetailSub,Title,TitleE,Content,ContentE,Photo,Status,DateCreate,IsHot,Price,IsShowPrice,Intro,Location,IsShowDefault,FileAttach,ViewCount,PromotionPrice,IsMostView,IsNew")] Product product)
        {
            if (ModelState.IsValid)
            {
                db.Products.Add(product);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(product);
        }

        // GET: Admin/Products/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // POST: Admin/Products/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Category,CategoryDetail,CategoryDetailSub,Title,TitleE,Content,ContentE,Photo,Status,DateCreate,IsHot,Price,IsShowPrice,Intro,Location,IsShowDefault,FileAttach,ViewCount,PromotionPrice,IsMostView,IsNew")] Product product)
        {
            if (ModelState.IsValid)
            {
                db.Entry(product).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(product);
        }

        // GET: Admin/Products/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // POST: Admin/Products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Product product = db.Products.Find(id);
            db.Products.Remove(product);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}