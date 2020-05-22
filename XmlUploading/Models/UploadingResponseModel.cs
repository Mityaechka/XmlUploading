using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace XmlUploading.Models
{
    public class UploadingResponseModel
    {
        public UserInfo UserInfo { get; set; }
        public PackageInfo PackageInfo { get; set; }
        public List<Document> Documents { get; set; }
    }
    public class ProcessingStage
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public int ProcessingStatus { get; set; }

        public List<Summary> Summaries { get; set; }
        public List<Error> Errors { get; set; }
        public List<Warning> Warnings { get; set; }
    }
    public class Document
    {
        public string FormatType { get; set; }
        public string FormatVersion { get; set; }
        public string FileName { get; set; }
        public int FileSize { get; set; }
        public int PropcessingStatus { get; set; }
        public List<ProcessingStage> ProcessingStages { get; set; }

    }

    public class PackageInfo
    {
        public int PackageType { get; set; }
        public string UploadId { get; set; }
        public string UploadStartDateTime { get; set; }
        public string UploadFinishDateTime { get; set; }
        public string SourceFileName { get; set; }
        public int PackageFileSize { get; set; }
        public int PackageDocumentCount { get; set; }
        public int ProcessingId { get; set; }
        public int ProcessingStatus { get; set; }
        public string ProcessingStartDateTime { get; set; }
        public string ProcessingFinishDateTime { get; set; }


    }

    public class UserInfo
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
        public int ClientId { get; set; }
        public string ClientName { get; set; }
        public string CertificateId { get; set; }
        public string RemoteAdress { get; set; }

    }

    public class Warning
    {
        public int Code { get; set; }
        public string SourceDataId { get; set; }
    }

    public class Error
    {
        public int Code { get; set; }
        public string SourceDataId { get; set; }
    }

    public class Summary
    {
        public string ForElementType { get; set; }
        public int TotalElementCount { get; set; }
        public int ProcessedElementsCount { get; set; }
        public List<SummaryCount> WarningCounts { get; set; }
        public List<SummaryCount> ErorCounts { get; set; }

    }
    public class SummaryCount
    {
        public int Code { get; set; }
        public int Count { get; set; }
    }
}