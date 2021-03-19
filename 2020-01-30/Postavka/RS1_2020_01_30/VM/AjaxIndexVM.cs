using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RS1_2020_01_30.VM
{
    public class AjaxIndexVM
    {
        public int TakmicenjeID { get; set; }
        public bool IsZakljucano { get; set; }

        public class Row
        {
            public int TakmicenjeUcesnikID { get; set; }
            public string OdjeljenjeOznaka { get; set; }
            public int BrojDnevnik { get; set; }
            public bool IsPristupio { get; set; }
            public int Bodovi { get; set; }

        }
        public List<Row> TakmUcesniciLista { get; set; }
    }
}
