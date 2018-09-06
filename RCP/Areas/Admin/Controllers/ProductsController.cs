using BLL;
using DAO;
using PagedList;
using System.Collections;
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
        private MenuBLL menuContext = new MenuBLL();
        private MenuSubBLL menuSubContext = new MenuSubBLL();
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

        public ActionResult Create()
        {
            ViewBag.lstMenu = menuContext.GetAll();
            return View();
        }

        public ActionResult ListCatSub()
        {
            int? idCat = int.Parse(Request.Form["cat"]);
            List<MenuSub> vList = menuSubContext.GetAll(idCat);
            if (vList != null)
            {
                Response.ContentType = "text/xml";
                Response.Write("<?xml version='1.0' encoding='utf-8'?>");
                Response.Write("<options>");
                Response.Write("<option>");
                Response.Write("<value> </value>");
                Response.Write("<text>Chọn</text>");
                Response.Write("</option>");
                if (vList != null && vList.Count > 0)
                {
                    IEnumerator ie = vList.GetEnumerator();
                    while (ie.MoveNext())
                    {
                        MenuSub vList_ = (MenuSub)ie.Current;
                        Response.Write("<option>");
                        Response.Write("<value>" + vList_.ID + "</value>");
                        Response.Write("<text>" + vList_.Name.Replace('&', '|') + "</text>");
                        Response.Write("</option>");
                    }
                }
                Response.Write("</options>");
                Response.End();
            }
            Response.Write("");
            Response.End();
           
            return View();
        }

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