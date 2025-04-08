namespace DesignPatternObserver.DAL
{
    public class Discount
    {
        public int DiscountID { get; set; }
        public string DiscountCode { get; set; } //indirim kodu
        public int DiscountAmount { get; set; } //indirim miktarı
        public bool DiscountCodeStatus { get; set; } //indirim kodu geçerli mi
    }
}
