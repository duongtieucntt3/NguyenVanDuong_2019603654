using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Ictshop.Models;
using System.Data.Entity;
using static System.Data.Entity.Infrastructure.Design.Executor;

namespace Ictshop.Areas.Admin.Controllers
{
    public class ThongkesController : Controller
    {
        private Qlbanhang db = new Qlbanhang();

        // GET: Admin/Thongkes
        public ActionResult Index()
        {
            var donhangs = db.Donhangs.ToList();
            var dataThongke = (from s in db.Donhangs
                      join x in db.Nguoidungs on s.MaNguoidung equals x.MaNguoiDung
                      group s by s.MaNguoidung into g
                      select new Thongke
                      {
                          Tennguoidung = g.FirstOrDefault().Nguoidung.Hoten,
                          Tongtien = g.Sum(x => x.Tongtien),
                          Dienthoai = g.FirstOrDefault().Nguoidung.Dienthoai,
                          Soluong = g.Count()
                      });
            var dataFinal = dataThongke.OrderByDescending(s => s.Tongtien).Take(5).ToList();
            return View(dataFinal);
        }
        public ActionResult ThongKeDoanhThu()
        {            
            return View();
        }
        [HttpGet]
        public ActionResult DoanhThu(string fromDate, string toDate)
        {
            var query = from o in db.Donhangs
                        join od in db.Chitietdonhangs
                        on o.Madon equals od.Madon
                        join p in db.Sanphams
                        on od.Masp equals p.Masp
                        select new
                        {
                            Ngaydat = o.Ngaydat,
                            Soluong = od.Soluong,
                            Dongia = od.Dongia                            
                        };
            if (!string.IsNullOrEmpty(fromDate))
            {
                DateTime startDate = DateTime.ParseExact(fromDate, "dd/MM/yyyy", null);
                query = query.Where(x => x.Ngaydat >= startDate);
            }
            if (!string.IsNullOrEmpty(toDate))
            {
                DateTime endDate = DateTime.ParseExact(toDate, "dd/MM/yyyy", null);
                query = query.Where(x => x.Ngaydat < endDate);
            }

            var result = query.GroupBy(x => DbFunctions.TruncateTime(x.Ngaydat)).Select(x => new
            {
                Date = x.Key.Value,                
                TotalSell = x.Sum(y => y.Soluong * y.Dongia),
            }).Select(x => new
            {
                Date = x.Date,
                DoanhThu = x.TotalSell                
            });
            return Json(new { Data = result }, JsonRequestBehavior.AllowGet);
        }    
    }
}