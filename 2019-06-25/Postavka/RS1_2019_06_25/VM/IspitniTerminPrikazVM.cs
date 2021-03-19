using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RS1_2019_06_25.VM
{
    public class IspitniTerminPrikazVM
    {
            public int AngazmanID { get; set; }
            public string PredmetNaziv { get; set; }
            public string NastavnikNaziv { get; set; }
            public string AkademskaGodinaNaziv { get; set; }
        public class Row
        {
            public int IspitniTerminID { get; set; }
            public DateTime DatumIspita { get; set; }
            public int BrojNisuPolozili { get; set; }
            public int BrojPrijavili { get; set; }
            public bool IsZakljucano { get; set; }

        }
        public List<Row> listaIspita { get; set; }
    }
}
