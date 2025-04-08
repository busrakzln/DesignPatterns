using RepositoryDesignPattern.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryDesignPattern.DataAccessLayer.Abstract
{
    public interface IProductDal:IGenericDal<Product>
    {
        //entitye özel metot olur ise buraya tanımlanır.
        List<Product> ProductListWithCategory();//ürün listesini kategorilerle beraber getir entitye özel metot
        //efproductdala gidip implemet edilir.

        //business katmanında da IProductService .ProductManagera gidilir
    }
}
