﻿using DesignPattern.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPattern.DataAccessLayer.Abstratc
{
    public interface ICustomerDal:IGenericDal<Customer>
    {
    }
}
