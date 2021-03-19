using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RS1_2019_12_02.EntityModels
{
    public class PopravniIspit
    {
        public int PopravniIspitID{ get; set; }

        public DateTime DatumIspita{ get; set; }

        public int PredmetID{ get; set; }
        public Predmet Predmet { get; set; }

        public int OdjeljenjeID{ get; set; }
        public Odjeljenje Odjeljenje{ get; set; }
    }
}
