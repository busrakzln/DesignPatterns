namespace DesignPattern.ChainOfResponsibility.Models
{
    public class CustomerProcessViewModel
    {
        public int CustomerProcessID { get; set; }
        public string Name { get; set; }//müşteri adı
        public int Amount { get; set; }//miktar
        public string EmployeeName { get; set; }//Çalışan bilgileri
        public string Description { get; set; }//AÇıklama
    }
}
