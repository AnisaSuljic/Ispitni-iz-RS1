using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RS1_2019_06_25.EF;
using RS1_2019_06_25.EntityModels;
using RS1_2019_06_25.VM;

namespace RS1_2019_06_25.Controllers
{
    public class AjaxController : Controller
    {
        private readonly MojContext db;

        public AjaxController(MojContext db)
        {
            this.db = db;
        }

        public IActionResult Index(int IspitniTerminID)
        {
            AjaxIndexVM model = new AjaxIndexVM();

            model.IspitniTerminID = IspitniTerminID;
            List<AjaxIndexVM.Row> lista = db.IspitniTerminStavke
                .Where(i=>i.IspitniTerminID==IspitniTerminID)
                .Select(i => new AjaxIndexVM.Row
            {
                IspitniTerminStavkeID=i.IspitniTerminStavkeID,
                StudentIme=i.Student.Ime,
                IsPristupio=i.IsPristupio,
                Ocjena=i.Ocjena
            }).ToList();

            model.ListaIspitniTerminStavke = lista;
            return PartialView(model);
        }
        public IActionResult Dodaj(int IspitniTerminID)
        {
            AjaxDodajVM model = new AjaxDodajVM();

            model.IspitniTerminID = IspitniTerminID;
            
            List<SelectListItem> listaSud = db.Student
                .Select(s => new SelectListItem
            {
                Value=s.Id.ToString(),
                Text=s.BrojIndeksa+"-"+s.Ime+" "+s.Prezime,
            }).ToList();

            model.Studenti = listaSud;

            return PartialView(model);
        }
        public IActionResult Snimi(AjaxDodajVM model)
        {
            IspitniTerminStavke novi = new IspitniTerminStavke();

            novi.IspitniTerminID = model.IspitniTerminID;
            novi.IspitniTerminStavkeID = model.IspitniTerminStavkeID;
            novi.StudentID = model.StudentId;
            novi.IsPristupio = model.Pristupio;
            novi.Ocjena = model.Ocjena;

            db.IspitniTerminStavke.Add(novi);
            db.SaveChanges();

            return Redirect("/IspitniTermin/Detalji?IspitniTerminID=" + novi.IspitniTerminID);
        }
    }
}
