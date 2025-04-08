using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using RepositoryDesignPattern.BusinessLayer.Abstract;
using RepositoryDesignPattern.EntityLayer.Concrete;

namespace RepositoryDesignPattern.PresentationLayer.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService _productService;
        private readonly ICategoryService _categoryService;

        public ProductController(IProductService productService, ICategoryService categoryService)
        {
            _productService = productService;
            _categoryService = categoryService;
        }

        public IActionResult Index()
        {
            var values=_productService.TGetList();
            return View(values);
        }
        public IActionResult Index2() //bu index2 ürünleri kategorileri ile getirmesi için
        {
            var values = _productService.TProductListWithCategory();
            return View(values);
        }

        [HttpGet]
        public IActionResult AddProduct()
        {
            List<SelectListItem> values=(from x in _categoryService.TGetList() //_categoryService.TGetList() ile kategori listesini alır.
                                         select new SelectListItem //SelectListItem türünde bir liste oluşturuyor, her bir kategori için:
                                         {
                                             Text=x.CategoryName, //Text kısmına kategori adını (CategoryName),
                                             Value =x.CategoryID.ToString() //Value kısmına kategori ID'sini (CategoryID.ToString()) koyuyor.
                                         }).ToList();
            ViewBag.v=values; //Sonuçta bu listeyi ViewBag.v içine atıyor.
            //Bu, genelde bir dropdown menüye veri göndermek için kullanılır.
            //Dropdown, kullanıcıların bir liste içinden bir öğe seçmesini sağlayan açılır menüdür.
            //Web sayfalarında sıkça kullanılan bir form elemanıdır.
            //Örneğin, şehir seçimi yaparken gördüğün "tıklayınca açılan liste" gibi.
            return View();
        }
        [HttpPost]
        public IActionResult AddProduct(Product product)
        {
            _productService.TInsert(product);
            return RedirectToAction("Index");
        }

        public IActionResult DeleteProduct(int id)
        {
            var values = _productService.TGetByID(id); //idye göre değeri bul
            _productService.TDelete(values);//bulduğun bu value değeri sil
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult UpdateProduct(int id)
        {
            List<SelectListItem> values = (from x in _categoryService.TGetList() //_categoryService.TGetList() ile kategori listesini alır.
                                           select new SelectListItem //SelectListItem türünde bir liste oluşturuyor, her bir kategori için:
                                           {
                                               Text = x.CategoryName, //Text kısmına kategori adını (CategoryName),
                                               Value = x.CategoryID.ToString() //Value kısmına kategori ID'sini (CategoryID.ToString()) koyuyor.
                                           }).ToList();
            ViewBag.v = values;
            var value = _productService.TGetByID(id);//idye göre bul
            return View(value); // value döndür sayfa yüklendiğinde güncellenecek olan veriler gelecek
        }

        [HttpPost]
        public IActionResult UpdateProduct(Product product)
        {
            _productService.TUpdate(product); //categoryden gelen bilgileri güncelle
            return RedirectToAction("Index");//güncelleme işleminden sonra bizi tekrar ındex sayfasına yönlendir.
        }
    }
}
