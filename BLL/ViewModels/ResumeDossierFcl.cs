using Lorenzo_InterTransit_MVC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.ViewModels
{
    /// <summary>
    /// ViewModel necessaire pour la fonctionnalité creation/edition "rapide" de dossier FCL export
    /// </summary>
    public class ResumeDossierFcl
    {
       
        public DossierFclExport DossierFclExports { get; set; }
        public Booking Bookings { get; set; }
        public IEnumerable<Conteneur> Conteneurs { get; set; }
        public IEnumerable<Marchandise> Marchandises { get; set; }
        public InstruTransporteur InstruTrans { get; set; }
        public Transporteur Transporteurs { get; set; }
        public MAD Mads { get; set; }
        public Devi Devis { get; set; }
        public IEnumerable<LigneDeVente> LigneDeVentes { get; set; }
        public Client Clients { get; set; }
        public CompagnieMaritime CompagnieMaritimes { get; set; }

       
    }
}
