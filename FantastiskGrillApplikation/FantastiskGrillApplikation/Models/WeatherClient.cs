using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;
using System.Diagnostics;
using System.Net;
using FantastiskGrillApplikation.Models;
using System.Xml.Serialization;
using System.IO;

namespace FantastiskGrillApplikation.Models
{

    public class WeatherClient
    {
        private WebClient wClient;

        public WeatherClient()
        {
            wClient = new WebClient();
            wClient.Encoding = System.Text.Encoding.UTF8;

        }

        public Root getData()
        {
            try
            {
                string apiString = wClient.DownloadString("http://www8.tfe.umu.se/weatherwebservice2012/service.asmx/Aktuellavarden");
                apiString = apiString.Replace("&lt;", "<");
                apiString = apiString.Replace("&gt;", ">");
                apiString = apiString.Replace("<? xml version = \"1.0\" encoding = \"utf - 8\" ?>", "");

                //87  apiString.ElementAt<char>(87) 38

                string temp = "";

                for (int i = 125; i <= 130; i++)
                {
                    temp = apiString.ElementAt<char>(i).ToString();
                    Debug.WriteLine(temp);
                }
                Debug.WriteLine("temp: " + temp);

                Debug.WriteLine("api string: " + apiString);
                XmlSerializer serializer = new XmlSerializer(typeof(Root));
                Debug.WriteLine("Ett");
                StringReader reader = new StringReader(apiString);
                Debug.WriteLine("Två");



                Root rt = (Root)serializer.Deserialize(reader);
                Debug.WriteLine("Tre");
                reader.Close();

                return rt;
            }
            catch (Exception e)
            {
                Debug.WriteLine("ERROR when fetching" + e.Message);
                return null;
            }
        }



    }


}