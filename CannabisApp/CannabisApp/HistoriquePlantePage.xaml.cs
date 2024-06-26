using System.Linq;
using System.Windows.Controls;

namespace CannabisApp
{
    public partial class HistoriquePlantePage : Page
    {
        private readonly AppDbContext _context;

        public HistoriquePlantePage(int planteId)
        {
            InitializeComponent();
            _context = new AppDbContext();
            LoadHistorique(planteId);
        }

        private void LoadHistorique(int planteId)
        {
            var historique = _context.HistoriquePlantes
                .Where(h => h.IdPlante == planteId)
                .ToList();
            HistoriqueDataGrid.ItemsSource = historique;
        }
    }
}
