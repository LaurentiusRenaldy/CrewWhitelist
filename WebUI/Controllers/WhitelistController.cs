using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
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
    [Authorize(Roles="adminwhitelist")]
    public class WhitelistController : MyController
    {
		private IWhitelistRepository RepoWhitelist;
		private ILogRepository RepoLog;

        public WhitelistController(IWhitelistRepository repoWhitelist, ILogRepository repoLog)
			: base(repoLog)
        {
            RepoWhitelist = repoWhitelist;
        }

		[MvcSiteMapNode(Title = "Whitelist", ParentKey = "Dashboard",Key="IndexWhitelist")]
		[SiteMapTitle("Breadcrumb")]
        public ActionResult Index()
        {
            return View();
        }

        public string Binding()
        {
            //kamus
            GridRequestParameters param = GridRequestParameters.Current;

            List<Whitelist> items = RepoWhitelist.FindAll(param.Skip, param.Take, (param.Sortings != null ? param.Sortings.ToList() : null), param.Filters);
            int total = RepoWhitelist.Count(param.Filters);

            return new JavaScriptSerializer().Serialize(new { total = total, data = new WhitelistPresentationStub().MapList(items) });
        }

        public string BindingToday()
        {
            //kamus
            GridRequestParameters param = GridRequestParameters.Current;

            Business.Infrastructure.FilterInfo filters;

            filters = new Business.Infrastructure.FilterInfo
            {
                Filters = new List<Business.Infrastructure.FilterInfo>
                {
                    new Business.Infrastructure.FilterInfo { Field = "tanggal_awal", Operator = "lte", Value = DateTime.Now.ToString() },
                    new Business.Infrastructure.FilterInfo { Field = "tanggal_akhir", Operator = "gte", Value = DateTime.Now.ToString() },
                },
                Logic = "and"
            };

            List<Whitelist> items = RepoWhitelist.FindAll(null, null, null,filters);
            int total = items.Count();

            return new JavaScriptSerializer().Serialize(new { total = total, data = new WhitelistPresentationStub().MapList(items) });
        }

		[MvcSiteMapNode(Title = "Create", ParentKey = "IndexWhitelist")]
		[SiteMapTitle("Breadcrumb")]
        public ActionResult Create()
        {

            WhitelistFormStub formStub = new WhitelistFormStub();

            return View("Form", formStub);
        }

        [HttpPost]
		[SiteMapTitle("Breadcrumb")]
        public ActionResult Create(WhitelistFormStub model)
        {
            //bool isNameExist = RepoContractor.Find().Where(p => p.name == model.Name).Count() > 0;
            
            if (ModelState.IsValid)
            {
                Whitelist dbItem = new Whitelist();
                dbItem = model.GetDbObject(dbItem);

                try
                {
                    RepoWhitelist.Save(dbItem);
                }
                catch (Exception e)
                {
                    return View("Form", model);
                }

                //message
                string template = HttpContext.GetGlobalResourceObject("MyGlobalMessage", "CreateSuccess").ToString();
                this.SetMessage(model.Barcode+"", template);

                return RedirectToAction("Index");
            }
            else
            {
                return View("Form", model);
            }
        }

		[MvcSiteMapNode(Title = "Edit", ParentKey = "IndexWhitelist", Key = "EditWhitelist", PreservedRouteParameters = "id")]
		[SiteMapTitle("Breadcrumb")]
        public ActionResult Edit(int id)
        {
            Whitelist whitelist = RepoWhitelist.FindByPk(id);
            WhitelistFormStub formStub = new WhitelistFormStub(whitelist);
            return View("Form", formStub);
        }

        [HttpPost]
		[SiteMapTitle("Breadcrumb")]
        public ActionResult Edit(WhitelistFormStub model)
        {
            //bool isNameExist = RepoKompetitor.Find().Where(p => p.name == model.Name && p.id != model.Id).Count() > 0;

            if (ModelState.IsValid)
            {
                Whitelist dbItem = RepoWhitelist.FindByPk(model.Id);
                dbItem = model.GetDbObject(dbItem);

                try
                {
                    RepoWhitelist.Save(dbItem);
                }
                catch (Exception e)
                { 
                    return View("Form", model);
                }

                //message
                string template = HttpContext.GetGlobalResourceObject("MyGlobalMessage", "CreateSuccess").ToString();
                this.SetMessage(model.Barcode+"", template);

                return RedirectToAction("Index");
            }
            else
            {
                return View("Form", model);
            }
        }

		[HttpPost]
		public JsonResult Delete(int id)
        {
			string template = "";
			ResponseModel response = new ResponseModel(true);
			Whitelist dbItem = RepoWhitelist.FindByPk(id);

            RepoWhitelist.Delete(dbItem);

            return Json(response);
        }
	}
}

