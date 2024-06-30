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
            LoadProvenances();
            LoadEmplacements();
        }

        private void ChargerPlante(int planteId)
        {
            var plante = _context.Plantes.Find(planteId);
            if (plante != null)
            {
                Description.Text = plante.Nom;
                StadeComboBox.SelectedItem = StadeComboBox.Items.OfType<ComboBoxItem>().FirstOrDefault(item => item.Content.ToString() == plante.Stade);
                Identification.Text = plante.Identification;
                ProvenanceComboBox.SelectedValue = plante.IdProvenance;
                Quantite.Text = plante.NombrePlantesActives.ToString();
                DateExpiration.Text = plante.DateExpiration.ToString("yyyy-MM-dd");
                EtatSanteComboBox.SelectedItem = EtatSanteComboBox.Items.OfType<ComboBoxItem>().FirstOrDefault(item => item.Content.ToString() == plante.EtatSante.ToString());
                EmplacementComboBox.SelectedItem = plante.Emplacement;
                NoteTextBox.Text = plante.Note;
            }
        }

        private void LoadProvenances()
        {
            var provenances = _context.Provenances.ToList();
            ProvenanceComboBox.ItemsSource = provenances;
        }

        private void LoadEmplacements()
        {
            var emplacements = _context.Plantes.Select(p => p.Emplacement).Distinct().ToList();
            EmplacementComboBox.ItemsSource = emplacements;
        }

        private void Modifier_Click(object sender, RoutedEventArgs e)
        {
            var plante = _context.Plantes.Find(_planteId);
            if (plante != null)
            {
                plante.Nom = Description.Text;
                plante.Stade = (StadeComboBox.SelectedItem as ComboBoxItem)?.Content.ToString();
                plante.Identification = Identification.Text;
                plante.IdProvenance = (int)ProvenanceComboBox.SelectedValue;
                plante.NombrePlantesActives = int.Parse(Quantite.Text);
                plante.DateExpiration = DateTime.Parse(DateExpiration.Text);
                plante.EtatSante = int.Parse((EtatSanteComboBox.SelectedItem as ComboBoxItem)?.Content.ToString());
                plante.Emplacement = EmplacementComboBox.SelectedItem.ToString();
                plante.Note = NoteTextBox.Text;

                _context.SaveChanges();
                MessageBox.Show("Plante modifiée avec succès !");
            }
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }

        private void Home_Click(object sender, RoutedEventArgs e)
        {
            //NavigationService.Navigate(new TableauDebordUser());
        }

        private void AjouterEmplacement_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AjouterEmplacement());
        }
    }
}
