using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RS1_2018_01_23.VM
{
    public class AjaxUrediVM
    {
        public int RezultatID { get; set; }
        public string PretragaNaziv { get; set; }
        public double Vrijednost { get; set; }
        public int vrstaVrijednosti { get; set; }
        public string jmj { get; set; }
        public int modalitetID { get; set; }
        public List<SelectListItem> listaModaliteta { get; set; }
    }
}
