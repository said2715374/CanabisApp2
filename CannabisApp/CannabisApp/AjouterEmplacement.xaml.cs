using System.Windows;
using System.Windows.Controls;

namespace CannabisApp
{
    public partial class AjouterEmplacement : Page
    {
        private readonly AppDbContext _context;

        public AjouterEmplacement()
        {
            InitializeComponent();
            _context = new AppDbContext();

            // Gérer le texte de l'espace réservé
            NomEmplacement.GotFocus += RemovePlaceholderText;
            NomEmplacement.LostFocus += ShowPlaceholderText;
        }

        private void RemovePlaceholderText(object sender, RoutedEventArgs e)
        {
            PlaceholderTextBlock.Visibility = Visibility.Collapsed;
        }

        private void ShowPlaceholderText(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(NomEmplacement.Text))
            {
                PlaceholderTextBlock.Visibility = Visibility.Visible;
            }
        }

        private void Ajouter_Click(object sender, RoutedEventArgs e)
        {
            var nomEmplacement = NomEmplacement.Text;

            if (string.IsNullOrEmpty(nomEmplacement))
            {
                MessageBox.Show("Veuillez entrer un nom pour l'emplacement.");
                return;
            }

            var nouvellePlante = new Plantes
            {
                Emplacement = nomEmplacement
            };

            _context.Plantes.Add(nouvellePlante);
            _context.SaveChanges();

            MessageBox.Show("Nouvel emplacement ajouté avec succès !");

            // Retour à la page précédente après l'ajout
            NavigationService.GoBack();
        }
    }
}
