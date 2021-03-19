using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RS1_2019_11_04.VM
{
    public class PopravniIspitPrikazVM
    {
        public int PredmetID { get; set; }
        public string PredmetNaziv { get; set; }
        public int RazredNaziv { get; set; }
        public class Row
        {
            public int PopravniIspitID{ get; set; }

            public string SkolaNaziv{ get; set; }
            public string SkolskaGodinaNaziv{ get; set; }
            public DateTime DatumIspita{ get; set; }
            public int BrojNaIspitu{ get; set; }
            public int BrojPolozenih{ get; set; }
        }
        public List<Row>ListaPopravnih { get; set; }
    }
}
