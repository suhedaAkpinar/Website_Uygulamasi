using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UygulamaWebSıte.VeriTransferNesneleri;
using System.Net.Mail;
using System.Net;
using System.Text;
namespace UygulamaWebSıte.Mail
{
    public class SendMail
    {

        public void bana_Mail_At(Form form)
        {


            SmtpClient SmtpServer = new SmtpClient();



            var mail = new MailMessage();

            mail.From = new MailAddress("vakifimdenemeapplication@hotmail.com");

            mail.SubjectEncoding = Encoding.Default;

            mail.BodyEncoding = Encoding.Default;

            mail.To.Add("vakifimDenemeApplication@hotmail.com");
            mail.To.Add("akpnr.suheda@gmail.com");


            mail.Subject = "Info";

            mail.IsBodyHtml = true;

            string htmlBody;



            htmlBody = " İsim:   " + form.İsim + "<br>" + "  Telefon: " + form.Tel + "<br>" + "Mesaj:    " + form.Messaj + "E_Mail Address: " + form.Email;

            mail.Body = htmlBody;



            SmtpServer.Host = "smtp.live.com";

            SmtpServer.Port = 587;

            SmtpServer.UseDefaultCredentials = false;

            SmtpServer.Credentials = new NetworkCredential("vakifimdenemeapplication@hotmail.com", "Aux12345");

            SmtpServer.EnableSsl = true;

            try
            {

                SmtpServer.Send(mail);
            }
            catch (Exception)
            {

                throw;
            }

        }

        public void ona_Mail_At(Form form)
        {


            SmtpClient SmtpServer = new SmtpClient();



            var mail = new MailMessage();

            mail.From = new MailAddress("vakifimdenemeapplication@hotmail.com");

            mail.SubjectEncoding = Encoding.Default;

            mail.BodyEncoding = Encoding.Default;
            mail.To.Add(form.Email);

            mail.Subject = "Vakifim Deneme Application Info";

            mail.IsBodyHtml = true;

            string htmlBody = " <h1> Mailiniz alınmıştır, en kısa sürede " + form.Email + " adresine geri dönüş yapılacaktır. </h1> </br> ";
            htmlBody += "<p style=" + "color: red;" + "><strong>Geri dönüş yapmayınız!</strong></p> ";
            mail.Body = htmlBody;



            SmtpServer.Host = "smtp.live.com";

            SmtpServer.Port = 587;

            SmtpServer.UseDefaultCredentials = false;

            SmtpServer.Credentials = new NetworkCredential("vakifimdenemeapplication@hotmail.com", "Aux12345");

            SmtpServer.EnableSsl = true;

            try
            {

                SmtpServer.Send(mail);
            }
            catch (Exception)
            {

                throw;
            }

        }

    }
}