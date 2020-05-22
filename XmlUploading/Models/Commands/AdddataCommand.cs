using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml;
using XmlUploading.Extensions;

namespace XmlUploading.Models.Commands
{
    public class AddDataCommand : Command
    {
        //TODO: id
        public  int?  CmdId {get;set;}= null;
        public string SId {get;set;}= null;

        public string SrcId {get;set;}= null;

        public string DtId {get;set;}= null;

        public string DtType {get;set;}= null;

        public string DtDate {get;set;}= null;

        public decimal? DtAmount {get;set;}= null;

        public string CcId {get;set;}= null;

        public override XmlElement GetNode(XmlDocument document)
        {
            XmlElement parentElement = document.CreateElement("AddData");

            parentElement.AppendChildNullCheck(document.CreateElemetNullCheck("cmdId", CmdId));
            parentElement.AppendChildNullCheck(document.CreateElemetNullCheck("sId", SId));
            parentElement.AppendChildNullCheck(document.CreateElemetNullCheck("srcId", SrcId));
            parentElement.AppendChildNullCheck(document.CreateElemetNullCheck("ccId", CcId));

            parentElement.AppendChildNullCheck(document.CreateElemetNullCheck("dtId", DtId));
            parentElement.AppendChildNullCheck(document.CreateElemetNullCheck("dtType", DtType));
            parentElement.AppendChildNullCheck(document.CreateElemetNullCheck("dtDate", DtDate));

            parentElement.AppendChildNullCheck(document.CreateElemetNullCheck("dtAmount", DtAmount));


            return parentElement;
        }
    }
}