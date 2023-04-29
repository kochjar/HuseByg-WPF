using HuseByg.model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.IO;
using System.IO.Enumeration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HuseByg_WPF
{
    public class Persistens
    {
        // Linje: "Adresse;HusType;Størrelse;AntalVærelser;LejemålFindes;DerErToLejere;Indflytningsdato;Fraflytningsdato;IndbetaltDepositum;AntalHunde;AntalKatte;
        // PrimærNavn;PrimærMail;PrimærTlf;SekundærNavn;SekundærMail;SekundærTlf;"

        static public string fileName = "dataTest.txt";

        static public void Save(ObservableCollection<Hus> Huse)
        {
            List<string> lines = new List<string>();
            foreach (Hus hus in Huse)
            {
                string line = "";
                if (hus.LejemålFindes == false)
                {
                    line = $"{hus.Adresse};{hus.Type};{hus.Kvm};{hus.AntalVærelser};{hus.LejemålFindes}";
                } else if (hus.LejemålFindes == true && hus.Lejemål.DerErToLejere == false)
                {
                    line = $"{hus.Adresse};{hus.Type};{hus.Kvm};{hus.AntalVærelser};{hus.LejemålFindes};{hus.Lejemål.DerErToLejere};"+
                           $"{hus.Lejemål.Indflytningsdato};{hus.Lejemål.Fraflytningsdato};{hus.Lejemål.IndbetaltDepositum};"+
                           $"{hus.Lejemål.AntalHunde};{hus.Lejemål.AntalHunde};{hus.Lejemål.Lejere[0].navn};{hus.Lejemål.Lejere[0].mail};"+
                           $"{hus.Lejemål.Lejere[0].tlf_nr}";
                } else if (hus.LejemålFindes == true && hus.Lejemål.DerErToLejere == true)
                {
                    line = $"{hus.Adresse};{hus.Type};{hus.Kvm};{hus.AntalVærelser};{hus.LejemålFindes};{hus.Lejemål.DerErToLejere};" +
                           $"{hus.Lejemål.Indflytningsdato};{hus.Lejemål.Fraflytningsdato};{hus.Lejemål.IndbetaltDepositum};" +
                           $"{hus.Lejemål.AntalHunde};{hus.Lejemål.AntalHunde};{hus.Lejemål.Lejere[0].navn};{hus.Lejemål.Lejere[0].mail};" +
                           $"{hus.Lejemål.Lejere[0].tlf_nr};{hus.Lejemål.Lejere[1].navn};{hus.Lejemål.Lejere[1].mail};" +
                           $"{hus.Lejemål.Lejere[1].tlf_nr};";
                }
                
                lines.Add(line);
            }
            File.WriteAllLines(fileName, lines);
        }

        static public ObservableCollection<Hus> Load()
        {
            ObservableCollection<Hus> Huse = new ObservableCollection<Hus>();
            string[] lines = File.ReadAllLines(fileName);

            foreach(string line in lines) {
                string[] lineArray = line.Split(";");

                Hus hus = new Hus(
                    lineArray[0],
                    (HusType)Enum.Parse(typeof(HusType), lineArray[1]),
                    int.Parse(lineArray[2]),
                    int.Parse(lineArray[3])
                );
                

                if (bool.Parse(lineArray[4]) == true)
                {
                    List<Lejer> lejere;
                    Lejer PrimærLejer = new Lejer(lineArray[11], lineArray[12], lineArray[13]);
                    if (bool.Parse(lineArray[5]) == true)
                    {  
                       Lejer SekundærLejer = new Lejer(lineArray[14], lineArray[15], lineArray[16]);
                       lejere = new List<Lejer>() { PrimærLejer, SekundærLejer }; 
                    } 
                    else
                    {  lejere = new List<Lejer>() { PrimærLejer };  }

                    Lejemål lejemål = new Lejemål(
                    DateTime.Parse(lineArray[6]),
                    DateTime.Parse(lineArray[7]),
                    double.Parse(lineArray[8]),
                    lejere,
                    int.Parse(lineArray[9]),
                    int.Parse(lineArray[10])
                    );

                    hus.TilføjLejemål(lejemål);
                }

                Huse.Add(hus);

            }

            return Huse;
        }
    }
}
