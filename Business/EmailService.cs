
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Business
{
    public class EmailService
    {
        private MailMessage email;
        private SmtpClient server;

        public EmailService()
        {
            server = new SmtpClient();
            server.Credentials = new NetworkCredential("5e70abebe0c8e0", "3a5daa4af402b8");
            server.Port = 2525;
            server.Host = "smtp.mailtrap.io";
        }

        public void createMail(string destination, string affair, string body)
        {
            email = new MailMessage();
            email.From = new MailAddress("noresponder@sorteo.com");
            email.To.Add(destination);
            email.Subject = affair;
            email.IsBodyHtml = true;
            email.Body = body;

        }

        public void sendEmail()
        {
            try
            {
                server.Send(email);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }

}

