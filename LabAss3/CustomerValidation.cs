using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabAss3
{
    internal class CustomerValidation
    {
        public void CheckCustomerName(string customerName)
        {
            if (customerName.Length > 10)
                throw new Exception("Name should be within 10 characters.");
            else if (customerName == "")
                throw new Exception("Name is required. ");
        }
    }
}
