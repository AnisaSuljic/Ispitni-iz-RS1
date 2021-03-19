using Microsoft.AspNetCore.Mvc.Rendering;
using RS1_2019_12_02.EntityModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RS1_2019_12_02.VM
{
    public class PopravniIspitDodajVM
    {
        public int OdjeljenjeID { get; set; }
        public string OdjeljenjeOznaka { get; set; }
        public string SkolaOznaka { get; set; }
        public string SkolGodOznaka { get; set; }

        public int PredmetID { get; set; }
        public List<SelectListItem> Predmet { get; set; }

        public DateTime DatumIspita { get; set; }

    }
}
