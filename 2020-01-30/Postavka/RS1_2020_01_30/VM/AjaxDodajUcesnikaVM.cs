using Microsoft.AspNetCore.Mvc.Rendering;
using RS1_2020_01_30.EntityModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RS1_2020_01_30.VM
{
    public class AjaxDodajUcesnikaVM
    {
        public int TakmicenjeID{ get; set; }

        public int Ucenici_TakmUcID{ get; set; }
        public List<SelectListItem> Ucenici_TakmUc { get; set; }

        public int Bodovi { get; set; }
        public bool IsPristupio { get; set; }

    }
}
