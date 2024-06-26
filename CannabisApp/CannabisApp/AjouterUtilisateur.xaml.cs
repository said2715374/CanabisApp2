using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CannabisApp
{
    public partial class AjouterUtilisateur : Page
    {
        private readonly AppDbContext _context;

        public AjouterUtilisateur()
        {
            InitializeComponent();
            _context = new AppDbContext();
            LoadRoles();
        }

        private void LoadRoles()
        {
            var roles = _context.Roles.ToList();
            RoleComboBox.ItemsSource = roles;
        }

        private void Ajouter_Click(object sender, RoutedEventArgs e)
        {
            var nomUtilisateur = NomUtilisateur.Text;
            var motDePasse = MotDePasse.Password;
            var selectedRole = (Roles)RoleComboBox.SelectedItem;

            if (string.IsNullOrEmpty(nomUtilisateur) || string.IsNullOrEmpty(motDePasse) || selectedRole == null)
            {
                MessageBox.Show("Veuillez remplir tous les champs.");
                return;
            }

            var nouvelUtilisateur = new Utilisateur
            {
                NomUtilisateur = nomUtilisateur,
                MotDePasse = motDePasse,
                IdRole = selectedRole.IdRole
            };

            _context.Utilisateurs.Add(nouvelUtilisateur);
            _context.SaveChanges();
            MessageBox.Show("Nouvel utilisateur ajouté avec succès !");
        }
    }
}