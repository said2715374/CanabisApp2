using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace CannabisApp
{
    public partial class HisPlantes : Page
    {
        private readonly AppDbContext _context;

        public HisPlantes()
        {
            InitializeComponent();
            _context = new AppDbContext();
            LoadHistorique();
        }

        private void LoadHistorique()
        {
            var historique = _context.HistoriquePlantes.ToList();
            HistoriqueDataGrid.ItemsSource = historique;
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
