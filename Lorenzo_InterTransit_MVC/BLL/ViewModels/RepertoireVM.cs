using Lorenzo_InterTransit_MVC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lorenzo_InterTransit_MVC.ViewModels
{
    public class RepertoireVM
    {
        public IEnumerable<Client> clientRepertoire { get; set; }
        public IEnumerable<CompagnieMaritime> cieMaritimeRepertoire { get; set; }
        public IEnumerable<Transporteur> transRepertoire { get; set; }
    }
}
