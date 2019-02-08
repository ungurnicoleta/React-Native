using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AccesaStart.WebApi.ViewModels
{
    public class TransferViewModel
    {
        public string PhoneNumber { get; set; }

        public string TargetPhoneNumber { get; set; }

        public double Amount { get; set; }
    }
}
