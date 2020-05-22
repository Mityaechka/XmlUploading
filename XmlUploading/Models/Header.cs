using Microsoft.Ajax.Utilities;
using System;
using System.Xml;
using XmlUploading.Extensions;

namespace XmlUploading.Models
{
    public class Header
    {
        public int? Ownerid { get; set; } = null;
        public string OwnerDescription { get; set; } = null;
        public DateTime? UploadCreationDateTime { get; set; } = null;
        public int? UploadId { get; set; } = null;

        public XmlElement GetNode(XmlDocument document)
        {
            XmlElement element = document.CreateElement("HEADER");
            element.AppendChildNullCheck(document.CreateElemetNullCheck("ownerId", Ownerid));
            element.AppendChildNullCheck(document.CreateElemetNullCheck("ownerDescription", OwnerDescription));
            element.AppendChildNullCheck(document.CreateElemetNullCheck("uploadCreationDateTime", UploadCreationDateTime));
            element.AppendChildNullCheck(document.CreateElemetNullCheck("uploadId", UploadId));

            return element;
        }
    }
}