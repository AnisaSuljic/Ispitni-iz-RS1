using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RS1_2018_01_23.VM
{
    public class UputnicaIndexVM
    {
        public class Row
        {
            public int UputnicaID { get; set; }
            public string Uputio { get; set; }
            public string Pacijent { get; set; }
            public string VrstaPretrage { get; set; }
            public string DatumEvidentiranjaRezultataPretrage { get; set; }
        }
        public List<Row> listaUputnica { get; set; }
    }
}
