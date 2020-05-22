using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.WebPages;
using System.Xml;
using XmlUploading.Extensions;

namespace XmlUploading.Models.Commands
{
    public class AddLegalEntityCommand : Command
    {
        public int? CmdId = null;
        public string SId = null;

        public string DateOfActuality = null;
        //public string item;
        public string leName = null;

        public string leShortName = null;

        public string leFirmName = null;

        public string leForeignName = null;

        public string leLocalName = null;

        public string leITN = null;

        public string lePSRN = null;

        public string leForeignID = null;

        public tAddLegalEntityLeReorganization[] leReorganization = null;

        public tHistoricalAddress[] leAddress = null;

        public tPhone[] lePhone = null;

        public string email = null;

        public string http = null;

        public tFmInfo[] fmInfo = null;

        public bool? nonResident = null;
        //public tHistoricalAddressCommonAddrStr commonAddrStr = null;
        public override XmlElement GetNode(XmlDocument document)
        {
            XmlElement parentElement = document.CreateElement("AddLegalEntity");
            if (nonResident != null)
                parentElement.SetAttributeNullCheck("nonResident", nonResident.Value?"true":"false");

            parentElement.AppendChildNullCheck(document.CreateElemetNullCheck("cmdId", CmdId));
            parentElement.AppendChildNullCheck(document.CreateElemetNullCheck("dateOfActuality", DateOfActuality));

            parentElement.AppendChildNullCheck(document.CreateElemetNullCheck("sId", SId));

            parentElement.AppendChildNullCheck(document.CreateElemetNullCheck("leName", leName));
            parentElement.AppendChildNullCheck(document.CreateElemetNullCheck("leShortName", leShortName));
            parentElement.AppendChildNullCheck(document.CreateElemetNullCheck("leFirmName", leFirmName));
            parentElement.AppendChildNullCheck(document.CreateElemetNullCheck("leForeignName", leForeignName));
            parentElement.AppendChildNullCheck(document.CreateElemetNullCheck("leLocalName", leLocalName));
            parentElement.AppendChildNullCheck(document.CreateElemetNullCheck("leITN", leITN));
            parentElement.AppendChildNullCheck(document.CreateElemetNullCheck("lePSRN", lePSRN));
            parentElement.AppendChildNullCheck(document.CreateElemetNullCheck("leForeignID", leForeignID));
            

            if (leReorganization != null)
            {
                foreach (tAddLegalEntityLeReorganization reorganization in leReorganization)
                {
                    if (reorganization == null)
                        continue;
                    XmlElement reorgElement = document.CreateElement("leReorganization");
                    reorgElement.AppendChildNullCheck(document.CreateElemetNullCheck("leActuality", reorganization.leActuality));
                    reorgElement.AppendChildNullCheck(document.CreateElemetNullCheck("leName", reorganization.leName));
                    reorgElement.AppendChildNullCheck(document.CreateElemetNullCheck("leShortName", reorganization.leShortName));
                    reorgElement.AppendChildNullCheck(document.CreateElemetNullCheck("leFirmName", reorganization.leFirmName));
                    reorgElement.AppendChildNullCheck(document.CreateElemetNullCheck("leForeignName", reorganization.leForeignName));
                    reorgElement.AppendChildNullCheck(document.CreateElemetNullCheck("leLocalName", reorganization.leLocalName));
                    reorgElement.AppendChildNullCheck(document.CreateElemetNullCheck("leITN", reorganization.leITN));
                    reorgElement.AppendChildNullCheck(document.CreateElemetNullCheck("lePSRN", reorganization.lePSRN));
                    reorgElement.AppendChildNullCheck(document.CreateElemetNullCheck("leForeignID", reorganization.leForeignID));


                    parentElement.AppendChildNullCheck(reorgElement);
                }
            }
            if (leAddress != null)
            {
                foreach (tHistoricalAddress adress in leAddress)
                {
                    if (adress == null)
                        continue;
                    XmlElement adressElement = document.CreateElement("leAddress");
                    adressElement.AppendChildNullCheck(document.CreateElemetNullCheck("addrActuality", adress.addrActuality));
                    if (adress.addrCapt != null)
                        foreach (var capt in adress.addrCapt)
                        {
                            if (capt == null)
                                continue;
                            XmlElement captElement = document.CreateElement("addrCapt");
                            captElement.SetAttributeNullCheck("id", capt.Attribute);
                            captElement.InnerTextNullCheck(capt.Value);
                            adressElement.AppendChildNullCheck(captElement);
                        }
                    if (adress.commonAddrStr != null)
                    {
                        XmlElement commonAddrStrElement = document.CreateElement("commonAddrStr");
                        commonAddrStrElement.SetAttributeNullCheck("codeRU", adress.commonAddrStr.codeRU);
                        commonAddrStrElement.InnerTextNullCheck(adress.commonAddrStr.value);
                        adressElement.AppendChildNullCheck(commonAddrStrElement);
                    }
                    adressElement.AppendChildNullCheck(document.CreateElemetNullCheck("hN", adress.hn));
                    adressElement.AppendChildNullCheck(document.CreateElemetNullCheck("bN", adress.bn));
                    adressElement.AppendChildNullCheck(document.CreateElemetNullCheck("bS", adress.bs));
                    adressElement.AppendChildNullCheck(document.CreateElemetNullCheck("ap", adress.ap));

                    parentElement.AppendChildNullCheck(adressElement);
                }
            }
            if (lePhone != null)
            {
                foreach (var phone in lePhone)
                {
                    if (phone == null)
                        continue;
                    XmlElement lePhoneElement = document.CreateElement("lePhone");
                    if (phone.phCapt != null)
                        foreach (var phCapt in phone.phCapt)
                        {
                            if (phCapt == null)
                                continue;
                            XmlElement phCaptEleemnt = document.CreateElement("phCapt");
                            phCaptEleemnt.SetAttributeNullCheck("id", phCapt.Attribute);
                            phCaptEleemnt.InnerTextNullCheck(phCapt.Value);
                            lePhoneElement.AppendChildNullCheck(phCaptEleemnt);
                        }
                    lePhoneElement.AppendChildNullCheck(document.CreateElemetNullCheck("phNum", phone.phNum));
                    parentElement.AppendChildNullCheck(lePhoneElement);
                }
            }
            parentElement.AppendChildNullCheck(document.CreateElemetNullCheck("email", email));
            parentElement.AppendChildNullCheck(document.CreateElemetNullCheck("http", http));
            if (fmInfo != null)
            {
                foreach (var fm in fmInfo)
                {
                    if (fm == null)
                        continue;
                    XmlElement fmInfoElement = document.CreateElement("fmInfo");
                    fmInfoElement.AppendChildNullCheck(document.CreateElemetNullCheck("LastName", fm.lastName));
                    fmInfoElement.AppendChildNullCheck(document.CreateElemetNullCheck("FirstName", fm.firstName));
                    fmInfoElement.AppendChildNullCheck(document.CreateElemetNullCheck("MiddleName", fm.middleName));
                    fmInfoElement.AppendChildNullCheck(document.CreateElemetNullCheck("StartDate", fm.startDate));
                    fmInfoElement.AppendChildNullCheck(document.CreateElemetNullCheck("ExpirationDate", fm.expirationDate));
                    fmInfoElement.AppendChildNullCheck(document.CreateElemetNullCheck("DateOfSendingData", fm.dateOfSendingData));
                    fmInfoElement.AppendChildNullCheck(document.CreateElemetNullCheck("DateOfReceivingData", fm.dateOfReceivingData));
                    parentElement.AppendChildNullCheck(fmInfoElement);
                }
            }
            return parentElement;
        }

    }

    public partial class tPhone
    {

        public ValueAttributte[] phCapt = null;

        public string phNum = null;
    }
    public partial class tFmInfo
    {

        public string lastName = null;

        public string firstName = null;

        public string middleName = null;

        public string startDate = null;

        public string expirationDate = null;

        public string dateOfSendingData = null;

        public string dateOfReceivingData = null;

    }
    public partial class tAddLegalEntityLeReorganization
    {

        public string leActuality = null;

        public string leName = null;

        public string leShortName = null;

        public string leFirmName = null;

        public string leForeignName = null;

        public string leLocalName = null;

        public string leITN = null;

        public string lePSRN = null;

        public string leForeignID = null;
    }
    public partial class tHistoricalAddress
    {

        public string addrActuality = null;

        public ValueAttributte[] addrCapt = null;

        public tHistoricalAddressCommonAddrStr commonAddrStr = null;

        public string hn = null;

        public string bn = null;

        public string bs = null;

        public string ap = null;
    }
    public class tHistoricalAddressCommonAddrStr
    {

        public string codeRU = null;

        public string value = null;
    }
}