using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RS1_2019_11_04.EntityModels
{
    public class PopravniIspitStavke
    {
        public int PopravniIspitStavkeID{ get; set; }

        public int PopravniIspitID{ get; set; }
        public PopravniIspit PopravniIspit { get; set; }

        public int OdjeljenjeStavkeID { get; set; }
        public OdjeljenjeStavka OdjeljenjeStavke { get; set; }

        public bool IsPrisutan { get; set; }
        public int Bodovi { get; set; }

    }
}
