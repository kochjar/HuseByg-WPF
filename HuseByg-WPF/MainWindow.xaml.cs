using HuseByg.model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
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

        public void SletHus_Click(object sender, RoutedEventArgs e)
        {
            Hus hus = ((FrameworkElement)sender).DataContext as Hus;
            Huse.Remove(hus);
        }


    }
}
