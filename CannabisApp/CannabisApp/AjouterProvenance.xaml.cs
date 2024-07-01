using System;
using System.Windows;
using System.Windows.Controls;

namespace CannabisApp
{
    public partial class AjouterProvenance : Page
    {
        private readonly AppDbContext _context;

        public AjouterProvenance()
        {
            InitializeComponent();
            _context = new AppDbContext();
        }

        private void Ajouter_Click(object sender, RoutedEventArgs e)
        {
            var ville = VilleTextBox.Text;
            var province = ProvinceTextBox.Text;
            var pays = PaysTextBox.Text;

            if (string.IsNullOrEmpty(ville) || string.IsNullOrEmpty(province) || string.IsNullOrEmpty(pays))
            {
                MessageBox.Show("Veuillez remplir tous les champs.");
                return;
            }

            var nouvelleProvenance = new Provenances
            {
                Ville = ville,
                Province = province,
                Pays = pays
            };

            _context.Provenances.Add(nouvelleProvenance);
            _context.SaveChanges();

            MessageBox.Show("Nouvelle provenance ajoutée avec succès !");
            NavigationService.GoBack();
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }

        private void Home_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new TableauDeBord());
        }
    }
}
