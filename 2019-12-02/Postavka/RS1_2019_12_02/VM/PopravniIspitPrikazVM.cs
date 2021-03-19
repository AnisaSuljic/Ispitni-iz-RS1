using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RS1_2019_12_02.VM
{
    public class PopravniIspitPrikazVM
    {
            public int OdjeljenjeID{ get; set; }
            public string OdjeljenjeOznaka{ get; set; }
            public string SkolaOznaka { get; set; }
            public string SkolGodOznaka { get; set; }

        public class Row
        {
            public int PopravniIspitID { get; set; }
            public DateTime DatumIspita{ get; set; }
            public string Predmet{ get; set; }
            public int BrojNaPopravnom{ get; set; }
            public int BrojPolozenih{ get; set; }

        }
        public List<Row> listaIspita { get; set; }

    }
}
