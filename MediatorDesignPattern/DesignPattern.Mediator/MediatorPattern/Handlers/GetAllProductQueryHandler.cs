using DesignPattern.Mediator.DAL;
using DesignPattern.Mediator.MediatorPattern.Queries;
using DesignPattern.Mediator.MediatorPattern.Results;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace DesignPattern.Mediator.MediatorPattern.Handlers
{
    public class GetAllProductQueryHandler : IRequestHandler<GetAllProductQuery, List<GetAllProductQueryResult>>
    {
        // Bağlam (context) sınıfı, veritabanı işlemleri için kullanılır.
        private readonly Context _context;

        // Constructor (yapıcı) metot, context'i bağımlılık enjeksiyonu ile alır.
        public GetAllProductQueryHandler(Context context)
        {
            _context = context; // Gelen context, sınıfın private alanına atanır.
        }

        // Handle metodu, IRequestHandler arayüzündeki metodu implement eder.
        // Bu metot, GetAllProductQuery'yi işler ve bir liste döner.
        public async Task<List<GetAllProductQueryResult>> Handle(GetAllProductQuery request, CancellationToken cancellationToken)
        {
            // Veritabanındaki Products tablosundan veriler alınır ve yeni bir liste oluşturulur.
            return await _context.Products
                // Products tablosundaki her bir kaydı, GetAllProductQueryResult nesnesine projekte eder.
                .Select(x => new GetAllProductQueryResult
                {
                    ProductID = x.ProductID,           // Ürün ID'si
                    ProductName = x.ProductName,       // Ürün adı
                    ProductCategory = x.ProductCategory, // Ürün kategorisi
                    ProductPrice = x.ProductPrice,     // Ürün fiyatı
                    ProductStock = x.ProductStock,     // Ürün stok miktarı
                    ProductStockType = x.ProductStockType // Ürün stok tipi
                })
                // AsNoTracking, EF Core'un izleme yapmamasını sağlar (performans için).
                .AsNoTracking()
                // Veriler liste olarak döndürülür.
                .ToListAsync();
        }
    }
    /*Genel Açıklama
Sınıf Tanımı:
GetAllProductQueryHandler, IRequestHandler arayüzünü uygular. 
Bu sınıf, GetAllProductQuery türündeki sorguları işler ve sonuç olarak bir List<GetAllProductQueryResult> döner.

Context Kullanımı:
Veritabanı işlemleri için EF Core Context sınıfı kullanılır. Context, Products tablosuna erişimi sağlar.

Select ile Projeksiyon:
Veritabanından alınan veriler, doğrudan sorgunun geri dönüş türü olan GetAllProductQueryResult formatına dönüştürülür.

AsNoTracking Kullanımı:
Performansı artırmak için veritabanından alınan veriler EF Core tarafından takip edilmez.

Async Yapı:
Veriler, ToListAsync() ile asenkron olarak işlenip döndürülür. Bu, uygulamanın daha hızlı ve ölçeklenebilir olmasını sağlar.

Bu yapı genellikle CQRS (Command Query Responsibility Segregation) deseninde sorgu işlemleri için kullanılır.*/
}
