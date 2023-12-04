using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using MimeKit;
using Org.BouncyCastle.Utilities.Bzip2;
using System.Runtime.CompilerServices;

namespace DatabaseProject.Helper
{
    public static class EmailSend

    {
        public static void EmailSendService(string To, string Subject)
        {
            try
            {
                MailMessage message = new MailMessage();
                SmtpClient smtp = new SmtpClient();
                message.From = new MailAddress("binitdubey8@gamil.com");
                message.To.Add(new MailAddress(To));
                message.Subject = Subject;
                message.IsBodyHtml = true; //to make message body as html
                message.Body = "Hi, I am Binit dubey";
                smtp.Port = 587;
                smtp.Host = "smtp.gmail.com"; //for gmail host
                smtp.EnableSsl = true;
                smtp.UseDefaultCredentials = false;
                smtp.Credentials = new NetworkCredential("binitdubey8@gmail.com", "binitdubey@128");
                smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                smtp.Send(message);
            }
            catch (Exception ex) 
            { throw ex; }
        }
    }
}

