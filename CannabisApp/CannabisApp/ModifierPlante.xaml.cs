using System;
using System.Windows;
using System.Windows.Controls;

namespace CannabisApp
{
    public partial class ModifierPlante : Page
    {
        private readonly AppDbContext _context;
        private readonly int _planteId;

        public ModifierPlante(int planteId)
        {
            InitializeComponent();
            _context = new AppDbContext();
            _planteId = planteId;
            ChargerPlante(planteId);
        }

        private void ChargerPlante(int planteId)
        {
            var plante = _context.Plantes.Find(planteId);
            if (plante != null)
            {
                Description.Text = plante.Nom;
                Stade.Text = plante.Stade;
                Identification.Text = plante.Identification;
                ProvenanceComboBox.SelectedValue = plante.IdProvenance;
                Quantite.Text = plante.NombrePlantesActives.ToString();
                DateExpiration.Text = plante.DateExpiration.ToString("yyyy-MM-dd");
                Emplacement.Text = plante.Emplacement;
            }
        }

        private void Modifier_Click(object sender, RoutedEventArgs e)
        {
            var plante = _context.Plantes.Find(_planteId);
            if (plante != null)
            {
                plante.Nom = Description.Text;
                plante.Stade = Stade.Text;
                plante.Identification = Identification.Text;
                plante.IdProvenance = (int)ProvenanceComboBox.SelectedValue;
                plante.NombrePlantesActives = int.Parse(Quantite.Text);
                plante.DateExpiration = DateTime.Parse(DateExpiration.Text);
                plante.Emplacement = Emplacement.Text;

                _context.SaveChanges();
                MessageBox.Show("Plante modifiée avec succès !");
                // Naviguer vers la page précédente ou une autre page après la modification
            }
        }
        private void Back_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }

        private void Home_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new TableauDebordUser());
        }

    }
}
