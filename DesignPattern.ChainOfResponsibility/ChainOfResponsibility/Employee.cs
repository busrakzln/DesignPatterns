using DesignPattern.ChainOfResponsibility.Models;

namespace DesignPattern.ChainOfResponsibility.ChainOfResponsibility
{
    public abstract class Employee
    {
        protected Employee NextApprover;

        public void SetNExtApprover(Employee superVisor)
        {
            this.NextApprover = superVisor;
        }
        public abstract void ProcessRequest(CustomerProcessViewModel req);
    }
}
