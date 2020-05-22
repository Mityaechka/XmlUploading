using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml;
using XmlUploading.Extensions;

namespace XmlUploading.Models.Commands
{
    public class AnnulCommand : Command
    {
        public int? CmdId = null;
        public string sId = null;
        public tAnnulAnnulReason annulReason;

        public override XmlElement GetNode(XmlDocument document)
        {
            XmlElement parentElement = document.CreateElement("Annul");

            parentElement.AppendChildNullCheck(document.CreateElemetNullCheck("cmdId",CmdId));
            parentElement.AppendChildNullCheck(document.CreateElemetNullCheck("sId", sId));

            if (annulReason != null)
            {
                XmlElement reasonElement = document.CreateElement("annulReason");
                reasonElement.InnerTextNullCheck(annulReason.value);
                reasonElement.SetAttributeNullCheck("id", annulReason.id);
                parentElement.AppendChildNullCheck(reasonElement);
            }


            return parentElement;
        }
    }
    public partial class tAnnulAnnulReason
    {

        public int? id = null;

        public string value = null;
    }
}