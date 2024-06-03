using Newtonsoft.Json;
using System.ComponentModel;
using System.Drawing;
using System.Xml.Linq;

namespace XML_by_Android

{
    internal class Program
    {
    static void Main(string[] args)
    {
            /*string xmlFilePath = "file.xml";
            string jsonFilePath = "file.json";
            XDocument xDoc = XDocument.Load(xmlFilePath);

            XNamespace androidNs = "http://schemas.android.com/apk/res/android";
            XNamespace aaptNs = "http://schemas.android.com/aapt";

            AddItemToGradient(xDoc, androidNs, "#FF0000","0,5");
            var element = FindElement(xDoc, androidNs + "fillColor","#FFFFFF");
            if (element != null )
            {
                Console.WriteLine(element.ToString());
                
            }
            UpdateGradientAttributes(xDoc, androidNs, "90.0", "95.0", "50.0", "55.0");

            ConvertToJson(xDoc, jsonFilePath);
            xDoc.Save(xmlFilePath);*/

            string path = "file2.xml";
            XDocument xDoc2 = XDocument.Load(path);
            foreach(var projectElement in xDoc2.Descendants("project"))
            {
                projectElement.Add(new XAttribute("newAtribute1" , "Value1"));
                projectElement.Add(new XAttribute("newAtribute2" , "Value2"));

                

            }
            Console.WriteLine(xDoc2.ToString());

            

    }

    public static void AddItemToGradient(XDocument xDoc, XNamespace androidNs, string color, string offset)
    {
        var gradient = xDoc.Descendants().FirstOrDefault(e => e.Name.LocalName == "gradient");
        if (gradient != null)
        {
            gradient.Add(new XElement("item", new XAttribute(androidNs + "color", color),
            new XAttribute(androidNs + "offset", offset)));
        }
    }

    public static void UpdateGradientAttributes(XDocument xDoc, XNamespace androidNs, string endX, string endY, string startX, string startY)
    {
        var gradient = xDoc.Descendants().FirstOrDefault(e => e.Name.LocalName == "gradient");
        if (gradient != null)
        {
            gradient.SetAttributeValue(androidNs + "endX", endX);
            gradient.SetAttributeValue(androidNs + "StartX", startX);
            gradient.SetAttributeValue(androidNs + "endY", endY);
            gradient.SetAttributeValue(androidNs + "StartY", startY);
        }

    }
    public static XElement FindElement(XDocument xDoc, XName name, string value)
    {
        return xDoc.Descendants().FirstOrDefault(e => e.Attribute(name)?.Value == value);
    }
    public static void ConvertToJson(XDocument xDoc, string filePath)
    {
        var json = JsonConvert.SerializeXNode(xDoc, Newtonsoft.Json.Formatting.Indented, omitRootObject: true);
        File.WriteAllText(filePath, json);
    }
   
    
        
    }
}

        

       
    

