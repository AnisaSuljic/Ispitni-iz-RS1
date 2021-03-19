using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RS1_2018_01_23.VM
{
    public class UputnicaDetaljiVM
    {
        public int UputnicaID{ get; set; }
        public string DatumUputnice{ get; set; }
        public string PacijentIme{ get; set; }
        public string DatumRezultata{ get; set; }
        public DateTime DatumRezultataDateTime{ get; set; }
        public bool IsGotov{ get; set; }
    }
}
