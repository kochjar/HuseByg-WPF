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

        private void Fortryd_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }
        public string Adresse { get { return tbAdresse.Text; } }
        public int AntalVærelser { get { return int.Parse(tbVærelser.Text); } }

        public int Størrelse { get { return int.Parse(tbStørrelse.Text); } }

        public HusType Type
        {
            get
            {
                if (rbStor.IsChecked == true)
                {
                    return HusType.Stor;
                } else if (rbLille.IsChecked == true)
                {
                    return HusType.Lille;
                } else
                {
                    return HusType.Ende;
                }
            }
        }

        private void Gem_Click(object sender, RoutedEventArgs e)
        {
            // Errors
            if (string.IsNullOrEmpty(tbAdresse.Text)) { MessageBox.Show("Du skal angive hvilken adresse huset har.", "Hov, der skete en fejl!", MessageBoxButton.OK, MessageBoxImage.Error); return; }
            if (string.IsNullOrEmpty(tbVærelser.Text)) { MessageBox.Show("Du skal angive hvor mange værelser huset har.", "Hov, der skete en fejl!", MessageBoxButton.OK, MessageBoxImage.Error); return; }
            if (string.IsNullOrEmpty(tbStørrelse.Text)) { MessageBox.Show("Du skal angive husets størrelse.", "Error", MessageBoxButton.OK, MessageBoxImage.Error); return; }
            if (!int.TryParse(tbVærelser.Text, out int _)) { MessageBox.Show("Du skal angive et tal i feltet for antal værelser.", "Hov, der skete en fejl!", MessageBoxButton.OK, MessageBoxImage.Error); return; }
            if (!int.TryParse(tbStørrelse.Text, out int _)) { MessageBox.Show("Du skal angive et tal i feltet for antal værelser.", "Hov, der skete en fejl!", MessageBoxButton.OK, MessageBoxImage.Error); return; }
            if (rbStor.IsChecked == false && rbLille.IsChecked == false && rbEnde.IsChecked == false) { MessageBox.Show("Du skal vælge en type til huset.", "Hov, der skete en fejl!", MessageBoxButton.OK, MessageBoxImage.Error); return; }

            DialogResult = true;
        }
    }
}
