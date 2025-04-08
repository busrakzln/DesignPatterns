namespace DesignPattern.TemplateMethod.TemplatePattern
{
    public abstract class NetflixPlans // ana sınıf
    {
        public void CreatePLan() //plan oluştur metodu
        {
            PlanType(string.Empty); // başlagıç olarak değer ataması
            CountPerson(0);
            Price(0);
            Resolutaion(string.Empty);
            Content(string.Empty);
        }//planlar oluştukta içerik düzenlenir

        public abstract string PlanType(string planType); //dışarıdan bir parametre alsın
        public abstract int CountPerson(int countPerson);
        public abstract double Price(double price);
        public abstract string Resolutaion(string resolutaion);
        public abstract string Content(string content); 
    }
}
