﻿using System;
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
        }

        private void Fortryd(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }
    }
    
}
