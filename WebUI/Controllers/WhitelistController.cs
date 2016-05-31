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
    [Authorize(Roles = "adminwhitelist")]
    public class WhitelistController : MyController
    {
        private IWhitelistRepository RepoWhitelist;
        private ICrewRepository RepoCrew;
        private ILogRepository RepoLog;

        public WhitelistController(IWhitelistRepository repoWhitelist, ILogRepository repoLog, ICrewRepository repoCrew)
            : base(repoLog)
        {
            RepoWhitelist = repoWhitelist;
            RepoCrew = repoCrew;
        }

        [MvcSiteMapNode(Title = "Whitelist", ParentKey = "Dashboard", Key = "IndexWhitelist")]
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

            List<Whitelist> items = RepoWhitelist.FindAll(null, null, null, filters);
            int total = items.Count();

            return new JavaScriptSerializer().Serialize(new { total = total, data = new WhitelistPresentationStub().MapList(items) });
        }

        [MvcSiteMapNode(Title = "Create", ParentKey = "IndexWhitelist")]
        [SiteMapTitle("Breadcrumb")]
        public ActionResult Create()
        {

            WhitelistFormStub formStub = new WhitelistFormStub();
            List<object> newList = new List<object>();
            foreach (var crew in RepoCrew.FindAll())
            {
                newList.Add(
                    new
                    {
                        Id = crew.barcode,
                        Name = crew.barcode + " " + crew.name
                    });
            }
            this.ViewBag.Crew = new SelectList(newList, "Name", "Id");

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
                    if (RepoWhitelist.FindAll().Where(x => x.barcode == dbItem.barcode) == null)
                    {
                        RepoWhitelist.Save(dbItem);
                    }
                    else
                    {
                        var items = RepoWhitelist.FindAll().Where(x => x.barcode == dbItem.barcode);
                        var flag = true;
                        foreach (var item in items)
                        {
                            if ((dbItem.tanggal_awal >= item.tanggal_awal && dbItem.tanggal_awal <= item.tanggal_akhir) ||
                                (dbItem.tanggal_akhir >= item.tanggal_awal && dbItem.tanggal_akhir <= item.tanggal_akhir))
                            {
                                flag = false;
                            }
                        }
                        if (flag == false)
                        {
                            ModelState.AddModelError("", "Jadwal Bentrok");
                        }
                        else if (flag == true)
                        {
                            RepoWhitelist.Save(dbItem);
                            //message
                            string template = HttpContext.GetGlobalResourceObject("MyGlobalMessage", "CreateSuccess").ToString();
                            this.SetMessage(model.Barcode + "", template);

                            return RedirectToAction("Index");
                        }
                    }
                }
                catch (Exception e)
                {
                    return View("Form", model);
                }
            }
            else
            {
                return View("Form", model);
            }
            List<object> newList = new List<object>();
            foreach (var crew in RepoCrew.FindAll())
            {
                newList.Add(
                    new
                    {
                        Id = crew.barcode,
                        Name = crew.barcode + " " + crew.name
                    });
            }
            this.ViewBag.Crew = new SelectList(newList, "Name", "Id");
            return View("Form", model);
        }

        [MvcSiteMapNode(Title = "Edit", ParentKey = "IndexWhitelist", Key = "EditWhitelist", PreservedRouteParameters = "id")]
        [SiteMapTitle("Breadcrumb")]
        public ActionResult Edit(int id)
        {
            Whitelist whitelist = RepoWhitelist.FindByPk(id);
            List<object> newList = new List<object>();
            foreach (var crew in RepoCrew.FindAll())
            {
                newList.Add(
                    new
                    {
                        Id = crew.barcode,
                        Name = crew.barcode + " " + crew.name
                    });
            }
            this.ViewBag.Crew = new SelectList(newList, "Name", "Id");

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
                    var items = RepoWhitelist.FindAll().Where(x => x.barcode == dbItem.barcode && x.id != dbItem.id);
                    var flag = true;
                    foreach (var item in items)
                    {
                        if ((dbItem.tanggal_awal >= item.tanggal_awal && dbItem.tanggal_awal <= item.tanggal_akhir) ||
                            (dbItem.tanggal_akhir >= item.tanggal_awal && dbItem.tanggal_akhir <= item.tanggal_akhir))
                        {
                            flag = false;
                        }
                    }
                    if (flag == false)
                    {
                        ModelState.AddModelError("", "Jadwal bentrok");
                    }
                    else if (flag == true)
                    {
                        RepoWhitelist.Save(dbItem);
                        //message
                        string template = HttpContext.GetGlobalResourceObject("MyGlobalMessage", "CreateSuccess").ToString();
                        this.SetMessage(model.Barcode + "", template);

                        return RedirectToAction("Index");
                    }
                }
                catch (Exception e)
                {
                    return View("Form", model);
                }
            }
            else
            {
                return View("Form", model);
            }
            List<object> newList = new List<object>();
            foreach (var crew in RepoCrew.FindAll())
            {
                newList.Add(
                    new
                    {
                        Id = crew.barcode,
                        Name = crew.barcode + " " + crew.name
                    });
            }
            this.ViewBag.Crew = new SelectList(newList, "Name", "Id");
            return View("Form", model);
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

