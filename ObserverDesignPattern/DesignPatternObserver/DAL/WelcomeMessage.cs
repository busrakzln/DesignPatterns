namespace DesignPatternObserver.DAL
{
    public class WelcomeMessage
    {
        public int WelcomeMessageID { get; set; }
        public string NameSurname { get; set; }//alıcı isim soyisim
        public string Content { get; set; }//mesaj başlığı
    }
}
