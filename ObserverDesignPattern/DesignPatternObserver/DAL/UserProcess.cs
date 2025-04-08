namespace DesignPatternObserver.DAL
{
    public class UserProcess //kullanıcı işlemleri
    {
        public int UserProcessID { get; set; } // kullanıcı işlemleri idsi
        public string NameSurname { get; set; }
        public string Content { get; set; }
        public string Magazine { get; set; } // kullanıcı  hangi dergiye abone
    }
}
