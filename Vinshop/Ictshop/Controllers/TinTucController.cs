using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Ictshop.Models;

namespace Ictshop.Controllers
{
    public class TinTucController : Controller
    {
        Qlbanhang db = new Qlbanhang();
        // GET: TinTuc
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult tintuc()
        {

            var lstSP = db.TinTucs;

            return View(lstSP);
        }
        public ActionResult TinTucpartial()
        {
            var ip = db.TinTucs.Take(4).ToList();
            return PartialView(ip);
        }
        public ActionResult xemchitiet(int maTinTuc = 0)
        {
            var chitiet = db.TinTucs.SingleOrDefault(n => n.maTinTuc == maTinTuc);
            if (chitiet == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            return View(chitiet);
        }
    }
}