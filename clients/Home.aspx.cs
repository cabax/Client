﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.UI;
using System.Web.UI.WebControls;
using clients.Enumerable;
using clients.views;

namespace clients
{
    public partial class Home : System.Web.UI.Page
    {
        Request request = new Request();
        public string medico111 = "{\"IsMedico\":true,\"idPersona\":\"c06c7e2f-1204-4257-a0dc-c8e4f175ae71\",\"Nombres\":\"Alexander Ramon\",\"Apellidos\":\"Mendez Jimenez\",\"Sexo\":\"M\",\"Cedula\":\"5412422323\",\"FechaDeNacimiento\":\"\\/Date(658987200000)\\/\",\"Email\":\"alexander@gmail.com\",\"TelefonoResidencial\":\"8093214432\",\"TelefonoCelular\":\"8093125434\",\"idProvincia\":1,\"Direccion\":\"Calle Sal si puedes\",\"TipoDeSangre\":\"O+\",\"FechaDeDefuncion\":\"\\/Date(-62135582400000)\\/\",\"Username\":\"alexander\",\"Password\":null}";

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            //const string Ipadd = "10.0.0.11";
            //var url = "/api/personas/GetPersona?Username=" + User.Text;
            //var urlencrypted = new SecureEncrypt().Encrypt(url, "password");
            //var path = "http://" + Ipadd + ":4001/api/user?url=" + urlencrypted;
            //var result = request.Using(WebRequestMethods.Http.Get, path);

            var jss = new JavaScriptSerializer();
            var persona = jss.Deserialize<PersonasEditCreateModel>(medico111);

            ////var o = JObject.Parse(result);
            ////Label1.Text = (string)o["IsMedico"];
            Label1.Text = persona.IsMedico.ToString(CultureInfo.InvariantCulture);
        }
    }
}