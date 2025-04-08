using System.Text;
using System.Xml.Linq;

namespace DesignPattern.Composite.CompositePattern
{
    public class ProductComposite : IComponent // 'ProductComposite' sınıfı, 'IComponent' arayüzünü uyguluyor.
    {
        public int Id { get; set; } // Ürünün kimlik numarasını tutan bir özellik.
        public string Name { get; set; } // Ürünün adını tutan bir özellik.

        private List<IComponent> _components; // Alt bileşenleri saklamak için bir liste (örneğin alt ürünler).

        // Constructor: Bu sınıfın bir örneğini oluştururken Id ve Name değerlerini atar.
        public ProductComposite(int id, string name)
        {
            Id = id;
            Name = name;
            _components = new List<IComponent>(); // Alt bileşenler için boş bir liste oluşturur.
        }

        // Bileşenleri dışarıdan okuma erişimi sağlıyor (readonly).
        public ICollection<IComponent> Components => _components;

        // Alt bileşen eklemek için bir metot.
        public void Add(IComponent component)
        {
            _components.Add(component); // Yeni bir alt bileşeni listeye ekler.
        }

        // Ürün ve alt ürünlerin görselleştirilmesi için HTML döndüren metot.
        public string Display()
        {
            var stringBuilder = new StringBuilder(); // String birleştirme işlemi için StringBuilder kullanılır.
            stringBuilder.Append($"<div class='text-success'>{Name} ({TotalCount()})</div>");
            // Ürünün adı ve toplam alt ürün sayısı gösterilir (örneğin: "Ürün Adı (3)").

            stringBuilder.Append("<ul class='list-group list-group-flush ms-2'>");
            // Alt ürünlerin sıralanacağı bir liste (HTML <ul>) başlatılır.

            foreach (var item in _components) // Tüm alt bileşenler üzerinden iterasyon yapılır.
            {
                stringBuilder.Append(item.Display()); // Her alt bileşenin 'Display' metodu çağrılarak görselleştirilir.
            }

            stringBuilder.Append("</ul>"); // Listeyi kapatır.
            return stringBuilder.ToString(); // HTML çıktısını döndürür.
        }

        // Toplam alt bileşen sayısını hesaplayan metot.
        public int TotalCount()
        {
            return _components.Sum(x => x.TotalCount());
            // Alt bileşenlerin 'TotalCount' değerlerini toplar. 
            // Bu sayede tüm alt ürünlerin toplam sayısını döner.
        }
    }
    //Ürünleri ve alt ürünlerini(kompozit yapı) tutup, bir ağaç yapısı
    //üzerinden dolaşarak işlem yapmayı sağlar.
    //Display metodu ile görselleştirme, TotalCount ile ise tüm
    //alt ürünlerin toplam sayısını hesaplama gibi işlevsellikler sunar.
}
