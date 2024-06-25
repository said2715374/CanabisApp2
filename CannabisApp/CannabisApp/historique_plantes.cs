using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CannabisApp
{
    public class Historique_Plantes
    {
        public int IdHistorique { get; set; }
        public int IdPlante { get; set; }
        public string Action { get; set; }
        public DateTime Timestamp { get; set; }
        public int IdUtilisateur { get; set; }
    }
}
