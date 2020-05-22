using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml;
using XmlUploading.Extensions;
using XmlUploading.Models;

namespace XmlUploading.Services
{
    public class XmlService : IXmlService
    {
        public XmlDocument GenerateXmlRequest(UploadingModel uploadingModel)
        {
            XmlDocument document = new XmlDocument();

            XmlElement root = document.CreateElement("UPLOADING");
            root.SetAttribute("version", "03.18");

            document.AppendChild(root);
            XmlDeclaration declaration = document.CreateXmlDeclaration("1.0", "windows-1251", null);
            document.InsertBefore(declaration, root);
            root.AppendChildNullCheck(uploadingModel?.Header?.GetNode(document));

            XmlElement commandsNode = document.CreateElement("COMMANDS");
            if(uploadingModel?.Commands!=null)
            foreach (Command command in uploadingModel?.Commands)
            {
                commandsNode.AppendChildNullCheck(command.GetNode(document));
            }
            root.AppendChildNullCheck(commandsNode);
            return document;
        }

        public UploadingResponseModel GenerateResponse(XmlDocument xml)
        {
            UploadingResponseModel model = new UploadingResponseModel();

            XmlElement root = xml?.DocumentElement;
            XmlNode userInfoNode = root?.SelectSingleNode("user-info");
            if (userInfoNode != null)
            {
                model.UserInfo = new UserInfo
                {
                    UserId = Convert.ToInt32(userInfoNode?.Attributes["user-id"]?.Value),
                    UserName = userInfoNode?.Attributes["user-name"]?.Value,
                    ClientId = Convert.ToInt32(userInfoNode?.Attributes["client-id"]?.Value),
                    ClientName = userInfoNode?.Attributes["client-name"]?.Value,
                    CertificateId = userInfoNode?.Attributes["certificate-id"]?.Value,
                    RemoteAdress = userInfoNode?.Attributes["remote-address"]?.Value
                };
            }
            XmlNode packageInfoNode = root?.SelectSingleNode("package-info");
            if (packageInfoNode != null)
            {
                model.PackageInfo = new PackageInfo
                {
                    PackageType = Convert.ToInt32(packageInfoNode?.Attributes["package-type"]?.Value),
                    PackageFileSize = Convert.ToInt32(packageInfoNode?.Attributes["package-file-size"]?.Value),
                    PackageDocumentCount = Convert.ToInt32(packageInfoNode?.Attributes["package-document-count"]?.Value),
                    ProcessingId = Convert.ToInt32(packageInfoNode?.Attributes["processing-id"]?.Value),
                    ProcessingStatus = Convert.ToInt32(packageInfoNode?.Attributes["processing-status"]?.Value),
                    UploadId = packageInfoNode?.Attributes["upload-id"]?.Value,
                    UploadStartDateTime = packageInfoNode?.Attributes["upload-start-datetime"]?.Value,
                    UploadFinishDateTime = packageInfoNode?.Attributes["upload-finish-datetime"]?.Value,
                    SourceFileName = packageInfoNode?.Attributes["source-file-name"]?.Value,
                    ProcessingStartDateTime = packageInfoNode?.Attributes["processing-start-datetime"]?.Value,
                    ProcessingFinishDateTime = packageInfoNode?.Attributes["processing-finish-datetime"]?.Value,
                };
            }
            model.Documents = new List<Document>();
            foreach (XmlNode documentNode in root?.SelectNodes("document"))
            {
                Document doc = new Document
                {
                    PropcessingStatus = Convert.ToInt32(documentNode?.Attributes["processing-status"]?.Value),
                    FileSize = Convert.ToInt32(documentNode?.Attributes["file-size"]?.Value),
                    FormatType = documentNode?.Attributes["format-type"]?.Value,
                    FormatVersion = documentNode?.Attributes["format-version"]?.Value,
                    FileName = documentNode?.Attributes["file-name"]?.Value,
                    
                };
                
                doc.ProcessingStages = new List<ProcessingStage>();
                foreach (XmlNode stageNode in documentNode?.SelectNodes("processing-stage"))
                {
                    ProcessingStage processingStage = new ProcessingStage
                    {
                        Id = Convert.ToInt32(stageNode?.Attributes["id"]?.Value),
                        Description = stageNode?.Attributes["description"]?.Value,
                        ProcessingStatus = Convert.ToInt32(stageNode?.Attributes["processing-status"]?.Value),

                        Summaries = new List<Summary>(),
                        Errors = new List<Error>(),
                        Warnings = new List<Warning>()
                    };
                    foreach (XmlNode summaryNode in stageNode.SelectNodes("summary"))
                    {
                        Summary summary = new Summary
                        {
                            WarningCounts = new List<SummaryCount>(),
                            ErorCounts = new List<SummaryCount>(),
                            ForElementType = summaryNode?.Attributes["for-element-type"]?.Value,
                            TotalElementCount = Convert.ToInt32(summaryNode?.Attributes["total-elements-count"]?.Value),
                            ProcessedElementsCount = Convert.ToInt32(summaryNode?.Attributes["processed-elements-count"]?.Value)
                        };
                        foreach (XmlNode errorNode in summaryNode?.SelectNodes("error-count"))
                        {
                            summary.ErorCounts.Add(new SummaryCount
                            {
                                Code = Convert.ToInt32(errorNode?.Attributes["code"]?.Value),
                                Count = Convert.ToInt32(errorNode?.Attributes["count"]?.Value)
                            });
                        }
                        foreach (XmlNode errorNode in summaryNode?.SelectNodes("warning-count"))
                        {
                            summary.WarningCounts.Add(new SummaryCount
                            {
                                Code = Convert.ToInt32(errorNode?.Attributes["code"]?.Value),
                                Count = Convert.ToInt32(errorNode?.Attributes["count"]?.Value)
                            });
                        }
                        processingStage.Summaries.Add(summary);


                    }
                    foreach (XmlNode errorNode in stageNode.SelectNodes("error"))
                    {
                        processingStage.Errors.Add(new Error
                        {
                            Code = Convert.ToInt32(errorNode?.Attributes["code"]?.Value),
                            SourceDataId = errorNode?.Attributes["source-data-id"]?.Value
                        });
                    }
                    foreach (XmlNode warningNode in stageNode.SelectNodes("warning"))
                    {
                        processingStage.Warnings.Add(new Warning
                        {
                            Code = Convert.ToInt32(warningNode?.Attributes["code"]?.Value),
                            SourceDataId = warningNode?.Attributes["source-data-id"]?.Value
                        });
                    }

                    doc.ProcessingStages.Add(processingStage);
                    
                }
                model.Documents.Add(doc);
            }
            
            return model;
        }
    }
}