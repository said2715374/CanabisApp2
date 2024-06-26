using System.Collections.Generic;
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
            _allPlantes = _context.Plantes.Include(p => p.Provenance).ToList();
            DisplayPage();
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
            PageNumberText.Text = $"Page {_currentPage} / {(_allPlantes.Count + PageSize - 1) / PageSize}";
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
            var searchText = SearchTextBox.Text.ToLower();
            _allPlantes = _context.Plantes
                .Include(p => p.Provenance)
                .Where(p => p.Nom.ToLower().Contains(searchText) || p.Provenance.Ville.ToLower().Contains(searchText) || p.Provenance.Province.ToLower().Contains(searchText))
                .ToList();
            _currentPage = 1;
            DisplayPage();
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
    }
}
