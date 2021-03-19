using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RS1_2019_06_25.VM
{
    public class IspitniTerminIndexVM
    {
        public class Row
        {
            public int AngazovanID { get; set; }
            public string NazivPredmeta { get; set; }
            public string AkademskaGodina { get; set; }
            public string ImePrezimeNastavnika { get; set; }
            public int BrojOdrzanihCasova { get; set; }
            public int BrojStudenataNaPredmetu { get; set; }

        }
        public List<Row>ListaAngazmana { get; set; }
    }
}
