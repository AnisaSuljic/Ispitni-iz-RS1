using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RS1_2019_01_21.VM
{
    public class OdrzanaNastavaIndexVM
    {
        public class Row
        {
            public int NastavnikID { get; set; }
            public string NastavnikImePrezime { get; set; }
            public string SkolaNaziv { get; set; }
        }
        public List<Row> listaNastavnika { get; set; }
    }
}
