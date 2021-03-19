using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RS1_2018_01_23.VM
{
    public class UputnicaDodajVM
    {
        public int UputnicaID{ get; set; }

        public int LjekarID{ get; set; }
        public List<SelectListItem>listaLjekara{ get; set; }

        public DateTime DatumUputnice { get; set; }

        public int PacijentID { get; set; }
        public List<SelectListItem> listaPacijenata { get; set; }

        public int VrstaPretragaID { get; set; }
        public List<SelectListItem> listaVrstaPretraga { get; set; }

    }
}
