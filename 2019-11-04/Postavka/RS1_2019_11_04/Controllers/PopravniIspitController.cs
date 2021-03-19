using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RS1_2019_11_04.EF;
using RS1_2019_11_04.EntityModels;
using RS1_2019_11_04.VM;

namespace RS1_2019_11_04.Controllers
{
    public class PopravniIspitController : Controller
    {
        private readonly MojContext db;

        public PopravniIspitController(MojContext db)
        {
            this.db = db;
        }

        public IActionResult Index()
        {
            PopravniIspitIndexVM model = new PopravniIspitIndexVM();

            List<PopravniIspitIndexVM.Row> lista = db.Predmet.Select(p => new PopravniIspitIndexVM.Row
            {
                PredmetID=p.Id,
                RazredNaziv=p.Razred,
                PredmetNaziv=p.Naziv
            }).OrderBy(p=>p.RazredNaziv).ToList();

            model.ListaPredmeta = lista;
            return View(model);
        }

        public IActionResult Prikaz(int PredmetID)
        {
            PopravniIspitPrikazVM model = new PopravniIspitPrikazVM();
            Predmet predmet = db.Predmet.Find(PredmetID);

            model.PredmetID = PredmetID;
            model.PredmetNaziv = predmet.Naziv;
            model.RazredNaziv = predmet.Razred;

            List<PopravniIspitPrikazVM.Row> lista = db.PopravniIspit
                .Select(p => new PopravniIspitPrikazVM.Row
                {
                    PopravniIspitID=p.PopravniIspitID,
                    SkolaNaziv=p.Skola.Naziv,
                    SkolskaGodinaNaziv=p.SkolskaGodina.Naziv,
                    DatumIspita=p.Datum,
                    BrojNaIspitu=10,
                    BrojPolozenih=5
                }).ToList();

            model.ListaPopravnih = lista;
            return View(model);
        }

        public IActionResult Dodaj(int PredmetID)
        {
            PopravniIspitDodajVM model = new PopravniIspitDodajVM();

            Predmet predmet = db.Predmet.Find(PredmetID);

            model.PredmetID = PredmetID;
            model.Predmet = predmet.Naziv;
            model.Razred = predmet.Razred;

            List<SelectListItem> listaSkole = db.Skola.Select(s => new SelectListItem
            {
                Value=s.Id.ToString(),
                Text=s.Naziv
            }).ToList();

            List<SelectListItem> listaSkolGod = db.SkolskaGodina.Select(sg => new SelectListItem
            {
                Value = sg.Id.ToString(),
                Text=sg.Naziv
            }).ToList();

            model.DatumIspita = DateTime.Today;
            model.SkolaLista = listaSkole;
            model.SkolskaGodinaLista = listaSkolGod;

            return View(model);
        }

        public IActionResult Snimi(PopravniIspitDodajVM model)
        {
            PopravniIspit noviIspit = new PopravniIspit();

            noviIspit.PredmetID = model.PredmetID;
            noviIspit.Datum = model.DatumIspita;
            noviIspit.SkolaID = model.SkolaID;
            noviIspit.SkolskaGodinaID = model.SkolskaGodinaID;

            db.PopravniIspit.Add(noviIspit);
            db.SaveChanges();


            return Redirect("/PopravniIspit/Prikaz?PredmetID="+noviIspit.PredmetID);
        }

        public IActionResult Uredi(int IspitID)
        {
            PopravniIspitUrediVM model = new PopravniIspitUrediVM();

            PopravniIspit popravni = db.PopravniIspit
                .Include(i => i.Skola).Include(i => i.SkolskaGodina)
                .Include(i=>i.Predmet)
                .Where(i => i.PopravniIspitID == IspitID).SingleOrDefault();

            model.PredmetID = popravni.Predmet.Id;
            model.PopravniIspitID = popravni.PopravniIspitID;
            model.Predmet = popravni.Predmet.Naziv;
            model.Razred = popravni.Predmet.Razred;

            List<SelectListItem> listaSkole = db.PopravniIspit.Where(pi=>pi.PopravniIspitID==IspitID).Select(pi => new SelectListItem
            {
                Value =pi.Skola.Id.ToString(),
                Text=pi.Skola.Naziv
            }).ToList();

            List<SelectListItem> listaSkolGod = db.PopravniIspit.Where(sg => sg.PopravniIspitID == IspitID).Select(sg => new SelectListItem
            {
                Value = sg.SkolskaGodina.Id.ToString(),
                Text = sg.SkolskaGodina.Naziv
            }).ToList();

            model.DatumIspita = popravni.Datum;
            model.SkolaID = popravni.Skola.Id;
            model.SkolskaGodinaID = popravni.SkolskaGodina.Id;
            model.SkolaLista = listaSkole;
            model.SkolskaGodinaLista = listaSkolGod;

            return View(model);
        }
    }
}
