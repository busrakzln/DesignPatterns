namespace DesignPattern.Composite.CompositePattern
{
    public interface IComponent
    {
        public int Id { get; set; }
        public string Name { get; set; }

        int TotalCount();//kategori içindeki alt kategori sayısı

        string Display(); //sidebarın html kodlarını tuatacak

    }
}
