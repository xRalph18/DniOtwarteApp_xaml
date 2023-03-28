using Newtonsoft.Json;
using SchoolOpenDays.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;

namespace SchoolOpenDays.ApiConnection
{
    class Forces
    {
        public static List<ForcesModel> GetForces()
        {
            HttpWebRequest WebReq = (HttpWebRequest)WebRequest.Create(string.Format("https://data.police.uk/api/forces"));

            WebReq.Method = "GET";

            HttpWebResponse WebResp = (HttpWebResponse)WebReq.GetResponse();

            Console.WriteLine(WebResp.StatusCode);
            Console.WriteLine(WebResp.Server);

            string jsonString;
            using(Stream stream = WebResp.GetResponseStream())
            {
                StreamReader reader = new StreamReader(stream, System.Text.Encoding.UTF8);
                jsonString = reader.ReadToEnd();
            }

            List<ForcesModel> forces = JsonConvert.DeserializeObject<List<ForcesModel>>(jsonString);

            return forces;
        }


    }
}
