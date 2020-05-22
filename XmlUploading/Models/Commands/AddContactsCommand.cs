using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Web;
using System.Xml;
using XmlUploading.Extensions;

namespace XmlUploading.Models.Commands
{
    public class AddContactsCommand : Command
    {
        public string DateOfActuality = null;
        public string SId = null;
        public int? CmdId = null;
        public TPhone[] SPhone = null;

        public string[] Emails = null;
        public string[] Https = null;

        public override XmlElement GetNode(XmlDocument document)
        {
            XmlElement parentElement = document.CreateElement("AddContacts");
            parentElement.AppendChildNullCheck(document.CreateElemetNullCheck("cmdId", CmdId));

            parentElement.AppendChildNullCheck(document.CreateElemetNullCheck("dateOfActuality", DateOfActuality));
            parentElement.AppendChildNullCheck(document.CreateElemetNullCheck("sId", SId));

            if (SPhone != null)
                foreach (TPhone sPhone in SPhone)
                {
                    if (sPhone == null)
                        continue;
                    XmlElement sPhoneElement = document.CreateElement("sPhone");


                    if (sPhone.PhCapt != null)
                        foreach (TPhonePhCapt phCapt in sPhone.PhCapt)
                        {
                            if (phCapt == null)
                                continue;
                            XmlElement phCaptElemnt = document.CreateElement("phCapt");
                            phCaptElemnt.SetAttributeNullCheck("id", phCapt.Id);
                            phCaptElemnt.InnerTextNullCheck( phCapt.Value);
                            sPhoneElement.AppendChildNullCheck(phCaptElemnt);
                        }
                    sPhoneElement.AppendChildNullCheck(document.CreateElemetNullCheck("phNum", sPhone.PhNum));

                    parentElement.AppendChildNullCheck(sPhoneElement);
                }
            if (Emails != null)
                foreach (string email in Emails)
                {
                    if (email == null)
                        continue;
                    parentElement.AppendChildNullCheck(document.CreateElemetNullCheck("email", email));
                }
            if (Https != null)
                foreach (string http in Https)
                {
                    if (http == null)
                        continue;
                    parentElement.AppendChildNullCheck(document.CreateElemetNullCheck("http", http));
                }
            return parentElement;
        }
    }
    public partial class TPhone
    {

        public TPhonePhCapt[] PhCapt = null;

        public string PhNum = null;
    }
    public partial class TPhonePhCapt
    {

        public int? Id = null;

        public string Value = null;
    }
}