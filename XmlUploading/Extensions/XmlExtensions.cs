using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml;

namespace XmlUploading.Extensions
{
    public static class XmlExtensions
    {
        public static void AppendChildNullCheck(this XmlElement parentElement, XmlElement element)
        {
            if (element == null || parentElement == null)
                return;
            parentElement.AppendChild(element);
        }
        public static XmlElement CreateElemetNullCheck(this XmlDocument document, string name, object data)
        {
            if (document == null|| data == null)
                return null;
            XmlElement element = document.CreateElement(name);
                element.InnerText = data.ToString();
            return element;
        }
        public static void SetAttributeNullCheck(this XmlElement element, string name, object data)
        {
            if (data == null || element == null)
                return;
            element.SetAttribute(name, data.ToString());
        }
        public static void InnerTextNullCheck(this XmlElement element, object value)
        {
            if (value == null || element == null)
                return;
            element.InnerText =  value.ToString();
        }
    }
}