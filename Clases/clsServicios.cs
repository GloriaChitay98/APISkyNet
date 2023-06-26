using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace APISkyNet.Clases
{
    public class clsServicios
    {
        clsArchivos clsarchivos = new clsArchivos();
        public string ConsumeAPI(string pUrl, string pMetodo, string pBody)
        {
            string vGuid = Guid.NewGuid().ToString();
            string respuesta = string.Empty;
            string endpoint = string.Empty;
            try
            {
                clsarchivos.EscribeLog(vGuid, clsarchivos.GetCurretMethod(), "Entrada Url: " +  pUrl);
                clsarchivos.EscribeLog(vGuid, clsarchivos.GetCurretMethod(), "Entrada Metodo: " + pMetodo);
                clsarchivos.EscribeLog(vGuid, clsarchivos.GetCurretMethod(), "Entrada Body: " + pBody);
                endpoint = pUrl + pMetodo;
                var client = new RestClient(endpoint);
                //System.Net.ServicePointManager.ServerCertificateValidationCallback += delegate { return true; };
                var request = new RestRequest(Method.POST);

               /* request.AddHeader("cache-control", "no-cache");
                request.AddHeader("Connection", "keep-alive");*/
                request.AddHeader("content-length", "46");
                request.AddHeader("accept-encoding", "gzip, deflate");
                request.AddHeader("Cache-Control", "no-cache");
                    
                request.AddHeader("Content-Type", "application/json");
                // request.AddParameter("undefined", pBody, ParameterType.RequestBody);
                request.AddParameter("application/json", pBody, ParameterType.RequestBody);

               
                IRestResponse response = client.Execute(request);
                var jResponse = JsonConvert.SerializeObject(response.Content);
                
                if (response.StatusDescription == "OK")
                {
                    respuesta = response.Content;
                }
                else
                {
                    respuesta = response.Content;
                }
                return respuesta;
            }
            catch(Exception ex)
            {
                clsarchivos.EscribeLog(vGuid, clsarchivos.GetCurretMethod(), "Error ref: " + ex.Message);
                return respuesta;
            }
        }
    }
}