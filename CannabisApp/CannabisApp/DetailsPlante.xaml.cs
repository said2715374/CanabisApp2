using QRCoder;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using static CannabisApp.MainWindow;

namespace CannabisApp
{
    public partial class DetailsPlante : Page
    {
        private readonly PlantRepository _plantRepository;
        private readonly int _planteId;

        public DetailsPlante(int planteId)
        {
            InitializeComponent();
            _plantRepository = new PlantRepository(new AppDbContext());
            _planteId = planteId;
            ChargerDetailsPlante(planteId);
        }

        private void ChargerDetailsPlante(int planteId)
        {
            var plante = _plantRepository.GetPlanteById(planteId);
            if (plante != null)
            {
                NomPlante.Text = plante.nom;
                DescriptionPlante.Text = $"Description: {plante.nom}";
                ProvenancePlante.Text = $"Provenance: {plante.id_provenance}";
                StadePlante.Text = $"Stade: {plante.emplacement}";
                DateAjoutPlante.Text = $"Date d'Ajout: {plante.cree_le:yyyy-MM-dd}";
                EtatSantePlante.Text = $"État de Santé: {plante.etat_sante}";
                DerniereMiseAJourPlante.Text = $"Dernière mise à jour: {plante.date_expiration:yyyy-MM-dd}";
                EmplacementPlante.Text = $"Emplacement: {plante.code_qr}";
                QuantiteDisponiblePlante.Text = $"Quantité Disponible (kg): {plante.nombre_plantes_actives}";
                DateExpirationPlante.Text = $"Date d'Expiration: {plante.date_expiration:yyyy-MM-dd}";
                GenererQRCode(plante.code_qr);
            }
        }

        private void GenererQRCode(string code)
        {
            QRCodeGenerator qrGenerator = new QRCodeGenerator();
            QRCodeData qrCodeData = qrGenerator.CreateQrCode(code, QRCodeGenerator.ECCLevel.Q);
            QRCode qrCode = new QRCode(qrCodeData);
            Bitmap qrCodeImage = qrCode.GetGraphic(20);

            using (MemoryStream ms = new MemoryStream())
            {
                qrCodeImage.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                ms.Position = 0;
                BitmapImage bitmapImage = new BitmapImage();
                bitmapImage.BeginInit();
                bitmapImage.StreamSource = ms;
                bitmapImage.CacheOption = BitmapCacheOption.OnLoad;
                bitmapImage.EndInit();

                QRCodeImage.Source = bitmapImage;
            }
        }

        private void Modifier_Click(object sender, RoutedEventArgs e)
        {
            // Navigation vers la page de modification
        }

        private void Retirer_Click(object sender, RoutedEventArgs e)
        {
            // Logique de suppression de la plante
        }

        private void AjouterAutre_Click(object sender, RoutedEventArgs e)
        {
            // Navigation vers la page d'ajout de plante
        }

        private void ProduitSuivant_Click(object sender, RoutedEventArgs e)
        {
            // Navigation vers la page de produit suivant
        }
    }
}

