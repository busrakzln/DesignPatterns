using DesignPatternObserver.DAL;

namespace DesignPatternObserver.ObserverPattern
{
    public class CreateMagazineAnnocuncement : IObserver //yeni dergi duyurusu sınıfı
    {
        private readonly IServiceProvider _serviceProvider;
        Context context=new Context();

        public CreateMagazineAnnocuncement(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public void CreateNewUser(AppUser appUser)
        {
            context.UserProcesses.Add(new UserProcess
            {
                NameSurname = appUser.Name + " " + appUser.Surname,
                Magazine="Bilim Dergisi",
                Content="Bilim Dergimiz Ocak Sayısı 1 Ocakta evinize ulaştırlacaktrır,konular Jüpiter ve Mars Gezegenleri Hakkında Olacaktır."
            });

            context.SaveChanges();
        }
    }
}
