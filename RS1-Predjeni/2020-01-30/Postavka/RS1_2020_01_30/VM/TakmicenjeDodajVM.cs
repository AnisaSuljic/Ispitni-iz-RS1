using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RS1_2020_01_30.VM
{
    public class TakmicenjeDodajVM
    {
        public int SkolaID { get; set; }
        public string Skola { get; set; }

        public int PredmetID { get; set; }
        public List<SelectListItem> ListaPredmeta { get; set; }


        public int RazredID { get; set; }
        public List<SelectListItem> listaRazreda { get; set; }

        public DateTime Datum { get; set; }
        public bool IsZakljucano { get; set; }
    }
}
