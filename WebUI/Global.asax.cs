﻿using Business.Entities;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Security.Principal;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.Script.Serialization;
using System.Web.Security;
using WebUI.Binders;
using WebUI.Infrastructure;
using WebUI.Infrastructure.Concrete;
using WebUI.Models;

namespace WebUI
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            DependencyResolver.SetResolver(new WebUI.Infrastructure.NinjectDependencyResolver());

            WebApiConfig.Register(GlobalConfiguration.Configuration);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            ClientDataTypeModelValidatorProvider.ResourceClassKey = "MyGlobalErrors";
            DefaultModelBinder.ResourceClassKey = "MyGlobalErrors";

            GlobalConfiguration.Configuration.MessageHandlers
                .Add(new BasicAuthMessageHandler()
                {
                    PrincipalProvider = new WebUI.Infrastructure.Concrete.DummyPrincipalProvider()
                });

            //model binder
            ModelBinders.Binders.Add(typeof(UserLogin), new UserLoginModelBinder());
        }

        protected void Application_AuthenticateRequest(Object sender, EventArgs e)
        {
            if (HttpContext.Current.User != null)
            {
                if (HttpContext.Current.User.Identity.IsAuthenticated)
                {
                    if (HttpContext.Current.User.Identity is FormsIdentity)
                    {
                        // Get Forms Identity From Current User
                        FormsIdentity id = (FormsIdentity)HttpContext.Current.User.Identity;
                        // Get Forms Ticket From Identity object
                        FormsAuthenticationTicket ticket = id.Ticket;
                        // Retrieve stored user-data (our roles from db)
                        string userData = ticket.UserData;
                        string[] roles = userData.Split(',');
                        // Create a new Generic Principal Instance and assign to Current User
                        HttpContext.Current.User = new GenericPrincipal(id, roles);
                    }
                }
            }
        }

        protected void Application_PostAuthenticateRequest(Object sender, EventArgs e)
        {
            //HttpCookie authCookie = Request.Cookies[FormsAuthentication.FormsCookieName];

            //if (authCookie != null)
            //{
            //    try
            //    {
            //        FormsAuthenticationTicket authTicket = FormsAuthentication.Decrypt(authCookie.Value);

            //        JavaScriptSerializer serializer = new JavaScriptSerializer();

            //        //CustomPrincipalSerializeModel serializeModel = serializer.Deserialize<CustomPrincipalSerializeModel>(authTicket.UserData);

            //        CustomPrincipal newUser = new CustomPrincipal(authTicket.Name);
            //        //newUser.Modules = serializeModel.Modules;

            //        HttpContext.Current.User = newUser;
            //    }
            //    catch
            //    {
            //        FormsAuthentication.SignOut();
            //        Response.Redirect(FormsAuthentication.LoginUrl, true);
            //    }
                
            //}
        }

        //protected void Application_PreRequestHandlerExecute(object sender, EventArgs e)
        //{
        //    //Check if user is authenticated
        //    HttpCookie authCookie = Request.Cookies[FormsAuthentication.FormsCookieName];
        //    if (authCookie != null)
        //    {
        //        FormsAuthenticationTicket authTicket = FormsAuthentication.Decrypt(authCookie.Value);
        //        if (!authTicket.Expired)
        //        {
        //            try
        //            {
        //                {
        //                    if (Session["userId"] == null) //session kosong, set dari servis
        //                    {
        //                        MobidigUser user = FindMobidigUser();

        //                        if (user == null)
        //                        {
        //                            FormsAuthentication.SignOut();
        //                            Response.Redirect(FormsAuthentication.LoginUrl, true);
        //                            return;
        //                        }
        //                        else
        //                        {
        //                            string[] roles = user.rolename.ToArray();

        //                            Session["userId"] = user.id;
        //                            Session["username"] = user.username;
        //                            Session["roles"] = roles;
        //                        }
        //                    }
        //                }
        //            }
        //            catch (Exception exception)
        //            {
        //            }
        //        }
        //        else
        //        {
        //            FormsAuthentication.SignOut();
        //            Response.Redirect(FormsAuthentication.LoginUrl, true);
        //            return;
        //        }
        //    }
        //}

        //public MobidigUser FindMobidigUser()
        //{
        //    //kamus
        //    string baseUrl = ConfigurationManager.AppSettings["MobidigUrl"];
        //    string serviceUrl = "Services/UserService/GetUserLogin?username=" + User.Identity.Name;
        //    string fullUrl = baseUrl + serviceUrl;
        //    string json = null;
        //    MobidigUser user = null;

        //    //algoritma
        //    if (Request.IsLocal)
        //    {
        //        fullUrl = "http://localhost/mobidig/Services/UserService/GetUserLogin.php";
        //    }

        //    using (var client = new WebClient())
        //    {
        //        json = client.DownloadString(fullUrl);
        //        new LogHelper().Write(fullUrl);
        //        new LogHelper().Write(json);

        //        try
        //        {
        //            user = new JavaScriptSerializer().Deserialize<MobidigUser>(json);
        //        }
        //        catch (Exception e)
        //        {
        //        }
        //    }

        //    return user;
        //}
    }
}