﻿using System;
using System.Net;
using System.Web;
using System.Web.Script.Serialization;
using clients.Enumerable;
using clients.views;
using mvc4.Account;
using mvc4.Models.EntitiesView;

namespace clients
{
    public partial class LabLogin1 : System.Web.UI.Page
    {
        Request request = new Request();

        protected void Page_Load(object sender, EventArgs e)
        {

            Session["auth"] = "False";
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            //Modificar encryp
            Session["hashi"] = CriptoUtil.HashLogin(txtuser.Text, txtpass.Text);
            Label2.Text = Session["hashi"].ToString();
            var url = "/api/instituciones/GetInstitucion?Username=" + txtuser.Text;
            var urlencrypted = new SecureEncrypt().Encrypt(url, Session["hashi"].ToString());
            var urlencoded = HttpUtility.UrlEncode(urlencrypted);
            var path = "http://" + request.ipadd() + ":4001/api/user?id=" + txtuser.Text + "&url=" + urlencoded;
            var result = request.Using(WebRequestMethods.Http.Get, path);

            var jss = new JavaScriptSerializer();
            try
            {
                var persona = jss.Deserialize<InstitucionesViewModel>(result);
                Session["idi"] = persona.IdInstitucion;
                Response.Redirect("/UserLogin.aspx");

            }

            catch (Exception)
            {

                Label1.Text = "Username o password no válido";

            }
        }
    }
}