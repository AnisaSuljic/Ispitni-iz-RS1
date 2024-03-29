﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RS1_2020_01_30.EntityModels
{
    public class TakmicenjeUcesnik
    {
        public int TakmicenjeUcesnikID { get; set; }

        public int TakmicenjeID { get; set; }
        public Takmicenje Takmicenje { get; set; }

        public int OdjeljenjeStavkaID{ get; set; }
        public OdjeljenjeStavka OdjeljenjeStavka { get; set; }

        public bool IsPristupio{ get; set; }
        public int Bodovi{ get; set; }

    }
}
