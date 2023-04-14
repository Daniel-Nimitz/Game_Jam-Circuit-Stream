using UnityEngine;
using System.IO;
using System.Xml;
using System.Collections.Generic;

public static class XmlLoader
{
    //turns all the titles in the xml file into an array
    public static XMLdata[] parseXmlFile(TextAsset xmlRawFile)
    {
        List<XMLdata> titles = new List<XMLdata>();

        string data = xmlRawFile.text;

        XmlDocument xmlDoc = new XmlDocument();
        xmlDoc.Load(new StringReader(data));

        string pattern = "//Tasks/Task";
        XmlNodeList nodeList = xmlDoc.SelectNodes(pattern);

        foreach(XmlNode node in nodeList)
        {
            XmlNode title = node.FirstChild;
            XmlNode id = title.NextSibling;

            titles.Add(new XMLdata(title.InnerXml, id.InnerXml));
        }

        return titles.ToArray();
    }
}

public class XMLdata
{
    public string title;
    public string tag;

    public XMLdata(string title, string tag){
        this.title = title;
        this.tag = tag;
    }
}