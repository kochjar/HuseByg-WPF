using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace HuseByg.model
{
    public class Lejer
    {
        private string _lejerId;
        private string _navn;
        private string _tlf_nr;
        private string _mail;
        private static int count = 0;

        public string LejerId
        {
            get { return _lejerId; }
            private set { _lejerId = value; }
        }

        public string navn
        {
            get { return _navn; }
            private set { _navn = value; }
        }
        public string tlf_nr
        {
            get { return _tlf_nr; }
            private set { _tlf_nr = value; }
        }

        public string mail
        {
            get { return _mail; }
            private set { _mail = value; }
        }


        public Lejer(string navn, string tlf_nr, string mail)
        {
            count++;
            LejerId = $"L{count}";
            this.navn = navn;
            this.tlf_nr = tlf_nr;
            this.mail = mail;

        }

    }
}
