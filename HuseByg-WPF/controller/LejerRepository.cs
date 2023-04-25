using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HuseByg.model;

namespace HuseByg.controller
{
    public class LejerRepository
    {
        public List<Lejer> lejere;

        public LejerRepository()
        {
            this.lejere = new List<Lejer>();
        }

        public void TilføjLejer(string navn, string tlf_nr, string mail)
        {
            lejere.Add(new Lejer(navn, tlf_nr, mail));
        }

        public List<Lejer> HentAlleLejere()
        {
            return lejere;
        }

    }
}

