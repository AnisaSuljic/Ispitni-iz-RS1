using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RS1_2019_12_02.VM
{
    public class AjaxIndexVM
    {
        public int PopravniIspitID{ get; set; }
        public class Row
        {
            public int PopravniIspitStavkeID{ get; set; }
            public string UcenikNaziv{ get; set; }
            public string OdjeljenjeOznaka { get; set; }
            public int BrojDnevnik{ get; set; }
            public bool IsPrisutan{ get; set; }
            public int Bodovi{ get; set; }       
        }
        public List<Row> ListaPopravniIspitStavke{ get; set; }
    }
}
