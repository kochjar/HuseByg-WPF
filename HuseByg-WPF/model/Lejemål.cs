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
            private set { _lejemålId = value; }
        }
        public DateTime Indflytningsdato
        {
            get { return _indflytningsdato; }
            private set { _indflytningsdato = value; }
        }
        public DateTime Fraflytningsdato
        {
            get { return _fraflytningsdato; }
            private set { _fraflytningsdato = value; }
        }

        public double IndbetaltDepositum
        {
            get { return _indbetaltDepositum; }
            private set { _indbetaltDepositum = value; }
        }

        public List<Lejer> Lejere
        {
            get { return _lejere; }
            private set { _lejere = value; }
        }

        public int AntalHunde
        {
            get { return _antalHunde; }
            private set { _antalHunde = value; }
        }

        public int AntalKatte
        {
            get { return _antalKatte; }
            private set { _antalKatte = value; }
        }

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
        }

        public Lejer HentPrimærLejer()
        {
            return Lejere[0];
        }
    }
}
