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
            string username = nomDutilisateur.Text;
            string password = motDePasse.Password;

            if (username == "admin" && password == "password") // Remplacer par une vraie vérification
            {
                MessageBox.Show("Connexion réussie !");
                // Naviguer vers la page principale après la connexion
                var mainWindow = Window.GetWindow(this) as MainWindow;
                if (mainWindow != null)
                {
                    mainWindow.MainFrame.Navigate(new Page2());
                }
            }
            else
            {
                MessageBox.Show("Nom d'utilisateur ou mot de passe incorrect.");
            }
        }

        private void Quitter_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}
