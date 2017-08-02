using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lorenzo_InterTransit_MVC.ViewModels
{
    /// <summary>
    /// ViewModel qui est utilisé pour afficher les dossiers du client
    /// </summary>
    public class DossierDuClient
    {
        public IEnumerable<Client> Clients { get; set; }
        public IEnumerable<DossierFclExport> DossierFclExports { get; set; }        
    }
}