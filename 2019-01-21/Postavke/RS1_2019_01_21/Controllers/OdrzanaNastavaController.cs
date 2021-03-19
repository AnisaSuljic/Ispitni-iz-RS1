using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RS1_2019_01_21.VM;
using RS1_2019_01_21.EF;
using RS1_2019_01_21.EntityModels;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace RS1_2019_01_21.Controllers
{
    public class OdrzanaNastavaController : Controller
    {
        private readonly MojContext db;

        public OdrzanaNastavaController(MojContext db)
        {
            this.db = db;
        }

        public IActionResult Index()
        {
            OdrzanaNastavaIndexVM model = new OdrzanaNastavaIndexVM();
            List<OdrzanaNastavaIndexVM.Row> lista = db.Nastavnik.Select(n => new OdrzanaNastavaIndexVM.Row
            {
                NastavnikID = n.Id,
                NastavnikImePrezime = n.Ime + " " + n.Prezime,
                SkolaNaziv = db.PredajePredmet.Where(p => p.NastavnikID == n.Id).Select(p => p.Odjeljenje.Skola.Naziv).FirstOrDefault()
            }).ToList();
            model.listaNastavnika = lista;
            return View(model);
        }
        public IActionResult Prikaz(int NastavnikID)
        {
            OdrzanaNastavaPrikazVM model = new OdrzanaNastavaPrikazVM();
            model.NastavnikID = NastavnikID;

            List<OdrzanaNastavaPrikazVM.Row> lista = db.MaturskiIspit.Where(n => n.NastavnikID == NastavnikID)
                .Select(n => new OdrzanaNastavaPrikazVM.Row
                {
                    MaturskiIspitID=n.MaturskiIspitID,
                    DatumIspita=n.DatumIspita,
                    SkolaNaziv=n.Skola.Naziv,
                    PredmetNaziv=n.Predmet.Naziv
                }).ToList();
            model.listaMaturskih = lista;

            return View(model);
        }
        public IActionResult Dodaj(int NastavnikID)
        {
            OdrzanaNastavaDodajVM model = new OdrzanaNastavaDodajVM();
            model.NastavnikID = NastavnikID;

            Nastavnik nast = db.Nastavnik.Find(NastavnikID);

            List<SelectListItem> listaSkola = db.Skola.Select(s => new SelectListItem
            {
                Value = s.Id.ToString(),
                Text=s.Naziv
            }).ToList();
            List<SelectListItem> listaPredmeta = db.Predmet.Select(p => new SelectListItem
            {
                Value=p.Id.ToString(),
                Text=p.Naziv
            }).ToList();

            model.SkolaLista = listaSkola;
            model.NastavnikImePrezime =nast.Ime+" "+nast.Prezime;
            model.SkolskaGodinaOznaka = db.SkolskaGodina.Where(s => s.Aktuelna == true).Select(s => s.Naziv).FirstOrDefault();
            model.SkolskaGodinaID = db.SkolskaGodina.Where(s => s.Aktuelna == true).Select(s => s.Id).FirstOrDefault();
            model.DatumIspita = DateTime.Now;
            model.PredmetLista = listaPredmeta;

            return View(model);
        }
        public IActionResult Snimi(OdrzanaNastavaDodajVM model)
        {
            MaturskiIspit ispit = new MaturskiIspit();

            ispit.SkolaID = model.SkolaID;
            ispit.NastavnikID = model.NastavnikID;
            ispit.SkolskaGodinaID = model.SkolskaGodinaID;
            ispit.DatumIspita = model.DatumIspita;
            ispit.PredmetID = model.PredmetID;

            db.MaturskiIspit.Add(ispit);
            db.SaveChanges();

            return Redirect("/OdrzanaNastava/Prikaz?NastavnikID="+ispit.NastavnikID);
        }

        public IActionResult Uredi(int MaturskiIspitID)
        {
            MaturskiIspit maturski = db.MaturskiIspit
                .Where(m => m.MaturskiIspitID == MaturskiIspitID)
                .Include(m => m.Predmet).FirstOrDefault();
            OdrzanaNastavaUrediVM model =new OdrzanaNastavaUrediVM();

            model.MaturskiIspitID = MaturskiIspitID;
            model.DatumIspita = maturski.DatumIspita;
            model.PredmetNaziv = maturski.Predmet.Naziv;
            model.Napomena = maturski.Napomena;

            return View(model);
        }

        public IActionResult SnimiUredjivanje(OdrzanaNastavaUrediVM model)
        {
            MaturskiIspit ispit = db.MaturskiIspit.Find(model.MaturskiIspitID);
            ispit.Napomena = model.Napomena;
            db.SaveChanges();

            return Redirect("/OdrzanaNastava/Uredi?MaturskiIspitID=" + model.MaturskiIspitID);
        }
    }
}
