using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using System.IO;
using System.Windows.Media.Imaging;
using Microsoft.EntityFrameworkCore;

namespace CannabisApp
{
    public partial class DetailsPlante : Page
    {
        private readonly AppDbContext _context;
        private readonly int _planteId;

        public DetailsPlante(int planteId)
        {
            InitializeComponent();
            _context = new AppDbContext();
            _planteId = planteId;
            LoadPlanteDetails(planteId);
        }

        private void LoadPlanteDetails(int planteId)
        {
            var plante = _context.Plantes.Include(p => p.Provenance).FirstOrDefault(p => p.IdPlante == planteId);
            if (plante != null)
            {
                NomPlante.Text = plante.Nom;
                EmplacementText.Text = plante.Emplacement;
                IdProvenanceText.Text = $"{plante.Provenance.Ville}, {plante.Provenance.Province}";
                EtatSanteText.Text = plante.EtatSante.ToString();
                NombrePlantesActivesText.Text = plante.NombrePlantesActives.ToString();
                CreeLeText.Text = plante.CreeLe.ToString("dd/MM/yyyy");
                DateExpirationText.Text = plante.DateExpiration.ToString("dd/MM/yyyy");
                StadeText.Text = plante.Stade;
                IdentificationText.Text = plante.Identification;

                // Afficher le code QR
                if (!string.IsNullOrEmpty(plante.CodeQr))
                {
                    var qrCodeImage = new BitmapImage();
                    qrCodeImage.BeginInit();
                    qrCodeImage.StreamSource = new MemoryStream(Convert.FromBase64String(plante.CodeQr));
                    qrCodeImage.EndInit();
                    QRCodeImage.Source = qrCodeImage;
                }
            }
        }

        private void Modifier_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new ModifierPlante(_planteId));
        }

        private void Retirer_Click(object sender, RoutedEventArgs e)
        {
            var plante = _context.Plantes.FirstOrDefault(p => p.IdPlante == _planteId);
            if (plante != null)
            {
                _context.Plantes.Remove(plante);
                _context.SaveChanges();
                MessageBox.Show("Plante retirée avec succès.");
                NavigationService.GoBack();
            }
            else
            {
                MessageBox.Show("Plante non trouvée.");
            }
        }

        private void AjouterAutre_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AjouterPlante());
        }

        private void VoirHistorique_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new HistoriquePlantePage(_planteId));
        }
        private void Back_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }

        private void Home_Click(object sender, RoutedEventArgs e)
        {
            //NavigationService.Navigate(new TableauDebordUser());
        }
    }
}
