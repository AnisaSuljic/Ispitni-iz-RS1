using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RS1_2019_11_04.EF;
using RS1_2019_11_04.VM;
using RS1_2019_11_04.EntityModels;
using Microsoft.EntityFrameworkCore;

namespace RS1_2019_11_04.Controllers
{
    public class AjaxController : Controller
    {
        private readonly MojContext db;

        public AjaxController(MojContext db)
        {
            this.db = db;
        }

        public IActionResult Index(int IspitID)
        {
            AjaxIndexVM model = new AjaxIndexVM();
            model.PopravniIspitID = IspitID;

            List<AjaxIndexVM.Row> lista = db.PopravniIspitStavke
                .Where(i => i.PopravniIspitID == IspitID).Select(i => new AjaxIndexVM.Row
                {
                    PopravniIspitStavkeID=i.PopravniIspitStavkeID,
                    UcenikNaziv=i.OdjeljenjeStavke.Ucenik.ImePrezime,
                    Odjeljenje=i.OdjeljenjeStavke.Odjeljenje.Oznaka,
                    BrojDnevnik=i.OdjeljenjeStavke.BrojUDnevniku,
                    IsPrisutan=i.IsPrisutan,
                    Bodovi=i.Bodovi
                }).ToList();

            model.ListPopravniIspitStavke = lista;

            return PartialView(model);
        }
        public IActionResult NijePristupio(int ID)
        {
            return Pristupanje(ID);
        }
        public IActionResult Pristupio(int ID)
        {
            return Pristupanje(ID);
        }
        public IActionResult Pristupanje(int ID)
        {
            PopravniIspitStavke pop = db.PopravniIspitStavke.Find(ID);
            pop.IsPrisutan = !pop.IsPrisutan;
            db.SaveChanges();
            return Redirect("/PopravniIspit/Uredi?IspitID=" + ID);
        }

        public IActionResult Uredi(int IspitID)
        {
            AjaxUrediVM model = new AjaxUrediVM();
            model.PopravniIspitID = IspitID;

            PopravniIspitStavke popStavke = db.PopravniIspitStavke
                .Include(p => p.OdjeljenjeStavke.Ucenik).Where(p => p.PopravniIspitStavkeID == IspitID)
                .SingleOrDefault();

            model.UcenikNaziv = popStavke.OdjeljenjeStavke.Ucenik.ImePrezime;
            model.Bodovi = popStavke.Bodovi;

            return PartialView(model);
        }
        public IActionResult Snimi(AjaxUrediVM model)
        {
            PopravniIspitStavke popStavke = db.PopravniIspitStavke
                .Include(p => p.OdjeljenjeStavke.Ucenik).Where(p => p.PopravniIspitStavkeID == model.PopravniIspitID)
                .SingleOrDefault();

            popStavke.Bodovi = model.Bodovi;
            db.SaveChanges();
            return Redirect("/PopravniIspit/Uredi?IspitID=" + popStavke.PopravniIspitID);
        }
    }
}
