using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lorenzo_InterTransit_MVC.DAL
{
    /// <summary>
    /// classe qui sert à initialiser la BDD
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            // pour faire un peuplement de la BDD
            Database.SetInitializer(new dbInitializer());
            using (var context = new InterTransit())
            {
                context.Database.Initialize(false);
            }
        }
    }
}
