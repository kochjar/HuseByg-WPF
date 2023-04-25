using HuseByg.model;
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
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

using System.Xaml.Permissions;

namespace HuseByg_WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
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

            


            ExpanderController.AddExpander(spList, lejemål1, hus1);

            ExpanderController.AddExpander(spList, lejemål2, hus2);
            ExpanderController.AddExpander(spList, null, hus3);

        }


    }
}
