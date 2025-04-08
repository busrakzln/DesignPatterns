using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryDesignPattern.BusinessLayer.Abstract
{
    public interface IGenericService<T> where T : class
    { //controller tarafında çağırılacak metotları tutacak 
        //controller da businnes katmanı kullanılacak
        //bu metotların çağırılabilmesi için yazılması gerek (ekle,sil,güncelle..)

        //dataaccess katmanındaki gibi yalnızca başına T ekliyoruz çünkü; iki katman arasındaki ifadeler karışmasın
        void TInsert(T t);//T türünde bir t parametresi al
        void TUpdate(T t);
        void TDelete(T t);
        List<T> TGetList(); // listeleme işlemi için
        T TGetByID(int id);
    }
}
