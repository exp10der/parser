using System;
using System.Collections.Generic;
using System.Windows;

namespace Pars
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        private readonly ErrorMessage _errorMessage = new ErrorMessage();
        public MainWindow()
        {

            InitializeComponent();
            ErrorMessage.DataContext = _errorMessage;


        }

        static List<Price> plList;
        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            var testing = new BaseEngine();
            try
            {
                _errorMessage.Message = "Выполняется опрос сайтов, пожалуйста ждите";
                var result = await testing.RunAsync();
                if (result.Item2 != null) throw result.Item2;
                plList = result.Item1;
                _errorMessage.Message = "Сбор информации успешно завершен";
            }
            catch (Exception exception)
            {
                _errorMessage.Message = exception.Message;
            }

            gridProducts.ItemsSource = plList;

        }
        public static List<Price> GG()
        {
            var gg = plList;
            return gg;
        }

        private void Button_Exit(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();

        }

        private void Click_toExel(object sender, RoutedEventArgs e)
        {
            if (plList == null)
            {
                MessageBox.Show("Сначало, спарсите страницы.");
            }
            else
            {

                PrintExel.ExportToExcel(plList);
            }
        }
        private void Click_toXML(object sender, RoutedEventArgs e)
        {
            //if (plList == null)
            //{
            //    MessageBox.Show("Сначало, спарсите страницы.");
            //}
            //else
            //{
            //    var ff = new mail();
            //    ff.send();
            //}
            MessageBox.Show("Недоступно в бета версии");

        }

    }
}



