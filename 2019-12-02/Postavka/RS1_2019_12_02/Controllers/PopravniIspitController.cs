using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RS1_2019_12_02.EF;
using RS1_2019_12_02.VM;
using RS1_2019_12_02.EntityModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace RS1_2019_12_02.Controllers
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

            List<PopravniIspitIndexVM.Row> lista = db.Odjeljenje.Select(o => new PopravniIspitIndexVM.Row
            {
                OdjeljenjeID = o.Id,
                SkolskaGodinaOznaka = o.SkolskaGodina.Naziv,
                SkolaOznaka = o.Skola.Naziv,
                OdjeljenjeOznaka = o.Oznaka
            }).OrderBy(o => o.SkolskaGodinaOznaka + o.OdjeljenjeOznaka).ToList();

            model.ListaOdjeljenja = lista;

            return View(model);
        }

        public IActionResult Prikaz(int OdjeljenjeID)
        {
            PopravniIspitPrikazVM model = new PopravniIspitPrikazVM();
            model.OdjeljenjeID = OdjeljenjeID;

            Odjeljenje odjel = db.Odjeljenje
                .Include(o => o.Skola).Include(o => o.SkolskaGodina)
                .Where(o => o.Id == OdjeljenjeID).SingleOrDefault();

            model.OdjeljenjeOznaka = odjel.Oznaka;
            model.SkolaOznaka = odjel.Skola.Naziv;
            model.SkolGodOznaka = odjel.SkolskaGodina.Naziv;


            List<PopravniIspitPrikazVM.Row> lista = db.PopravniIspit
                .Where(i => i.OdjeljenjeID == OdjeljenjeID).Select(i => new PopravniIspitPrikazVM.Row
                {
                    PopravniIspitID = i.PopravniIspitID,
                    DatumIspita = i.DatumIspita,
                    Predmet = i.Predmet.Naziv,
                    BrojNaPopravnom = db.PopravniIspitStavke.Where(p=>p.PopravniIspitID==i.PopravniIspitID
                    && p.IsPristupio==true).Count(),
                    BrojPolozenih = db.PopravniIspitStavke.Where(ps=>ps.PopravniIspitID==i.PopravniIspitID
                    && ps.Bodovi>50).Count()
                }).ToList();
            model.listaIspita = lista;
            return View(model);
        }

        public IActionResult Dodaj(int OdjeljenjeID)
        {
            PopravniIspitDodajVM model = new PopravniIspitDodajVM();

            Odjeljenje odjel = db.Odjeljenje
                .Include(o => o.Skola).Include(o => o.SkolskaGodina)
                .Where(o => o.Id == OdjeljenjeID).SingleOrDefault();

            List<SelectListItem> listaPredmeta = db.Predmet.Select(p => new SelectListItem
            {
                Value = p.Id.ToString(),
                Text = p.Naziv
            }).ToList();

            model.DatumIspita = DateTime.Today;
            model.OdjeljenjeOznaka = odjel.Oznaka;
            model.SkolaOznaka = odjel.Skola.Naziv;
            model.SkolGodOznaka = odjel.SkolskaGodina.Naziv;
            model.Predmet = listaPredmeta;

            return View(model);
        }

        public IActionResult Snimi(PopravniIspitDodajVM model)
        {
            PopravniIspit popIspit = new PopravniIspit();
            popIspit.OdjeljenjeID = model.OdjeljenjeID;
            popIspit.DatumIspita = model.DatumIspita;
            popIspit.PredmetID = model.PredmetID;

            db.PopravniIspit.Add(popIspit);
            db.SaveChanges();

          
            List<OdjeljenjeStavka> naPredmetu = db.DodjeljenPredmet
                .Where(p => p.PredmetId == popIspit.PredmetID && p.ZakljucnoKrajGodine==1)
                .Select(p => p.OdjeljenjeStavka).ToList();

            foreach (var x in naPredmetu)
            {
                PopravniIspitStavke ZaDodat = new PopravniIspitStavke
                {
                    PopravniIspitID = popIspit.PopravniIspitID,
                    OdjeljenjeStavkaID = x.Id,
                    IsPristupio = false,
                    Bodovi = 0
                };
                db.PopravniIspitStavke.Add(ZaDodat);
            }
            db.SaveChanges();

            int brojacNegativnih;
            foreach (var ucenik in db.OdjeljenjeStavka)
            {
                brojacNegativnih = 0;
                foreach (var pred in db.DodjeljenPredmet)
                {
                    if(ucenik.Id==pred.OdjeljenjeStavkaId)
                    {
                        if (pred.ZakljucnoKrajGodine == 1)
                            brojacNegativnih++;
                    }
                }
                if(brojacNegativnih>=3)
                {
                    PopravniIspitStavke ZaDodat = new PopravniIspitStavke
                    {
                        PopravniIspitID = popIspit.PopravniIspitID,
                        OdjeljenjeStavkaID = ucenik.Id,
                        IsPristupio = false,
                        Bodovi = -1
                    };
                    db.PopravniIspitStavke.Add(ZaDodat);
                }
            }
            db.SaveChanges();

            return Redirect("/PopravniIspit/Prikaz?OdjeljenjeID="+popIspit.OdjeljenjeID);
        }

        public IActionResult Uredi(int PopravniIspitID)
        {
            PopravniIspitUrediVM model =new PopravniIspitUrediVM();

            PopravniIspit popIspit = db.PopravniIspit
                .Include(i => i.Odjeljenje.Skola).Include(i => i.Predmet)
                .Include(i => i.Odjeljenje.SkolskaGodina)
                .Where(i => i.PopravniIspitID == PopravniIspitID).SingleOrDefault();

            model.PopravniIspitID = PopravniIspitID;
            model.OdjeljenjeID = popIspit.OdjeljenjeID;
            model.OdjeljenjeOznaka = popIspit.Odjeljenje.Oznaka;
            model.SkolaID = popIspit.Odjeljenje.Skola.Id;
            model.SkolaOznaka = popIspit.Odjeljenje.Skola.Naziv;
            model.SkolskaGodinaID = popIspit.Odjeljenje.SkolskaGodina.Id;
            model.SkolGodOznaka = popIspit.Odjeljenje.SkolskaGodina.Naziv;
            model.SkolskaGodinaID = popIspit.Odjeljenje.SkolskaGodina.Id;
            model.SkolGodOznaka = popIspit.Odjeljenje.SkolskaGodina.Naziv;
            model.DatumIspita = popIspit.DatumIspita;
            model.PredmetID = popIspit.Predmet.Id;
            model.PredmetOznaka = popIspit.Predmet.Naziv;

            return View(model);
        }
    }
}
