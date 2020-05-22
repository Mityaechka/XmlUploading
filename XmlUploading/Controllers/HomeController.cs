using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Web;
using System.Web.Mvc;
using System.Xml;
using System.Xml.Schema;
using XmlUploading.Extensions;
using XmlUploading.Models;
using XmlUploading.Models.Commands;
using XmlUploading.Services;

namespace XmlUploading.Controllers
{
    public class HomeController : Controller
    {
        public ContentResult Index()
        {
            var model = new UploadingModel();
            model.Header = new Header { OwnerDescription = "owner", UploadCreationDateTime = DateTime.Now, Ownerid = 1, UploadId = 1 };

            model.Commands = new List<Command>();

            model.Commands.Add(new AddContactsCommand
            {
                CmdId = 12,
                DateOfActuality = "22.22.2020",
                SId = "123",
                SPhone = new TPhone[]
                {
                    new TPhone
                    {
                        PhCapt= new TPhonePhCapt[]
                        {
                            new TPhonePhCapt
                            {
                                Id=1,
                                Value = "PhCapt 1"
                            },
                            new TPhonePhCapt
                            {
                                Id=2,
                                Value = "PhCapt 2"
                            }
                        },
                        PhNum = "880083536"
                    }
                },
                Emails = new string[] { "test@t.com", "test@t.com", "test@t.com" },
                Https = new string[] { "https://regex101.com/" },
            });
            model.Commands.Add(new AddDataCommand
            {
                CmdId = 2,
                SId = "100",
                SrcId = "101",
                CcId = "100",
                DtId = "104",
                DtType = "105",
                DtDate = "22.22.2020",
                DtAmount = 107
            });
            model.Commands.Add(new AddEventCommand
            {
                CmdId = 123,
                SId = "1",
                SrcId = "2",
                SrcType = new AddEventSrcType
                {
                    Value = "type",
                    Id = 3
                },
                CcId = "4",
                EvType = 5,
                EvDate = "20.20.2020",
                EvMicrofinance = new Microfinance
                {
                    NextPaymentDate = "20.20.2020",
                    OtstPrncAmnt = 7,
                    OvrdAmnt = 8,
                    OvrdAmntDrtn = new Duration
                    {
                        Type = 12,
                        Value = "1"
                    },
                    Amount = 13,
                    NextPayment = 14
                }
            });
            model.Commands.Add(new AddIndividualCommand
            {
                CmdId = 1,
                DateOfActuality = "20.20.2020",
                SId = "2",
                ISurname = "sur",
                IName = "name",
                IPatronymic = "pat",
                IOldSurname = "osur",
                IOldName = "oname",
                IOldPatronymic = "opat",
                IbDate = "20.20.2020",
                IbPlace = "bplace",
                IDoc = new Models.Commands.Document[]
                {
                    new Models.Commands.Document
                    {
                        PreviouslyIssued = true,
                        Type= new DocumentType
                        {
                            Id = 10,
                            Value = "value"
                        },
                        Num = new DocumentNum
                        {
                            Ser = "ser",
                            Value = "value"
                        },
                        Issue = new DocumentIssue
                        {
                            Value = "value",
                            Date = "20.20.2002",
                            Code = "code",
                            Place = "place"
                        }
                    }
                },
                IITN = "1234567890",
                IPens = "999-999-999 99"
            });
            model.Commands.Add(new AddInfoCommand
            {
                CmdId = 1,
                DateOfActuality = "20.20.2020",
                SId = "2",
                SrcId = "3",
                SrcType = new ValueAttributte
                {
                    Attribute = 1,
                    Value = "value"
                },
                CcStage = new ValueAttributte
                {
                    Attribute = 2,
                    Value = "value"
                },
                CcTypeApproved = new ValueAttributte
                {
                    Attribute = 3,
                    Value = "value"
                },
                CreditApplication = new AddInfoCreditApplication
                {
                    Id = "5",
                    Number = "6",
                    Date = "20.20.2020",
                    Method = new ValueAttributte
                    {
                        Attribute = 8,
                        Value = "value"
                    },
                    TypeRequested = new ValueAttributte
                    {
                        Attribute = 9,
                        Value = "value"
                    },
                    ApprovalDate = "20.20.2020",
                    ApprovalExpirationDate = "20.20.2020",
                    Refusal = new AddInfoCreditApplicationCcRefusal
                    {
                        rfReason = new ValueAttributte
                        {
                            Attribute = 11,
                            Value = "value"
                        },
                        rfAmount = 12,
                        rfCurrency = new tCurrency
                        {
                            id = 13,
                            code = "RUB",
                            value = "value"
                        },
                        rfDate = "20.20.2020"
                    },
                    CcId = "id",
                    CcNumber = new ValueAttributte
                    {
                        Attribute = 14,
                        Value = "value"
                    }
                },
                CcCloseDate = "20.20.2020",
                SuretyContract = new AddInfoSuretyContract
                {
                    scId = "1",
                    scNumber = new ValueAttributte
                    {
                        Attribute = 1,
                        Value = "1"
                    }
                }
            });
            model.Commands.Add(new AddLegalEntityCommand
            {
                nonResident = true,
                CmdId = 1,
                SId = "2",
                leName = "name",
                leShortName = "sn",
                leFirmName = "fiName",
                leForeignName = "forName",
                leLocalName = "locName",
                leITN = "1234567890",
                lePSRN = "12312312312312",
                leForeignID = "forId",
                leReorganization = new tAddLegalEntityLeReorganization[]
                {
                    new tAddLegalEntityLeReorganization
                    {
                        leActuality = "20.20.2020",
                        leName = "name",
                        leShortName = "shortName",
                        leLocalName = "locName",
                        leITN = "1234567890",
                        lePSRN = "12312312312312",
                        leForeignID = "id",
                        leFirmName = "firm",
                        leForeignName= "forName"
                    }
                },
                leAddress = new tHistoricalAddress[]
                {
                    new tHistoricalAddress
                    {
                        addrActuality = "20.20.2020",
                        addrCapt = new ValueAttributte[]
                        {
                            new ValueAttributte
                            {
                                Value = "value",
                                Attribute = 22
                            }
                        },
                        commonAddrStr = new tHistoricalAddressCommonAddrStr
                        {
                            value = "value",
                            codeRU = "1231231231231231223"
                        },
                        bn = "bn",
                        ap = "ap",
                        bs = "bs",
                        hn="hn"
                    }
                },
                lePhone = new tPhone[]
                {
                    new tPhone
                    {
                        phCapt = new ValueAttributte[]
                        {
                            new ValueAttributte
                            {
                                Attribute = 100,
                                Value = "value"
                            }
                        },
                        phNum = "123"
                    }
                },
                email = "email@e.com",
                http = "http",
                fmInfo = new tFmInfo[]
                {
                    new tFmInfo
                    {
                        lastName = "last",
                        firstName = "first",
                        middleName = "middle",
                        startDate = "20.20.2353",
                        expirationDate = "20.20.0220",
                        dateOfSendingData ="20.20.2020",
                        dateOfReceivingData = "20.20.2000"
                    }
                },
                DateOfActuality = "20.20.2020"
            });
            model.Commands.Add(new AddMainCommand
            {
                CmdId = 1,
                DateOfActuality = "20.20.2020",
                sId = "2",
                Individual = new tIndividualMain
                {
                    iAddress = new tAddress[]
                    {
                        new tAddress
                        {
                            addrCapt = new ValueAttributte[]
                            {
                                 new ValueAttributte
                                    {
                                        Attribute = 1,
                                        Value = "value"
                                    }
                            },
                            commonAddrStr =  new CommonAddrStr
                            {
                                CodeRu = "123123123123123123123",
                                Value = "value"
                            },
                            ap = "ap",
                            bn = "bn",
                            bs = "bs",
                            hn = "hn"
                        }
                    },
                    iIndividualEntrepreneur = "inEnt",

                    iIncapacity = new tIncapacity
                    {
                        status = 1,
                        incapacityCourtInfo = new string[] { "info 1", "info 2" }
                    },
                    iBankruptcy = new tIBankruptcy
                    {
                        status = 1,
                        statusText = "text",
                        bankruptcyCourtInfo = new string[] { "bankInfo 1", "bankinfo 2" },
                        iEFRSBData = new tEFRSBData
                        {
                            id = 12,
                            date = "20.20.2020"
                        }
                    }
                },
                srcId = "id",
                CreditContract = new tCreditContract
                {
                    ccId = "ccId",
                    caId = "caId",
                    ccNumber = new tCreditContractCcNumber
                    {
                        type = 2,
                        value = "value"
                    },
                    ccAmount = 12,
                    ccTotalAmount = new tCreditContractCcTotalAmount
                    {
                        value = 150
                    },
                    ccCurrency = new tCurrency
                    {
                        value = "v",
                        id = 1,
                        code = "KZT"
                    },
                    ccDate = "20.20.2020",
                    ccExpirationDate = "02.20.2020",
                    ccPaymentFrequency = new tPaymentFrequency
                    {
                        type = 1,
                        value = 2
                    },
                    ccStatus = 1,
                    ccPledge = new string[] { "pl 1", "pl 2" },
                    ccChanges = new tCreditContractCcChanges
                    {
                        value = "v",
                        date = "20.20.2020",
                        id = 0
                    },
                    ccRepayment = new tCreditContractCcRepayment
                    {
                        value = "v",
                        date = "20.20.2020",
                        status = 0
                    },
                    ccDisputeCourtInfo = "cInfo",
                    ccType = new tCreditContractCcType
                    {
                        value = "v",
                        id = 0
                    }
                },
                processingTermination = new tAddMainProcessingTermination
                {
                    id = 0,
                    date = "20.20.2020",
                    value = "v"
                }
            });
            model.Commands.Add(new AnnulCommand
            {
                CmdId = 1,
                sId = "12",
                annulReason = new tAnnulAnnulReason
                {
                    value = "v",
                    id = 1
                }
            });
            model.Commands.Add(new ChangeCCCHCodeCommand
            {
                CmdId = 1,
                sId = "20",
                sCode = new tCCCHCode
                {
                    isAdditional = false,
                    value = "asdv"
                }
            });
            model.Commands.Add(new ChangeCCCHCodeCommand
            {
                CmdId = 2,
                sId = "203",
                sCode = new tCCCHCode
                {
                    isAdditional = false,
                    value = "asdv"
                }
            });
            var service = new XmlService();
            var xml = service.GenerateXmlRequest(model);
            var response = service.GenerateResponse(CreateResponse());

            return Content(xml.OuterXml, "application/xml");
        }

        XmlDocument CreateResponse()
        {
            XmlDocument doc = new XmlDocument();
            var root = doc.CreateElement("upload");
            var userInfo = doc.CreateElement("user-info");
            userInfo.SetAttribute("user-id", "12");
            userInfo.SetAttribute("user-name", "userName");
            userInfo.SetAttribute("client-id", "1");
            userInfo.SetAttribute("client-name", "clientName");
            userInfo.SetAttribute("certificate-id", "123456afb");
            userInfo.SetAttribute("remote-address", "192.192.192.192");
            root.AppendChild(userInfo);

            var packageInfo = doc.CreateElement("package-info");
            packageInfo.SetAttribute("package-type", "1");
            packageInfo.SetAttribute("upload-id", "2");
            packageInfo.SetAttribute("upload-start-datetime", "3");
            packageInfo.SetAttribute("upload-finish-datetime", "4");
            packageInfo.SetAttribute("source-file-name", "5");
            packageInfo.SetAttribute("package-file-size", "6");
            packageInfo.SetAttribute("package-document-count", "7");
            packageInfo.SetAttribute("processing-id", "8");
            packageInfo.SetAttribute("processing-status", "9");
            packageInfo.SetAttribute("processing-start-datetime", "10");
            packageInfo.SetAttribute("processing-finish-datetime", "11");
            root.AppendChild(packageInfo);

            var document = doc.CreateElement("document");
            document.SetAttribute("format-type", "1");
            document.SetAttribute("format-version", "2");
            document.SetAttribute("file-name", "3");
            document.SetAttribute("file-size", "4");
            document.SetAttribute("processing-status", "5");

            var processingStage = doc.CreateElement("processing-stage");
            processingStage.SetAttribute("id", "1");
            processingStage.SetAttribute("description", "2");
            processingStage.SetAttribute("processing-status", "3");
            var stageWarning = doc.CreateElement("warning");
            stageWarning.SetAttribute("code", "1");
            stageWarning.SetAttribute("source-data-id", "2");
            processingStage.AppendChild(stageWarning);
            var stageError = doc.CreateElement("error");
            stageError.SetAttribute("code", "1");
            stageError.SetAttribute("source-data-id", "2");
            processingStage.AppendChild(stageError);

            var summary = doc.CreateElement("summary");
            summary.SetAttribute("for-element-type", "1");
            summary.SetAttribute("total-elements-count", "2");
            summary.SetAttribute("processed-elements-count", "3");

            var warningCount = doc.CreateElement("warning-count");
            warningCount.SetAttribute("code", "1");
            warningCount.SetAttribute("count", "2");
            summary.AppendChild(warningCount);

            var errorCount = doc.CreateElement("error-count");
            errorCount.SetAttribute("code", "1");
            errorCount.SetAttribute("count", "2");
            summary.AppendChild(errorCount);
            processingStage.AppendChild(summary);
            document.AppendChild(processingStage);
            root.AppendChild(document);
            doc.AppendChild(root);
            return doc;
        }
    }
}