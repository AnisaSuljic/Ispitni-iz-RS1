using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RS1_2019_12_02.VM
{
    public class PopravniIspitIndexVM
    {
        public class Row
        {
            public int OdjeljenjeID{ get; set; }

            public string SkolskaGodinaOznaka{ get; set; }
            public string SkolaOznaka { get; set; }

            public string OdjeljenjeOznaka { get; set; }

        }
        public List<Row> ListaOdjeljenja{ get; set; }
    }
}
