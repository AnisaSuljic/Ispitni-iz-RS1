using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RS1_2018_01_23.VM;
using RS1_2018_01_23.EF;
using RS1_2018_01_23.EntityModels;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace RS1_2018_01_23.Controllers
{
    public class AjaxController : Controller
    {
        private readonly MojContext db;

        public AjaxController(MojContext db)
        {
            this.db = db;
        }
        public IActionResult Index(int UputnicaID)
        {
            AjaxIndexVM model =new AjaxIndexVM();

            model.UputnicaID = UputnicaID;

            Uputnica trenutna = db.Uputnica.Where(u=>u.Id==UputnicaID)
                .Include(u => u.VrstaPretrage).FirstOrDefault();


            model.isGotov = trenutna.IsGotovNalaz;

            List<AjaxIndexVM.Row> lista = db.RezultatPretrage.Where(r => r.UputnicaId == UputnicaID)
                .Select(r => new AjaxIndexVM.Row
                {
                    RezultatiPretrageID = r.Id,
                    RezPretragaNaziv = r.LabPretraga.Naziv,
                    IzmjerenaVrijednost = r.ModalitetId == null && r.NumerickaVrijednost != null ? r.NumerickaVrijednost.ToString()
                : r.ModalitetId != null && r.NumerickaVrijednost == null ? r.Modalitet.Opis : "(nije evidentirano)",
                    refVrijednosti = r.NumerickaVrijednost<r.LabPretraga.ReferentnaVrijednostMin ||
                    r.NumerickaVrijednost>r.LabPretraga.ReferentnaVrijednostMax || r.Modalitet.IsReferentnaVrijednost?"!!!":"",
                jmj = r.ModalitetId != 0 ? r.LabPretraga.MjernaJedinica : ""
                }).ToList();


            model.listaRezultata = lista;

            return PartialView(model);
        }

        public IActionResult Uredi(int RezultatID)
        {
            RezultatPretrage rezultat = db.RezultatPretrage
                .Where(r => r.Id == RezultatID)
                .Include(r => r.LabPretraga).FirstOrDefault();

            AjaxUrediVM model = new AjaxUrediVM();

            model.RezultatID = RezultatID;
            model.PretragaNaziv = rezultat.LabPretraga.Naziv;
            model.vrstaVrijednosti = (int)rezultat.LabPretraga.VrstaVr;
            if(model.vrstaVrijednosti==0)
            {
                model.Vrijednost = rezultat.NumerickaVrijednost.GetValueOrDefault();
                model.jmj = rezultat.LabPretraga.MjernaJedinica;
            }
            else
            {
                List<SelectListItem> lista = db.Modalitet.Select(m => new SelectListItem
                {
                    Value=m.Id.ToString(),
                    Text=m.Opis
                }).ToList();
                model.modalitetID = (int)rezultat.ModalitetId;
                model.listaModaliteta = lista;
            }

            return PartialView(model);
        }
        public IActionResult SnimiRezultat(AjaxUrediVM model)
        {
            RezultatPretrage rez = db.RezultatPretrage
                .Where(r => r.Id == model.RezultatID)
                .Include(r => r.Modalitet).Include(r => r.LabPretraga)
                .FirstOrDefault();

            if(rez.LabPretraga.VrstaVr==0)
            {
                rez.NumerickaVrijednost = model.Vrijednost;
            }
            else
            {
                rez.ModalitetId = model.modalitetID;
            }
            db.SaveChanges();


            return Redirect("/Uputnica/Detalji?UputnicaID="+rez.UputnicaId);
        }
    }
}
