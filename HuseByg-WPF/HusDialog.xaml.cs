using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using HuseByg.model;

namespace HuseByg_WPF
{
    /// <summary>
    /// Interaction logic for TilføjHusDialog.xaml
    /// </summary>
    public partial class HusDialog : Window
    {
        private Hus hus;
        public HusDialog()
        {
            InitializeComponent();
        }

        public HusDialog(Hus hus)
        {
            InitializeComponent(); // DET HER OPRETTER ALLE XAML KOMPONENTERNE
             
            this.hus = hus;

            tbTitel.Text = $"Rediger: {hus.HusId}";

            tbAdresse.Text = hus.Adresse;
            tbVærelser.Text = hus.AntalVærelser.ToString();
            tbStørrelse.Text = hus.Kvm.ToString();
            
            switch (hus.Type)
            {
                case HusType.Stor:
                    rbStor.IsChecked = true;
                    break;
                case HusType.Lille:
                    rbLille.IsChecked = true;
                    break;
                case HusType.Ende:
                    rbEnde.IsChecked = true;
                    break;
                default:
                    rbStor.IsChecked = false;
                    rbLille.IsChecked = false;
                    rbEnde.IsChecked = false;
                    break;
            }
        }

        private void Fortryd(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }
    }
}
