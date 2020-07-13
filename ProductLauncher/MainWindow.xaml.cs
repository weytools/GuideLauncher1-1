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
using System.Windows.Navigation;
using System.Windows.Shapes;

using ProductLauncher.VM;

namespace ProductLauncher
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public GuideScreen viewModel = new GuideScreen();

        public MainWindow()
        {
            InitializeComponent();
            DataContext = viewModel;
            //RecentlySearchedList.ItemsSource = viewModel.ProductList;
        }

        private void ActivateSearch(object sender, RoutedEventArgs e)
        {
            viewModel.ActivateGradeSearch();
        }

        private void OpenMockup(object sender, RoutedEventArgs e)
        {
            Mockup mockupWin = new Mockup();
            mockupWin.Show();
        }

        private void LaunchGuide(object sender, RoutedEventArgs e)
        {
            string guidePath;

            // primary or secondary guide?
            string requestingButton = ((System.Windows.FrameworkElement)e.Source).Name;

            // get the guide path
            if (requestingButton == "PrimaryGuide")
                guidePath = ((ProductLauncher.Data.Product)((System.Windows.FrameworkElement)e.Source).DataContext).ProductGuide;
            else
                guidePath = ((ProductLauncher.Data.Product)((System.Windows.FrameworkElement)e.Source).DataContext).SecondGuide;

            // LAUNCH IT
            System.Diagnostics.Process.Start(guidePath);


        }

        private void GradeTextKeyDownHandler(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)    
                ActivateSearch(sender, e);
        }

        private void ClearProductList(object sender, RoutedEventArgs e)
        {
            viewModel.ClearProductList();
        }
    }
}
