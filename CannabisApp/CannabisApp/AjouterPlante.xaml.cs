﻿using System;
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
        }

        private void LoadProvenances()
        {
            var provenances = _context.Provenances.ToList();
            ProvenanceComboBox.ItemsSource = provenances;
        }

        private void Ajouter_Click(object sender, RoutedEventArgs e)
        {
            var description = Description.Text;
            var stade = Stade.Text;
            var identification = Identification.Text;
            var selectedProvenance = (Provenances)ProvenanceComboBox.SelectedItem;
            var quantite = int.Parse(Quantite.Text);
            var dateExpiration = DateTime.Parse(DateExpiration.Text);
            var emplacement = Emplacement.Text;

            if (selectedProvenance == null)
            {
                MessageBox.Show("Veuillez sélectionner une provenance.");
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
                IdProvenance = selectedProvenance.IdProvenance,
                Stade = stade,
                Identification = identification
            };

            // Génération du code QR après avoir ajouté la plante pour obtenir son Id
            _context.Plantes.Add(nouvellePlante);
            _context.SaveChanges();

            var codeQr = GenererCodeQR(nouvellePlante.IdPlante, description, selectedProvenance.Ville);
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
    }
}
