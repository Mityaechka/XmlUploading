using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml;
using XmlUploading.Extensions;

namespace XmlUploading.Models
{
    public class AddEventCommand : Command
    {
        public int? CmdId { get; set; } = null;
        public string CcId { get; set; } = null;
        public string SId { get; set; } = null;
        public string SrcId { get; set; } = null;
        public AddEventSrcType SrcType { get; set; } = null;
        public int? EvType { get; set; } = null;

        public string EvDate { get; set; } = null;
        public Microfinance EvMicrofinance { get; set; } = null;
        public override XmlElement GetNode(XmlDocument document)
        {
            XmlElement parentElement = document.CreateElement("AddEvent");
            parentElement.AppendChildNullCheck(document.CreateElemetNullCheck("cmdId", CmdId));
            parentElement.AppendChildNullCheck(document.CreateElemetNullCheck("sId", SId));
            parentElement.AppendChildNullCheck(document.CreateElemetNullCheck("srcId", SrcId));
            if (SrcType != null)
            {
                XmlElement eventSrcElement = document.CreateElement("srcType");
                eventSrcElement.SetAttributeNullCheck("id", SrcType.Id);
                eventSrcElement.InnerTextNullCheck(SrcType.Value);
                parentElement.AppendChildNullCheck(eventSrcElement);
            }
            parentElement.AppendChildNullCheck(document.CreateElemetNullCheck("ccId", CcId));

            parentElement.AppendChildNullCheck(document.CreateElemetNullCheck("evType", EvType));
            parentElement.AppendChildNullCheck(document.CreateElemetNullCheck("evDate", EvDate));


            if (EvMicrofinance != null)
            {
                XmlElement evElement = document.CreateElement("evMicrofinance");

                evElement.AppendChildNullCheck(document.CreateElemetNullCheck("mfNextPaymentDate", EvMicrofinance.NextPaymentDate));
                evElement.AppendChildNullCheck(document.CreateElemetNullCheck("stOtstPrncAmnt", EvMicrofinance.OtstPrncAmnt));
                evElement.AppendChildNullCheck(document.CreateElemetNullCheck("stNextPayment", EvMicrofinance.NextPayment));
                evElement.AppendChildNullCheck(document.CreateElemetNullCheck("stAmount", EvMicrofinance.Amount));
                evElement.AppendChildNullCheck(document.CreateElemetNullCheck("stOvrdAmnt", EvMicrofinance.OvrdAmnt));

                if (EvMicrofinance.OvrdAmntDrtn != null)
                {
                    XmlElement stOvrdAmntDrtnElemnt = document.CreateElement("stOvrdAmntDrtn");
                    stOvrdAmntDrtnElemnt.SetAttributeNullCheck("type", EvMicrofinance.OvrdAmntDrtn.Type);
                    stOvrdAmntDrtnElemnt.InnerTextNullCheck(EvMicrofinance.OvrdAmntDrtn.Value);
                    evElement.AppendChildNullCheck(stOvrdAmntDrtnElemnt);
                }
                parentElement.AppendChildNullCheck(evElement);
            }
            return parentElement;
        }
    }
    public class AddEventSrcType
    {
        public int? Id { get; set; } = null;

        public string Value { get; set; } = null;
    }
    public class Microfinance
    {
        public string NextPaymentDate { get; set; } = null;
        public decimal? OtstPrncAmnt { get; set; } = null;
        public decimal? NextPayment { get; set; } = null;
        public decimal? Amount { get; set; } = null;
        public decimal? OvrdAmnt { get; set; } = null;
        public Duration OvrdAmntDrtn { get; set; } = null;
    }
    public class Duration
    {
        public int? Type { get; set; } = null;
        public string Value { get; set; } = null;
    }
}