using Microsoft.VisualBasic.ApplicationServices;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace CannabisApp
{
    public partial class GererUser : Page
    {
        public GererUser()
        {
            InitializeComponent();
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            // Code pour retourner à la page précédente
        }

        private void Home_Click(object sender, RoutedEventArgs e)
        {
            // Code pour aller à la page d'accueil
        }

        private void AjouterUtilisateur_Click(object sender, RoutedEventArgs e)
        {
            // Code pour aller à la page AjouterUtilisateur
            NavigationService.Navigate(new AjouterUtilisateur());
        }

        private void UsersListView_MouseDoubleClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            // Code pour naviguer vers la page DetailsUser avec l'utilisateur sélectionné
            var selectedUser = (User)UsersListView.SelectedItem;
            if (selectedUser != null)
            {
                NavigationService.Navigate(new DetailsUser(selectedUser));
            }
        }

        private void SearchTextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            // Code pour gérer le focus de la boîte de recherche
            if (SearchTextBox.Text == "Rechercher un utilisateur")
            {
                SearchTextBox.Text = "";
                SearchTextBox.Foreground = new SolidColorBrush(Colors.Black);
            }
        }

        private void SearchTextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            // Code pour gérer la perte de focus de la boîte de recherche
            if (string.IsNullOrWhiteSpace(SearchTextBox.Text))
            {
                SearchTextBox.Text = "Rechercher un utilisateur";
                SearchTextBox.Foreground = new SolidColorBrush(Colors.White);
            }
        }

        private void SearchTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            // Code pour filtrer les utilisateurs dans la liste en fonction de la recherche
        }
    }
}
