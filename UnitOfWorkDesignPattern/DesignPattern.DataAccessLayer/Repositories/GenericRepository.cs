using DesignPattern.DataAccessLayer.Abstratc;
using DesignPattern.DataAccessLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPattern.DataAccessLayer.Repositories
{
    public class GenericRepository<T> : IGenericDal<T> where T : class
    {
        private readonly Context _context;


        //repository design pattern kullanıldığında savechange işlemi burada yapılmalı fakat 
        //unit of workün farkı bu bir yerden diğerine işlem gerçekleştiğinde hata olursa işlem bütünyle iptal edilsin
        //bu yüzden ayrı bir klasör tanımlanıp orada gerçeklşecek (IUowDal.cs)
        public GenericRepository(Context context)
        {
            _context = context;
        }

        public void Delete(T t)
        {
            _context.Remove(t);
        }

        public T GetByID(int id)
        {
            return _context.Set<T>().Find(id);
        }

        public List<T> GetList()
        {
            return _context.Set<T>().ToList();
        }

        public void Insert(T t)
        {
            _context.Add(t);
        }

        public void MultiUpdate(List<T> t)
        {
            _context.UpdateRange(t);
        }

        public void Update(T t)
        {
            _context.Update(t);
        }
    }
}
