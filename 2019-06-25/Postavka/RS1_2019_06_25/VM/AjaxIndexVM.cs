using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RS1_2019_06_25.VM
{
    public class AjaxIndexVM
    {
        public int IspitniTerminID{ get; set; }
        public class Row
        {
            public int IspitniTerminStavkeID { get; set; }
            public string StudentIme { get; set; }
            public bool IsPristupio { get; set; }
            public int Ocjena { get; set; }

        }
        public List<Row>ListaIspitniTerminStavke { get; set; }
    }
}
