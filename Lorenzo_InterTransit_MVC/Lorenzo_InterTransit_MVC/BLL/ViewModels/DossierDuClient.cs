using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lorenzo_InterTransit_MVC.ViewModels
{
    public class DossierDuClient
    {
        public IEnumerable<Client> Clients { get; set; }
        public IEnumerable<DossierFclExport> DossierFclExports { get; set; }
        public IEnumerable<Booking> Bookings { get; set; }
        public IEnumerable<InstruTransporteur> InstruTransporteurs { get; set; }
        public IEnumerable<Devi> Devis { get; set; }        
    }
}