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
using static CannabisApp.MainWindow;

namespace CannabisApp
{
    public partial class ModifierPlante : Page
    {
        private readonly PlantRepository _plantRepository;
        private readonly int _planteId;

        public ModifierPlante(int planteId)
        {
            InitializeComponent();
            _plantRepository = new PlantRepository(new AppDbContext());
            _planteId = planteId;
            ChargerPlante(planteId);
        }

        private void ChargerPlante(int planteId)
        {
            var plante = _plantRepository.GetPlanteById(planteId);
            if (plante != null)
            {
                Description.Text = plante.nom;
                Stade.Text = plante.emplacement;
                ProvenanceComboBox.SelectedValue = plante.id_provenance;
                Quantite.Text = plante.nombre_plantes_actives.ToString();
                DateExpiration.Text = plante.date_expiration.ToString("yyyy-MM-dd");
                Emplacement.Text = plante.code_qr;
            }
        }

        private void Modifier_Click(object sender, RoutedEventArgs e)
        {
            var plante = new plantes
            {
                id_plante = _planteId,
                nom = Description.Text,
                emplacement = Stade.Text,
                id_provenance = (int)ProvenanceComboBox.SelectedValue,
                nombre_plantes_actives = int.Parse(Quantite.Text),
                date_expiration = DateTime.Parse(DateExpiration.Text),
                code_qr = Emplacement.Text
            };

            _plantRepository.UpdatePlante(plante);
            MessageBox.Show("Plante modifiée avec succès !");
            // Naviguer vers la page précédente ou une autre page après la modification
        }
    }
}