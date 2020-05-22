using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;
using System.Xml;
using XmlUploading.Extensions;

namespace XmlUploading.Models.Commands
{
    public class AddInfoCommand : Command
    {
        public int? CmdId = null;
        public string DateOfActuality = null;

        public string SId = null;

        public string SrcId = null;

        public ValueAttributte SrcType = null;

        public ValueAttributte CcStage = null;

        public ValueAttributte CcTypeApproved = null;
        public string CcCloseDate = null;


        public AddInfoCreditApplication CreditApplication = null;
        public AddInfoSuretyContract SuretyContract = null;
        public override XmlElement GetNode(XmlDocument document)
        {
            XmlElement parentElement = document.CreateElement("AddInfo");

            parentElement.AppendChildNullCheck(document.CreateElemetNullCheck("cmdId", CmdId));
            parentElement.AppendChildNullCheck(document.CreateElemetNullCheck("dateOfActuality", DateOfActuality));
            parentElement.AppendChildNullCheck(document.CreateElemetNullCheck("sId", SId));
            parentElement.AppendChildNullCheck(document.CreateElemetNullCheck("srcId", SrcId));

            if (SrcType != null)
            {
                XmlElement srcTypeElement = document.CreateElement("srcType");
                srcTypeElement.SetAttributeNullCheck("id", SrcType.Attribute);
                srcTypeElement.InnerTextNullCheck( SrcType.Value);
                parentElement.AppendChildNullCheck(srcTypeElement);
            }
            if (CcStage != null)
            {
                XmlElement ccStageTypeElement = document.CreateElement("ccStage");
                ccStageTypeElement.SetAttributeNullCheck("id", CcStage.Attribute);
                ccStageTypeElement.InnerTextNullCheck(CcStage.Value);
                parentElement.AppendChildNullCheck(ccStageTypeElement);
            }
            if (CcTypeApproved != null)
            {
                XmlElement ccTypeApprovedTypeElement = document.CreateElement("ccTypeApproved");
                ccTypeApprovedTypeElement.SetAttributeNullCheck("id", CcTypeApproved.Attribute);
                ccTypeApprovedTypeElement.InnerTextNullCheck(CcTypeApproved.Value);
                parentElement.AppendChildNullCheck(ccTypeApprovedTypeElement);
            }
            if (CreditApplication != null)
            {
                XmlElement creditElement = document.CreateElement("CreditApplication");

                creditElement.AppendChildNullCheck(document.CreateElemetNullCheck("caId", CreditApplication.Id));
                creditElement.AppendChildNullCheck(document.CreateElemetNullCheck("caNumber", CreditApplication.Number));
                creditElement.AppendChildNullCheck(document.CreateElemetNullCheck("caDate", CreditApplication.Date));

                
                if (CreditApplication.Method != null)
                {
                    XmlElement caMethodElement = document.CreateElement("caMethod");
                    caMethodElement.SetAttributeNullCheck("id", CreditApplication.Method.Attribute);
                    caMethodElement.InnerTextNullCheck( CreditApplication.Method.Value);
                    creditElement.AppendChildNullCheck(caMethodElement);
                }
                if (CreditApplication.TypeRequested != null)
                {
                    XmlElement ccTypeRequestedElement = document.CreateElement("ccTypeRequested");
                    ccTypeRequestedElement.SetAttributeNullCheck("id", CreditApplication.TypeRequested.Attribute);
                    ccTypeRequestedElement.InnerTextNullCheck( CreditApplication.TypeRequested.Value);
                    creditElement.AppendChildNullCheck(ccTypeRequestedElement);
                }
                creditElement.AppendChildNullCheck(document.CreateElemetNullCheck("ccApprovalDate", CreditApplication.ApprovalDate));
                creditElement.AppendChildNullCheck(document.CreateElemetNullCheck("ccApprovalExpirationDate", CreditApplication.ApprovalExpirationDate));
                if (CreditApplication.Refusal != null)
                {
                    XmlElement ccRefusalElement = document.CreateElement("ccRefusal");
                    if (CreditApplication.Refusal.rfReason != null)
                    {
                        XmlElement rfReasonElement = document.CreateElement("rfReason");
                        rfReasonElement.SetAttributeNullCheck("id", CreditApplication.Refusal.rfReason.Attribute);
                        rfReasonElement.InnerTextNullCheck(CreditApplication.Refusal.rfReason.Value);
                        ccRefusalElement.AppendChildNullCheck(rfReasonElement);
                    }
                    ccRefusalElement.AppendChildNullCheck(document.CreateElemetNullCheck("rfAmount", CreditApplication.Refusal.rfAmount));
                    if (CreditApplication.Refusal.rfCurrency != null)
                    {
                        XmlElement rfReasonElement = document.CreateElement("rfCurrency");
                        rfReasonElement.SetAttributeNullCheck("id", CreditApplication.Refusal.rfCurrency.id);
                        rfReasonElement.SetAttributeNullCheck("code", CreditApplication.Refusal.rfCurrency.code);
                        rfReasonElement.InnerTextNullCheck(CreditApplication.Refusal.rfCurrency.value);
                        ccRefusalElement.AppendChildNullCheck(rfReasonElement);
                    }

                    ccRefusalElement.AppendChildNullCheck(document.CreateElemetNullCheck("rfDate", CreditApplication.Refusal.rfDate));



                    creditElement.AppendChildNullCheck(ccRefusalElement);
                }
                creditElement.AppendChildNullCheck(document.CreateElemetNullCheck("ccId", CreditApplication.CcId));

                if (CreditApplication.CcNumber != null)
                {
                    XmlElement ccNumberElement = document.CreateElement("ccNumber");

                    ccNumberElement.InnerTextNullCheck(CreditApplication.CcNumber.Value);
                    ccNumberElement.SetAttributeNullCheck("type", CreditApplication.CcNumber.Attribute);
                    creditElement.AppendChildNullCheck(ccNumberElement);
                }
                

                parentElement.AppendChildNullCheck(creditElement);
            }else if (SuretyContract != null)
            {
                XmlElement suretyContractElement = document.CreateElement("SuretyContract");
                suretyContractElement.AppendChildNullCheck(document.CreateElemetNullCheck("scId", SuretyContract.scId));
                if (SuretyContract.scNumber!= null)
                {
                    XmlElement scNumberElement = document.CreateElement("scNumber");
                    scNumberElement.SetAttributeNullCheck("type", SuretyContract.scNumber.Attribute);
                    scNumberElement.InnerTextNullCheck( SuretyContract.scNumber.Value);
                    suretyContractElement.AppendChildNullCheck(scNumberElement);
                }
                parentElement.AppendChildNullCheck(suretyContractElement);
            }
            parentElement.AppendChildNullCheck(document.CreateElemetNullCheck("ccCloseDate", CcCloseDate));
            return parentElement;
        }
    }
    public partial class AddInfoCreditApplication
    {

        public string Id = null;

        public string Number = null;

        public string Date = null;

        public ValueAttributte Method = null;

        public ValueAttributte TypeRequested = null;

        public string ApprovalDate = null;

        public string ApprovalExpirationDate = null;

        public AddInfoCreditApplicationCcRefusal Refusal = null;

        public string CcId = null;

        public ValueAttributte CcNumber = null;
    }
    public partial class AddInfoCreditApplicationCcRefusal
    {

        public ValueAttributte rfReason = null;

        public decimal? rfAmount = null;

        public tCurrency rfCurrency = null;

        public string rfDate = null;
    }
    public partial class tCurrency
    {

        public int? id = null;

        public string code = null;

        public string value = null;
    }
        public partial class AddInfoSuretyContract
    {

        public string scId = null;

        public ValueAttributte scNumber = null;
    }
    }