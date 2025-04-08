﻿using DesignPattern.TemplateMethod.TemplatePattern;
using Microsoft.AspNetCore.Mvc;

namespace DesignPattern.TemplateMethod.Controllers
{
    public class DefaultController : Controller
    {
        public IActionResult BasicPlanIndex()
        {
            NetflixPlans netflixPlans = new BasicPlan();
            //NetflixPlans sınıfından bir netflixPLans nesnesi türetildi. 
            //new NetflixPlans();  şeklinde örnek oluşturamayız çünkü bu bir abstarct class
            //new BasicPlan(); burada abstrackı inherit eden yani kalıtan sınıfı göndereceğiz.

            ViewBag.v1 = netflixPlans.PlanType("Temel Plan");
            ViewBag.v2 = netflixPlans.CountPerson(1);
            ViewBag.v3 = netflixPlans.Price(100);
            ViewBag.v4 = netflixPlans.Content("Film-Dizi");
            ViewBag.v5 = netflixPlans.Resolutaion("480px");
            return View();
        }

        public IActionResult StandartPlanIndex()
        {
            NetflixPlans netflixPlans = new StandartPlan();
            //NetflixPlans sınıfından bir netflixPLans nesnesi türetildi. 
            //new NetflixPlans();  şeklinde örnek oluşturamayız çünkü bu bir abstarct class
            //new BasicPlan(); burada abstrackı inherit eden yani kalıtan sınıfı göndereceğiz.

            ViewBag.v1 = netflixPlans.PlanType("Standart Plan");
            ViewBag.v2 = netflixPlans.CountPerson(2);
            ViewBag.v3 = netflixPlans.Price(240);
            ViewBag.v4 = netflixPlans.Content("Film-Dizi-Animasyon");
            ViewBag.v5 = netflixPlans.Resolutaion("720px");
            return View();
        }

        public IActionResult UltraPlanIndex()
        {
            NetflixPlans netflixPlans = new StandartPlan();
            //NetflixPlans sınıfından bir netflixPLans nesnesi türetildi. 
            //new NetflixPlans();  şeklinde örnek oluşturamayız çünkü bu bir abstarct class
            //new BasicPlan(); burada abstrackı inherit eden yani kalıtan sınıfı göndereceğiz.

            ViewBag.v1 = netflixPlans.PlanType("Ultra Plan");
            ViewBag.v2 = netflixPlans.CountPerson(4);
            ViewBag.v3 = netflixPlans.Price(480);
            ViewBag.v4 = netflixPlans.Content("Film-Dizi-Animasyon-Belgesel");
            ViewBag.v5 = netflixPlans.Resolutaion("1040px");
            return View();
        }
    }
}
