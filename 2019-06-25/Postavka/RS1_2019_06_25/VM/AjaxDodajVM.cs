using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RS1_2019_06_25.VM
{
    public class AjaxDodajVM
    {
        public int IspitniTerminID { get; set; }

        public int IspitniTerminStavkeID { get; set; }
        public int StudentId { get; set; }
        public List<SelectListItem> Studenti { get; set; }
        public int Ocjena { get; set; }
        public bool Pristupio { get; set; }
    }
}
