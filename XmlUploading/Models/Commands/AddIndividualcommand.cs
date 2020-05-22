using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml;
using XmlUploading.Extensions;

namespace XmlUploading.Models.Commands
{
    public class AddIndividualCommand : Command
    {
        public int? CmdId = null;
        public string DateOfActuality = null;
        public string ISurname = null;
        public string IName = null;
        public string IPatronymic = null;
        public string IOldSurname = null;
        public string IOldName = null;
        public string IOldPatronymic = null;
        public string IbDate = null;
        public string IbPlace = null;
        public Document[] IDoc = null;
        public string IITN = null;
        public string IPens = null;
        public string SId = null;
        public override XmlElement GetNode(XmlDocument document)
        {
            XmlElement parentElement = document.CreateElement("AddIndividual");
            parentElement.AppendChildNullCheck(document.CreateElemetNullCheck("cmdId", CmdId));

            parentElement.AppendChildNullCheck(document.CreateElemetNullCheck("dateOfActuality", DateOfActuality));

            parentElement.AppendChildNullCheck(document.CreateElemetNullCheck("sId", SId));

            parentElement.AppendChildNullCheck(document.CreateElemetNullCheck("iSurname", ISurname));
            parentElement.AppendChildNullCheck(document.CreateElemetNullCheck("iName", IName));
            parentElement.AppendChildNullCheck(document.CreateElemetNullCheck("iPatronymic", IPatronymic));
            parentElement.AppendChildNullCheck(document.CreateElemetNullCheck("iOldSurname", IOldSurname));
            parentElement.AppendChildNullCheck(document.CreateElemetNullCheck("iOldName", IOldName));
            parentElement.AppendChildNullCheck(document.CreateElemetNullCheck("iOldPatronymic", IOldPatronymic));
            parentElement.AppendChildNullCheck(document.CreateElemetNullCheck("ibDate", IbDate));
            parentElement.AppendChildNullCheck(document.CreateElemetNullCheck("ibPlace", IbPlace));
            

            if (IDoc != null)
            {
                foreach (Document tDocument in IDoc)
                {
                    if (tDocument == null)
                        continue;

                    XmlElement tDocElement = document.CreateElement("iDoc");
                    if (tDocument.PreviouslyIssued != null)
                    {
                        tDocElement.SetAttributeNullCheck("previouslyIssued", tDocument.PreviouslyIssued.Value?"true":"false");
                    }
                    if (tDocument.Type != null)
                    {
                        XmlElement dTypeElement = document.CreateElement("dType");
                        dTypeElement.SetAttributeNullCheck("id", tDocument.Type.Id);
                        dTypeElement.InnerTextNullCheck( tDocument.Type.Value);
                        tDocElement.AppendChildNullCheck(dTypeElement);
                    }
                    if (tDocument.Num != null)
                    {
                        XmlElement dNumElement = document.CreateElement("dNum");
                        dNumElement.SetAttributeNullCheck("dSer", tDocument.Num.Ser);
                        dNumElement.InnerTextNullCheck( tDocument.Num.Value);
                        tDocElement.AppendChildNullCheck(dNumElement);
                    }
                    if (tDocument.Issue != null)
                    {
                        XmlElement dNumElement = document.CreateElement("dIssue");
                        dNumElement.SetAttributeNullCheck("diDate", tDocument.Issue.Date);
                        dNumElement.SetAttributeNullCheck("diPlace", tDocument.Issue.Place);
                        dNumElement.SetAttributeNullCheck("diCode", tDocument.Issue.Code);
                        dNumElement.InnerTextNullCheck( tDocument.Issue.Value);
                        tDocElement.AppendChildNullCheck(dNumElement);
                    }
                    parentElement.AppendChildNullCheck(tDocElement);
                }
            }
            parentElement.AppendChildNullCheck(document.CreateElemetNullCheck("iITN", IITN));
            parentElement.AppendChildNullCheck(document.CreateElemetNullCheck("iPens", IPens));
            return parentElement;
        }
    }
    public partial class Document
    {

        public DocumentType Type = null;

        public DocumentNum Num = null;

        public DocumentIssue Issue = null;

        public bool? PreviouslyIssued = null;

    }
    public partial class DocumentType
    {

        public int? Id = null;

        public string Value = null;
    }
    public partial class DocumentNum
    {

        public string Ser = null;

        public string Value = null;
    }
    public partial class DocumentIssue
    {

        public string Date = null;

        public string Code = null;

        public string Place = null;

        public string Value = null;
    }
}