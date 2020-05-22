using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Web;

namespace XmlUploading.Models
{
    public class UploadingModel
    {
        public Header Header { get; set; }
        public List<Command> Commands { get; set; } = new List<Command>();
    }
}
