using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RS1_2019_12_02.VM
{
    public class PopravniIspitUrediVM
    {
        public int PopravniIspitID { get; set; }

        public DateTime DatumIspita { get; set; }

        public int PredmetID { get; set; }
        public string PredmetOznaka { get; set; }

        public int OdjeljenjeID { get; set; }
        public string OdjeljenjeOznaka { get; set; }

        public int SkolaID { get; set; }
        public string SkolaOznaka { get; set; }

        public int SkolskaGodinaID { get; set; }
        public string SkolGodOznaka { get; set; }
    }
}
