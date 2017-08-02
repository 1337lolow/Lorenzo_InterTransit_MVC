using Lorenzo_InterTransit_MVC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.ViewModels
{
    public class ResumeDossierFcl
    {
        public string FCL_ID { get; set; }
        public int BKG_ID { get; set; }
        public string CM_REF { get; set; }

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
        public int CLT_ID { get; set; }
    }
}
