using DesignPatternObserver.DAL;
using DesignPatternObserver.Models;
using DesignPatternObserver.ObserverPattern;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace DesignPatternObserver.Controllers
{
    public class DefaultController : Controller
    {
        //indetityin sınfında olan usermanager sınıfından appuser parametres alınır buradan türetilen nesne _usermanager olsun
        private readonly UserManager<AppUser> _userManager;
        private readonly ObserverObject _observerObject;

        public DefaultController(UserManager<AppUser> userManager, ObserverObject observerObject)//consuctor methodu
        {
            _userManager = userManager;
            _observerObject = observerObject;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public  async Task<IActionResult> Index(RegisterViewModel model) //registerviewmodelden model örneği aldı
        {
            var appUser = new AppUser()
            {
                Name = model.Name,
                Surname = model.Surname,
                Email = model.Email,
                UserName = model.Name,

            };
            var result= await _userManager.CreateAsync(appUser,model.Password);//createasync identityde kullanıcı oluşturmak için kullanılan method burada iki parametre alır.
                                                                               //1-kullanıcı bilgisi(appuser) 2-password alıyor (modelden gelen )
            if(result.Succeeded)
            {
                _observerObject.NotifyObserver(appUser);
                return View();
            }
            return View();
        }
    }
}
