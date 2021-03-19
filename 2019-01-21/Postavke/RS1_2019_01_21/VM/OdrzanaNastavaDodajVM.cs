using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RS1_2019_01_21.VM
{
    public class OdrzanaNastavaDodajVM
    {
        public int NastavnikID { get; set; }

        public int SkolaID { get; set; }
        public List<SelectListItem> SkolaLista { get; set; }

        public string NastavnikImePrezime { get; set; }

        public int SkolskaGodinaID { get; set; }
        public string SkolskaGodinaOznaka { get; set; }

        public DateTime DatumIspita { get; set; }

        public int PredmetID { get; set; }
        public List<SelectListItem> PredmetLista { get; set; }

    }
}
