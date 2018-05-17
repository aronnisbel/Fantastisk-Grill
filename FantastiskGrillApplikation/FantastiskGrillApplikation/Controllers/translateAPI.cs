using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;

namespace FantastiskGrillApplikation.Controllers
{
    public class translateAPI
    {

        public static String parseApi(String s)
        {
            string key = "trnsl.1.1.20180517T081257Z.4258a6f3c41938ff.2b5426d0e1e8890ad73706be663506cfb4d5aae4";

            string urlXml = "https://translate.yandex.net/api/v1.5/tr/getLangs?key=trnsl.1.1.20180517T081257Z.4258a6f3c41938ff.2b5426d0e1e8890ad73706be663506cfb4d5aae4&ui=en";

            string urlJSON = "https://translate.yandex.net/api/v1.5/tr.json/getLangs?key=trnsl.1.1.20180517T081257Z.4258a6f3c41938ff.2b5426d0e1e8890ad73706be663506cfb4d5aae4&[ui=en]";

            string translateUrl = "https://translate.yandex.net/api/v1.5/tr.json/translate?key=trnsl.1.1.20180517T081257Z.4258a6f3c41938ff.2b5426d0e1e8890ad73706be663506cfb4d5aae4&text=Hello+my+name+is+bob&lang=en-sv&[format=plain]&[options=1]";

            string text = "What are you doing later this evening?";

            string lang = "en-sv";

            string url = "https://translate.yandex.net/api/v1.5/tr.json/translate?key=" + key + "&text=" + text + "&lang=" + lang + "&[format=html]&[options=1]";

            WebClient syncClient = new WebClient();
            syncClient.Encoding = System.Text.Encoding.UTF8;
            string result = "Default";

            try
            {
                result = syncClient.DownloadString(url);
            }
            catch (WebException ex)
            {
                result = string.Format("Could not get data. {0}", ex);

            }

            LanguageModel model = new LanguageModel();
            model = JsonConvert.DeserializeObject<LanguageModel>(result);

            return model.text.ToString();

        }


    }

    internal class LanguageModel
    {
        public int code { get; set; }
        public string lang { get; set; }
        public object text { get; set; }
    }
}