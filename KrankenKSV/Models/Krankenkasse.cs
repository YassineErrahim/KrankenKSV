using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KrankenKSV.Models
{
    public class Krankenkasse : BaseModel
    {
        public string Name { get; set; }

        public int IK { get; set; }

        public Guid HausanschriftId { get; set; }

        public Address Hausanschrift { get; set; } = new Address();

        public Guid PostanschriftId { get; set; } = Guid.Empty;

        public Address Postanschrift { get; set; } = new Address();

        public Address Anschrift { get; set; } = new Address();

        public int VerweisIK { get; set; }

        public string UnkNumber { get; set; } = "";

        public string Email { get; set; }
    }
}
