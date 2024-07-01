using System.Collections.ObjectModel;
using System.Windows;
using System.Data.SqlClient;
using System.Windows.Controls;

namespace CannabisApp
{
    public partial class DetailsUser : Page
    {
        private readonly AppDbContext _context;
        public DetailsUser(utilisateur selectedUser)
        {
            InitializeComponent();
            _context = new AppDbContext();
            
            // Set the details of the selected user
            NomUtilisateurText.Text = selectedUser.nom_utilisateur;
            RoleText.Text = selectedUser.id_role.ToString();
        }
        
        private void Back_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }

        private void Home_Click(object sender, RoutedEventArgs e)
        {
            //NavigationService.Navigate(new TableauDebordUser());
        }

        private void Modifier_Click(object sender, RoutedEventArgs e)
        {
            // Code pour modifier l'utilisateur
        }

        private void Retirer_Click(object sender, RoutedEventArgs e)
        {
            // Code pour retirer l'utilisateur
        }

        private void AjouterAutre_Click(object sender, RoutedEventArgs e)
        {
            // Code pour ajouter un autre utilisateur
        }

        private void VoirHistorique_Click(object sender, RoutedEventArgs e)
        {
            // Code pour voir l'historique
        }
    }
}
