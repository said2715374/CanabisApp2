using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;

namespace CannabisApp
{
    public partial class TableauDeBord : Page
    {
        private string Username;
        public TableauDeBord(string username)
        {
            InitializeComponent();
            Username = username;
            UsernameTextBlock.Text = Username;
           
        }

        private void AjouterPlante_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AjouterPlante());
        }

        private void AccederInventaire_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new PageInventaire());
        }

        private void VoirHistorique_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new HisPlantes());
        }

        private void AjouterUtilisateur_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AjouterUtilisateur());
        }

        private void Deconnecter_Click(object sender, RoutedEventArgs e)
        {
            // Redirigez vers la page de connexion
            NavigationService.Navigate(new Page1());
        }
    }
}
