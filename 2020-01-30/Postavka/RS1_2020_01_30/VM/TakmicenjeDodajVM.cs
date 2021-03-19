using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RS1_2020_01_30.VM
{
    public class TakmicenjeDodajVM
    {
        public int TakmicenjeID{ get; set; }
        public int SkolaId{ get; set; }
        public string SkolaNaziv{ get; set; }

        public int PredmetID{ get; set; }
        public List<SelectListItem> Predmeti{ get; set; }

        public int RazredID{ get; set; }
        public List<SelectListItem> Razredi{ get; set; }
        public DateTime Datum { get; set; }
    }
}
