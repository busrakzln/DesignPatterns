using DesignPattern.DataAccessLayer.Abstratc;
using DesignPattern.DataAccessLayer.Concrete;
using DesignPattern.DataAccessLayer.Repositories;
using DesignPattern.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPattern.DataAccessLayer.EntityFramework
{
    public class EfProcessDal : GenericRepository<Process>, IProcessDal
    {
        public EfProcessDal(Context context) : base(context)
        {
            //EfCustomerDal:
            //Bu sınıfın adı.Muhtemelen bir Entity Framework(EF) veri erişim katmanı
            //(Data Access Layer - DAL) sınıfıdır ve Customer(müşteri) ile ilgili işlemleri içerir.

            //Context context:
            //Bu, bir parametre olarak geçirilen veritabanı bağlamıdır. EF'de,
            //bağlam (DbContext türevi) veritabanı ile iletişim kurmak için kullanılır.

            //base anahtar kelimesi, bir sınıfın üst sınıfındaki
            //(yani, miras aldığı sınıfındaki) constructor veya üyeleri çağırmak için kullanılır.

            //Bu örnekte, constructor'un gövdesi boş.
            //Yani, yapıcı metot şu anda yalnızca temel sınıfa parametre iletmeyi sağlıyor.
        }
    }
}
