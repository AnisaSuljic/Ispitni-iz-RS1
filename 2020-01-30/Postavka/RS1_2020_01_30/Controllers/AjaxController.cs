using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RS1_2020_01_30.EF;
using RS1_2020_01_30.VM;
using RS1_2020_01_30.EntityModels;
using Microsoft.AspNetCore.Mvc.Rendering;

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

            List<AjaxIndexVM.Row> lista = db.TakmicenjeUcesnik.Where(s=>s.TakmicenjeID==TakmID).Select(u => new AjaxIndexVM.Row
            {
                TakmicenjeUcesnikID=u.TakmicenjeUcesnikID,
                OdjeljenjeOznaka=u.OdjeljenjeStavka.Odjeljenje.Oznaka,
                BrojDnevnik=u.OdjeljenjeStavka.BrojUDnevniku,
                IsPristupio=u.IsPristupio,
                Bodovi=u.Bodovi
            }).ToList();

            Takmicenje takm = db.Takmicenje.Find(TakmID);

            model.TakmicenjeID = takm.TakmicenjeID;
            model.IsZakljucano = takm.IsZakljucano;
            model.TakmUcesniciLista = lista;            

            return PartialView(model);
        }

        public IActionResult UrediUcesnika(int TakmicenjeUcId)
        {
            AjaxDodajUcesnikaVM model = new AjaxDodajUcesnikaVM();

            TakmicenjeUcesnik takmUc = db.TakmicenjeUcesnik.Find(TakmicenjeUcId);

            List<SelectListItem> listaUcenikaTakmUc = db.TakmicenjeUcesnik
                .Select(u => new SelectListItem
                {
                    Value=u.TakmicenjeUcesnikID.ToString(),
                    Text=u.OdjeljenjeStavka.Odjeljenje.Oznaka+"-"+u.OdjeljenjeStavka.Ucenik.ImePrezime
                }).OrderBy(o=>o.Text).ToList();

            model.TakmicenjeID = takmUc.TakmicenjeID;
            model.Ucenici_TakmUcID = TakmicenjeUcId;
            model.Bodovi = takmUc.Bodovi;
            model.IsPristupio = takmUc.IsPristupio;
            model.Ucenici_TakmUc = listaUcenikaTakmUc;

            return PartialView("DodajUcesnika",model);
        }
        public IActionResult DodajUcesnika(int TakmicenjeId)
        {
            AjaxDodajUcesnikaVM model = new AjaxDodajUcesnikaVM();

            Takmicenje Trenutno = db.Takmicenje.Find(TakmicenjeId);

            model.TakmicenjeID = Trenutno.TakmicenjeID;

            List<SelectListItem> Ucenici_OdjStavke = db.OdjeljenjeStavka
                .Select(u => new SelectListItem
                {
                    Value = u.Id.ToString(),
                    Text = u.Odjeljenje.Oznaka + "-" + u.Ucenik.ImePrezime
                }).OrderBy(o => o.Text).ToList();

            model.Ucenici_TakmUc = Ucenici_OdjStavke;

            return PartialView("DodajUcesnika", model);
        }
        public IActionResult SnimiUcesnika(AjaxDodajUcesnikaVM model )
        {
                TakmicenjeUcesnik uredjivanje = db.TakmicenjeUcesnik
                    .Where(o => o.TakmicenjeUcesnikID == model.Ucenici_TakmUcID).FirstOrDefault();

            if (uredjivanje != null)
            {               
                uredjivanje.Bodovi = model.Bodovi;
            }
            else
            {
                TakmicenjeUcesnik novi = new TakmicenjeUcesnik();
                novi.TakmicenjeID = model.TakmicenjeID;
                novi.OdjeljenjeStavkaID = model.Ucenici_TakmUcID;
                novi.Bodovi = model.Bodovi;
                novi.IsPristupio = false;
                db.TakmicenjeUcesnik.Add(novi);
            }
            db.SaveChanges();

            return Redirect("/Takmicenje/Rezultati?TakmID=" + model.TakmicenjeID);
        }

        public IActionResult UpdateBodovi(int TakmUcID, int NoviBodovi)
        {
            TakmicenjeUcesnik takmUc = db.TakmicenjeUcesnik.Find(TakmUcID);

            takmUc.Bodovi = NoviBodovi;
            db.SaveChanges();
            return Redirect("/Takmicenje/Rezultati?TakmID=" + takmUc.TakmicenjeID);
        }


        public IActionResult Pristupio(int TakmicenjeUcId)
        {
            return PromjenaPristupa(TakmicenjeUcId);
        }
        public IActionResult NijePristupio(int TakmicenjeUcId)
        {
            return PromjenaPristupa(TakmicenjeUcId);
        }
        public IActionResult PromjenaPristupa(int TakmicenjeUcId)
        {
            TakmicenjeUcesnik takmUc = db.TakmicenjeUcesnik.Find(TakmicenjeUcId);

            if (takmUc.IsPristupio)
                takmUc.IsPristupio = false;
            else
                takmUc.IsPristupio = true;
            db.SaveChanges();
            return Redirect("/Takmicenje/Rezultati?TakmID=" + takmUc.TakmicenjeID);
        }

        public IActionResult Zakljucaj(int TakmID)
        {
            Takmicenje takm = db.Takmicenje.Find(TakmID);
            takm.IsZakljucano = true;
            db.SaveChanges();

            return Redirect("/Takmicenje/Rezultati?TakmID=" + TakmID);
        }
    }
}
