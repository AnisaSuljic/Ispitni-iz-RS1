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
    public class AjaxController : Controller
    {
        private readonly MojContext db;

        public AjaxController(MojContext db)
        {
            this.db = db;
        }

        public IActionResult Index(int MaturskiID)
        {
            AjaxIndexVM model = new AjaxIndexVM();

            model.MaturskiIspitID = MaturskiID;

            List<AjaxIndexVM.Row> lista = db.MaturskiIspitStavke
                .Where(s => s.MaturskiIspitID == MaturskiID)
                .Select(s => new AjaxIndexVM.Row
                {
                    MaturskiIspitStavkaID = s.MaturskiIspitStavkeID,
                    UcenikIme = s.OdjeljenjeStavka.Ucenik.ImePrezime,
                    Prosjek = (float)db.DodjeljenPredmet
                    .Where(dp=>dp.OdjeljenjeStavkaId==s.OdjeljenjeStavkaID)
                    .Select(dp=>dp.ZakljucnoKrajGodine).Average(),
                    pristupio = s.IsPristupio,
                    bodovi = s.Bodovi
                }).ToList();
            model.listaMatStavke = lista;

            return  PartialView(model);
        }
        public IActionResult Uredi(int MatruskiStavkeID)
        {
            AjaxUrediVM model = new AjaxUrediVM();
            MaturskiIspitStavke stavke = db.MaturskiIspitStavke
                .Where(s => s.MaturskiIspitStavkeID == MatruskiStavkeID)
                .Include(s => s.OdjeljenjeStavka.Ucenik).FirstOrDefault();
            model.MaturskiIspitStavkeID = MatruskiStavkeID;
            model.UcenikIme = stavke.OdjeljenjeStavka.Ucenik.ImePrezime;
            model.Bodovi = stavke.Bodovi;

            return PartialView(model);
        }
        public IActionResult Snimi(AjaxUrediVM model)
        {
            MaturskiIspitStavke stavke = db.MaturskiIspitStavke.Find(model.MaturskiIspitStavkeID);
            stavke.Bodovi = model.Bodovi;
            db.SaveChanges();

            return Redirect("/OdrzanaNastava/Uredi?MaturskiIspitID=" + stavke.MaturskiIspitID);
        }
    }
}
