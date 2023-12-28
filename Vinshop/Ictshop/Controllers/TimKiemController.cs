using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Ictshop.Models;

namespace Ictshop.Controllers
{
    public class TimKiemController : Controller
    {
        Qlbanhang db = new Qlbanhang();
        // GET: TimKiem
        [HttpGet]
        public ActionResult KQTimKiem(string TuKhoa)
        {
            var listSP = db.Sanphams.Where(n => n.Tensp.Contains(TuKhoa));
            ViewBag.TuKhoa = TuKhoa;
            return View(listSP.OrderBy(n => n.Tensp));
        }
        [HttpPost]
        public ActionResult LayTuKhoaTimKiem(string TuKhoa)
        {

            return RedirectToAction("KQTimKiem", new { @TuKhoa = TuKhoa });
        }
    }
}