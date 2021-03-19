using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RS1_2019_01_21.EntityModels
{
    public class MaturskiIspitStavke
    {
        public int MaturskiIspitStavkeID{ get; set; }

        public int OdjeljenjeStavkaID { get; set; }
        public OdjeljenjeStavka OdjeljenjeStavka { get; set; }

        public int MaturskiIspitID { get; set; }
        public MaturskiIspit MaturskiIspit { get; set; }

        public float ProcjekOcjena { get; set; }
        public bool IsPristupio { get; set; }
        public int Bodovi { get; set; }
    }
}
