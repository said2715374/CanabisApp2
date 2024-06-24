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
            var provenances = _context.provenances.ToList();
            ProvenanceComboBox.ItemsSource = provenances;
        }

        private void Ajouter_Click(object sender, RoutedEventArgs e)
        {
            var description = Description.Text;
            var stade = Stade.Text;
            var selectedProvenance = (provenances)ProvenanceComboBox.SelectedItem;
            var quantite = int.Parse(Quantite.Text);
            var dateExpiration = DateTime.Parse(DateExpiration.Text);
            var emplacement = Emplacement.Text;

            if (selectedProvenance == null)
            {
                MessageBox.Show("Veuillez sélectionner une provenance.");
                return;
            }

            // Génération du code QR
            var codeQr = GenererCodeQR(description, selectedProvenance.ville);

            var nouvellePlante = new plantes
            {
                nom = description,
                emplacement = emplacement,
                code_qr = codeQr,
                etat_sante = 1, // Exemple de valeur par défaut
                nombre_plantes_actives = quantite,
                date_expiration = dateExpiration,
                cree_le = DateTime.Now,
                id_provenance = selectedProvenance.id_provenance
            };

            _context.plantes.Add(nouvellePlante);
            _context.SaveChanges();
            MessageBox.Show("Nouvelle plante ajoutée avec succès !");
        }

        private string GenererCodeQR(string nom, string emplacement)
        {
            using (var qrGenerator = new QRCodeGenerator())
            {
                var qrCodeData = qrGenerator.CreateQrCode($"{nom} - {emplacement}", QRCodeGenerator.ECCLevel.Q);
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
