using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryDesignPattern.EntityLayer.Concrete
{
    public class Product
    {
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public int ProductStock { get; set; }
        public  decimal ProductPrice { get; set; }
        //category tablosu ile product tablosunu ilişkili hale getirmek için code firstte;
        public int CategoryID { get; set; } // ilk önce yansıyacak sütun ismi
                                            //veri tabanına yansıyacak kısım

        public Category Category { get; set; } //ilişkili olduğunu belirtmek için Category türünde bir category propertysi alınır
                                                //bu veri tabanına yansımayacak 
    }
}
