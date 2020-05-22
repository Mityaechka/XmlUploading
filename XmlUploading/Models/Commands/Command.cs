using Microsoft.Ajax.Utilities;
using System.Xml;
using XmlUploading.Extensions;

namespace XmlUploading.Models
{
    public abstract class Command
    {
        public abstract XmlElement GetNode(XmlDocument document);

        //protected XmlElement[] CreateElemets(XmlDocument document,params string[] data)
        //{
        //    XmlElement[] elements = new XmlElement[data.Length];
        //    for (int i = 0; i < data.Length; i++)
        //    {
        //       elements[i] =  CreateElemet(document, data[i]);
        //    }
        //    return elements;
        //}
        // XmlElement CreateElemet(XmlDocument document, string data)
        //{
        //    if (data == null)
        //        return null;
        //    XmlElement element = document.CreateElement(data.GetLowerName());
        //   protected element.InnerText = data;
        //    return element;
        //}
    }
}
