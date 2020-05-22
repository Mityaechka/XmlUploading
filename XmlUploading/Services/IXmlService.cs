using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml;
using XmlUploading.Models;

namespace XmlUploading.Services
{
    public interface IXmlService
    {
        XmlDocument GenerateXmlRequest(UploadingModel uploadingModel);
        UploadingResponseModel GenerateResponse(XmlDocument xml);
    }
}