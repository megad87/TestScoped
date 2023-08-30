using DifferentScopes;
using Microsoft.AspNetCore.Mvc;
using ScodedAll.Models;
using System.Data;
using System.Diagnostics;

namespace ScodedAll.Controllers
{
    public class HomeController : Controller
    {
       
        private readonly ILogger<HomeController> _logger;
        private readonly ITransientService _tranService1;
        private readonly ITransientService _tranService2;
        private readonly IScopedService _scopedService1;
        private readonly IScopedService _scopedService2;
        private readonly ISingletonService _singletonService1;
        private readonly ISingletonService _singletonService2;

        public HomeController(ILogger<HomeController> logger,
            ITransientService tranService1,
            ITransientService tranService2,
            IScopedService scopedService1,
            IScopedService scopedService2,
            ISingletonService singletonService1,
            ISingletonService singletonService2)
        {
            _logger = logger;
            _tranService1 = tranService1;
            _tranService2 = tranService2;
            _scopedService1 = scopedService1;
            _scopedService2 = scopedService2;
            _singletonService1 = singletonService1;
            _singletonService2 = singletonService2;
        }

        public IActionResult Index()
        {
            ViewBag.transient1 = _tranService1.GetCurrentGUID().ToString();
            ViewBag.transient2 = _tranService2.GetCurrentGUID().ToString();
            ViewBag.scoped1 = _scopedService1.GetCurrentGUID().ToString();
            ViewBag.scoped2 = _scopedService2.GetCurrentGUID().ToString();
            ViewBag.singleton1 = _singletonService1.GetCurrentGUID().ToString();
            ViewBag.singleton2 = _singletonService2.GetCurrentGUID().ToString();
            MemberDataAccessLayer m = new MemberDataAccessLayer();
            //m.TestMem();
            //m.TestMemNonQuery();
            //m.TestCOnnection();
           // m.InsertProduct();
            //ViewBag.memberDataAccessLayer = m;
            DataSet ds = m.GetData();
            //m.MemberDataOutput();
            m.MemberDataOutput();

            return View();
        }

        public IActionResult Index1()
        {
            ViewBag.transient1 = _tranService1.GetCurrentGUID().ToString();
            ViewBag.transient2 = _tranService2.GetCurrentGUID().ToString();
            ViewBag.scoped1 = _scopedService1.GetCurrentGUID().ToString();
            ViewBag.scoped2 = _scopedService2.GetCurrentGUID().ToString();
            ViewBag.singleton1 = _singletonService1.GetCurrentGUID().ToString();
            ViewBag.singleton2 = _singletonService2.GetCurrentGUID().ToString();
            return View();
        }
    }
}