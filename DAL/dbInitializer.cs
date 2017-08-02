using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lorenzo_InterTransit_MVC.DAL
{
    /// <summary>
    /// Class qui sert à initialiser/créer la base de données
    /// </summary>
    public class dbInitializer : System.Data.Entity.CreateDatabaseIfNotExists<InterTransit>
    {
        /// <summary>
        /// méthode "Seed", permettant de peuplé la BDD à la création de la BDD
        /// </summary>
        /// <param name="context"></param>
        protected override void Seed(InterTransit context)
        {
            var natureMarch = new List<NatureMarchandise>
            {
                new NatureMarchandise {NAT_MARCH_ID =1, NAT_MARCH_LIBELLE ="Frais" },
                new NatureMarchandise {NAT_MARCH_ID =2, NAT_MARCH_LIBELLE ="Dangereux" },
                new NatureMarchandise {NAT_MARCH_ID =3, NAT_MARCH_LIBELLE ="Chimique" },
                new NatureMarchandise {NAT_MARCH_ID =4, NAT_MARCH_LIBELLE ="Nucléaire" },
                new NatureMarchandise {NAT_MARCH_ID =5, NAT_MARCH_LIBELLE ="Vivant" },
                new NatureMarchandise {NAT_MARCH_ID =5, NAT_MARCH_LIBELLE ="Fragile" },
                new NatureMarchandise {NAT_MARCH_ID =5, NAT_MARCH_LIBELLE ="non-spécifié" }
            };
            natureMarch.ForEach(s => context.NatureMarchandises.Add(s));
            context.SaveChanges();

            var typeTrans = new List<TypeTransporteur>
            {
                new TypeTransporteur {TYTRANS_ID = 1 , TYTRANS_LIBELLE ="Routier" },
                new TypeTransporteur {TYTRANS_ID = 2, TYTRANS_LIBELLE ="Fluvial" },
                new TypeTransporteur {TYTRANS_ID = 3, TYTRANS_LIBELLE ="Spatial" },
                new TypeTransporteur {TYTRANS_ID = 4, TYTRANS_LIBELLE ="Férroviere" },
                new TypeTransporteur {TYTRANS_ID = 4, TYTRANS_LIBELLE ="Aérien" }
            };
            typeTrans.ForEach(s => context.TypeTransporteurs.Add(s));
            context.SaveChanges();

            var typeTC = new List<TypeTC>
            {
                new TypeTC {TYTC_ID=1 , TYTC_TYPE ="45' High Cude Dry" },
                new TypeTC {TYTC_ID= 2, TYTC_TYPE ="40' Dry Freight" },
                new TypeTC {TYTC_ID= 3, TYTC_TYPE ="40' Open Top" },
                new TypeTC {TYTC_ID=4 , TYTC_TYPE ="40' Flat Rack" },
                new TypeTC {TYTC_ID= 5, TYTC_TYPE ="40' Collapsible Flat Rack" },
                new TypeTC {TYTC_ID=6 , TYTC_TYPE ="40' Platform" },
                new TypeTC {TYTC_ID= 7, TYTC_TYPE ="40' Reefer" },
                new TypeTC {TYTC_ID= 8, TYTC_TYPE ="40' High Cube Reefer" },
                new TypeTC {TYTC_ID= 9, TYTC_TYPE ="20' Dry Freight" },
                new TypeTC {TYTC_ID= 10, TYTC_TYPE ="20' open Top" },
                new TypeTC {TYTC_ID= 11, TYTC_TYPE ="20' Flat Rack" },
                new TypeTC {TYTC_ID= 12, TYTC_TYPE ="20' Tank" },
            };
            typeTC.ForEach(s => context.TypeTCs.Add(s));
            context.SaveChanges();
            base.Seed(context);
        }
    }
}
