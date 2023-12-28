﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Ictshop.Models;

namespace Ictshop.Controllers
{
    public class SanphamController : Controller
    {
        Qlbanhang db = new Qlbanhang();

        // GET: Sanpham
        public ActionResult sanphammoi()
        {
            var ip = db.Sanphams.Where(n => n.Sanphammoi == true);
            return PartialView(ip);
        }
        public ActionResult PhuKienpartial()
        {
            var ss = db.Sanphams.Where(n => n.Mahang == 9);
            return PartialView(ss);
        }        
        public ActionResult Laptoppartial()
        {
            var mi = db.Sanphams.Where(n => n.maLinhKien == 7);
            return PartialView(mi);
        }        
        //public ActionResult dttheohang(int Mahang)
        //{
        //    var mi = db.Sanphams.Where(n => n.Mahang == Mahang).Take(4).ToList();
        //    return PartialView(mi);
        //}
        
        public ActionResult xemchitiet(int Masp=0)
        {
            var chitiet = db.Sanphams.SingleOrDefault(n=>n.Masp==Masp);
            if (chitiet == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            return View(chitiet);
        }
        public ActionResult sanpham(int MaHang)       
        {
            
            var lstSP = db.Sanphams.Where(n => n.Mahang == MaHang);
            
            return View(lstSP);
        }
        public ActionResult LinhKien(int MaLinhKien)
        {

            var lstSP = db.Sanphams.Where(n => n.maLinhKien == MaLinhKien);
            
            return View(lstSP);
        }
        
    }

}