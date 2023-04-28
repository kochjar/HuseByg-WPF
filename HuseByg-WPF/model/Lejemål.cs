using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace HuseByg.model
{
    public class Lejemål
    {
        private string _lejemålId;
        private DateTime _indflytningsdato;
        private DateTime _fraflytningsdato;
        private double _indbetaltDepositum;
        private List<Lejer> _lejere;
        private int _antalHunde;
        private int _antalKatte;
        private static int count = 0;

        public string LejemålId
        {
            get { return _lejemålId; }
            set { _lejemålId = value; }
        }
        public DateTime Indflytningsdato
        {
            get { return _indflytningsdato; }
            set { _indflytningsdato = value; }
        }
        public DateTime Fraflytningsdato
        {
            get { return _fraflytningsdato; }
            set { _fraflytningsdato = value; }
        }

        public double IndbetaltDepositum
        {
            get { return _indbetaltDepositum; }
            set { _indbetaltDepositum = value; }
        }

        public List<Lejer> Lejere
        {
            get { return _lejere; }
            set { _lejere = value; }
        }

        public int AntalHunde
        {
            get { return _antalHunde; }
            set { _antalHunde = value; }
        }

        public int AntalKatte
        {
            get { return _antalKatte; }
            set { _antalKatte = value; }
        }

        public bool DerErToLejere { get; set; }

        public Lejemål(DateTime indflytningsdato, DateTime fraflytningsdato, double indbetaltDepositum, List<Lejer> lejere, int antalHunde, int antalKatte)
        {
            count++;
            LejemålId = $"LM{count}";
            Indflytningsdato = indflytningsdato;
            Fraflytningsdato = fraflytningsdato;
            IndbetaltDepositum = indbetaltDepositum;
            Lejere = lejere;
            AntalHunde = antalHunde;
            AntalKatte = antalKatte;
            if (lejere.Count == 2) {
                this.DerErToLejere = true;
            } else
            {
                this.DerErToLejere = false;
            }
        }

        public Lejer HentPrimærLejer()
        {
            return Lejere[0];
        }
    }
}
