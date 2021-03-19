using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RS1_2019_12_02.EF;
using RS1_2019_12_02.VM;
using RS1_2019_12_02.EntityModels;
using Microsoft.EntityFrameworkCore;

namespace RS1_2019_12_02.Controllers
{
    public class AjaxController : Controller
    {
        private readonly MojContext db;

        public AjaxController(MojContext db)
        {
            this.db = db;
        }

        public IActionResult Index(int PopravniID)
        {
            AjaxIndexVM model = new AjaxIndexVM();

            model.PopravniIspitID = PopravniID;

            List<AjaxIndexVM.Row> lista = db.PopravniIspitStavke.Where(s => s.PopravniIspitID == PopravniID)
                .Select(s => new AjaxIndexVM.Row
                {
                    PopravniIspitStavkeID = s.PopravniIspitStavkeID,
                    UcenikNaziv = s.OdjeljenjeStavka.Ucenik.ImePrezime,
                    OdjeljenjeOznaka = s.OdjeljenjeStavka.Odjeljenje.Oznaka,
                    BrojDnevnik=s.OdjeljenjeStavka.BrojUDnevniku,
                    IsPrisutan=s.IsPristupio,
                    Bodovi= (int)s.Bodovi
                }).ToList();
            model.ListaPopravniIspitStavke = lista;

            return PartialView(model);
        }

        public IActionResult Uredi(int PopravniStavkaID)
        {
            AjaxUrediVM model = new AjaxUrediVM();

            PopravniIspitStavke popStavke = db.PopravniIspitStavke
                .Include(i => i.OdjeljenjeStavka.Ucenik)
                .Where(i => i.PopravniIspitStavkeID == PopravniStavkaID)
                .FirstOrDefault();

            model.PopravniIspitStavkaID = PopravniStavkaID;
            model.UcenikNaziv = popStavke.OdjeljenjeStavka.Ucenik.ImePrezime;
            model.Bodovi = (int)popStavke.Bodovi;

            return PartialView(model);
        }

        public IActionResult SnimiIzmjene(AjaxUrediVM model)
        {
            PopravniIspitStavke snimiIspit = db.PopravniIspitStavke.Find(model.PopravniIspitStavkaID);

            snimiIspit.Bodovi = model.Bodovi;
            db.SaveChanges();

            return Redirect("/PopravniIspit/Uredi?PopravniIspitID="+snimiIspit.PopravniIspitID);
        }

        public IActionResult NijePrisutan(int PopravniStavkaID)
        {
            return Prisustvo(PopravniStavkaID);
        }
        public IActionResult Prisutan(int PopravniStavkaID)
        {
            return Prisustvo(PopravniStavkaID);
        }

        public IActionResult Prisustvo(int ID)
        {
            PopravniIspitStavke popStav = db.PopravniIspitStavke.Find(ID);
            popStav.IsPristupio = !popStav.IsPristupio;
            db.SaveChanges();

            return Redirect("/PopravniIspit/Uredi?PopravniIspitID=" + popStav.PopravniIspitID);
        }
        
        public IActionResult UpdateBodovi(int PopStavkaID, int NoviBodovi)
        {
            PopravniIspitStavke popStav = db.PopravniIspitStavke.Find(PopStavkaID);
            popStav.Bodovi = NoviBodovi;
            db.SaveChanges();
            return Redirect("/PopravniIspit/Uredi?PopravniIspitID=" + popStav.PopravniIspitID);

        }
    }
}
