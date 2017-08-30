using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DeathValley.Models;

namespace DeathValley.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";

            return View();
        }

        [HttpPost]
        public JsonResult CreateDataChart(Param model)
        {
            List<CacheData> pointArray = new List<CacheData>();

            int k = 0;

            for (double x = model.RangeFrom; x <= model.RangeTo; x += model.Step)
            {
                k++;
                double y = model.CoefficientA * x * x + model.CoefficientB * x + model.CoefficientC;
                pointArray.Add(new CacheData {CacheDataId = k, PointX = x, PointY = y, ParamId = k});
            }

            return Json(pointArray, JsonRequestBehavior.AllowGet);
        }
    }
}
