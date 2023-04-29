using HuseByg.model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

using System.Xaml.Permissions;
using System.Xml.Linq;

namespace HuseByg_WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public ObservableCollection<Hus> Huse { get; set; }
        public MainWindow()
        {
            InitializeComponent();
            this.Icon = new BitmapImage(new Uri("Favicon.ico", UriKind.Relative));



            Hus hus1 = new Hus("Søndervangen 23, 8000 Aarhus", HusType.Stor, 67, 3);
            List<Lejer> lejere1 = new List<Lejer>()
            {
                new Lejer("Craven Morhead", "10203040","craven.morhead@gmail.com"),
                new Lejer("Hugh Janus", "30205070","hugh.janus@gmail.com")
            };
            Lejemål lejemål1 = new Lejemål(new DateTime(2021, 1, 1), new DateTime(2023, 1, 1), 23000, lejere1, 3, 2);

            Hus hus2 = new Hus("Birkevej 12, 5000 Odense", HusType.Lille, 35, 2);
            List<Lejer> lejere2 = new List<Lejer>()
            {
                new Lejer("John Doe", "12345678", "john.doe@gmail.com"),
            };
            Lejemål lejemål2 = new Lejemål(new DateTime(2022, 6, 1), new DateTime(2024, 6, 1), 12000, lejere2, 2, 1);

            Hus hus3 = new Hus("Nørrebrogade 25, 2200 København", HusType.Ende, 50, 4);

            hus1.TilføjLejemål(lejemål1);
            hus2.TilføjLejemål(lejemål2);

            DataContext = this;

            Huse = new ObservableCollection<Hus>()
            {
                hus1, hus2, hus3
            };

            
        }

        private void NytHus_Click(object sender, RoutedEventArgs e)
        {
            
            HusDialog dialog = new HusDialog();
            bool? result = dialog.ShowDialog();
            if (result == true)
            {
                
                Huse.Add(new Hus(dialog.Adresse, dialog.Type, dialog.Størrelse, dialog.AntalVærelser));
            }
        }
        public void TilføjLejemål_Click(object sender, RoutedEventArgs e)
        {
            var hus = ((FrameworkElement)sender).DataContext as Hus;

            LejemålDialog dialog = new LejemålDialog();
            bool? result = dialog.ShowDialog();
            if (result == true)
            {
                List<Lejer> lejere = new List<Lejer>
                { new Lejer(dialog.PrimærLejerNavn, dialog.PrimærLejerMail, dialog.PrimærLejerTlfNr) };

                if (dialog.ToLejere == true)
                { lejere.Add(new Lejer(dialog.SekundærLejerNavn, dialog.SekundærLejerMail, dialog.SekundærLejerTlfNr)); }

                Lejemål lejemål = new Lejemål(
                    dialog.Indflytningsdato,
                    dialog.Fraflytningsdato,
                    dialog.IndbetaltDepositum,
                    lejere,
                    dialog.AntalHunde,
                    dialog.AntalKatte
                );

                int index = Huse.IndexOf(hus);
                Huse[index].TilføjLejemål(lejemål);
                Huse[index].OnPropertyChanged("Lejemål");
                Huse[index].OnPropertyChanged("LejemålFindes");
                Huse[index].OnPropertyChanged("LejemålFindesIkke");
            }
        }

        public void RedigerHus_Click(object sender, RoutedEventArgs e)
        {

            var hus = ((FrameworkElement)sender).DataContext as Hus;
                                                                    
            //Hus hus1 = (Hus)((Button)sender).Tag;
            HusDialog dialog = new HusDialog(hus);
            bool? result = dialog.ShowDialog();
            if (result == true)
            {
                int index = Huse.IndexOf(hus);
                Huse[index].Adresse = dialog.Adresse;
                Huse[index].Kvm = dialog.Størrelse;
                Huse[index].AntalVærelser = dialog.AntalVærelser; 
                Huse[index].Type = dialog.Type;
                Huse[index].OnPropertyChanged("Adresse");
                Huse[index].OnPropertyChanged("Type");
                Huse[index].OnPropertyChanged("Kvm");
                Huse[index].OnPropertyChanged("AntalVærelser");
            }

        }

        public void RedigerLejemål_Click(object sender, RoutedEventArgs e)
        {
            var hus = ((FrameworkElement)sender).DataContext as Hus;
            bool ToLejereFør = hus.Lejemål.DerErToLejere;
            LejemålDialog dialog = new LejemålDialog(hus.Lejemål);
            bool? result = dialog.ShowDialog();
            if(result == true)
            {
                int index = Huse.IndexOf(hus);
                
                if (dialog.ToLejere == true && ToLejereFør == true)
                {
                    Huse[index].Lejemål.Lejere[1].navn = dialog.SekundærLejerNavn;
                    Huse[index].Lejemål.Lejere[1].mail = dialog.SekundærLejerMail;
                    Huse[index].Lejemål.Lejere[1].tlf_nr = dialog.SekundærLejerTlfNr;
                } else if (dialog.ToLejere == true && ToLejereFør == false)
                {
                    Huse[index].Lejemål.Lejere.Add(new Lejer(
                        dialog.SekundærLejerNavn,
                        dialog.SekundærLejerMail,
                        dialog.SekundærLejerTlfNr
                    ));
                    Huse[index].Lejemål.DerErToLejere = true;
                } else if (dialog.ToLejere == false && ToLejereFør == true)
                {
                    Huse[index].Lejemål.Lejere.Remove(Huse[index].Lejemål.Lejere[1]);
                    Huse[index].Lejemål.DerErToLejere = false;
                }
                Huse[index].Lejemål.Lejere[0].navn = dialog.PrimærLejerNavn;
                Huse[index].Lejemål.Lejere[0].mail = dialog.PrimærLejerMail;
                Huse[index].Lejemål.Lejere[0].tlf_nr = dialog.PrimærLejerTlfNr;

                Huse[index].Lejemål.IndbetaltDepositum = dialog.IndbetaltDepositum;
                Huse[index].Lejemål.Indflytningsdato = dialog.Indflytningsdato;
                Huse[index].Lejemål.Fraflytningsdato = dialog.Fraflytningsdato;
                Huse[index].Lejemål.AntalHunde = dialog.AntalHunde;
                Huse[index].Lejemål.AntalKatte = dialog.AntalKatte;
                Huse[index].OnPropertyChanged("Lejemål");
                Huse[index].OnPropertyChanged("DerErToLejere");
            }
        }

        public void SletHus_Click(object sender, RoutedEventArgs e)
        {
            Hus hus = ((FrameworkElement)sender).DataContext as Hus;
            Huse.Remove(hus);
        }

        public void SletLejemål_Click(object sender, RoutedEventArgs e)
        {
            Hus hus = ((FrameworkElement)sender).DataContext as Hus;
            int index = Huse.IndexOf(hus);
            Huse[index].Lejemål = null;
            Huse[index].LejemålFindes = false;
            Huse[index].LejemålFindesIkke = true;
            Huse[index].OnPropertyChanged("Lejemål");
            Huse[index].OnPropertyChanged("LejemålFindes");
            Huse[index].OnPropertyChanged("LejemålFindesIkke");
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Debug.WriteLine("Hiiii");
            Persistens.Save(Huse);
        }


    }
}
