using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using RS1_2020_01_30.EF;
using RS1_2020_01_30.EntityModels;
using RS1_2020_01_30.VM;

namespace RS1_2020_01_30.Controllers
{
    public class AjaxController : Controller
    {
        private readonly MojContext db;

        public AjaxController(MojContext _db)
        {
            db = _db;
        }
        public IActionResult Index(int TakmID)
        {

            AjaxIndexVM model = new AjaxIndexVM();
            model.TakmicenjeID = TakmID;
            model.IsZakljucano = false;
            List<AjaxIndexVM.Row> lista = db.TakmicenjeUcesnik.Where(t => t.TakmicenjeId == TakmID).Select(t => new AjaxIndexVM.Row
            {
                TakmicenjeUcesnikId = t.TakmicenjeUcesnikID,
                Odjeljenje = t.OdjeljenjeStavka.Odjeljenje.Oznaka,
                BrojDnevnik = t.OdjeljenjeStavka.BrojUDnevniku,
                IsPristupio = t.IsPristupio,
                BodoviRezultat = t.Bodovi
            }).ToList();

            model.ListaTakmUces = lista;
            return PartialView(model);
        }

        public IActionResult Dodaj(int TakmicenjeID)
        {
            var TrenutnoTakmicenje = db.Takmicenje.Find(TakmicenjeID);

            var AktivniTakmicari = db.TakmicenjeUcesnik
                .Where(i => i.TakmicenjeId == TakmicenjeID)
                .Select(i => i.OdjeljenjeStavkaID);

            AjaxDodajUrediVM model = new AjaxDodajUrediVM();
            model.TakmicenjeID = TakmicenjeID;
            List<SelectListItem> ucesnici = db.OdjeljenjeStavka
                                        .Where(i=>i.Odjeljenje.Razred==TrenutnoTakmicenje.Razred
                                        && !AktivniTakmicari.Contains(i.Id))
                                        .Select(u => new SelectListItem
                                        {
                                            Value=u.Id.ToString(),
                                            Text=u.Odjeljenje.Oznaka+"-"+u.Ucenik.ImePrezime
                                        }).ToList();
            model.listaUcesnika = ucesnici;

            return PartialView("DodajUredi",model);
        }
        public IActionResult Uredi(int TakmicenjeUcID)
        {
            var takmicar = db.TakmicenjeUcesnik.Where(i => i.TakmicenjeUcesnikID == TakmicenjeUcID).FirstOrDefault();

            AjaxDodajUrediVM model = new AjaxDodajUrediVM();
            model.TakmicenjeID = takmicar.TakmicenjeId;
            model.UcesnikID = takmicar.TakmicenjeUcesnikID;
            model.listaUcesnika = db.TakmicenjeUcesnik
                .Where(i => i.TakmicenjeUcesnikID == TakmicenjeUcID)
                .Select(i => new SelectListItem
                {
                    Value = i.TakmicenjeUcesnikID.ToString(),
                    Text = i.OdjeljenjeStavka.Odjeljenje.Oznaka + "-" + i.OdjeljenjeStavka.Ucenik.ImePrezime
                }).ToList();

            model.Bodovi = db.TakmicenjeUcesnik.Where(i => i.TakmicenjeUcesnikID == TakmicenjeUcID)
                .Select(i => i.Bodovi).FirstOrDefault();

            db.SaveChanges();

            return PartialView("DodajUredi", model);
        }
        public IActionResult SnimiUcesnika(AjaxDodajUrediVM model)
        {
            var takmicar = db.TakmicenjeUcesnik.Where(i => i.TakmicenjeUcesnikID == model.UcesnikID).FirstOrDefault();

            if (takmicar != null)
            {
                takmicar.Bodovi = model.Bodovi;
                db.SaveChanges();
            }
            else if(model.UcesnikID!=0)
            {
                TakmicenjeUcesnik noviUcesnik = new TakmicenjeUcesnik();
                noviUcesnik.TakmicenjeId = model.TakmicenjeID;
                noviUcesnik.Bodovi = model.Bodovi;
                noviUcesnik.OdjeljenjeStavkaID = model.UcesnikID;
                if (model.Bodovi == 0)
                    noviUcesnik.IsPristupio = false;
                else
                    noviUcesnik.IsPristupio = true;

                db.Add(noviUcesnik);
                db.SaveChanges();
            }

            return Redirect("/Takmicenje/Rezultati?idtakm=" + model.TakmicenjeID);
        }

        public IActionResult UpdateBodovi(int id, int bodovi)
        {
            var takmUces = db.TakmicenjeUcesnik.Find(id);
            takmUces.Bodovi = bodovi;
            db.SaveChanges();
            return Redirect("/Takmicenje/Rezultati/" + takmUces.TakmicenjeId);
        }

        public IActionResult Pristupio(int takmUcesnikID)
        {
            var takmicenjeUcesnik = db.TakmicenjeUcesnik.Find(takmUcesnikID);
            takmicenjeUcesnik.IsPristupio = !takmicenjeUcesnik.IsPristupio;
            db.SaveChanges();

            return Redirect("/Takmicenje/Rezultati?idtakm=" + takmicenjeUcesnik.TakmicenjeId);
        }

        public IActionResult UcenikNijePristupio(int idTakmUc)
        {
            return Pristupio(idTakmUc);
        }

        public IActionResult UcenikJePristupio(int idTakmUc)
        {
            return Pristupio(idTakmUc);
        }
    }
}
