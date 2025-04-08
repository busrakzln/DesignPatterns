using Microsoft.AspNetCore.Identity;

namespace DesignPatternObserver.DAL
{
    public class AppUser:IdentityUser<int>
    {
        //identity kütüphanesi bize login, register gibi işlemleri otomatik olarak yapmamızı sağlayan
        //ve arka tarafta pek çok hazır tablo sunan bir yapıdır.

        public string Name { get; set; }
        public string Surname { get; set; }
        public string? City { get; set; }
        public string? District { get; set; } // ilçe 
    }
}
