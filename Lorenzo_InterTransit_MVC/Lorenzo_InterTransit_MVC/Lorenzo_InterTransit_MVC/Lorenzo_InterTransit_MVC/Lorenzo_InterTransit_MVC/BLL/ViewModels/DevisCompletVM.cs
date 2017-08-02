using Lorenzo_InterTransit_MVC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.ViewModels
{
    public class DevisCompletVM
    {
        public Devi Devis { get; set; }
        public IEnumerable<LigneDeVente> LigneDeVentesDuDevi { get; set; }
        public Client LeClientDuDevis { get; set; }

    }
}
