using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WinfinityClass;


namespace Winfinity_Mvc.Controllers
{
    public class HomeController : Controller
    {

        public HomeController()
        { 
            
        }
        //
        // GET: /Home/
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(TestEntity obj)
        {
            Test t = new Test();
            t.Save(obj);
            return View();
        }
        [HttpGet]
        public ActionResult Registration()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Registration(UserAcct obj)
        {
           
            obj.Save(obj);
            List<UserAcctEntity> obj1 = obj.GetAll();
            return View();
        }

    }
}
