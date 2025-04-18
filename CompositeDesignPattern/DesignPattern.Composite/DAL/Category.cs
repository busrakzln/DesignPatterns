﻿namespace DesignPattern.Composite.DAL
{
    public class Category
    {
        public int CategoryID { get; set; }
        public string CategoryName { get; set; }
        public int UpperCategoryID { get; set; } // bir üst kategori ıdsi
        public List<Product> Products { get; set; }
    }
}
