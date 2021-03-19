using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RS1_2020_01_30.VM
{
    public class TakmicenjeIndexVM
    {
        public int SkolaID { get; set; }
        public List<SelectListItem> skoleLista { get; set; }

        public int RazredID { get; set; }
        public List<SelectListItem> razrediLista { get; set; }
    }
}
