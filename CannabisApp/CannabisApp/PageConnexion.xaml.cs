using System;
using System.Windows;
using System.Windows.Controls;

namespace CannabisApp
{
    public partial class Page1 : Page
    {
        public Page1()
        {
            InitializeComponent();
        }

        private void Connexion_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var mainWindow = Window.GetWindow(this) as MainWindow;

                if (mainWindow != null)
                {

                    mainWindow.MainFrame.Navigate(new TableauDeBord());


                    mainWindow.MainFrame.Navigate(new AjouterPlante());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}");
            }
        }

        private void Quitter_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}
