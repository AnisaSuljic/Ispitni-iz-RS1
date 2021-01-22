using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RS1_2020_01_30.VM
{
    public class TakmicenjeRezultatiVM
    {     
        public int TakmicenjeID{ get; set; }
        public int SkolaID{ get; set; }
        public string Skola{ get; set; }

        public string Predmet{ get; set; }
        public int Razred{ get; set; }
        public DateTime Datum{ get; set; }

    }
}
