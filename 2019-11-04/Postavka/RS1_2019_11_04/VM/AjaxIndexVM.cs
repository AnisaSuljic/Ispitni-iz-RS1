using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RS1_2019_11_04.VM
{
    public class AjaxIndexVM
    {
        public int PopravniIspitID { get; set; }

        public class Row
        {
            public int PopravniIspitStavkeID { get; set; }
            public string UcenikNaziv { get; set; }
            public string Odjeljenje { get; set; }
            public int BrojDnevnik{ get; set; }
            public bool IsPrisutan { get; set; }
            public int Bodovi { get; set; }
        }
        public List<Row> ListPopravniIspitStavke { get; set; }
    }
}
