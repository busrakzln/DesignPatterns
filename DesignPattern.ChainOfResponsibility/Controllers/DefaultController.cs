using DesignPattern.ChainOfResponsibility.ChainOfResponsibility;
using DesignPattern.ChainOfResponsibility.Models;
using Microsoft.AspNetCore.Mvc;

namespace DesignPattern.ChainOfResponsibility.Controllers
{
    public class DefaultController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Index(CustomerProcessViewModel model)
        {
            Employee treasurer = new Treasure();
            Employee managerAssistant=new ManagerAssistant();
            Employee manager = new Manager();
            Employee areaDirector = new AreaDirector();

            treasurer.SetNExtApprover(managerAssistant);
            managerAssistant.SetNExtApprover(manager);
            manager.SetNExtApprover(areaDirector);

            treasurer.ProcessRequest(model);
            return View();
        }
    }
}
