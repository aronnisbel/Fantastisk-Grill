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

        public string getData()
        {
            try
            {
                string apiString = wClient.DownloadString("http://www8.tfe.umu.se/weatherwebservice2012/service.asmx/Aktuellavarden");
                apiString = apiString.Replace("&lt;", "<");
                apiString = apiString.Replace("&gt;", ">");
                apiString = apiString.Replace("<? xml version = \"1.0\" encoding = \"utf - 8\" ?>", "");

                string temp = "";
                string allTemp = "";

                for (int i = 125; i <= 130; i++)
                {
                    temp = apiString.ElementAt<char>(i).ToString();
                    Debug.WriteLine(temp);
                    allTemp += temp;

                }
                Debug.WriteLine("temp: " + temp);
                Debug.WriteLine("allTemp: " + allTemp);

                allTemp = allTemp.Replace(">", "");
                allTemp = allTemp.Replace("<", "");
                allTemp = allTemp.Replace("/", "");
                Debug.WriteLine("allTemp efter replace: " + allTemp);

                Debug.WriteLine("api string: " + apiString);

                return allTemp;

            }
            catch (Exception e)
            {
                Debug.WriteLine("ERROR when fetching" + e.Message);
                return "ERROR!!!!";
            }
        }

    }

}