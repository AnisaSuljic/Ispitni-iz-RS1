using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RS1_2019_06_25.EntityModels
{
    public class IspitniTermin
    {
        public int IspitniTerminID{ get; set; }
        public int AngazovanID{ get; set; }
        public Angazovan Angazovan { get; set; }
        public DateTime DatumIspita{ get; set; }
        public string Napomena{ get; set; }
        public bool Zakljucano { get; set; }


    }
}
