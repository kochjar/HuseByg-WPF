using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HuseByg.model
{
    public class Hus
    {
        private string _husId;
        private string _adresse;
        private HusType _type;
        private int _kvm;
        private int _antalVærelser;
        private Lejemål _lejemål;
        private static int count = 0;

        public string HusId
        {
            get { return _husId; }
            private set { _husId = value; }
        }
        public string Adresse
        {
            get { return _adresse; }
            private set { _adresse = value; }
        }

        public HusType Type
        {
            get { return _type; }
            private set { _type = value; }
        }

        public int Kvm
        {
            get { return _kvm; }
            private set { _kvm = value; }
        }
        public int AntalVærelser
        {
            get { return _antalVærelser; }
            private set { _antalVærelser = value; }
        }

        public Lejemål Lejemål
        {
            get { return _lejemål; }
            private set { _lejemål = value; }
        }

        public Hus(string adresse, HusType type, int kvm, int antalVærelser)
        {
            count++;
            this.HusId = $"H{count}";
            this.Adresse = adresse;
            this.Type = type;
            this.Kvm = kvm;
            this.AntalVærelser = antalVærelser;

        }
        public void TilføjLejemål(Lejemål lejemål)
        {
            this.Lejemål = lejemål;
        }
    }
}
