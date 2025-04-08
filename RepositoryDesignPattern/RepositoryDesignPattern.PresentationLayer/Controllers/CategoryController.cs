using Microsoft.AspNetCore.Mvc;
using RepositoryDesignPattern.BusinessLayer.Abstract;
using RepositoryDesignPattern.EntityLayer.Concrete;

namespace RepositoryDesignPattern.PresentationLayer.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        
        public IActionResult Index()
        {
            var values=_categoryService.TGetList();
            return View(values);
        }

        [HttpGet]
        public IActionResult AddCategory()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddCategory(Category category)
        {
            _categoryService.TInsert(category);
            return RedirectToAction("Index");
        }

        public IActionResult DeleteCategory(int id)
        {
            var value=_categoryService.TGetByID(id); //idye göre değeri bul
            _categoryService.TDelete(value);//bulduğun bu value değeri sil
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult UpdateCategory(int id)
        {
            var value = _categoryService.TGetByID(id);//idye göre bul
            return View(value); // value döndür sayfa yüklendiğinde güncellenecek olan veriler gelecek
        }

        [HttpPost]
        public IActionResult UpdateCategory(Category category)
        {
            _categoryService.TUpdate(category); //categoryden gelen bilgileri güncelle
            return RedirectToAction("Index");//güncelleme işleminden sonra bizi tekrar ındex sayfasına yönlendir.
        }
    }
}
