using GetImagesFromDatabase.Code;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GetImagesFromDatabase.Controllers
{
    public class SearchImageController : Controller
    {
        [HttpGet]
        // GET: SearchImage
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult XemBang(GetImagesFromDatabase.Models.GetIDFromTable model)
        {
            return View();
        }

        [HttpGet]
        public ActionResult XemAnh(string ID)
       // public ActionResult XemAnh()
        {
            DataTable dtHinhAnh = Common.dtImage(ID);

            //DataTable dtHinhAnh = Common.dtImage("31182");

            List<string> imgDataURLs = new List<string>();
            foreach (DataRow drHinhAnh in dtHinhAnh.Rows)
            {
                byte[] byteData = (byte[])drHinhAnh["HinhAnh"];
                string imreBase64Data = Convert.ToBase64String(byteData);
                string imgDataURL1 = string.Format("data:image/jpg;base64,{0}", imreBase64Data);
                imgDataURLs.Add(imgDataURL1);
            }

            ViewBag.ImageData = imgDataURLs;
            return View();
        }

    }
}