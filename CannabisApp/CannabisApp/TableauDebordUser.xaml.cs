using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace CannabisApp
{
    public partial class TableauDebordUser : Page
    {
        private readonly AppDbContext _context;

        public TableauDebordUser()
        {
            InitializeComponent();
            _context = new AppDbContext();
            LoadDashboardData();
        }

        private void LoadDashboardData()
        {
            int totalPlantes = _context.Plantes.Count();
            int plantesEnBonneSante = _context.Plantes.Count(p => p.EtatSante == 5); // Exemple de condition pour "bonne santé"
            int plantesNecessitantAttention = _context.Plantes.Count(p => p.EtatSante < 3); // Exemple de condition pour "nécessitant attention"

            // Mettre à jour les TextBlocks
            NombreTotalPlantesTextBlock.Text = totalPlantes.ToString();
           
            PlantesNecessitantAttentionTextBlock.Text = plantesNecessitantAttention.ToString();

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

            double centerX = 100;
            double centerY = 100;
            double radius = 100 - 10; // Subtract stroke thickness

            double endX = centerX + radius * Math.Cos(radians);
            double endY = centerY + radius * Math.Sin(radians);

            PathFigure pathFigure = new PathFigure
            {
                StartPoint = new Point(centerX, centerY - radius)
            };

            ArcSegment arcSegment = new ArcSegment
            {
                Point = new Point(endX, endY),
                Size = new Size(radius, radius),
                IsLargeArc = angle >= 180,
                SweepDirection = SweepDirection.Clockwise
            };

            pathFigure.Segments.Add(arcSegment);

            PathGeometry pathGeometry = new PathGeometry();
            pathGeometry.Figures.Add(pathFigure);

            ProgressPath.Data = pathGeometry;
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
