using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RS1_2019_06_25.VM
{
    public class IspitniTerminDodajVM
    {
        public int IspitniTerminID{ get; set; }

        public int AngazmanID{ get; set; }

        public string PredmetNaziv { get; set; }
        public string NastavnikNaziv { get; set; }
        public string AkademskaGodinaNaziv { get; set; }
        public DateTime DatumIspita { get; set; }
        public string Napomena { get; set; }


    }
}
