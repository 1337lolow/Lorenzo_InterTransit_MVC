using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.ViewModels
{
    /// <summary>
    /// ViewModel necessaire pour lier la marchandise au conteneur 
    /// (confere la conception du MCD : relation 0,n / 0,n entre la marchandise et le TC)
    /// </summary>
    public class MarchConteneurVM
    {
        public int marchID { get; set; }
        public string marchName { get; set; }
        public bool Assigned { get; set; }
    }
}
