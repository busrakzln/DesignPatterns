using DesignPatternObserver.DAL;

namespace DesignPatternObserver.ObserverPattern
{
    public class ObserverObject //observer objelerinin oluşturulacağı sınıf
    {
        private readonly List<IObserver> _observers;

        public ObserverObject()
        {
            _observers = new List<IObserver>();
        }
        //gözlemleyeceğimiz adımları bir liste içerisinde tutacağız


        //görmek istediğimiz veya görmek istemediğimiz observer nesneleri için oluşturmamız gerekiyor.bu yapı 

        public void RegisterObserver(IObserver observer) //IObserverdan bir observer parametresi alınır.
        {
            _observers.Add(observer); // _observer içerisine observerdan gelen değeri ekle
        }

        public void RemoveObserver(IObserver observer)
        {
            _observers.Remove(observer); //gözlemciyi siler.
        }

        public void NotifyObserver(AppUser appUser) //her bir kullanıcı için tek tek tetiklenmesi için 
        {
            _observers.ForEach(x => // listenin  her bir ögesi için foreach
            {
                x.CreateNewUser(appUser);
            });
        }
    }
}
