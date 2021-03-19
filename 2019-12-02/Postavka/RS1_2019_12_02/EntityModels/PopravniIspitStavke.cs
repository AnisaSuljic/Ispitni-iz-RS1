using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RS1_2019_12_02.EntityModels
{
    public class PopravniIspitStavke
    {
        public int PopravniIspitStavkeID{ get; set; }

        public int PopravniIspitID{ get; set; }
        public PopravniIspit PopravniIspit { get; set; }

        public int OdjeljenjeStavkaID { get; set; }
        public OdjeljenjeStavka OdjeljenjeStavka { get; set; }

        public bool IsPristupio { get; set; }
        public int Bodovi { get; set; }

    }
}
