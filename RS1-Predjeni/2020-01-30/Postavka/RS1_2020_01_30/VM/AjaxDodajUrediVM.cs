using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RS1_2020_01_30.VM
{
    public class AjaxDodajUrediVM
    {
        public int TakmicenjeID { get; set; }

        public int UcesnikID { get; set; }
        public List<SelectListItem> listaUcesnika { get; set; }
        public int Bodovi { get; set; }
        public bool IsPristupio { get; set; }
    }
}
