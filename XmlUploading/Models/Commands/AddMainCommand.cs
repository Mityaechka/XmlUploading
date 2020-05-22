using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml;
using XmlUploading.Extensions;

namespace XmlUploading.Models.Commands
{
    public class AddMainCommand : Command
    {
        public string DateOfActuality = null;
        public int? CmdId = null;
        public string sId = null;
       public string srcId = null;

        public tIndividualMain Individual = null;
        public tCreditContract CreditContract = null;
        public tAddMainProcessingTermination processingTermination = null;
        public override XmlElement GetNode(XmlDocument document)
        {
            XmlElement parentElement = document.CreateElement("AddMain");
            parentElement.AppendChildNullCheck(document.CreateElemetNullCheck("cmdId", CmdId));
            parentElement.AppendChildNullCheck(document.CreateElemetNullCheck("dateOfActuality", DateOfActuality));
            parentElement.AppendChildNullCheck(document.CreateElemetNullCheck("sId", sId));
            
            if (Individual != null)
            {
                XmlElement individualElement = document.CreateElement("Individual");

                if (Individual.iAddress != null)
                {
                    foreach (var adress in Individual.iAddress)
                    {
                        if (adress == null)
                            continue;
                        XmlElement iAdressElement = document.CreateElement("iAddress");
                        if (adress.addrCapt != null)
                            foreach (var addrCapt in adress.addrCapt)
                            {
                                if (addrCapt == null)
                                    continue;
                                XmlElement adressCaptElement = document.CreateElement("addrCapt");
                                adressCaptElement.SetAttributeNullCheck("id", addrCapt.Attribute);
                                adressCaptElement.InnerTextNullCheck(addrCapt.Value);
                                iAdressElement.AppendChildNullCheck(adressCaptElement);
                            }
                        if (adress.commonAddrStr != null)
                        {
                            XmlElement commonAddrStrElement = document.CreateElement("commonAddrStr");
                            commonAddrStrElement.SetAttributeNullCheck("codeRU", adress.commonAddrStr.CodeRu);
                            commonAddrStrElement.InnerTextNullCheck(adress.commonAddrStr.Value);
                            iAdressElement.AppendChild(commonAddrStrElement);
                        }
                        iAdressElement.AppendChildNullCheck(document.CreateElemetNullCheck("hN", adress.hn));
                        iAdressElement.AppendChildNullCheck(document.CreateElemetNullCheck("bN", adress.bn));
                        iAdressElement.AppendChildNullCheck(document.CreateElemetNullCheck("bS", adress.bs));
                        iAdressElement.AppendChildNullCheck(document.CreateElemetNullCheck("ap", adress.ap));

                        individualElement.AppendChildNullCheck(iAdressElement);
                    }
                    if (Individual.iIndividualEntrepreneur != null)
                    {
                        XmlElement iIndividualEntrepreneurElement = document.CreateElement("iIndividualEntrepreneur");
                        iIndividualEntrepreneurElement.AppendChildNullCheck(document.CreateElemetNullCheck("ieInfo", Individual.iIndividualEntrepreneur));
                        individualElement.AppendChildNullCheck(iIndividualEntrepreneurElement);
                    }

                    if (Individual.iIncapacity != null)
                    {
                        XmlElement iIncapacityElement = document.CreateElement("iIncapacity");
                        iIncapacityElement.SetAttributeNullCheck("status", Individual.iIncapacity.status);
                        if (Individual.iIncapacity.incapacityCourtInfo != null)
                            foreach (var incatacityCoutr in Individual.iIncapacity.incapacityCourtInfo)
                            {
                                if (incatacityCoutr == null)
                                    continue;
                                XmlElement iIncapacityCourtElement = document.CreateElement("incapacityCourtInfo");
                                XmlElement courtInfoElement = document.CreateElement("courtInfo");
                                courtInfoElement.InnerTextNullCheck(incatacityCoutr);

                                iIncapacityCourtElement.AppendChildNullCheck(courtInfoElement);
                                iIncapacityElement.AppendChildNullCheck(iIncapacityCourtElement);

                            }
                        individualElement.AppendChildNullCheck(iIncapacityElement);
                    }
                    if (Individual.iBankruptcy != null)
                    {
                        XmlElement iBankruptcyElement = document.CreateElement("iBankruptcy");
                        iBankruptcyElement.SetAttributeNullCheck("status", Individual.iBankruptcy.status);
                        iBankruptcyElement.SetAttributeNullCheck("statusText", Individual.iBankruptcy.statusText);
                        if (Individual.iBankruptcy.bankruptcyCourtInfo != null)
                            foreach (var iBankCoutr in Individual.iBankruptcy.bankruptcyCourtInfo)
                            {
                                if (iBankCoutr == null)
                                    continue;
                                XmlElement bankruptcyCourtInfo = document.CreateElement("bankruptcyCourtInfo");
                                XmlElement courtInfo = document.CreateElement("courtInfo");
                                bankruptcyCourtInfo.AppendChildNullCheck(courtInfo);

                                courtInfo.InnerTextNullCheck( iBankCoutr);
                                iBankruptcyElement.AppendChildNullCheck(bankruptcyCourtInfo);

                            }


                        if (Individual.iBankruptcy.iEFRSBData != null)
                        {
                            XmlElement iEFRSBData = document.CreateElement("iEFRSBData");
                            iEFRSBData.AppendChildNullCheck(document.CreateElemetNullCheck("ID", Individual.iBankruptcy.iEFRSBData.id));
                            iEFRSBData.AppendChildNullCheck(document.CreateElemetNullCheck("Date", Individual.iBankruptcy.iEFRSBData.date));
                            iBankruptcyElement.AppendChildNullCheck(iEFRSBData);
                        }
                        individualElement.AppendChildNullCheck(iBankruptcyElement);
                    }
                    
                }
                parentElement.AppendChildNullCheck(individualElement);

            }
            parentElement.AppendChildNullCheck(document.CreateElemetNullCheck("srcId", srcId));
            if (CreditContract != null)
            {
                XmlElement creditElement = document.CreateElement("CreditContract");
                creditElement.AppendChildNullCheck(document.CreateElemetNullCheck("ccId", CreditContract.ccId));
                creditElement.AppendChildNullCheck(document.CreateElemetNullCheck("caId", CreditContract.caId));

                if (CreditContract.ccNumber != null)
                {
                    XmlElement ccNumberElement = document.CreateElement("ccNumber");
                    ccNumberElement.InnerTextNullCheck(CreditContract.ccNumber.type);
                    ccNumberElement.SetAttributeNullCheck("type", CreditContract.ccNumber.type);
                    creditElement.AppendChildNullCheck(ccNumberElement);
                }
                creditElement.AppendChildNullCheck(document.CreateElemetNullCheck("ccAmount", CreditContract.ccAmount));
                if (CreditContract.ccTotalAmount != null)
                {
                    XmlElement totalAmountElement = document.CreateElement("ccTotalAmount");
                    totalAmountElement.InnerTextNullCheck(CreditContract.ccTotalAmount.value);
                    if(CreditContract.ccTotalAmount.nonPercent!=null)
                    totalAmountElement.SetAttributeNullCheck("nonPercent", CreditContract.ccTotalAmount.nonPercent.Value?"true":"false");
                    creditElement.AppendChildNullCheck(totalAmountElement);
                }
                if (CreditContract.ccCurrency != null)
                {
                    XmlElement currencyElement = document.CreateElement("ccCurrency");
                    currencyElement.InnerTextNullCheck(CreditContract.ccCurrency.value);
                    currencyElement.SetAttributeNullCheck("id", CreditContract.ccCurrency.id);
                    currencyElement.SetAttributeNullCheck("code", CreditContract.ccCurrency.code);
                    creditElement.AppendChildNullCheck(currencyElement);
                }
                creditElement.AppendChildNullCheck(document.CreateElemetNullCheck("ccDate", CreditContract.ccDate));
                creditElement.AppendChildNullCheck(document.CreateElemetNullCheck("ccExpirationDate", CreditContract.ccExpirationDate));

                if (CreditContract.ccPaymentFrequency != null)
                {
                    XmlElement paymentFrequencyElement = document.CreateElement("ccPaymentFrequency");
                    paymentFrequencyElement.InnerTextNullCheck(CreditContract.ccPaymentFrequency.value);
                    paymentFrequencyElement.SetAttributeNullCheck("type", CreditContract.ccPaymentFrequency.type);
                    creditElement.AppendChildNullCheck(paymentFrequencyElement);
                }
                creditElement.AppendChildNullCheck(document.CreateElemetNullCheck("ccStatus", CreditContract.ccStatus));
                if (CreditContract.ccType != null)
                {
                    XmlElement ccTypeElement = document.CreateElement("ccType");
                    ccTypeElement.InnerTextNullCheck(CreditContract.ccType.value);
                    ccTypeElement.SetAttributeNullCheck("id", CreditContract.ccType.id);
                    creditElement.AppendChildNullCheck(ccTypeElement);
                }
                if (CreditContract.ccPledge != null)
                    foreach (var pledge in CreditContract.ccPledge)
                    {
                        if (pledge == null)
                            continue;
                        XmlElement ccPledgeElement = document.CreateElement("ccPledge");
                        XmlElement pledgeInfoElement = document.CreateElement("pledgeInfo");
                        pledgeInfoElement.InnerTextNullCheck(pledge);
                        ccPledgeElement.AppendChildNullCheck(pledgeInfoElement);
                        creditElement.AppendChildNullCheck(ccPledgeElement);
                    }

                if (CreditContract.ccChanges != null)
                {
                    XmlElement ccChangesElement = document.CreateElement("ccChanges");
                    ccChangesElement.InnerTextNullCheck(CreditContract.ccChanges.value);
                    ccChangesElement.SetAttributeNullCheck("id", CreditContract.ccChanges.id);
                    ccChangesElement.SetAttributeNullCheck("date", CreditContract.ccChanges.date);
                    creditElement.AppendChildNullCheck(ccChangesElement);
                }
                if (CreditContract.ccRepayment != null)
                {
                    XmlElement ccRepaymentElement = document.CreateElement("ccRepayment");
                    ccRepaymentElement.InnerTextNullCheck(CreditContract.ccRepayment.value);
                    ccRepaymentElement.SetAttributeNullCheck("status", CreditContract.ccRepayment.status);
                    ccRepaymentElement.SetAttributeNullCheck("date", CreditContract.ccRepayment.date);
                    creditElement.AppendChildNullCheck(ccRepaymentElement);
                }
                if (CreditContract.ccDisputeCourtInfo != null)
                {
                    XmlElement ccDisputeCourtInfoElement = document.CreateElement("ccDisputeCourtInfo");
                    ccDisputeCourtInfoElement.AppendChildNullCheck(document.CreateElemetNullCheck("courtInfo", CreditContract.ccDisputeCourtInfo));
                    creditElement.AppendChildNullCheck(ccDisputeCourtInfoElement);
                }
                parentElement.AppendChildNullCheck(creditElement);
            }
            if (processingTermination != null)
            {
                XmlElement processingTerminationElement = document.CreateElement("processingTermination");
                processingTerminationElement.InnerTextNullCheck(processingTermination.value);
                processingTerminationElement.SetAttributeNullCheck("id", processingTermination.id);
                processingTerminationElement.SetAttributeNullCheck("date", processingTermination.date);
                parentElement.AppendChildNullCheck(processingTerminationElement);
            }
            return parentElement;
        }
    }
    public partial class tCreditContract
    {

        public string ccId = null;

        public string caId = null;

        public tCreditContractCcNumber ccNumber = null;

        public decimal? ccAmount = null;

        public tCreditContractCcTotalAmount ccTotalAmount = null;

        public tCurrency ccCurrency = null;

        public string ccDate = null;

        public string ccExpirationDate = null;

        public tPaymentFrequency ccPaymentFrequency = null;

        public int? ccStatus = null;

        public tCreditContractCcType ccType = null;

        public string[] ccPledge = null;

        public tCreditContractCcChanges ccChanges = null;

        public tCreditContractCcRepayment ccRepayment = null;

        public string ccDisputeCourtInfo = null;
    }
    public partial class tAddMainProcessingTermination
    {

        public int? id = null;

        public string date = null;

        public string value = null;
    }
    public partial class tCreditContractCcTotalAmount
    {

        public bool? nonPercent = null;

        public decimal? value = null;
    }
    public partial class tPaymentFrequency
    {

        public int? type = null;

        public int? value = null;
    }
    public partial class tCreditContractCcChanges
    {

        public string date = null;

        public int? id = null;

        public string value = null;
    }
    public partial class tCreditContractCcType
    {

        public int? id = null;

        public string value = null;
    }
    public partial class tCreditContractCcRepayment
    {

        public string date = null;

        public int? status = null;

        public string value = null;
    }
    public partial class tCreditContractCcNumber
    {

        public int? type = null;

        public string value = null;
    }

    public partial class tIndividualMain
    {

        public tAddress[] iAddress = null;

        public string iIndividualEntrepreneur = null;

        public tIncapacity iIncapacity = null;

        public tIBankruptcy iBankruptcy = null;
    }
    public partial class tAddress
    {

        public ValueAttributte[] addrCapt = null;

        public CommonAddrStr commonAddrStr = null;

        public string hn = null;

        public string bn = null;

        public string bs = null;

        public string ap = null;
    }
    public class CommonAddrStr
    {
        public string Value;
        public string CodeRu;
    }
    public partial class tIncapacity
    {

        public string[] incapacityCourtInfo = null;

        public int? status = null;
    }
    public partial class tIBankruptcy
    {

        public string[] bankruptcyCourtInfo = null;

        public tEFRSBData iEFRSBData = null;

        public int? status = null;

        public string statusText = null;
    }
    public partial class tEFRSBData
    {
        public int? id = null;

        public string date = null;
    }
}