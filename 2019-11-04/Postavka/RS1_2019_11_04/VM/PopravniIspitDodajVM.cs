using Microsoft.AspNetCore.Mvc.Rendering;
using RS1_2019_11_04.EntityModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RS1_2019_11_04.VM
{
    public class PopravniIspitDodajVM
    {
        public int PredmetID{ get; set; }
        public int Razred{ get; set; }
        public string Predmet{ get; set; }

        public DateTime DatumIspita { get; set; }

        public int SkolaID { get; set; }
        public List<SelectListItem> SkolaLista { get; set; }

        public int SkolskaGodinaID { get; set; }
        public List<SelectListItem> SkolskaGodinaLista { get; set; }
    }
}
