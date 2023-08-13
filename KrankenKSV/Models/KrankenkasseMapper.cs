using CsvHelper.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KrankenKSV.Models
{
    public class KrankenkasseMapper : ClassMap<Krankenkasse>
    {
        public KrankenkasseMapper()
        {
            Map(kk => kk.Name).Index(0);
            Map(kk => kk.IK).Index(1);
            Map(kk => kk.Hausanschrift.PostCode).Index(7);
            Map(kk => kk.Hausanschrift.City).Index(8);
            Map(kk => kk.Hausanschrift.StreetName).Index(9);

            Map(kk => kk.Postanschrift.PostCode).Index(10);
            Map(kk => kk.Postanschrift.City).Index(11);
            Map(kk => kk.Postanschrift.StreetName).Index(12);

            Map(kk => kk.Anschrift.PostCode).Index(13);
            Map(kk => kk.Anschrift.City).Index(14);
            Map(kk => kk.Anschrift.StreetName).Index(15);

            Map(kk => kk.VerweisIK).Index(17);
            Map(kk => kk.UnkNumber).Index(18);
            Map(kk => kk.Email).Index(19);
        }
    }
}
