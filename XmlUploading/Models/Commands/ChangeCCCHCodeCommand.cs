using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml;
using XmlUploading.Extensions;

namespace XmlUploading.Models.Commands
{
    public class ChangeCCCHCodeCommand : Command
    {
        public int? CmdId = null;
        public string sId = null;
        public tCCCHCode sCode = null;

        public override XmlElement GetNode(XmlDocument document)
        {
            XmlElement parentElement = document.CreateElement("ChangeCCCHCode");
            parentElement.AppendChildNullCheck(document.CreateElemetNullCheck("cmdId", CmdId));
            parentElement.AppendChildNullCheck(document.CreateElemetNullCheck("sId", sId));
            if (sCode != null)
            {
                XmlElement sCodeElement = document.CreateElement("sCode");
                sCodeElement.InnerTextNullCheck(sCode.value);
                if (sCode.isAdditional != null)
                    sCodeElement.SetAttributeNullCheck("isAdditional", sCode.isAdditional.Value?"true":"false");
                parentElement.AppendChildNullCheck(sCodeElement);
            }
            return parentElement;
        }
    }
    public partial class tCCCHCode
    {
        public bool? isAdditional = null;
        public string value;
    }
}