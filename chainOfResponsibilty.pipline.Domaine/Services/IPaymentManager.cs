using chainOfResponsibilty.pipline.Domaine.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace chainOfResponsibilty.pipline.Domaine.Services
{
     public interface  IPaymentManager
    {
        public bool CalculateFee(decimal fee, int subId);
    }
}
