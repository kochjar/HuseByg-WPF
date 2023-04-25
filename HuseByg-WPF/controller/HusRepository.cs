using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HuseByg.model;



namespace HuseByg.controller
{
    public class HusRepository
    {
        private List<Hus> huse;

        public HusRepository() {
            this.huse = new List<Hus>();
        }

        public void TilføjHus(string adresse, HusType type, int kvm, int antalVærelser)
        {
            Hus hus = new Hus(adresse, type, kvm, antalVærelser);
            huse.Add(hus);
        }

        public List<Hus> HentAlleHuse()
        {
            return huse;
        }


    }
}

