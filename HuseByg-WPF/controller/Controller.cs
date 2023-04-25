using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HuseByg.model;

namespace HuseByg.controller
{
    public class Controller
    {
        private LejerRepository lejerRepository;
        private HusRepository husRepository;
        private LejemålRepository lejemålRepository;
        public Controller() {
            this.lejerRepository = new LejerRepository();
            this.husRepository = new HusRepository();
            this.lejemålRepository = new LejemålRepository();
        }


        public void TilføjHus(string adresse, HusType type, int kvm, int antalVærelser)
        {
            husRepository.TilføjHus(adresse, type, kvm, antalVærelser);
        }

        public void TilføjLejer(string navn, string tlf_nr, string mail)
        {
            lejerRepository.TilføjLejer(navn,tlf_nr, mail);
        }

        //controller.TilføjLejemål("depositum", "antalhund", "antalkat", "H1, "L1", "L2"];
        public void TilføjLejemål(DateTime indflytningsdato, DateTime fraflytningsdato, double indbetaltDepositum,
                                  int antalHunde, int antalKatte, string husId, params string[] lejerIds) 
        {
            List<Hus> huse = husRepository.HentAlleHuse();
            List<Lejer> alleLejere = lejerRepository.HentAlleLejere();
            List<Lejer> fundneLejere = new List<Lejer>();
            Hus fundetHus;

            foreach (Lejer lejer in alleLejere)
            {
                foreach (string lejerId in lejerIds)
                {
                        if(lejerId == lejer.LejerId)
                        {
                            fundneLejere.Add(lejer);
                        }
                }
            }

            foreach (Hus hus in huse)
            {
                if (husId == hus.HusId)
                {
                    Lejemål lejemål = new Lejemål(indflytningsdato, fraflytningsdato, indbetaltDepositum, fundneLejere, antalHunde, antalKatte);
                    hus.TilføjLejemål(lejemål);
                    lejemålRepository.TilføjLejemål(lejemål);
                }
            }
        }

        public Lejer HentPrimærLejer(Lejemål lejemål)
        {
            return lejemål.Lejere[0];
        }

        public Lejer HentPrimærLejer(string LejemålId)
        {
            foreach (Lejemål lejemål in lejemålRepository.HentAlleLejemål())
            {
                if (lejemål.LejemålId== LejemålId) { return lejemål.Lejere[0]; }
            }
            return null;
        }

        public List<Hus> HentAlleHuse() { return husRepository.HentAlleHuse(); }
        public List<Lejer> HentAlleLejere() { return lejerRepository.HentAlleLejere(); }
        public List<Lejemål> HentAlleLejemål() { return lejemålRepository.HentAlleLejemål(); }


    }
}
