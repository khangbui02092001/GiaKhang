using Project_Travel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Project_Travel.Controllers
{
    public class TourController : Controller
    {
        // GET: Tour
        MyDataDataContext data = new MyDataDataContext();
        public ActionResult ListTour()
        {
            var all_tour = from ss in data.Tours select ss;
            return View(all_tour);
        }
        public ActionResult Detail(int id)
        {
            var D_tour = data.Tours.Where(m => m.MaTour== id).First();
            return View(D_tour);
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(FormCollection collection, Tour s)
        {
            var E_matour = collection["MaTour"];
            var E_tentour = collection["TenTour"];
            var E_hinh = collection["Hinh"];
            var E_gia = Convert.ToDecimal(collection["Gia"]);
            var E_ngaykhoihanh = collection["NgayKhoiHanh"];
            var E_phuongtien = collection["PhuongTien"];
            var E_songaydi = collection["SoNgayDi"];
            if (string.IsNullOrEmpty(E_matour))
            {
                ViewData["Error"] = "Don't empty!";
            }
            else
            {
                
                s.TenTour = E_tentour.ToString();
                s.Hinh = E_hinh.ToString();
                s.Gia = E_gia;
                s.NgayKhoiHanh = E_ngaykhoihanh.ToString();
                s.PhuongTien = E_phuongtien.ToString();
                s.SoNgayDi = E_songaydi.ToString();
                data.Tours.InsertOnSubmit(s);
                data.SubmitChanges();
                return RedirectToAction("ListTour");
            }
            return this.Create();
        }
    }
}