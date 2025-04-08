using DesignPatternObserver.DAL;

namespace DesignPatternObserver.ObserverPattern
{
    public class CreateWelcomeMessage : IObserver
    {
        private readonly IServiceProvider _serviceProvider; //program.cs de
        Context context=new Context();

        public CreateWelcomeMessage(IServiceProvider serviceProvider) //generate constuctor dependicy injection uygulanacak
        {
            _serviceProvider = serviceProvider; //serviceprovider ataması yapıldı
        }

        public void CreateNewUser(AppUser appUser) // method yeni bir kullanıcı oluştuğunda tetiklenecek olan method
        {
            //welcome message içerisine yeni welcomemessages ekle
            context.WelcomeMessages.Add(new WelcomeMessage 
            {
                NameSurname= appUser.Name + " " + appUser.Surname, // appuserdan gelen name ver surname al
                Content="Dergi Bültenimize Kayıt Olduğunuz İçin Çok Teşekkür Ederiz,Dergilerimize Web Sitemizden Ulaşabilirsiniz "

            });
            context.SaveChanges();
        }
    }
}
