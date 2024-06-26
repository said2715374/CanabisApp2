using System;
using System.Windows;
using System.Windows.Controls;
using QRCoder;
using System.Drawing;
using System.IO;
using System.Windows.Media.Imaging;
using System.Numerics;

namespace CannabisApp
{
    public partial class DetailsPlante : Page
    {
        private plantes _plante;

        public DetailsPlante()
        {
            plantes plante = new plantes();
            InitializeComponent();
            _plante = plante;
            LoadPlanteDetails();
        }

        private void LoadPlanteDetails()
        {
            NomPlante.Text = _plante.nom;
            EmplacementText.Text = _plante.emplacement;
            IdProvenanceText.Text = _plante.id_provenance.ToString();
            EtatSanteText.Text = _plante.etat_sante.ToString();
            NombrePlantesActivesText.Text = _plante.nombre_plantes_actives.ToString();
            CreeLeText.Text = _plante.cree_le.ToString("d");
            DateExpirationText.Text = _plante.date_expiration.ToString("d");
            StadeText.Text = _plante.stade;
            IdentificationText.Text = _plante.identification;

            // QRCodeImage.Source = GenererQRCode(_plante.code_qr);
        }

        /*private BitmapImage GenererQRCode(string text)
        {
            QRCodeGenerator qrGenerator = new QRCodeGenerator();
            QRCodeData qrCodeData = qrGenerator.CreateQrCode(text, QRCodeGenerator.ECCLevel.Q);
            QRCode qrCode = new QRCode(qrCodeData);
            Bitmap qrCodeImage = qrCode.GetGraphic(20);

            using (MemoryStream memory = new MemoryStream())
            {
                qrCodeImage.Save(memory, System.Drawing.Imaging.ImageFormat.Png);
                memory.Position = 0;
                BitmapImage bitmapImage = new BitmapImage();
                bitmapImage.BeginInit();
                bitmapImage.StreamSource = memory;
                bitmapImage.CacheOption = BitmapCacheOption.OnLoad;
                bitmapImage.EndInit();
                return bitmapImage;
            }
        }*/

        private void Modifier_Click(object sender, RoutedEventArgs e)
        {
            ModifierPlante modifierPage = new ModifierPlante(_plante.id_plante);
            this.NavigationService.Navigate(modifierPage);
        }        
        

        private void Retirer_Click(object sender, RoutedEventArgs e)
        {
            // Code pour retirer le produit
        }

        private void VoirHistorique_Click(object sender, RoutedEventArgs e)
        {
            HistoriquePlantePage historiquePage = new HistoriquePlantePage(_plante.id_plante);
            this.NavigationService.Navigate(historiquePage);
        }
        private void Suivant_Click(object sender, RoutedEventArgs e)
        {
            // Code pour passer au produit suivant
        }
    }
}
