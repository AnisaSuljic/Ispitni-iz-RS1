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
            TakmicenjeIndexVM model = new TakmicenjeIndexVM();

            List<SelectListItem> listaSkola = db.Skola.Select(s => new SelectListItem
            {
                Value=s.Id.ToString(),
                Text=s.Naziv
            }).OrderBy(sk => sk.Text).ToList();

            List<int> raz = new List<int>();

            foreach (var x in db.Odjeljenje)
            {
                if (!raz.Contains(x.Razred))
                    raz.Add(x.Razred);
            }

            List<SelectListItem> razredi = raz.Select(r => new SelectListItem
            {
                Value=r.ToString(),
                Text=r.ToString()
            }).OrderBy(l=>l.Value).ToList();

            model.skoleLista = listaSkola;
            model.razrediLista = razredi;
            
            return View(model);
        }

        public IActionResult Odaberi(int skolaId=1)
        {
            TakmicenjeOdabirVM odabirModel = new TakmicenjeOdabirVM();
            List<SelectListItem> listeskola = db.Skola.Select(s => new SelectListItem
            {
                Value = s.Id.ToString(),
                Text = s.Naziv
            }).OrderBy(s => s.Text).ToList();

            odabirModel.SkoleLista = listeskola;

            odabirModel.SkolaNaziv = db.Skola.Where(s => s.Id == skolaId).Select(s => s.Naziv).FirstOrDefault();
            odabirModel.SkolaID = skolaId;

            List<TakmicenjeOdabirVM.Row> Takmicenja = db.Takmicenje.Where(t => t.SkolaID == skolaId).Select(t => new TakmicenjeOdabirVM.Row
            {
                TakmicenjeID = t.TakmicenjeID,
                PredmetNaziv = t.Predmet.Naziv,
                Razred = t.Razred,
                Datum = t.Datum,
                BrojOnihKojiNisuPristupili = t.BrojKojiNisuPristupili,
                NajboljiUcenikImePrezime = "/",
                NajboljiUcenikOdjeljenje = "/",
                NajboljiUcenikSkola = "/"
            }).ToList();

            odabirModel.listaTakmicenja = Takmicenja;

            return View(odabirModel);
        }

        //public IActionResult Odaberi(TakmicenjeIndexVM model)
        //{
        //    TakmicenjeOdabirVM odabirModel = new TakmicenjeOdabirVM();
        //    odabirModel.SkolaID= db.Skola.Where(s => s.Id == model.SkolaID).Select(s => s.Id).FirstOrDefault();
        //    odabirModel.SkolaNaziv = db.Skola.Where(s => s.Id == model.SkolaID).Select(s => s.Naziv).FirstOrDefault();
        //    odabirModel.Razred = model.RazredID;

        //    List<SelectListItem> listeskola = db.Skola.Select(s => new SelectListItem
        //    {
        //        Value=s.Id.ToString(),
        //        Text=s.Naziv
        //    }).OrderBy(s => s.Text).ToList();

        //    odabirModel.SkoleLista = listeskola;

        //    List<TakmicenjeOdabirVM.Row> Takmicenja = db.Takmicenje.Where(t=>t.Razred==model.RazredID).Select(t => new TakmicenjeOdabirVM.Row
        //    {
        //        TakmicenjeID=t.TakmicenjeID,
        //        PredmetNaziv=t.Predmet.Naziv,
        //        Razred=t.Razred,
        //        Datum=t.Datum,
        //        BrojOnihKojiNisuPristupili=t.BrojKojiNisuPristupili,
        //        NajboljiUcenikImePrezime="/",
        //        NajboljiUcenikOdjeljenje="/",
        //        NajboljiUcenikSkola="/"
        //    }).ToList();

        //    odabirModel.listaTakmicenja = Takmicenja;

        //    return View(odabirModel);
        //}
        public IActionResult Dodaj(int SkolaID)
        {
            TakmicenjeDodajVM dodajModel = new TakmicenjeDodajVM();


            List<SelectListItem> listPredmeta = db.Predmet.Select(p => new SelectListItem
            {
                Value=p.Id.ToString(),
                Text=p.Naziv+"-"+p.Razred.ToString()
            }).OrderBy(l => l.Text).ToList();


            List<int> raz = new List<int>();

            foreach (var x in db.Odjeljenje)
            {
                if (!raz.Contains(x.Razred))
                    raz.Add(x.Razred);
            }

            List<SelectListItem> razredi = raz.Select(r => new SelectListItem
            {
                Value = r.ToString(),
                Text = r.ToString()
            }).OrderBy(l => l.Value).ToList();

            dodajModel.SkolaId = SkolaID;
            dodajModel.SkolaNaziv = db.Skola.Where(s => s.Id == SkolaID).Select(s => s.Naziv).FirstOrDefault();
            dodajModel.Predmeti = listPredmeta;
            dodajModel.Razredi = razredi;
            dodajModel.Datum = DateTime.Today;            

            return View(dodajModel);
        }

        public IActionResult Snimi(TakmicenjeDodajVM dodajModel)
        {
            Takmicenje novo = new Takmicenje();

            novo.SkolaID = dodajModel.SkolaId;
            novo.PredmetID = dodajModel.PredmetID;
            novo.Razred = dodajModel.RazredID;
            novo.Datum = dodajModel.Datum;
            novo.BrojKojiNisuPristupili = db.TakmicenjeUcesnik.Where(tu => tu.TakmicenjeID == dodajModel.TakmicenjeID).Select(tu => tu.IsPristupio == false).ToList().Count;
            novo.IsZakljucano = false;

            db.Takmicenje.Add(novo);
            db.SaveChanges();

            List<OdjeljenjeStavka> zakljucno5 = db.DodjeljenPredmet
                .Where(o => o.PredmetId == dodajModel.PredmetID &&
                o.ZakljucnoKrajGodine == 5)
                .Select(o => o.OdjeljenjeStavka).ToList();

            List<OdjeljenjeStavka> listaBezPonavljanja = new List<OdjeljenjeStavka>();
            foreach (var x in zakljucno5)
            {
                if (!listaBezPonavljanja.Contains(x))
                    listaBezPonavljanja.Add(x);
            }

            foreach (var ucenik in listaBezPonavljanja)
            {
                var noviUcesnik = new TakmicenjeUcesnik
                {
                    TakmicenjeID = novo.TakmicenjeID,
                    OdjeljenjeStavkaID = ucenik.Id,
                    IsPristupio = false,
                    Bodovi = 0
                };
                db.TakmicenjeUcesnik.Add(noviUcesnik);
            }
            db.SaveChanges();
            return Redirect("/Takmicenje/Odaberi?skolaID="+novo.SkolaID);
        }

        public IActionResult Rezultati(int TakmID)
        {
            TakmicenjeRezultatiVM model = new TakmicenjeRezultatiVM();

            Takmicenje trenutnoTakm = db.Takmicenje.Include(s => s.Skola)
                .Include(p => p.Predmet).Where(t => t.TakmicenjeID == TakmID)
                .SingleOrDefault();

            model.TakmicenjeID = trenutnoTakm.TakmicenjeID;
            model.SkolaNaziv = trenutnoTakm.Skola.Naziv;
            model.PredmetNaziv = trenutnoTakm.Predmet.Naziv;
            model.Razred = trenutnoTakm.Razred;
            model.Datum = trenutnoTakm.Datum;

            return View(model);
        }

       
    }
}
