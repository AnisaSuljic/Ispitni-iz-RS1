using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RS1_2019_01_21.VM
{
    public class AjaxIndexVM
    {
        public int MaturskiIspitID { get; set; }
        public class Row
        {
            public int MaturskiIspitStavkaID { get; set; }
            public string UcenikIme { get; set; }
            public float Prosjek { get; set; }
            public bool pristupio { get; set; }
            public int bodovi { get; set; }
        }
        public List<Row> listaMatStavke { get; set; }
    }
}
