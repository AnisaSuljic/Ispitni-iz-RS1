using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RS1_2020_01_30.EF;
using RS1_2020_01_30.EntityModels;
using RS1_2020_01_30.VM;

namespace RS1_2020_01_30.Controllers
{
    public class TakmicenjeController : Controller
    {
        private readonly MojContext db;

        public TakmicenjeController(MojContext _db)
        {
            db = _db;
        }

        public IActionResult Index()
        {
            List<SelectListItem> skoleLista = db.Skola.Select(s => new SelectListItem
            {
                Value=s.Id.ToString(),
                Text=s.Naziv
            }).ToList();

            List<int> sviRazredi = new List<int>();
            foreach (Odjeljenje x in db.Odjeljenje)
            {
                if(!sviRazredi.Contains(x.Razred))
                {
                    sviRazredi.Add(x.Razred);
                }
            }

            List<SelectListItem> razrediLista = sviRazredi.Select(r => new SelectListItem
            {
                Value=r.ToString(),
                Text=r.ToString()
            }).ToList();

            TakmicenjeIndexVM model = new TakmicenjeIndexVM();
            model.listaSkola = skoleLista;
            model.listaRazreda = razrediLista;

            return View(model);
        }

        public IActionResult Prikaz(TakmicenjeIndexVM ind)
        {
            TakmicenjePrikazVM model = new TakmicenjePrikazVM();
            model.OdabranaSkola = db.Skola.Find(ind.SkolaID).Naziv;
            model.OdabranaSkolaID = ind.SkolaID;
            model.OdabraniRazred = ind.razred;


            List<TakmicenjePrikazVM.Row> lista = db.Takmicenje
                .Where(t => t.SkolaID == ind.SkolaID /*&& t.Razred == ind.razred*/)
                .Select(t => new TakmicenjePrikazVM.Row
                {
                    TakmicenjeID = t.TakmicenjeID,
                    Predmet = t.Predmet.Naziv,
                    Razred = t.Razred,
                    Datum = t.Datum,
                    BrojUcesnik_NisuPristupili = db.TakmicenjeUcesnik.Where(p => p.IsPristupio == false).Count(),
                    NajboljiUcesnik = "/"
                    //NajboljiUcesnik= db.TakmicenjeUcesnik.Where(b => b.Bodovi == db.TakmicenjeUcesnik
                    //                                             .Where(tu => tu.TakmicenjeId == t.TakmicenjeID).Select(o => o.Bodovi).Max())
                    //                                               .Select(o => o.OdjeljenjeStavka.Ucenik.ImePrezime).FirstOrDefault()
                }).ToList();

          

            model.ListaTaknmicenja = lista;
            return View(model);
        }

        public IActionResult Dodaj(int idSkola)
        {
            List<SelectListItem> predmeti = db.Predmet.Select(p => new SelectListItem
            {
                Value=p.Id.ToString(),
                Text=p.Naziv+"-"+p.Razred.ToString()
            }).ToList();

            List<int> sviRazredi = new List<int>();
            foreach (Odjeljenje x in db.Odjeljenje)
            {
                if (!sviRazredi.Contains(x.Razred))
                {
                    sviRazredi.Add(x.Razred);
                }
            }

            List<SelectListItem> razrediLista = sviRazredi.Select(r => new SelectListItem
            {
                Value = r.ToString(),
                Text = r.ToString()
            }).ToList();

            TakmicenjeDodajVM model = new TakmicenjeDodajVM();
            model.Skola = db.Skola.Where(s => s.Id == idSkola).Select(s => s.Naziv).FirstOrDefault();
            model.ListaPredmeta = predmeti;
            model.listaRazreda = razrediLista;
            model.Datum = DateTime.Today;

            model.SkolaID = idSkola;
            
            

            return View(model);
        }

        public IActionResult Snimi(TakmicenjeDodajVM model)
        {
            Takmicenje novoTakmicenje = new Takmicenje();

            novoTakmicenje.PredmetID = model.PredmetID;
            novoTakmicenje.SkolaID = model.SkolaID;
            novoTakmicenje.Datum = model.Datum;
            novoTakmicenje.Razred = model.RazredID;

            db.Takmicenje.Add(novoTakmicenje);
            db.SaveChanges();


            return Redirect("/Takmicenje/Index");
        }

        public IActionResult Rezultati(int idtakm)
        {
            var takmicenje = db.Takmicenje
                .Include(t => t.Predmet)
                .Include(t => t.Skola)
                .Where(i => i.TakmicenjeID == idtakm).SingleOrDefault();

            TakmicenjeRezultatiVM model = new TakmicenjeRezultatiVM();
            model.TakmicenjeID = idtakm;
            model.Skola = takmicenje.Skola.Naziv;
            model.SkolaID = takmicenje.SkolaID;
            model.Predmet = takmicenje.Predmet.Naziv;
            model.Razred = takmicenje.Razred;
            model.Datum = takmicenje.Datum;
            

            return View(model);
        }
        public IActionResult Pristupio(int takm)
        {
            TakmicenjeUcesnik x = db.TakmicenjeUcesnik.Where(t => t.TakmicenjeId == takm).FirstOrDefault();
            if (x.IsPristupio == true)
                x.IsPristupio = false;
            else
                x.IsPristupio = true;

            return Redirect("/Takmicenje/Rezultati?idtakm=" + takm);
        }

        

    }

}
