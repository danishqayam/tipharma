using AutoMapper;
using System.Web.Mvc;
using TiPharma.CoreHelper;
using TiPharma.Models;
using TiPharma.EntityModel;

namespace TiPharma.Controllers
{
    public class HomeController : Controller
    {
        private TiPharmaEntities dbContext = new TiPharmaEntities();

        // GET: Home
        public ActionResult Index()
        {

            return View();
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Register()
        {
            UserMasterViewModel userMaster = new UserMasterViewModel();
            return View(userMaster);
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult Register(UserMasterViewModel userMasterViewModel)
        {
            if (ModelState.IsValid)
            {
                userMasterViewModel.UserType = "Client";
                var userMaster = Mapper.Map<UserMasterViewModel, UserMaster>(userMasterViewModel);
                userMaster.Password = DataProtection.Encrypt(userMasterViewModel.Password);
                dbContext.UserMasters.Add(userMaster);
                dbContext.SaveChanges();
            }

            return View();
        }
    }
}