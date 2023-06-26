using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using APISkyNet.Models;
using APISkyNet.Clases;
using Newtonsoft.Json;

namespace APISkyNet.Controllers
{
    [RoutePrefix("api/Procesador")]
    public class ProcesadorController : ApiController
    {
        #region Definiciones 
        public clsArchivos clsarchivos = new clsArchivos();
        public clsConstantes cons = new clsConstantes();
        #endregion
        [HttpPost]
        [Route("Transaccion")]
        public respuesta ProcesaTansaccion([FromBody] peticion entrada)
        {
            respuesta objresp = new respuesta();
            clsServicios servs = new clsServicios();
            string vGuid = Guid.NewGuid().ToString();
            string vUrl = string.Empty;
            string vMetodo = string.Empty;
            apisrequeste requestapi = new apisrequeste();
            try
            {
                clsarchivos.EscribeLog(vGuid, clsarchivos.GetCurretMethod(), "Entrada: " + JsonConvert.SerializeObject(entrada));
                requestapi.idtransaccion = entrada.idtransaccion;
                requestapi.datos = entrada.datos;
                switch (entrada.modulo)
                {
                    case "1":
                       objresp = JsonConvert.DeserializeObject<respuesta>(servs.ConsumeAPI(clsarchivos.LeeClaveArchivos(clsConstantes.cons_ApiClientes), "", JsonConvert.SerializeObject(requestapi)));
                        break;
                    case "2":
                        objresp = JsonConvert.DeserializeObject<respuesta>(servs.ConsumeAPI(clsarchivos.LeeClaveArchivos(clsConstantes.cons_ApiUsuarios), "", JsonConvert.SerializeObject(requestapi)));
                        break;
                    case "3":
                        objresp = JsonConvert.DeserializeObject<respuesta>(servs.ConsumeAPI(clsarchivos.LeeClaveArchivos(clsConstantes.cons_ApiGestiones), "", JsonConvert.SerializeObject(requestapi)));
                        break;
                }
                return objresp;
            }catch(Exception ex)
            {
                clsarchivos.EscribeLog(vGuid, clsarchivos.GetCurretMethod(), "Error ref: " + ex.Message);
                return objresp;
            }
        }
    }
}
