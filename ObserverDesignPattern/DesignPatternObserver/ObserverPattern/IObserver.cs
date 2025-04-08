using DesignPatternObserver.DAL;

namespace DesignPatternObserver.ObserverPattern
{
    public interface IObserver
    {
        void CreateNewUser(AppUser appUser); 
        // yeni kullanıcı oluştur ve Appuser sınfından bir appUser parametresi alacak

    }
}
