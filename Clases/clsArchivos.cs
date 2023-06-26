using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Web;

namespace APISkyNet.Clases
{
    public class clsArchivos
    {
        public string LeeClaveArchivos(string jPath)
        {
            try
            {
                String mappingpath = System.Web.HttpContext.Current.Server.MapPath("~/Configuration/Configuration.json");
                JObject config = JObject.Parse(File.ReadAllText(mappingpath));
                JToken conf = config.SelectToken(jPath);
                return conf.Value<string>();
            }
            catch (Exception ex)
            {

                return null;
            }
        }

        public void EscribeLog(string pGuid, string pMetodo,  string pTexto)
        {
            try
            {
                String line;
                try
                {
                    //Pass the file path and file name to the StreamReader constructor
                    StreamReader sr = new StreamReader( @"C:\tmp\Log" + DateTime.Now.ToString("yyyyMMhh24:mm:ss") + ".txt");
                    //Read the first line of text
                    line = sr.ReadLine();
                    //Continue to read until you reach end of file
                    while (line != null)
                    {
                        //write the line to console window
                        Console.WriteLine(DateTime.Now.ToString("yyyyMMhh24:mm:ss") + " | " + pGuid + " | " + pMetodo  + " | " + pTexto );
                        //Read the next line
                        line = sr.ReadLine();
                    }
                    //close the file
                    sr.Close();
                    Console.ReadLine();
                }
                catch (Exception e)
                {
                    Console.WriteLine("Exception: " + e.Message);
                }
                finally
                {
                    Console.WriteLine("Executing finally block.");
                }
            }
            catch(Exception ex)
            {

            }
        }

        public string GetCurretMethod()
        {
            string currentMethod = String.Empty;
            currentMethod = MethodBase.GetCurrentMethod().Name;
            return currentMethod;
        }
    }
}