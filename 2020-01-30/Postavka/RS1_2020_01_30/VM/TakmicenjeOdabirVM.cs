using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RS1_2020_01_30.VM
{
    public class TakmicenjeOdabirVM
    {
        public int SkolaID { get; set; }
        public string SkolaNaziv { get; set; }
        public List<SelectListItem> SkoleLista { get; set; }
        public int Razred { get; set; }
        public class Row
        {
            public int TakmicenjeID { get; set; }
            public string PredmetNaziv { get; set; }
            public int Razred { get; set; }
            public DateTime Datum { get; set; }
            public int BrojOnihKojiNisuPristupili { get; set; }
            public string NajboljiUcenikSkola { get; set; }
            public string NajboljiUcenikOdjeljenje { get; set; }
            public string NajboljiUcenikImePrezime { get; set; }

        }
        public List<Row> listaTakmicenja { get; set; }
    }
}
