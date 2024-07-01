using System.Collections.ObjectModel;
using System.Data.SqlClient;
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
            string connectionString = "Server=LAPTOP-K1T841TP\\SQLEXPRESS;Database=NomDeLaBaseDeDonnées;Trusted_Connection=True;";

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "SELECT id_historique, id_plante, action, timestamp, id_utilisateur FROM historique_plantes";
                    SqlCommand command = new SqlCommand(query, connection);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        ObservableCollection<Historique_Plantes> historiquePlantesList = new ObservableCollection<Historique_Plantes>();
                        while (reader.Read())
                        {
                            Historique_Plantes historiquePlante = new Historique_Plantes
                            {
                                IdHistorique = reader.GetInt32(reader.GetOrdinal("id_historique")),
                                IdPlante = reader.GetInt32(reader.GetOrdinal("id_plante")),
                                Action = reader.GetString(reader.GetOrdinal("action")),
                                Timestamp = reader.GetDateTime(reader.GetOrdinal("timestamp")),
                                IdUtilisateur = reader.GetInt32(reader.GetOrdinal("id_utilisateur"))
                            };
                            historiquePlantesList.Add(historiquePlante);
                        }

                        
                        HistoriqueDataGrid.ItemsSource = historiquePlantesList;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur lors du chargement de l'historique des plantes : " + ex.Message);
            }

            
        }
        private void Back_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }

        private void Home_Click(object sender, RoutedEventArgs e)
        {
           // NavigationService.Navigate(new TableauDebordUser());
        }

        private void HistoriqueDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
