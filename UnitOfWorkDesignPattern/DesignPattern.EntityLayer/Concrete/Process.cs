using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPattern.EntityLayer.Concrete
{
    public class Process //işlemler sınıfı
    {
        public int ProcessId { get; set; } //işlem idsi
        public int Sender { get; set; } //gönderen id
        public int Receiver { get; set; } //alıcı id
        public decimal Amount { get; set; } //ne kadar gönderildi
    }
}
