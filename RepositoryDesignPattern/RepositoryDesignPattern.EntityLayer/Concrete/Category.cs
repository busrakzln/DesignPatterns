using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryDesignPattern.EntityLayer.Concrete
{
    public class Category
    {
        public int CategoryID { get; set; }
        public string CategoryName { get; set; }

        //proudctta ilişki kurulduktan sonra list türünde product alınacak
        public List<Product> Products { get; set; }
    }
}
