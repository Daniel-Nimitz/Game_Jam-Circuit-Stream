using UnityEngine;
using System.IO;
using System.Xml;
using System.Collections.Generic;

public static class XmlLoader
{
    //turns all the titles in the xml file into an array
    public static string[] parseXmlFile(TextAsset xmlRawFile)
    {
        List<string> titles = new List<string>();

        string data = xmlRawFile.text;

        XmlDocument xmlDoc = new XmlDocument();
        xmlDoc.Load(new StringReader(data));

        string pattern = "//Tasks/Task";
        XmlNodeList nodeList = xmlDoc.SelectNodes(pattern);

        foreach(XmlNode node in nodeList)
        {
            XmlNode title = node.FirstChild;

            titles.Add(title.InnerXml);
        }

        return titles.ToArray();
    }
}