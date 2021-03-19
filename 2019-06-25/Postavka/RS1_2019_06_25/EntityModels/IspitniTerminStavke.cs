using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RS1_2019_06_25.EntityModels
{
    public class IspitniTerminStavke
    {
        public int IspitniTerminStavkeID { get; set; }

        public int StudentID { get; set; }
        public Student Student { get; set; }

        public int IspitniTerminID { get; set; }
        public IspitniTermin IspitniTermin { get; set; }

        public bool IsPristupio { get; set; }
        public int Ocjena { get; set; }



    }
}
