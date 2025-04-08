using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryDesignPattern.DataAccessLayer.Abstract
{
    public interface IGenericDal<T> where T : class
    {
        //T parametresi alacaksın ve bu T parametresi Entitylere karşılık gelecek ve bu T parametresi class olmalı

        // bütün entityler için sabit  olan metotlar 
        void Insert(T t);//T türünde bir t parametresi al
        void Update(T t);
        void Delete(T t);
        List<T> GetList(); // listeleme işlemi için
        T GetByID(int id);
    }
}
