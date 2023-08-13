using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KrankenKSV.Models
{
    public class Address : BaseModel
    {
        public string StreetName { get; set; } = String.Empty;

        public string PostCode { get; set; } = String.Empty;

        public string City { get; set; } = String.Empty ;
    }
}
