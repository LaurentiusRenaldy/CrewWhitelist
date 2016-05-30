using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using System.Web.Script.Serialization;
using WebUI.Models;
using WebUI.Controllers;
using WebUI.Infrastructure;
using WebUI.Extension;
using MvcSiteMapProvider;
using MvcSiteMapProvider.Web.Mvc.Filters;
using Business.Abstract;
using Business.Entities;
using WebUI.Models.CrewWhitelist;

namespace WebUI.Controllers
{
    [Authorize(Roles = "admin")]
    public class CrewController : MyController
    {
		private ICrewRepository RepoCrew;
		private ILogRepository RepoLog;

        public CrewController(ICrewRepository repoCrew, ILogRepository repoLog)
			: base(repoLog)
        {
            RepoCrew = repoCrew;
        }

		[MvcSiteMapNode(Title = "Crew", ParentKey = "Dashboard",Key="IndexCrew")]
		[SiteMapTitle("Breadcrumb")]
        public ActionResult Index()
        {
            return View();
        }

        public string Binding()
        {
            //kamus
            GridRequestParameters param = GridRequestParameters.Current;

            List<Crew> items = RepoCrew.FindAll(param.Skip, param.Take, (param.Sortings != null ? param.Sortings.ToList() : null), param.Filters);
            int total = RepoCrew.Count(param.Filters);

            return new JavaScriptSerializer().Serialize(new { total = total, data = new CrewPresentationStub().MapList(items) });
        }

		[MvcSiteMapNode(Title = "Create", ParentKey = "IndexCrew")]
		[SiteMapTitle("Breadcrumb")]
        public ActionResult Create()
        {
			
            CrewFormStub formStub = new CrewFormStub();

            return View("Form", formStub);
        }

        [HttpPost]
		[SiteMapTitle("Breadcrumb")]
        public ActionResult Create(CrewFormStub model)
        {
            //bool isNameExist = RepoContractor.Find().Where(p => p.name == model.Name).Count() > 0;
            
            if (ModelState.IsValid)
            {
                Crew dbItem = new Crew();
                dbItem = model.GetDbObject(dbItem);
                dbItem.tanggal_daftar = DateTime.Now;
                string temp = dbItem.tanggal_daftar.ToString("ddMMyyyy") + (RepoCrew.Count() + 1).ToString("D3");
                dbItem.barcode = long.Parse(temp);

                try
                {
                    RepoCrew.Save(dbItem);
                }
                catch (Exception e)
                {
                    return View("Form", model);
                }

                //message
                string template = HttpContext.GetGlobalResourceObject("MyGlobalMessage", "CreateSuccess").ToString();
                this.SetMessage(model.Name, template);

                return RedirectToAction("Index");
            }
            else
            {
                return View("Form", model);
            }
        }

		[MvcSiteMapNode(Title = "Edit", ParentKey = "IndexCrew", Key = "EditCrew", PreservedRouteParameters = "barcode")]
		[SiteMapTitle("Breadcrumb")]
        public ActionResult Edit(long barcode)
        {
            Crew crew = RepoCrew.FindByPk(barcode);
            CrewFormStub formStub = new CrewFormStub(crew);
            return View("Form", formStub);
        }

        [HttpPost]
		[SiteMapTitle("Breadcrumb")]
        public ActionResult Edit(CrewFormStub model)
        {
            //bool isNameExist = RepoKompetitor.Find().Where(p => p.name == model.Name && p.id != model.Id).Count() > 0;

            if (ModelState.IsValid)
            {
                Crew dbItem = RepoCrew.FindByPk(model.Barcode);
                DateTime temp = dbItem.tanggal_daftar;
                dbItem = model.GetDbObject(dbItem);
                dbItem.tanggal_daftar = temp;

                try
                {
                    RepoCrew.Save(dbItem);
                }
                catch (Exception e)
                { 
                    return View("Form", model);
                }

                //message
                string template = HttpContext.GetGlobalResourceObject("MyGlobalMessage", "CreateSuccess").ToString();
                this.SetMessage(model.Name, template);

                return RedirectToAction("Index");
            }
            else
            {
                return View("Form", model);
            }
        }

		[HttpPost]
		public JsonResult Delete(long barcode)
        {
			string template = "";
			ResponseModel response = new ResponseModel(true);
			Crew dbItem = RepoCrew.FindByPk(barcode);

            RepoCrew.Delete(dbItem);

            return Json(response);
        }
	}
}

