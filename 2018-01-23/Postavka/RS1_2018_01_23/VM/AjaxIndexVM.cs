using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RS1_2018_01_23.VM
{
    public class AjaxIndexVM
    {
        public int UputnicaID { get; set; }
        public bool isGotov { get; set; }
        public class Row
        {
            public int RezultatiPretrageID { get; set; }
            public string RezPretragaNaziv { get; set; }
            public string IzmjerenaVrijednost { get; set; }
            public string jmj { get; set; }
            public string refVrijednosti { get; set; }
        }
        public List<Row> listaRezultata { get; set; }
    }
}
