using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RS1_2019_01_21.VM
{
    public class OdrzanaNastavaPrikazVM
    {
        public int NastavnikID { get; set; }
        public class Row
        {
            public int MaturskiIspitID { get; set; }
            public DateTime DatumIspita { get; set; }
            public string SkolaNaziv { get; set; }
            public string PredmetNaziv { get; set; }
            public List<string> NisuPristupili { get; set; }
        }
        public List<Row> listaMaturskih { get; set; }

    }
}
