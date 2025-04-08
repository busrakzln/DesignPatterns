namespace DesignPattern.ChainOfResponsibility.DAL
{
    public class CustomerProcess // Müşteri Hareketleri
    {
        public int CustomerProcessID { get; set; }
        public string Name { get; set; }//müşteri adı
        public string Amount { get; set; }//miktar
        public string EmployeeName { get; set; }//Çalışan bilgileri
        public string Description { get; set; }//AÇıklama
    }
}
