using System.Web.Mvc;
using Sample.Web.Models;

namespace Sample.Web.Controllers
{
    public class CustomerController : BaseController
    {
        //[SampleMvcAuthorize]
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Create()
        {
            return View(new CustomerViewModel());
        }

        [HttpPost]
        public ActionResult Create(CustomerViewModel model)
        {
            // save operation
            return Json("ok");
        }

        public ActionResult Update()
        {
            return View(new CustomerViewModel());
        }

        [HttpPost]
        public ActionResult Update(CustomerViewModel model)
        {
            // updae operation
            return Json("ok");
        }

        [HttpPost]
        public ActionResult Delete(CustomerViewModel model)
        {
            // delete operation
            return Json("ok");
        }
    }
}