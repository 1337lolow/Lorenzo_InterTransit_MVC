using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lorenzo_InterTransit_MVC.ViewModels
{
    public class DossierFCLDetail
    {
        public IEnumerable<DossierFclExport> DossierFclExports { get; set; }
        public IEnumerable<Booking> Bookings { get; set; }
        public IEnumerable<Conteneur> Conteneurs { get; set; }
        public IEnumerable<Marchandise> Marchandises { get; set; }
        public IEnumerable<InstruTransporteur> InstruTrans { get; set; }
        public IEnumerable<Transporteur> Transporteurs { get; set; }
        public IEnumerable<MAD> Mads { get; set; }
        public IEnumerable<Devi> Devis { get; set; }
        public IEnumerable<LigneDeVente> LigneDeVentes { get; set; }
        public IEnumerable<Client> Clients { get; set; }
        public IEnumerable<CompagnieMaritime> CompagnieMaritimes { get; set; }

    }
}