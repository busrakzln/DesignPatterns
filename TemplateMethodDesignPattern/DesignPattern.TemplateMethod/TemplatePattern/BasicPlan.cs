namespace DesignPattern.TemplateMethod.TemplatePattern
{
    public class BasicPlan : NetflixPlans // basicplan sınıfı,netflixplans ana sınfından miras
                                          // alır ve bun sınıf içeriği basicplan sınıfına implement edilir.
    {
        public override string Content(string content)
        {
            return content; //parametreden gönderilen değer dönücek bu parametreden gönderilecek değer controller tarafında kullanıcıya bırakılacak.
        }

        public override int CountPerson(int countPerson)
        {
            return countPerson; //parametreden gönderilen değer dönücek bu parametreden gönderilecek değer controller tarafında kullanıcıya bırakılacak.
        }

        public override string PlanType(string planType)
        {
            return planType; //parametreden gönderilen değer dönücek bu parametreden gönderilecek değer controller tarafında kullanıcıya bırakılacak.
        }

        public override double Price(double price)
        {
            return price; //parametreden gönderilen değer dönücek bu parametreden gönderilecek değer controller tarafında kullanıcıya bırakılacak.
        }

        public override string Resolutaion(string resolutaion)
        {
            return resolutaion; //parametreden gönderilen değer dönücek bu parametreden gönderilecek değer controller tarafında kullanıcıya bırakılacak.
        }
    }
}
