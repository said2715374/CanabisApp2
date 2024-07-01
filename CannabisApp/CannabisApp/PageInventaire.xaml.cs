using System.Collections.Generic;
using System.Data.SqlClient;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using Microsoft.EntityFrameworkCore;

namespace CannabisApp
{
    public partial class PageInventaire : Page
    {
        private readonly AppDbContext _context;
        private List<Plantes> _allPlantes;
        private int _currentPage = 1;
        private const int PageSize = 4;

        public PageInventaire()
        {
            InitializeComponent();
            _context = new AppDbContext();
            LoadPlantes();
            UpdatePageNumber();
        }

        private void LoadPlantes()
        {
            string connectionString = "Server=LAPTOP-K1T841TP\\SQLEXPRESS;Database=NomDeLaBaseDeDonnées;Trusted_Connection=True;";

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "SELECT * FROM plantes";
                    SqlCommand command = new SqlCommand(query, connection);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        ObservableCollection<plantes> Plantes = new ObservableCollection<plantes>();
                        while (reader.Read())
                        {
                            plantes plante = new plantes
                            {
                                id_plante = reader.GetInt32(reader.GetOrdinal("id_plante")),
                                nom = reader.GetString(reader.GetOrdinal("nom")),
                                emplacement = reader.GetString(reader.GetOrdinal("emplacement")),
                                code_qr = reader.GetString(reader.GetOrdinal("code_qr")),
                                id_provenance = reader.GetInt32(reader.GetOrdinal("id_provenance")),
                                etat_sante = reader.GetInt32(reader.GetOrdinal("etat_sante")),
                                nombre_plantes_actives = reader.GetInt32(reader.GetOrdinal("nombre_plantes_actives")),
                                date_expiration = reader.GetDateTime(reader.GetOrdinal("date_expiration")),
                                cree_le = reader.GetDateTime(reader.GetOrdinal("cree_le")),
                             
                            };
                            Plantes.Add(plante);
                        }

                       
                        PlantesListView.ItemsSource = Plantes;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur lors du chargement des plantes : " + ex.Message);
            }
        }

        private void DisplayPage()
        {
            var plantesToShow = _allPlantes.Skip((_currentPage - 1) * PageSize).Take(PageSize).ToList();
            PlantesListView.ItemsSource = plantesToShow.Select(p => new
            {
                p.IdPlante,
                p.Nom,
                ProvenanceInfo = $"{p.Provenance.Ville}, {p.Provenance.Province}",
                p.Stade,
                QRCodeImage = p.CodeQr // Assurez-vous que cela convertit l'image correctement
            });
            UpdatePageNumber();
        }

        private void UpdatePageNumber()
        {
            
        }

        private void PagePrecedente_Click(object sender, RoutedEventArgs e)
        {
            if (_currentPage > 1)
            {
                _currentPage--;
                DisplayPage();
            }
        }

        private void PageSuivante_Click(object sender, RoutedEventArgs e)
        {
            if (_currentPage < (_allPlantes.Count + PageSize - 1) / PageSize)
            {
                _currentPage++;
                DisplayPage();
            }
        }

        private void Ajouter_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AjouterPlante());
        }

        private void SearchTextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            if (SearchTextBox.Text == "Rechercher une plante")
            {
                SearchTextBox.Text = "";
                SearchTextBox.Foreground = new SolidColorBrush(Colors.Black);
            }
        }

        private void SearchTextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(SearchTextBox.Text))
            {
                SearchTextBox.Text = "Rechercher une plante";
                SearchTextBox.Foreground = new SolidColorBrush(Colors.Gray);
            }
        }

        private void SearchTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
           
        }

        private void PlantesListView_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (PlantesListView.SelectedItem != null)
            {
                dynamic selectedItem = PlantesListView.SelectedItem;
                int planteId = selectedItem.IdPlante;

                // Naviguer vers la page des détails de la plante
                NavigationService.Navigate(new DetailsPlante(planteId));
            }
        }
        private void Back_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }

        private void Home_Click(object sender, RoutedEventArgs e)
        {
            //NavigationService.Navigate(new TableauDebord());
        }
    }
}
