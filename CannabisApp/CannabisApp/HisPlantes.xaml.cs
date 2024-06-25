using System.Linq;
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
    }
}
