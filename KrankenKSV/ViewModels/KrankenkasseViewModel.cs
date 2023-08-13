using KrankenKSV.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KrankenKSV.ViewModels
{
    public class KrankenkasseViewModel : ViewModelBase
    {
        //because Krankenkasse in Models does not implement Notify on Change so we could have Memory leak -
        //best way to implement it is this class instead of using Krankenkasse it self
        private readonly Krankenkasse _krankenkasse;
        public string Name => _krankenkasse.Name;

        public int IK => _krankenkasse.IK;

        public Address Hausanschrift => _krankenkasse.Hausanschrift;

        public Address Postanschrift => _krankenkasse.Postanschrift;

        public Address Anschrift => _krankenkasse.Anschrift;

        public int VerweisIK => _krankenkasse.VerweisIK;

        public string UnkNumber => _krankenkasse.UnkNumber;

        public string Email => _krankenkasse.Email;

        public KrankenkasseViewModel(Krankenkasse krankenkasse)
        {
            this._krankenkasse = krankenkasse;
        }
    }
}
