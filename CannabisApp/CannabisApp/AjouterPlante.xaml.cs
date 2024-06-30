using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using QRCoder;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;

namespace CannabisApp
{
    public partial class AjouterPlante : Page
    {
        private readonly AppDbContext _context;

        public AjouterPlante()
        {
            InitializeComponent();
            _context = new AppDbContext();
            LoadProvenances();
            LoadEmplacements();
        }

        private void LoadProvenances()
        {
            var provenances = _context.Provenances
                                  .Select(p => new
                                  {
                                      p.IdProvenance,
                                      p.Ville,
                                      p.Province,
                                      p.Pays
                                  })
                                  .ToList();
            ProvenanceComboBox.ItemsSource = provenances;
            ProvenanceComboBox.DisplayMemberPath = "Ville";
            ProvenanceComboBox.SelectedValuePath = "IdProvenance";
        }

        private void LoadEmplacements()
        {
            var emplacements = _context.Plantes
                                   .Select(e => e.Emplacement)
                                   .Distinct()
                                   .ToList();
            EmplacementComboBox.ItemsSource = emplacements;
        }

        private void Ajouter_Click(object sender, RoutedEventArgs e)
        {
            var description = Description.Text;
            var stade = ((ComboBoxItem)StadeComboBox.SelectedItem)?.Content.ToString() ?? string.Empty;
            var identification = Identification.Text;
            var selectedProvenance = (int?)ProvenanceComboBox.SelectedValue;
            var quantite = int.Parse(Quantite.Text);
            var dateExpiration = DateTime.Parse(DateExpiration.Text);
            var etatSante = ((ComboBoxItem)EtatSanteComboBox.SelectedItem)?.Content.ToString() ?? string.Empty;
            var emplacement = EmplacementComboBox.SelectedItem?.ToString();
            var note = NoteTextBox.Text;

            if (selectedProvenance == null || emplacement == null)
            {
                MessageBox.Show("Veuillez sélectionner une provenance et un emplacement.");
                return;
            }

            var nouvellePlante = new Plantes
            {
                Nom = description,
                Emplacement = emplacement,
                EtatSante = 1, // Exemple de valeur par défaut
                NombrePlantesActives = quantite,
                DateExpiration = dateExpiration,
                CreeLe = DateTime.Now,
                IdProvenance = selectedProvenance.Value,
                Stade = stade,
                Identification = identification,
                Note = note
            };

            _context.Plantes.Add(nouvellePlante);
            _context.SaveChanges();

            var codeQr = GenererCodeQR(nouvellePlante.IdPlante, description, emplacement);
            nouvellePlante.CodeQr = codeQr;
            _context.SaveChanges();

            MessageBox.Show("Nouvelle plante ajoutée avec succès !");
        }

        private string GenererCodeQR(int planteId, string nom, string emplacement)
        {
            using (var qrGenerator = new QRCodeGenerator())
            {
                var qrCodeData = qrGenerator.CreateQrCode($"{planteId} - {nom} - {emplacement}", QRCodeGenerator.ECCLevel.Q);
                using (var qrCode = new QRCode(qrCodeData))
                {
                    using (var qrCodeImage = qrCode.GetGraphic(20))
                    {
                        return ConvertImageToBase64(qrCodeImage);
                    }
                }
            }
        }

        private string ConvertImageToBase64(Bitmap image)
        {
            using (var ms = new MemoryStream())
            {
                image.Save(ms, ImageFormat.Png);
                return Convert.ToBase64String(ms.ToArray());
            }
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }

        private void Home_Click(object sender, RoutedEventArgs e)
        {
            // NavigationService.Navigate(new TableauDebordUser());
        }

        private void AjouterEmplacement_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AjouterEmplacement());
        }
    }
}
