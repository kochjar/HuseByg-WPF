using System;
using System.Collections.Generic;
using System.Globalization;
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
    /// Interaction logic for LejemålDialog.xaml
    /// </summary>
    public partial class LejemålDialog : Window
    {
        public LejemålDialog()
        {
            InitializeComponent();
            rbEnLejer.IsChecked = true;
            this.Icon = new BitmapImage(new Uri("Favicon.ico", UriKind.Relative));
        }
        
        public LejemålDialog(Lejemål lejemål)
        {
            InitializeComponent();

            tbTitel.Text = "Rediger Lejemål";
            this.Icon = new BitmapImage(new Uri("Favicon.ico", UriKind.Relative));

            switch (lejemål.Lejere.Count)
            {
                case 1:
                    rbEnLejer.IsChecked = true;
                    break;
                case 2:
                    rbToLejere.IsChecked = true;
                    tbSekundærLejerNavn.Text = lejemål.Lejere[1].navn;
                    tbSekundærLejerMail.Text = lejemål.Lejere[1].mail;
                    tbSekundærLejerTlfNr.Text = lejemål.Lejere[1].tlf_nr;
                    break;
                default:
                    rbEnLejer.IsChecked = true;
                    break;
            }
            tbPrimærLejerNavn.Text = lejemål.Lejere[0].navn;
            tbPrimærLejerMail.Text = lejemål.Lejere[0].mail;
            tbPrimærLejerTlfNr.Text = lejemål.Lejere[0].tlf_nr;

            tbIndbetaltDepositum.Text = lejemål.IndbetaltDepositum.ToString();
            tbIndflytningsdato.Text = lejemål.Indflytningsdato.ToString("dd-MM-yyyy");
            tbFraflytningsdato.Text = lejemål.Fraflytningsdato.ToString("dd-MM-yyyy");
            tbAntalHunde.Text = lejemål.AntalHunde.ToString();
            tbAntalKatte.Text = lejemål.AntalKatte.ToString();


        }

        public bool? ToLejere { get { return rbToLejere.IsChecked; } } 
        public string PrimærLejerNavn { get { return tbPrimærLejerNavn.Text; } }
        public string PrimærLejerMail { get { return tbPrimærLejerMail.Text; } }
        public string PrimærLejerTlfNr { get { return tbPrimærLejerTlfNr.Text; } }
        public string SekundærLejerNavn { get { return tbSekundærLejerNavn.Text; } }
        public string SekundærLejerMail { get { return tbSekundærLejerMail.Text; } }
        public string SekundærLejerTlfNr { get { return tbSekundærLejerTlfNr.Text; } }
        public double IndbetaltDepositum { get { return double.Parse(tbIndbetaltDepositum.Text); } }
        public DateTime Indflytningsdato { get { return DateTime.ParseExact(tbIndflytningsdato.Text, "dd-MM-yyyy", CultureInfo.InvariantCulture); } }
        public DateTime Fraflytningsdato { get { return DateTime.ParseExact(tbFraflytningsdato.Text, "dd-MM-yyyy", CultureInfo.InvariantCulture); } }
        public int AntalHunde { get { return int.Parse(tbAntalHunde.Text); } }
        public int AntalKatte { get { return int.Parse(tbAntalKatte.Text); } }

        private void Fortryd_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }

        private void Gem_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(tbPrimærLejerNavn.Text) ||
                string.IsNullOrEmpty(tbPrimærLejerMail.Text) ||
                string.IsNullOrEmpty(tbPrimærLejerTlfNr.Text) 
                ) 
            { MessageBox.Show("Du skal angive navn, e-mailadresse og tlf. nr. for den primære lejer.", "Hov, der skete en fejl!", MessageBoxButton.OK, MessageBoxImage.Error); return; }
            if (string.IsNullOrEmpty(tbSekundærLejerNavn.Text) && rbToLejere.IsChecked == true ||
                string.IsNullOrEmpty(tbPrimærLejerMail.Text) && rbToLejere.IsChecked == true ||
                string.IsNullOrEmpty(tbPrimærLejerTlfNr.Text) && rbToLejere.IsChecked == true
                )
            { MessageBox.Show("Du skal angive navn, e-mailadresse og tlf. nr. for den sekundære lejer eller vælge en lejer i stedet for to.", "Hov, der skete en fejl!", MessageBoxButton.OK, MessageBoxImage.Error); return; }
            if (!double.TryParse(tbIndbetaltDepositum.Text, out double _)) 
            { MessageBox.Show("Du skal angive et tal i feltet for indbetalt depositum.", "Hov, der skete en fejl!", MessageBoxButton.OK, MessageBoxImage.Error); return; }

            if (!DateTime.TryParseExact(tbIndflytningsdato.Text, "dd-MM-yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out _))
            { MessageBox.Show("Du skal angive en indflytningsdato i formattet DD-MM-YYYY", "Hov, der skete en fejl!", MessageBoxButton.OK, MessageBoxImage.Error); return; }

            if (!DateTime.TryParseExact(tbFraflytningsdato.Text, "dd-MM-yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out _))
            { MessageBox.Show("Du skal angive en fraflytningsdato i formattet DD-MM-YYYY", "Hov, der skete en fejl!", MessageBoxButton.OK, MessageBoxImage.Error); return; }

            if (!int.TryParse(tbAntalHunde.Text, out int _))
            { MessageBox.Show("Du skal angive et tal i feltet for antal hunde.", "Hov, der skete en fejl!", MessageBoxButton.OK, MessageBoxImage.Error); return; }
            if (!int.TryParse(tbAntalKatte.Text, out int _))
            { MessageBox.Show("Du skal angive et tal i feltet for antal katte.", "Hov, der skete en fejl!", MessageBoxButton.OK, MessageBoxImage.Error); return; }

            DialogResult = true;
        }
 
        private void RadioButton_Checked(object sender, RoutedEventArgs e)
        {
            if (rbToLejere.IsChecked == true)
            {
                SekundærLejerTitel.Foreground = new SolidColorBrush(Colors.Black);
                tbSekundærLejerNavn.IsEnabled = true;
                tbSekundærLejerMail.IsEnabled = true;
                tbSekundærLejerTlfNr.IsEnabled = true;
            } else
            {
                SekundærLejerTitel.Foreground = new SolidColorBrush(Colors.Gray);
                tbSekundærLejerNavn.IsEnabled = false;
                tbSekundærLejerMail.IsEnabled = false;
                tbSekundærLejerTlfNr.IsEnabled = false;
            }
        }
    }
    
}
