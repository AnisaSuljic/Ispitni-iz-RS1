using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RS1_2019_11_04.VM
{
    public class PopravniIspitUrediVM
    {
        public int PopravniIspitID{ get; set; }
        public int PredmetID{ get; set; }
        public int Razred{ get; set; }
        public string Predmet{ get; set; }

        public DateTime DatumIspita{ get; set; }

        public int SkolaID { get; set; }
        public List<SelectListItem> SkolaLista { get; set; }

        public int SkolskaGodinaID { get; set; }
        public List<SelectListItem> SkolskaGodinaLista { get; set; }


    }
}
