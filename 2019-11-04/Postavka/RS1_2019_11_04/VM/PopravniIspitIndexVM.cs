using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RS1_2019_11_04.VM
{
    public class PopravniIspitIndexVM
    {
        public class Row
        {
            public int PredmetID{ get; set; }
            public int RazredNaziv { get; set; }
            public string PredmetNaziv { get; set; }

        }
        public List<Row> ListaPredmeta{ get; set; }
    }
}
