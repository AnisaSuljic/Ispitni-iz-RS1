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
    public class UputnicaController : Controller
    {
        private readonly MojContext db;

        public UputnicaController(MojContext db)
        {
            this.db = db;
        }

        public IActionResult Index()
        {
            UputnicaIndexVM model = new UputnicaIndexVM();

            List<UputnicaIndexVM.Row> lista = db.Uputnica.Select(u => new UputnicaIndexVM.Row
            {
                UputnicaID=u.Id,
                Uputio=u.DatumUputnice.Date.ToString()+" | "+u.UputioLjekar.Ime,
                Pacijent=u.Pacijent.Ime,
                VrstaPretrage=u.VrstaPretrage.Naziv,
                DatumEvidentiranjaRezultataPretrage =u.DatumRezultata==null?"(nema rezultata)":u.DatumRezultata.ToString()
            }).ToList();
            model.listaUputnica = lista;

            return View(model);
        }
        public IActionResult Dodaj()
        {
            UputnicaDodajVM model = new UputnicaDodajVM();

            List<SelectListItem> listaLjekara = db.Ljekar.Select(l => new SelectListItem
            {
                Value=l.Id.ToString(),
                Text=l.Ime
            }).ToList();
            List<SelectListItem> listaPacijenata = db.Pacijent.Select(p => new SelectListItem
            {
                Value = p.Id.ToString(),
                Text = p.Ime
            }).ToList();
            List<SelectListItem> listaPretrage = db.VrstaPretrage.Select(pr => new SelectListItem
            {
                Value = pr.Id.ToString(),
                Text = pr.Naziv
            }).ToList();

            model.DatumUputnice = DateTime.Today;
            model.listaLjekara = listaLjekara;
            model.listaPacijenata = listaPacijenata;
            model.listaVrstaPretraga = listaPretrage;
            return View(model);
        }
        public IActionResult Snimi(UputnicaDodajVM model)
        {
            Uputnica nova = new Uputnica();

            nova.UputioLjekarId = model.LjekarID;
            nova.PacijentId = model.PacijentID;
            nova.VrstaPretrageId = model.VrstaPretragaID;
            nova.DatumUputnice = model.DatumUputnice;
            nova.IsGotovNalaz = false;

            db.Uputnica.Add(nova);
            db.SaveChanges();

            return Redirect("/Uputnica/Index");
        }
        public IActionResult Detalji(int UputnicaID)
        {
            UputnicaDetaljiVM model = new UputnicaDetaljiVM();

            model.UputnicaID = UputnicaID;

            Uputnica trenutna = db.Uputnica.Where(u => u.Id == UputnicaID)
                .Include(u => u.Pacijent).FirstOrDefault();

            model.DatumUputnice = trenutna.DatumUputnice.ToString("dd.MM.yyyy");
            model.PacijentIme = trenutna.Pacijent.Ime;
            model.DatumRezultata = trenutna.DatumRezultata == null ? "nema rezultata" : trenutna.DatumRezultata.ToString();
            model.DatumRezultataDateTime = trenutna.DatumRezultata.GetValueOrDefault();
            model.IsGotov = trenutna.IsGotovNalaz;
          
            return View(model);
        }

        public IActionResult Zakljucaj(int UputnicaID)
        {
            Uputnica uput = db.Uputnica.Find(UputnicaID);

            uput.IsGotovNalaz = true;
            uput.DatumRezultata = DateTime.Today;

            db.SaveChanges();

            return Redirect("/Uputnica/Detalji?UputnicaID=" + UputnicaID);
        }
    }
}
