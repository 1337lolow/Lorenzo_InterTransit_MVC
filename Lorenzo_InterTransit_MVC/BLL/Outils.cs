using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class Outils
    {

        public List<string> PeuplerDropDownListDoss(object selectedStatut = null)
        {
            var lstStatut = new List<string>();
            lstStatut.Add("Open");
            lstStatut.Add("Close");
            lstStatut.Add("Pending");

            return lstStatut;
        }
    }
}
