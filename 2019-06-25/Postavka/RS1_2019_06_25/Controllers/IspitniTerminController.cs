using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RS1_2019_06_25.EF;
using RS1_2019_06_25.EntityModels;
using RS1_2019_06_25.VM;

namespace RS1_2019_06_25.Controllers
{
    public class IspitniTerminController : Controller
    {
        private readonly MojContext db;

        public IspitniTerminController(MojContext db)
        {
            this.db = db;
        }

        public IActionResult Index()
        {
            IspitniTerminIndexVM model =new IspitniTerminIndexVM();

            List<IspitniTerminIndexVM.Row> lista = db.Angazovan.Select(a => new IspitniTerminIndexVM.Row
            {
                AngazovanID=a.Id,
                NazivPredmeta=a.Predmet.Naziv,
                AkademskaGodina=a.AkademskaGodina.Opis,
                ImePrezimeNastavnika=a.Nastavnik.Ime+" "+a.Nastavnik.Prezime,
                BrojOdrzanihCasova=db.OdrzaniCas.Where(c=>c.AngazovaniId == a.Id).Count(),
                BrojStudenataNaPredmetu=db.SlusaPredmet.Where(c=>c.AngazovanId==a.Id).Count()
            }).OrderBy(a=>a.NazivPredmeta).ToList();
            model.ListaAngazmana = lista;
            return View(model);
        }
        public IActionResult Prikaz(int AngazmanID)
        {
            IspitniTerminPrikazVM model = new IspitniTerminPrikazVM();

            model.AngazmanID = AngazmanID;

            Angazovan ang = db.Angazovan.Include(a => a.Predmet)
                .Include(a => a.Nastavnik).Include(a => a.AkademskaGodina)
                .Where(a => a.Id == AngazmanID).FirstOrDefault();
            model.PredmetNaziv = ang.Predmet.Naziv;
            model.NastavnikNaziv = ang.Nastavnik.Ime + " " + ang.Nastavnik.Prezime;
            model.AkademskaGodinaNaziv = ang.AkademskaGodina.Opis;

            List<IspitniTerminPrikazVM.Row> lista = db.IspitniTermin
                .Where(i=>i.AngazovanID==AngazmanID)
                .Select(i => new IspitniTerminPrikazVM.Row
            {
                IspitniTerminID=i.IspitniTerminID,
                DatumIspita=i.DatumIspita,
                BrojNisuPolozili=db.IspitniTerminStavke.Where(s=>s.IspitniTerminID==i.IspitniTerminID&& s.Ocjena==5).Count(),
                BrojPrijavili=db.IspitniTerminStavke.Where(st=>st.IspitniTerminID==i.IspitniTerminID ).Count(),
                IsZakljucano=i.Zakljucano
            }).ToList();
            model.listaIspita = lista;
            return View(model);
        }
        public IActionResult Dodaj(int AngazmanID)
        {
            IspitniTerminDodajVM model = new IspitniTerminDodajVM();
            model.AngazmanID = AngazmanID;

            Angazovan ang = db.Angazovan.Include(a => a.Predmet)
                .Include(a => a.Nastavnik).Include(a => a.AkademskaGodina)
                .Where(a => a.Id == AngazmanID).FirstOrDefault();
            model.PredmetNaziv = ang.Predmet.Naziv;
            model.NastavnikNaziv = ang.Nastavnik.Ime + " " + ang.Nastavnik.Prezime;
            model.AkademskaGodinaNaziv = ang.AkademskaGodina.Opis;

            model.DatumIspita = DateTime.Today;

            return View(model);
        }
        public IActionResult Snimi(IspitniTerminDodajVM model)
        {
            IspitniTermin novi = new IspitniTermin();
            novi.AngazovanID = model.AngazmanID;
            novi.IspitniTerminID = model.IspitniTerminID;
            novi.DatumIspita = model.DatumIspita;
            novi.Zakljucano = false;
            novi.Napomena = model.Napomena;

            db.IspitniTermin.Add(novi);
            db.SaveChanges();

            return Redirect("/IspitniTermin/Prikaz?AngazmanID=" + model.AngazmanID);
        }

        public IActionResult Detalji(int IspitniTerminID)
        {
            IspitniTerminDetaljiVM model = new IspitniTerminDetaljiVM();

            IspitniTermin termin = db.IspitniTermin
                .Include(i => i.Angazovan.Predmet)
                .Include(i => i.Angazovan.Nastavnik)
                .Include(i => i.Angazovan.AkademskaGodina)
                .Where(i => i.IspitniTerminID == IspitniTerminID)
                .SingleOrDefault();
            model.IspitniTerminID = termin.IspitniTerminID;
            model.AngazmanID = termin.Angazovan.Id;
            model.PredmetNaziv = termin.Angazovan.Predmet.Naziv;
            model.NastavnikNaziv=termin.Angazovan.Nastavnik.Ime+" "+termin.Angazovan.Nastavnik.Prezime;
            model.AkademskaGodinaNaziv = termin.Angazovan.AkademskaGodina.Opis;
            model.DatumIspita = termin.DatumIspita;
            model.Napomena = termin.Napomena;

            return View(model);
        }
    }
}
