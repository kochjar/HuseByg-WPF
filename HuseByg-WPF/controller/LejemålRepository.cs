using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HuseByg.model;

namespace HuseByg.controller
{
    public class LejemålRepository
    {
        private List<Lejemål> lejemåls;

        public LejemålRepository()
        {
            this.lejemåls = new List<Lejemål>();
        }
        /*
        public void TilføjLejemål(DateTime indflytningsdato, DateTime fraflytningsdato, double indbetaltDepositum, List<Lejer> lejere, 
            int antalHunde, int antalKatte)
        {
            lejemåls.Add(new Lejemål(indflytningsdato, fraflytningsdato, indbetaltDepositum, lejere, antalHunde, antalKatte));
        }*/

        public void TilføjLejemål(Lejemål lejemål)
        {
            lejemåls.Add(lejemål);
        }

        public List<Lejemål> HentAlleLejemål()
        {
            return lejemåls;
        }
    }
}
