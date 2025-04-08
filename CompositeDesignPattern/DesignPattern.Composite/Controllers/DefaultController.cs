using DesignPattern.Composite.CompositePattern;
using DesignPattern.Composite.DAL;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace DesignPattern.Composite.Controllers
{
    public class DefaultController : Controller
    {
        private readonly Context _context;

        // Constructor: Controller'dan bir `Context` nesnesi alır ve bunu private bir alana atar.
        public DefaultController(Context context)
        {
            _context = context;
        }

        // Basit bir Index action'ı. Varsayılan olarak bir View döner.
        public IActionResult Index()
        {
            // Veritabanından Categories tablosundaki tüm veriler çekiliyor.
            // Include metodu ile Categories ile ilişkili Products tablosu da dahil ediliyor (Eager Loading).
            var categories = _context.Categories.Include(x => x.Products).ToList();

            // Rekursive adında bir metod çağrılıyor.
            // Bu metodun işlevi burada belirtilmemiş ancak genelde bir özyineleme işlemi yapar.
            // İlk parametre olarak kategoriler listesi, ikinci parametre olarak varsayılan bir kategori nesnesi,
            // üçüncü parametre olarak ise varsayılan bir ProductComposite nesnesi gönderiliyor.
            var values = Rekursive(
                categories,
                new Category { CategoryName = "FirstCategory", CategoryID = 0 },
                new ProductComposite(0, "FirstComposite")
            );

            // Rekursive metodundan dönen değer ViewBag'e aktarılıyor.
            // Bu değer View içerisinde kullanılabilecek.
            ViewBag.v = values;

            // Varsayılan olarak Index.cshtml view'ı döndürülüyor.
            return View();
        }


        // Rekursive metodu: Kategorileri ve ürünleri hiyerarşik bir yapıya dönüştürmek için kullanılır.
        public ProductComposite Rekursive(List<Category> categories, Category firstCategory, ProductComposite firsComposite, ProductComposite leaf = null)
        {
            // `categories` listesinden `firstCategory`'ye bağlı (üst kategori olarak) olan tüm kategorileri alır.
            categories.Where(x => x.UpperCategoryID == firstCategory.CategoryID).ToList().ForEach(y =>
            {
                // Her bir kategori için bir `ProductComposite` nesnesi oluşturur.
                var productComposite = new ProductComposite(y.CategoryID, y.CategoryName);

                // İlgili kategoriye ait tüm ürünleri dolaşır ve her bir ürün için bir `ProductComponent` oluşturur.
                y.Products.ToList().ForEach(z =>
                {
                    productComposite.Add(new ProductComponent(z.ProductID, z.ProductName));
                });

                // Eğer `leaf` parametresi null değilse, mevcut `ProductComposite` yaprak nesneye eklenir.
                if (leaf != null)
                {
                    leaf.Add(productComposite);
                }
                // Aksi takdirde, `firsComposite` kök nesnesine eklenir.
                else
                {
                    firsComposite.Add(productComposite);
                }

                // Mevcut kategori altındaki diğer kategorileri işlemek için metod kendisini çağırır.
                Rekursive(categories, y, firsComposite, productComposite);
            });

            // En sonunda kök composite nesnesini döner.
            return firsComposite;
        }
    }
// Bu metot, kategorileri ve kategorilere bağlı ürünleri ProductComposite
//ve ProductComponent yapılarıyla bir hiyerarşi içinde organize eder.
//leaf parametresi, mevcut düğümün altındaki kategorilerle bağlantı kurar.
//firsComposite ise, tüm ağacın kök elemanıdır.

}
