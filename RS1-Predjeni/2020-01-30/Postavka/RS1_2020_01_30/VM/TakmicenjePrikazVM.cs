using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RS1_2020_01_30.VM
{
    public class TakmicenjePrikazVM
    {
        public string OdabranaSkola { get; set; }
        public int OdabranaSkolaID { get; set; }
        public int OdabraniRazred { get; set; }
        public class Row
        {
            public int TakmicenjeID { get; set; }
            public string Predmet { get; set; }
            public int Razred { get; set; }
            public DateTime Datum { get; set; }
            public int BrojUcesnik_NisuPristupili { get; set; }
            public string NajboljiUcesnik { get; set; }

        }
        public List<Row> ListaTaknmicenja { get; set; }
    }
}
