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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WimeaApplication
{
    /// <summary>
    /// Interaction logic for ArchivePage.xaml
    /// </summary>
    public partial class ArchivePage : Page
    {
        public ArchivePage()
        {
            InitializeComponent();
        }

        private void dataGridEvaluation_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
        private void deleteClick(object sender, RoutedEventArgs e)
        {
            //System.Diagnostics.Debug.WriteLine("" + (dataGridEvaluation.SelectedItem as Application).Id);
            //  (dataGridEvaluation.SelectedItem as Application).DeleteApplication();
            // _applicationed.Applicationed.Remove((dataGridEvaluation.SelectedItem as Application));
            //  dataGridEvaluation.ItemsSource = null;
            //dataGridEvaluation.ItemsSource = _applicationed.Applicationed;


        }
    }
}
