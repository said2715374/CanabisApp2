using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace CannabisApp
{
    public partial class TableauDeBord : Page
    {
        private readonly AppDbContext _context;

        public TableauDeBord()
        {
            InitializeComponent();
            _context = new AppDbContext();
            LoadDashboardData();
        }

        private void LoadDashboardData()
        {
            int totalPlantes = _context.Plantes.Count();
            int plantesEnMauvaiseSante = _context.Plantes.Count(p => p.EtatSante == 1 || p.EtatSante == 2); // Exemple de conditions pour "mauvaise santé"

            // Mettre à jour les TextBlocks
            NombreTotalPlantesTextBlock.Text = totalPlantes.ToString();
            PlantesMauvaiseSanteTextBlock.Text = plantesEnMauvaiseSante.ToString();

            // Calculer et mettre à jour le graphique de remplissage
            double percentage = (totalPlantes / 500.0) * 100;
            PercentageText.Text = $"{percentage:F2}%";
            TotalPlantesText.Text = $"{totalPlantes}/500";

            UpdateGraph(percentage);
        }

        private void UpdateGraph(double percentage)
        {
            double angle = percentage * 360 / 100;
            double radians = angle * Math.PI / 180;

            double x = 100 + 100 * Math.Cos(radians);
            double y = 100 - 100 * Math.Sin(radians);

            bool isLargeArc = percentage > 50;

            string pathData = $"M 100,0 A 100,100 0 {(isLargeArc ? 1 : 0)},1 {x},{y} L 100,100 Z";

            ProgressPath.Data = Geometry.Parse(pathData);
        }

        private void AjouterPlante_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AjouterPlante());
        }

        private void AccederInventaire_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new PageInventaire());
        }

        private void VoirHistorique_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new HisPlantes());
        }

        private void GererUser_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new GererUser());
        }

        private void Deconnecter_Click(object sender, RoutedEventArgs e)
        {
            // Code de déconnexion ici
        }
    }
}
