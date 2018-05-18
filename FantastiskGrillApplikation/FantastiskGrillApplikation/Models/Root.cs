using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Serialization;

namespace FantastiskGrillApplikation.Models
{
    [XmlRoot(ElementName = "root", Namespace = "http://tempuri.org/")]
    public class Root
    {
        [XmlElement(ElementName = "datum", Namespace = "http://tempuri.org/")]
        public string Datum { get; set; }
        [XmlElement(ElementName = "tempmed", Namespace = "http://tempuri.org/")]
        public string Tempmed { get; set; }
        [XmlElement(ElementName = "fukt", Namespace = "http://tempuri.org/")]
        public string Fukt { get; set; }
        [XmlElement(ElementName = "tryck", Namespace = "http://tempuri.org/")]
        public string Tryck { get; set; }
        [XmlElement(ElementName = "vindh", Namespace = "http://tempuri.org/")]
        public string Vindh { get; set; }
        [XmlElement(ElementName = "vindr", Namespace = "http://tempuri.org/")]
        public string Vindr { get; set; }
        [XmlElement(ElementName = "vindmax", Namespace = "http://tempuri.org/")]
        public string Vindmax { get; set; }
        [XmlElement(ElementName = "regn", Namespace = "http://tempuri.org/")]
        public string Regn { get; set; }
        [XmlElement(ElementName = "vindord", Namespace = "http://tempuri.org/")]
        public string Vindord { get; set; }
        [XmlElement(ElementName = "solinstralning", Namespace = "http://tempuri.org/")]
        public string Solinstralning { get; set; }
        [XmlElement(ElementName = "windChill", Namespace = "http://tempuri.org/")]
        public string WindChill { get; set; }
    }

    [XmlRoot(ElementName = "string", Namespace = "http://tempuri.org/")]
    public class String
    {
        [XmlElement(ElementName = "root", Namespace = "http://tempuri.org/")]
        public Root Root { get; set; }
        [XmlAttribute(AttributeName = "xmlns")]
        public string Xmlns { get; set; }
    }
}