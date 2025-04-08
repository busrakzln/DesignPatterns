using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPattern.DataAccessLayer.UnitOfWork
{
    public interface IUowDal
    { //UowDal sınıfı oluşturulup metot implement edilir.
        void Save();
    }
}
